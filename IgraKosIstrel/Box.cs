﻿using System;
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

        public static bool isInsideList(List<Box> boxList, Coordinate k)
        {
            for (int i = boxList.Count-1; i >=0; i--)
            {
                if (boxList[i].isInside(k))
                {
                    boxList.RemoveAt(i);
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
           // g.DrawPolygon(p, polyPoints.ToArray());

            g.DrawImage(Form1.ccube, (int)Koordinati[3].X, h - (int)Koordinati[3].Y);
            //g.DrawPolygon(p, polyPoints.ToArray());

        }

        public void updateBoxVerticaly(int dy)
        {
            for (int i = 0; i < Koordinati.Count; i++)
            {
                Koordinati[i].Y += dy;
            }
        }

        public void updateBoxHorizontaly(int dx)
        {
            for (int i = 0; i < Koordinati.Count; i++)
            {
                Koordinati[i].X += dx;
            }
        }

        public static void updateAllBoxes(List<Box> boxes,int dx, int dy,int height,int width)
        {
            for (int i = 0; i < boxes.Count; i++)
            {
                boxes[i].updateBoxHorizontaly(dx);
                boxes[i].updateBoxVerticaly(dy);

                int sum = 0;

                for (int j = 0; j < boxes[i].Koordinati.Count; j++)
                {
                    if (boxes[i].Koordinati[j].Y < 0)
                    { sum++; }
                }
                if (sum == 4)
                    boxes[i].updateBoxVerticaly(height);

            }
        }

    }
}
