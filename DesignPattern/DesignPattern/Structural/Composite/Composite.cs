using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Structural.Composite
{
    /// <summary>
    /// interface component 
    /// </summary>
    public interface Graphic
    {
        void move(int x, int y);
        void draw();
    }

    /// <summary>
    /// composite object
    /// </summary>
    public class Dot : Graphic
    {
        public int x { get; set; }
        public int y { get; set; }
        public Dot(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void draw()
        {
            throw new NotImplementedException();
        }

        public void move(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// It is the Leaf object of the pattern.
    /// </summary>
    public class Cicle : Dot
    {
        public int x { get; set; }
        public int y { get; set; }
        public Cicle(int x, int y):base(x,y)
        {

        }
    }
}
