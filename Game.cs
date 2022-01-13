using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
namespace Pseudo
{
    internal class Game
    {
        public List<Tile> map;
        SFML.System.Clock c;
        float time;
        Player player;
        public Game() 
        {
            player = new Player((float)(Math.PI / 2), 0f, 0.05f,0f);
            c = new SFML.System.Clock();
            map = new List<Tile>();
            map.Insert(0, new Tile( new SFML.Graphics.FloatRect(0,0,1,1), SFML.Graphics.Color.Red  ) );
            map.Insert(1, new Tile(new SFML.Graphics.FloatRect(0, 100, 150, 150), SFML.Graphics.Color.Green));
            map.Insert(2, new Tile(new SFML.Graphics.FloatRect(350, 0, 150, 150), SFML.Graphics.Color.Blue));
            map.Insert(3, new Tile(new SFML.Graphics.FloatRect(500, 300, 150, 150), SFML.Graphics.Color.Yellow));
            map.Insert(4, new Tile(new SFML.Graphics.FloatRect(200, 300, 100, 100), SFML.Graphics.Color.Black));
        }
        public void Update()
        {
            PlayerMove();
            time = c.ElapsedTime.AsMicroseconds()/1000;
            float fps = 1f / c.Restart().AsSeconds();
            Program.win.SetTitle(fps.ToString());
            player.Update(time);
        }
        public void Draw() 
        {
            //for (int i = 0; i < map.Count(); i++)
            //{
            //    RectangleShape rect = new RectangleShape(new SFML.System.Vector2f(map.ElementAt(i).fr.Width, map.ElementAt(i).fr.Height));
            //    rect.Position = new SFML.System.Vector2f(map.ElementAt(i).fr.Left, map.ElementAt(i).fr.Top);
            //    rect.FillColor = map.ElementAt(i).c;
            //    Program.win.Draw(rect);
            //}
            for (float i = player.fov; i <= player.fov+player.fov_scale; i+=(float)(Math.PI/180))
            {
                Intersect(i);
            }
        }
        private void Intersect(float angle)
        {
            float dx = (float)Math.Cos(angle);
            float dy = (float)Math.Sin(angle);
            //Console.WriteLine("cos " + angle.ToString() + " =  " + dx.ToString());
            //Console.WriteLine("sin " + angle.ToString() + " =  " + dy.ToString());
            float startLeft = map.ElementAt(0).fr.Left;
            float startTop = map.ElementAt(0).fr.Top;
            for (int i = 1; i < map.Count; i++)
            {
                while (!map.ElementAt(0).fr.Intersects(map.ElementAt(i).fr) && (Math.Abs(map.ElementAt(0).fr.Left - map.ElementAt(i).fr.Left)<800) && (Math.Abs(map.ElementAt(0).fr.Top - map.ElementAt(i).fr.Top) < 800))
                {
                    map.ElementAt(0).fr.Left += dx;
                    map.ElementAt(0).fr.Top += dy;
                }
                if(map.ElementAt(0).fr.Intersects(map.ElementAt(i).fr))
                {
                    RectangleShape rect = new RectangleShape(new SFML.System.Vector2f(5,5));
                    rect.Position = new SFML.System.Vector2f(map.ElementAt(0).fr.Left, map.ElementAt(0).fr.Top);
                    rect.FillColor = map.ElementAt(i).c;
                    Program.win.Draw(rect);
                }
                map.ElementAt(0).fr.Left = startLeft;
                map.ElementAt(0).fr.Top = startTop;            
            }
            RectangleShape test = new RectangleShape(new SFML.System.Vector2f(5, 5));
            test.Position = new SFML.System.Vector2f(map.ElementAt(0).fr.Left, map.ElementAt(0).fr.Top);
            test.FillColor = map.ElementAt(0).c;
            Program.win.Draw(test);
        }
        private void PlayerMove(){
            if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.A)) map.ElementAt(0).fr.Left -= 0.1f*time;
            if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.D)) map.ElementAt(0).fr.Left += 0.1f*time;
            if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.W)) map.ElementAt(0).fr.Top -= 0.1f*time;
            if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.S)) map.ElementAt(0).fr.Top += 0.1f*time;
        }

    }
}
