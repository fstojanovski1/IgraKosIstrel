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

        public Circle(int r, Coordinate cc) //constructor
        {
            radius = r;
            c = cc;
            disappear = false;
        }

        public bool isInside(Coordinate a) //checks whether a given coordinate is inside the area of the circle
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

<<<<<<< HEAD
        public void drawCircle(Graphics g, int h) // in this case draws the vortex
=======
        public void drawCircle(Graphics g, int h)
>>>>>>> e1a9f008927e9d12dcce8a88968053020029f007
        {
            if(!disappear)
            g.DrawImage(Form1.orangeVortex, (int)(c.X - radius-1), h - (int)(c.Y + radius+1));
        }

        public static int isInsideList(List<Circle> circleList, Coordinate k, int s) 
            //checks whether a point is inside one of a whole list of circles
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
