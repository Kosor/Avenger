using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace lukajepeder
{
    class Program
    {
        static int count = 0;
        static void Main(string[] args)
        {
            var upd = new List<Updatable>();
            var kurac = new List<Drawable>();
            var window = new RenderWindow(new VideoMode( 800 , 500 ), "Kosor Peder");
            window.SetVerticalSyncEnabled(true);
            var shape = new RectangleShape(new Vector2f(50, 50));
            shape.Position += new Vector2f(0, 270-64);
            kurac.Add(shape);
            var map = new Map(800, 50);
            kurac.Add(map);
            upd.Add(map);
      
            shape.Texture = new Texture("pimpolovacx.png");

            while (window.IsOpen)
            {
                count++;
                window.DispatchEvents();
                window.Closed += delegate { window.Close(); };
                window.Clear();
                shape.Position = new Vector2f((float)Math.Sin(count / 60.0f) * 400.0f + 400, 100.0f);
                upd.ForEach(u => u.Update(window, count));
                kurac.ForEach( k => window.Draw(k) );
                window.Display();
            }
        }
    }
}
