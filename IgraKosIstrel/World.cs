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
        public List<Circle> circles { get; set; }
        public int level;
        public int w, h;
        public int score;
        public int lives;
        public bool isInvisible;
        public int disappear;
        public int count;
        public Circle invisible;

        public World(int lvl, int Width, int Height) //constructor
        {
            boxes = new List<Box>();
            circles = new List<Circle>();
            level = lvl;
            createLevel();
            w = Width;
            h = Height;
            score = 0;
            lives = 5;
            isInvisible = false;
            disappear = 0;
            count = 0;
        }

        public void createLevel() //creates the level according to the player's choice
        {
            if (level == 0)
            {
                //Create 10 circles at random positions
                Random rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int x = rnd.Next(50, 600);
                    int y = rnd.Next(50, 300);
                    Coordinate c=new Coordinate(x,y);
                    Circle circ = new Circle(39, c);
                    circles.Add(circ);
                }
                //Circles created
            }
            else if (level == 1)
            {
                //Create circles
                for (int i = 2; i < 7; i+=2)
                {
                    for (int j = 0; j < 4; j+=2)
                    {
                        Coordinate c = new Coordinate(i * 95 + 70, j*70+100);
                        Circle circ = new Circle(39, c);
                        circles.Add(circ);
                    }
                }
                //circles created!

                //Create Boxes
                for (int i = 1; i < 7; i += 2)
                {
                    for (int j = 1; j < 4; j += 2)
                    {
                            Coordinate c1 = new Coordinate(i * 95 + 50, j * 70 + 100);
                            Coordinate c2 =new Coordinate(i * 95 + 103, j * 70 + 100);
                            Coordinate c3= new Coordinate(i * 95 + 103, j * 70 + 153);
                            Coordinate c4 = new Coordinate(i * 95 + 50, j * 70 + 153);
                            List<Coordinate> tmpCoordBoxes = new List<Coordinate>();
                            tmpCoordBoxes.Add(c1);
                            tmpCoordBoxes.Add(c2);
                            tmpCoordBoxes.Add(c3);
                            tmpCoordBoxes.Add(c4);

                            Box temp_box = new Box(tmpCoordBoxes);
                            boxes.Add(temp_box);
                     }
                }
                //boxes created!
                  

             }
            else if (level == 2)
            {
                //Create circles
                for (int i = 2; i < 7; i += 2)
                {
                    for (int j = 0; j < 4; j += 2)
                    {
                        Coordinate c = new Coordinate(i * 95 + 70, j * 70 + 100);
                        Circle circ = new Circle(39, c);
                        circles.Add(circ);
                    }
                }
                //circles created!

                //Create Boxes
                for (int i = 1; i < 7; i += 2)
                {
                    for (int j = 1; j < 4; j += 1)
                    {
                        Coordinate c1 = new Coordinate(i * 95 + 50, j * 70 + 100);
                        Coordinate c2 = new Coordinate(i * 95 + 103, j * 70 + 100);
                        Coordinate c3 = new Coordinate(i * 95 + 103, j * 70 + 153);
                        Coordinate c4 = new Coordinate(i * 95 + 50, j * 70 + 153);
                        List<Coordinate> tmpCoordBoxes = new List<Coordinate>();
                        tmpCoordBoxes.Add(c1);
                        tmpCoordBoxes.Add(c2);
                        tmpCoordBoxes.Add(c3);
                        tmpCoordBoxes.Add(c4);

                        Box temp_box = new Box(tmpCoordBoxes);
                        boxes.Add(temp_box);
                    }
                }
                //boxes created!


            }
        }

        public void addBox(Box k) //adds a box to the box list of the world
        {
            boxes.Add(k);
        }

        public void drawWorldBefore(Graphics g, Arc arc) //draws the world before the shooting of the cannon
        {
            using (g)
            {
                g.FillRectangle(Brushes.White, new Rectangle(0, 0, w, h));
                g.DrawImage(Form1.backgroundPortal, 0, 0);

                for (int i = 0; i < boxes.Count; i++)
                {
                        boxes[i].drawBox(g, h);
                }
                //boxes drawn!

                Random rnd = new Random();
                for (int i = circles.Count - 1; i >= 0; i--)
                {
                    if (level == 2)
                    {
                        if (!isInvisible)
                        {
                            disappear = rnd.Next(0, circles.Count);
                            isInvisible = true;
                            invisible = circles[disappear];
                        }
                        
                        count++;
                        if (count > 300)
                        {
                            count = 0;
                            isInvisible = false;
                            invisible.disappear = false;
                        }
                        else
                        {
                            invisible.disappear = true;
                        }
                    }
                    circles[i].drawCircle(g, h);
                }


                g.DrawImage(Form1.ccanon, (int)Form1.cannonCoordinate.X, (int)Form1.cannonCoordinate.Y);

                arc.drawArc(g, h);
                arc.moveAngle(1);

            }
            Box.updateAllBoxes(boxes, -1, h, w);
        }

        public void drawWorldAfter(Graphics g, ShootingBall ball, Timer timer2, List<Coordinate> states, Button b, Button r)
            //draws the world after the cannon has been shot with its trajectory
        {
            Pen blackPen = new Pen(Color.Black);
            if (ball.coordinate.Y < 0 || ball.coordinate.Y > h - 10 || ball.coordinate.X>w || ball.coordinate.X<0)
            {
                timer2.Enabled = false;
                
                if (lives > 0)
                {
                    lives--;
                    b.PerformClick();
                }
                else
                {
                    MessageBox.Show("You lost!");
                    b.Enabled = false;
                }
            }

            //resources

            Coordinate tmp1 = new Coordinate(ball.calcX(1.0/5, true), ball.calcY(1.0/5, 0, true));
            
            ball.Update_Angle(tmp1);
            ball.Update_Coordinate(tmp1);

            if (!Form1.startCounting)
            {
                if (Box.isInsideList(boxes, ball.coordinate))
                {
                    Form1.startCounting = true;
                    if (lives > 0)
                    {
                        lives--;
                    }
                    else
                    {
                        MessageBox.Show("You lost!");
                        b.Enabled = false;
                    }

                }
            }

            
            if (Form1.startCounting == false)
            {
                for (int i = circles.Count - 1; i >= 0; i--)
                {
                    if (circles[i].isInside(ball.coordinate))
                    {
                        circles.RemoveAt(i);
                        score++;
                    }
                }
                if (circles.Count == 0)
                {
                    r.PerformClick();
                    MessageBox.Show("You won!");
                    
                    
                }
            }
            states.Add(new Coordinate(ball.coordinate.X, h - ball.coordinate.Y));
            List<Point> polySostojbi = new List<Point>();
            using (g)
            {
                //g.FillRectangle(Brushes.White, new Rectangle(0, 0, w, h));
                g.DrawImage(Form1.backgroundPortal, 0, 0);
                for (int i = 0; i < boxes.Count; i++)
                {
                        boxes[i].drawBox(g, h);

                }
                //kraj na crtanje na kutiite
                Random rnd = new Random();
                for (int i = circles.Count - 1; i >= 0; i--)
                {
                    if (level == 2 && circles.Count > 1)
                    {
                        if (!isInvisible)
                        {
                            disappear = rnd.Next(0, circles.Count - 1);
                            isInvisible = true;
                            invisible = circles[disappear];
                        }

                        count++;
                        if (count > 300)
                        {
                            count = 0;
                            isInvisible = false;
                            invisible.disappear = false;
                        }
                        else
                        {
                            invisible.disappear = true;
                        }
                    }
                    else
                    {
                        invisible.disappear = false;
                    }
                    circles[i].drawCircle(g, h);
                }
                foreach (Coordinate k in states)
                {
                    polySostojbi.Add(new Point((int)k.X, (int)k.Y));
                }
                float[] values = { 5, 5 };
                blackPen.DashPattern = values;
                if (states.Count > 1)
                    g.DrawCurve(blackPen, polySostojbi.ToArray());
                

                g.DrawImage(Form1.ccanon,(int)Form1.cannonCoordinate.X,(int)Form1.cannonCoordinate.Y);
                if(Form1.startCounting!=true)
                g.DrawImage(Form1.cannonArray[Form1.pictureOrder], (int)ball.coordinate.X - 10, h - (int)ball.coordinate.Y - 11);
                Form1.pictureOrder=(Form1.pictureOrder+1)%8;

                if (Form1.startCounting == true)
                {
                    Form1.explosionsOrder++;
                }
                if (Form1.explosionsOrder > 10)
                {
                    timer2.Enabled = false;
                    b.PerformClick();
                }

                if(Form1.explosionsOrder>=0)
                    g.DrawImage(Form1.explosionArray[Form1.explosionsOrder], (int)ball.coordinate.X - 10, h - (int)ball.coordinate.Y - 11);

            }
            Box.updateAllBoxes(boxes, -1,h,w);
            blackPen.Dispose();
        }

    }
}
