using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.System;

namespace lukajepeder
{
    class Map : Drawable, Updatable
    {
        RectangleShape map;
        int width;
        int height;
        Random rng;
        List<RectangleShape> obstacles;

        public Map(int w, int h)
        {
            map = new RectangleShape(new Vector2f(w, h));
            width = w;
            height = h;
            map.Position += new Vector2f(0, 500 - h);
            map.Texture = new Texture("maptex.png");
            rng = new Random();
            obstacles = new List<RectangleShape>();
        }

        void Gen()
        {
            var rnd_height = rng.Next(70)+ 30;
            var rnd_width = rng.Next(20) + 30;
            var rng_obj = new RectangleShape(new Vector2f(rnd_width, rnd_height));
            rng_obj.Position = new Vector2f(800 - rnd_width, 450 - rnd_height);
            obstacles.Add(rng_obj);
        }


        public void Draw(RenderTarget target, RenderStates states)
        {
            map.Draw(target, states);
            obstacles.ForEach(o => o.Draw(target, states));
        }

        public void Update(RenderWindow window, int counter)
        {
            if (counter % 120 == 0)
            {
                Gen();
            
            }

            obstacles.ForEach(o => o.Position += new Vector2f(-1 - counter/300, 0));
            
        }
    }
}
