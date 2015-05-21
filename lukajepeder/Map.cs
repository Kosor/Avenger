using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace lukajepeder
{
    class Map : Drawable, Updatable
    {
        RectangleShape map;
        int width;
        int height;
        Text score;
        Random rng;
        List<RectangleShape> obstacles;

        public Map(int w, int h, Avengeri sonjo)
        {
            map = new RectangleShape(new Vector2f(w, h));
            width = w;
            height = h;
            map.Position += new Vector2f(0, 500 - h);
            //map.Texture = new Texture("maptex.png");
            map.FillColor = Color.Green;
            rng = new Random();
            obstacles = new List<RectangleShape>();
            score = new Text(height.ToString(), new Font("arial.ttf")); 
        }

        void GenDown()
        {
            var rnd_height = rng.Next(80)+ 10;
            var rnd_width = rng.Next(65) + 15;
            var rng_obj = new RectangleShape(new Vector2f(rnd_width, rnd_height));
            rng_obj.FillColor = Color.Green;
            rng_obj.Position = new Vector2f(800 - rnd_width, 450 - rnd_height);
            obstacles.Add(rng_obj);
           
        }

        void Genmid()
        {
            var rnd_height = rng.Next(80) + 10;
            var rnd_width = rng.Next(65) + 10;
            var rng_obj = new RectangleShape(new Vector2f(rnd_width, rnd_height));
            rng_obj.FillColor = Color.Green;
            rng_obj.Position = new Vector2f(800 - rnd_width, 210);
            obstacles.Add(rng_obj);
        
        }


        public void Draw(RenderTarget target, RenderStates states)
        {
            map.Draw(target, states);
            score.Draw(target, states);
            obstacles.ForEach(o => o.Draw(target, states));
        }

        public void Update(RenderWindow window, int counter)
        {
            if (counter % 30  == 0)
            {
                for (int i = 0; i < 1 + counter / (20 * 60); ++i)
                {
                    GenDown();
                    if (counter > 180) Genmid();
                }
            }

            
            obstacles.ForEach(o => o.Position += new Vector2f(-3 - counter/600 * 5 , 0));
            
        }
    }
}
