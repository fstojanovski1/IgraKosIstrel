using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgraKosIstrel
{
    public class ShootingBall
    {
        public Coordinate coordinate { get; set; }
        public double angle { get; set; }
        public double velocity { get; set; }
        public const double earthAcceleration = 9.91;

        public ShootingBall(Coordinate k, double a, double v) //constructor
        {
            coordinate = k;
            angle = a;
            velocity = v;
        }

        public double calcX(double time, bool vred) 
            //Calculating the change over X axis
        {
            return 2 * velocity * time * Math.Cos(angle * (Math.PI / 180));
        }
        
        public double calcY(double time, double prevousValue, bool vred)
            //Calculating the change over Y axis
        {
            return 2 * velocity * (time) * Math.Sin(angle * (Math.PI / 180)) - ((earthAcceleration * Math.Pow((time), 2)) / 2);
        }
        
        public void Update_Angle(Coordinate c)
            //Updating the angle according to the next position in the trajectory
        {
            this.angle = -Math.Atan(-(c.Y - 0) / (c.X - 0)) * (180 / Math.PI);
        }
        
        public void Update_Coordinate(Coordinate c)
            //Updating the coordinate according to the next position in the trajectory
        {
            this.coordinate.X += c.X;
            this.coordinate.Y += c.Y;
        }
    }
}
