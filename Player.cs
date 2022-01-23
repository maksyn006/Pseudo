using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pseudo
{
    internal class Player:Transformable,Drawable
    {
        public float fov_scale, fov, fov_speed, speed, time;
        public FloatRect playerRect;
        public Player(float fov_scale,float fov,float fov_speed,float speed,FloatRect playerRect)
        {
            this.fov_scale = fov_scale;
            this.fov = fov;
            this.speed = speed;
            this.fov_speed = fov_speed;
            this.playerRect = playerRect;
        }
        public void Update(float time)
        {
            this.time=time;
            Control();
        }
        public void Control() {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Z)) fov -= (float)(Math.PI / 180) * time * fov_speed;
            if (Keyboard.IsKeyPressed(Keyboard.Key.X)) fov += (float)(Math.PI / 180) * time * fov_speed;
            if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.A)){ 
                playerRect.Left += (float)Math.Cos((fov + fov_scale / 2) - Math.PI / 2) * 0.01f * time; 
                playerRect.Top  += (float)Math.Sin((fov + fov_scale / 2) - Math.PI / 2) * 0.01f * time; 
            }
            if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.D)) { 
                playerRect.Left += (float)Math.Cos((fov + fov_scale / 2) + Math.PI / 2) * 0.01f * time; 
                playerRect.Top  += (float)Math.Sin((fov + fov_scale / 2) + Math.PI / 2) * 0.01f * time; 
            }
            if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.W)) {
                playerRect.Left += (float)Math.Cos(fov + fov_scale / 2) * 0.01f * time; 
                playerRect.Top  += (float)Math.Sin(fov + fov_scale / 2) * 0.01f * time;
            }
            if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.S)) {
                playerRect.Left += (float)Math.Cos((fov + fov_scale / 2) + Math.PI) * 0.01f * time;
                playerRect.Top  += (float)Math.Sin((fov + fov_scale / 2) + Math.PI) * 0.01f * time;
            }

        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            RectangleShape rect = new RectangleShape(new SFML.System.Vector2f(5, 5));
            rect.Position = new SFML.System.Vector2f(playerRect.Left, playerRect.Top);
            rect.FillColor = Color.Red;
            target.Draw(rect);
        }
    }
}
