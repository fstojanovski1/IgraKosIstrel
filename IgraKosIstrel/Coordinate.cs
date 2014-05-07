using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgraKosIstrel
{
    public class Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Coordinate(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }


        public override string ToString()
        {
            return string.Format("x:{0} y:{1}", X, Y);
        }
    }
}
