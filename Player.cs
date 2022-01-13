using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pseudo
{
    internal class Player
    {
        public float fov_scale;
        public float fov;
        public float fov_speed;
        public float speed;
        public float time;
        public Player(float fov_scale,float fov,float fov_speed,float speed)
        {
            this.fov_scale = fov_scale;
            this.fov = fov;
            this.speed = speed;
            this.fov_speed = fov_speed;
        }
        public void Update(float time)
        {
            this.time=time;
            Control();
        }
        public void Control() {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Z)) fov += (float)(Math.PI / 180)*time*fov_speed;
            if (Keyboard.IsKeyPressed(Keyboard.Key.X)) fov -= (float)(Math.PI / 180)*time*fov_speed;
        }
    }
}
