using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IgraKosIstrel
{
    public class World
    {
        public List<Box> boxes { get; set; }
        public int level;
        public int w, h;

        public World(int lvl, int Width, int Height)
        {
            boxes = new List<Box>();
            level = lvl;
            createLevel();
            w = Width;
            h = Height;
        }

        public void createLevel()
        {
            if (level == 1)
            {
                Coordinate k1 = new Coordinate(120, 140);
                Coordinate k2 = new Coordinate(170, 140);
                Coordinate k3 = new Coordinate(170, 151);
                Coordinate k4 = new Coordinate(120, 151);
                List<Coordinate> list1 = new List<Coordinate>();
                list1.Add(k1);
                list1.Add(k2);
                list1.Add(k3);
                list1.Add(k4);
                Box box1 = new Box(list1, 10, true);
                addBox(box1);

                List<Coordinate> list2 = new List<Coordinate>();
                Coordinate k5 = new Coordinate(50, 50);
                Coordinate k6 = new Coordinate(150 + w / 4, 50);
                Coordinate k7 = new Coordinate(100 + w / 4, 200);
                Coordinate k8 = new Coordinate(50 + w / 4, 200);

                list2.Add(k5);
                list2.Add(k6);
                list2.Add(k7);
                list2.Add(k8);
                Box box2 = new Box(list2, 20, true);
                addBox(box2);

            }
        }

        public void addBox(Box k)
        {
            boxes.Add(k);
        }

        public void drawWorldBefore(Graphics g, Arc arc)
        {

            Pen blackPen = new Pen(Color.Black);
            Pen redPen = new Pen(Color.Red);
            Pen grayPen = new Pen(Color.Gray);

            List<Point> polySostojbi = new List<Point>();
            //pocetok na crtanje na kutiite

            using (g)
            {
                g.FillRectangle(Brushes.White, new Rectangle(0, 0, w, h));
                for (int i = 0; i < boxes.Count; i++)
                {
                    if (boxes[i].Life == false)
                    {
                        boxes[i].drawBox(grayPen, g, h);
                    }
                    else
                    {
                        boxes[i].drawBox(blackPen, g, h);
                    }

                }
                //kraj na crtanje na kutiite

                Bitmap resource_cannon = IgraKosIstrel.Properties.Resources.cannon;

                resource_cannon.MakeTransparent();

                g.DrawImage(resource_cannon, 0, h - 50);

                arc.drawArc(g, h);
                arc.moveAngle(1);

            }
        }

        public void drawWorldAfter(Graphics g, ShootingBall ball, Timer timer2, List<Coordinate> states)
        {
            Pen blackPen = new Pen(Color.Black);
            Pen redPen = new Pen(Color.Red);
            Pen grayPen = new Pen(Color.Gray);
            if (ball.coordinate.Y < 0 || ball.coordinate.Y > h - 10)
            {
                timer2.Enabled = false;

            }
            Coordinate tmp1 = new Coordinate(ball.calcX(1.0 / 24, true), ball.calcY(1.0 / 24, 0, true));
            ball.Update_Angle(tmp1);
            ball.Update_Coordinate(tmp1);

            if (Box.isInsideLista(boxes, ball.coordinate))
            {
                timer2.Enabled = false;
            }
            states.Add(new Coordinate(ball.coordinate.X, h - ball.coordinate.Y));
            List<Point> polySostojbi = new List<Point>();
            using (g)
            {
                g.FillRectangle(Brushes.White, new Rectangle(0, 0, w, h));
                for (int i = 0; i < boxes.Count; i++)
                {
                    if (boxes[i].Life == false)
                    {
                        boxes[i].drawBox(grayPen, g, h);
                    }
                    else
                    {
                        boxes[i].drawBox(blackPen, g, h);
                    }

                }
                //kraj na crtanje na kutiite
                foreach (Coordinate k in states)
                {
                    polySostojbi.Add(new Point((int)k.X, (int)k.Y));
                }
                float[] values = { 5, 5 };
                blackPen.DashPattern = values;
                if (states.Count > 1)
                    g.DrawCurve(blackPen, polySostojbi.ToArray());
                SolidBrush br = new SolidBrush(Color.Red);

                Bitmap resource_cannon = IgraKosIstrel.Properties.Resources.cannon;
                Bitmap resource_cannonBall = IgraKosIstrel.Properties.Resources.cannonBall;

                resource_cannonBall.MakeTransparent();
                resource_cannon.MakeTransparent();

                g.DrawImage(resource_cannon, 0, h - 50);
                g.DrawImage(resource_cannonBall, (int)ball.coordinate.X - 10, h - (int)ball.coordinate.Y - 11);
            }
        }

    }
}
