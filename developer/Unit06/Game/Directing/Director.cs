using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;
using Raylib_cs;

namespace Unit06.Game.Directing
{
    // <summary>
    // <para>A person who directs the game.</para>
    // <para>
    // The responsibility of a Director is to control the sequence of play.
    // </para>
    // </summary>
    public class Director
    {
        private KeyboardService keyboardService = null;
        private VideoService videoService = null;
        private int time = 5;
        private int countdown = 50;

        // <summary>
        // Constructs a new instance of Director using the given KeyboardService and VideoService.
        // </summary>
        // <param name="keyboardService">The given KeyboardService.</param>
        // <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;
        }

        // <summary>
        // Starts the game by running the main game loop for the given cast.
        // </summary>
        // <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {
            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            videoService.CloseWindow();
        }

        // <summary>
        // Gets directional input from the keyboard and applies it to the robot.
        // </summary>
        // <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {
            Actor robot = cast.GetFirstActor("robot");
            Point velocity = keyboardService.GetDirection();
            robot.SetVelocity(velocity);     
        }

        // <summary>
        // Updates the robot's position and resolves any collisions with artifacts.
        // </summary>
        // <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
            if (countdown == 0)
            {
                time--;
                countdown = 60;
            }

            else
            {
                countdown--;
            }

            Actor banner = cast.GetFirstActor("banner");
            Actor robot = cast.GetFirstActor("robot");
            List<Actor> artifacts = cast.GetActors("artifacts");

            banner.SetText($"Time:{time}");
            int maxX = videoService.GetWidth();
            int maxY = videoService.GetHeight();
            robot.MoveNext(maxX, maxY);

            if (time <= 0)
            {
                GameOver();
            }

            foreach (Actor actor in artifacts)
            {
                actor.MoveNext(maxX,maxY);
                if (Raylib.CheckCollisionRecs(robot.GetRectangle(),actor.GetRectangle()))
                {
                    Console.WriteLine("GAME OVER");
                }
            } 
        }

        // <summary>
        // Draws the actors on the screen.
        // </summary>
        // <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            videoService.ClearBuffer();
            videoService.DrawActors(actors);
            videoService.FlushBuffer();
        }

        private void GameOver()
        {
            Console.WriteLine("Game Over!");
            Environment.Exit(0);
        }
    }
}