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
            var window = new RenderWindow(new VideoMode( 800 , 500 ), "Pimpolovac Pre-Nightly");
            window.SetVerticalSyncEnabled(true);

            var shape = new Avengeri(25);
            var map = new Map(800, 50, shape);
           
            
            kurac.Add(map);
            upd.Add(map);
            kurac.Add(shape);
            upd.Add(shape);
            

            while (window.IsOpen)
            {
                count++;
                window.DispatchEvents();
                window.Closed += delegate { window.Close(); };
                window.Clear();
                upd.ForEach(u => u.Update(window, count));
                kurac.ForEach(k => window.Draw(k));
                window.Display();
            }
        }
    }
}
