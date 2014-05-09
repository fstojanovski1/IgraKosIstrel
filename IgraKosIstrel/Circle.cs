using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IgraKosIstrel
{
    public class Circle
    {
        public int radius { get; set; }
        public Coordinate c { get; set; }
        public bool disappear { get; set; }

        public Circle(int r, Coordinate cc)
        {
            radius = r;
            c = cc;
            disappear = false;
        }

        public bool isInside(Coordinate a)
        {
            double d1=Math.Pow((double)c.X-(double)a.X,2);
            double d2 = Math.Pow((double)c.Y - (double)a.Y, 2);
            double d = Math.Sqrt(d1+d2);
            if (d<=radius && !disappear)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void drawCircle(Graphics g, int h)
        {
            if(!disappear)
            g.DrawImage(Form1.orangeVortex, (int)(c.X - radius-1), h - (int)(c.Y + radius+1));
        }

        public static int isInsideList(List<Circle> circleList, Coordinate k, int s)
        {
            for (int i = circleList.Count-1; i >=0; i--)
            {
                if (circleList[i].isInside(k))
                {
                    circleList.RemoveAt(i);
                    s++;  
                }
            }
            return s;
        }

    }
}
