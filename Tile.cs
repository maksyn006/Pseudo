using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
namespace Pseudo
{
    internal class Tile
    {
        public FloatRect fr;
        public Color c;
        public Tile(FloatRect fr, Color c)
        {
            this.fr = fr;
            this.c = c;
        }
    }
}
