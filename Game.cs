using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
namespace Pseudo{
    internal class Game
    {
        public List<Tile> map;
        SFML.System.Clock c;
        float time;
        Player player;
        public Game() 
        {
            player = new Player((float)(Math.PI / 2), 0f, 0.05f,0f,new FloatRect(0,0,1,1));
            c = new SFML.System.Clock();
            map = new List<Tile>();            
            map.Insert(0, new Tile(new SFML.Graphics.FloatRect(0, 100, 150, 150), SFML.Graphics.Color.Green));
            map.Insert(1, new Tile(new SFML.Graphics.FloatRect(350, 0, 150, 150), SFML.Graphics.Color.Blue));
            map.Insert(2, new Tile(new SFML.Graphics.FloatRect(500, 300, 150, 150), SFML.Graphics.Color.Yellow));
            map.Insert(3, new Tile(new SFML.Graphics.FloatRect(200, 300, 100, 100), SFML.Graphics.Color.Black));
        }
        public void Update()
        {
            time = c.ElapsedTime.AsMicroseconds()/1000;
            float fps = 1f / c.Restart().AsSeconds();
            Program.win.SetTitle(fps.ToString());
            player.Update(time);
        }
        public void Draw() 
        {            
            for (float i = player.fov - (player.fov_scale/2); i <= player.fov+(player.fov_scale/2); i+=(float)(Math.PI/1600))
            {
                Intersect(i, i * (player.fov_scale / (float)(Math.PI / 1600)) / (player.fov+(player.fov_scale/2)) );
            }
            //Program.win.Draw(player);
        }

        private void Intersect(float angle,float camx)
        {
            float dx = (float)Math.Cos(angle);
            float dy = (float)Math.Sin(angle);
            float startLeft = player.playerRect.Left;
            float startTop = player.playerRect.Top;
            bool intersects = false;
            Color c = new Color();
            //Console.WriteLine(camx);
            while (!intersects && (Math.Abs(player.playerRect.Left - startLeft) < 800) && (Math.Abs(player.playerRect.Top - startTop) < 800))
            {
                for (int i = 0; i < map.Count; i++)
                {
                    if (player.playerRect.Intersects(map.ElementAt(i).fr))
                    {
                        intersects = true;
                        c = map.ElementAt(i).c;
                    }
                }
                if (!intersects) {
                    player.playerRect.Left += dx;
                    player.playerRect.Top += dy;
                } else {
                    float distance = (float)Math.Sqrt(Math.Pow((player.playerRect.Left-startLeft),2) + Math.Pow((player.playerRect.Top-startTop),2));
                    RectangleShape rect = new RectangleShape(new SFML.System.Vector2f(2, 600/distance));
                    rect.Position = new SFML.System.Vector2f(camx, (600-(600/distance))/2);
                    rect.FillColor = c;
                    Program.win.Draw(rect);
                }
            }
            player.playerRect.Left = startLeft;
            player.playerRect.Top = startTop;

        }
    }
}
//for (int i = 0; i < map.Count; i++)
//{
//    while (!player.playerRect.Intersects(map.ElementAt(i).fr) && (Math.Abs(player.playerRect.Left - map.ElementAt(i).fr.Left) < 800) && (Math.Abs(player.playerRect.Top - map.ElementAt(i).fr.Top) < 800))
//    {
//        player.playerRect.Left += dx;
//        player.playerRect.Top += dy;
//    }
//    if (player.playerRect.Intersects(map.ElementAt(i).fr))
//    {
//        RectangleShape rect = new RectangleShape(new SFML.System.Vector2f(1, 300));
//        rect.Position = new SFML.System.Vector2f(camx, 150);
//        rect.FillColor = map.ElementAt(i).c;
//        Program.win.Draw(rect);
//    }
//    player.playerRect.Left = startLeft;
//    player.playerRect.Top = startTop;
//}