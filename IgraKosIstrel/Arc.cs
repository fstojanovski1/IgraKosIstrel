using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgraKosIstrel
{
    public class Arc
    {
        public Coordinate c1, c2;
        public int width1, width2;
        public int angle;
        public SolidBrush br_red;
        public SolidBrush br_white;
        public int factor;
        public Arc(Coordinate a, Coordinate b, int w1, int w2)
        {
            c1 = a;
            c2 = b;
            width1 = w1;
            width2 = w2;
            br_red = new SolidBrush(Color.Red);
            br_white = new SolidBrush(Color.White);
            factor = -1;
        }

        public void drawArc(Graphics g, int h)
        {
            g.FillPie(br_red, (int)c1.X, (int)c1.Y, width1, width1, 0, angle);
            g.FillPie(br_white, (int)c2.X, (int)c2.Y, width2, width2, 0, angle);
        }

        public void moveAngle(int d)
        {
            angle = angle + factor * d;
            if (angle > 90) factor = -1;
            else if (angle < -90) factor = 1;
            
            
        }

    }
}
