using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace lukajepeder
{
    class Avengeri : Drawable, Updatable
    {
        int radius;
        CircleShape avenger;

        public Avengeri(int r)
        {
            radius = r;
            avenger = new CircleShape(r);
            avenger.Texture = new Texture("pimpolovacx.png");
            //avenger.FillColor = Color.Red;
            avenger.Position = new Vector2f(40, 450 - 2 * r);
        
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            avenger.Draw(target, states);
        }

        public void Update(RenderWindow window, int counter)
        {
            if(Keyboard.IsKeyPressed(Keyboard.Key.Up))
                avenger.Position += new Vector2f(0, -3);
  
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                avenger.Position += new Vector2f(0, 3);

           /* if (Keyboard.IsKeyPressed(Keyboard.Key.Left))         
                avenger.Position += new Vector2f(-3, 0);

            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                avenger.Position += new Vector2f(3, 0);*/

            avenger.Position += new Vector2f(0, 1);
            avenger.Origin = new Vector2f(25f, 25f);
            avenger.Rotation += 12.0f;
            

        }
    }
}
