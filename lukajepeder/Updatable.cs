using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace lukajepeder
{
    public interface Updatable
    {
        void Update(RenderWindow window, int counter);
    }
}
