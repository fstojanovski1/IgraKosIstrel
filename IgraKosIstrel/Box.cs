using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgraKosIstrel
{
    public class Box
    {
        public List<Coordinate> Koordinati { get; set; }
        public double Masa { get; set; }
        public bool Life { get; set; }

        public Box(List<Coordinate> k, double masa, bool life)
        {
            Koordinati = k;
            Masa = masa;
            Life = life;
        }

        public bool isInside(Coordinate k)
        {
            int i, j;
            bool c = false;
            for (i = 0, j = this.Koordinati.Count - 1; i < this.Koordinati.Count; j = i++)
            {

                if (((Koordinati[i].Y >= k.Y) != (Koordinati[j].Y >= k.Y)) &&
                    (k.X <= (Koordinati[j].X - Koordinati[i].X) * (k.Y - Koordinati[i].Y) / (Koordinati[j].Y - Koordinati[i].Y) + Koordinati[i].X))
                {
                    c = !c;
                }

            }

            return c;
        }

        public static bool isInsideLista(List<Box> listaKutii, Coordinate k)
        {
            for (int i = 0; i < listaKutii.Count; i++)
            {
                if (listaKutii[i].isInside(k) && listaKutii[i].Life == true)
                {
                    listaKutii[i].Life = false;
                    return true;
                }
            }
            return false;
        }

        public void drawBox(Pen p, Graphics g, int h)
        {
            List<Point> polyPoints = new List<Point>();
            polyPoints.Add(new Point((int)Koordinati[0].X, h - (int)Koordinati[0].Y));
            polyPoints.Add(new Point((int)Koordinati[1].X, h - (int)Koordinati[1].Y));
            polyPoints.Add(new Point((int)Koordinati[2].X, h - (int)Koordinati[2].Y));
            polyPoints.Add(new Point((int)Koordinati[3].X, h - (int)Koordinati[3].Y));
            //drawingArea.DrawPolygon(whitePen, polyPoints.ToArray());
            g.DrawPolygon(p, polyPoints.ToArray());
        }

    }
}
