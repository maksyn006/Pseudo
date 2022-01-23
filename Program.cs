﻿using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pseudo
{
    internal class Program
    {
        public static RenderWindow win;
        public static RenderWindow test;
        static void Main(string[] args)
        {
            win = new RenderWindow(new VideoMode(800, 600), "Pseudo");
            test = new RenderWindow(new VideoMode(800,600),"test");
            win.SetVerticalSyncEnabled(true);
            Game game = new Game();

            win.Closed += Win_Close;
            win.Resized += Win_Resize;
            while (win.IsOpen)
            {
                win.DispatchEvents();
                game.Update(); 
                win.Clear(Color.White);
                test.Clear(Color.White);
                game.Draw();
                game.Test();
                win.Display();
                test.Display();
            }
        }

        private static void Win_Resize(object sender, SizeEventArgs e)
        {
            win.Size = new SFML.System.Vector2u(e.Width,e.Height);
        }

        private static void Win_Close(object sender, EventArgs e)
        {
            win.Close();
        }
    }
}
