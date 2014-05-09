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
        public double mass { get; set; }
        public double angle { get; set; }
        public double velocity { get; set; }
        public const double earthAcceleration = 9.91;

        public ShootingBall(Coordinate k, double m, double a, double v)
        {
            coordinate = k;
            mass = m;
            angle = a;
            velocity = v;
        }

        public double calcX(double time, bool vred)
        {
            //    if(vred==true)
            //    NloKoordinata.X = NloKoordinata.X + Brzina * time * Math.Cos(Agol * (Math.PI / 180));
            //    return NloKoordinata.X;
            return velocity * time * Math.Cos(angle * (Math.PI / 180));
        }

        public double calcDX(double time)
        {
            return velocity * time * Math.Cos(angle * (Math.PI / 180));
        }

        public double calcY(double time, double prevousValue, bool vred)
        {
            return velocity * (time) * Math.Sin(angle * (Math.PI / 180)) - ((earthAcceleration * Math.Pow((time), 2)) / 2);
        }

        public double calcDY(double time)
        {
            return velocity * (time) * Math.Sin(angle * (Math.PI / 180)) - ((earthAcceleration * Math.Pow((time), 2)) / 2);
        }

        public void Update_Angle(Coordinate c)
        {
            this.angle = -Math.Atan(-(c.Y - 0) / (c.X - 0)) * (180 / Math.PI);
        }

        public void Update_Coordinate(Coordinate c)
        {
            this.coordinate.X += c.X;
            this.coordinate.Y += c.Y;
        }
    }
}
