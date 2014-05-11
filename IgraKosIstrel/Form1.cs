using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IgraKosIstrel
{
    public partial class Form1 : Form
    {
        ShootingBall ball;
        public static double time = 0;
        List<Coordinate> states;
        public int a = 0;
        public static int ArrowAngle = 0;
        bool firstTime = false;
        public World w;
        public Arc arc;
        public static Coordinate cannonCoordinate{get;set;}
        public static Bitmap []cannonArray=new Bitmap[8];
        public static Bitmap[] explosionArray = new Bitmap[12];
        public static int pictureOrder = 0;
        public static int explosionsOrder = -1;
        public static bool startCounting = false;
        public static Bitmap ccube;
        public static Bitmap ccanon;
        public static Bitmap backgroundPortal;
        public static Bitmap orangeVortex;
        public static int level;
        public static Bitmap bufl;

        public Form1()
        {
            InitializeComponent();
            Form2 f = new Form2();
            f.ShowDialog();
            level = f.selection;
            Init(level);
        }

        public void Init(int difficulty)
        {
            bufl = new Bitmap(pbBackground.Width, pbBackground.Height);
<<<<<<< HEAD
            ball = new ShootingBall(new Coordinate(38, 43), 85, 30);
=======
            ball = new ShootingBall(new Coordinate(38, 43), 10, 85, 30);
>>>>>>> e1a9f008927e9d12dcce8a88968053020029f007
            w = new World(difficulty, pbBackground.Width, pbBackground.Height);
            arc = new Arc(new Coordinate(38, pbBackground.Height - 78), 
                new Coordinate(43, pbBackground.Height - 73), 60, 50);
            states = new List<Coordinate>();
            cannonCoordinate = new Coordinate(0, pbBackground.Height - 50);

            cannonArray[0] = IgraKosIstrel.Properties.Resources._1;
            cannonArray[1] = IgraKosIstrel.Properties.Resources._2;
            cannonArray[2] = IgraKosIstrel.Properties.Resources._3;
            cannonArray[3] = IgraKosIstrel.Properties.Resources._4;
            cannonArray[4] = IgraKosIstrel.Properties.Resources._5;
            cannonArray[5] = IgraKosIstrel.Properties.Resources._6;
            cannonArray[6] = IgraKosIstrel.Properties.Resources._7;
            cannonArray[7] = IgraKosIstrel.Properties.Resources._8;
            for (int i = 0; i < 8; i++)
                cannonArray[i].MakeTransparent();

            explosionArray[0] = IgraKosIstrel.Properties.Resources._11;
            explosionArray[1] = IgraKosIstrel.Properties.Resources._12;
            explosionArray[2] = IgraKosIstrel.Properties.Resources._13;
            explosionArray[3] = IgraKosIstrel.Properties.Resources._14;
            explosionArray[4] = IgraKosIstrel.Properties.Resources._15;
            explosionArray[5] = IgraKosIstrel.Properties.Resources._16;
            explosionArray[6] = IgraKosIstrel.Properties.Resources._17;
            explosionArray[7] = IgraKosIstrel.Properties.Resources._18;
            explosionArray[8] = IgraKosIstrel.Properties.Resources._19;
            explosionArray[9] = IgraKosIstrel.Properties.Resources._20;
            explosionArray[10] = IgraKosIstrel.Properties.Resources._21;
            explosionArray[11] = IgraKosIstrel.Properties.Resources._22;
            for (int i = 0; i < 8; i++)
                explosionArray[i].MakeTransparent();

            ccube = IgraKosIstrel.Properties.Resources.ccube;
            ccube.MakeTransparent();

            ccanon = IgraKosIstrel.Properties.Resources.pcannon;
            ccanon.MakeTransparent();

            backgroundPortal = IgraKosIstrel.Properties.Resources.background_portal;
            orangeVortex=IgraKosIstrel.Properties.Resources.orange_vortex;
        }

        public void startup()
        {
            time = 0;
<<<<<<< HEAD
            timer1.Interval = 20;
=======
            timer1.Interval = 10;
>>>>>>> e1a9f008927e9d12dcce8a88968053020029f007
            timer1.Enabled = true;
            timer1.Start();
            firstTime = true;
            timer2.Enabled = false;
            ball = new ShootingBall(new Coordinate(48, (pbBackground.Height - cannonCoordinate.Y - 2)),
<<<<<<< HEAD
                85, int.Parse(tbSpeed.Text));
=======
                10, 85, int.Parse(tbSpeed.Text));
>>>>>>> e1a9f008927e9d12dcce8a88968053020029f007



            states = new List<Coordinate>();
            pictureOrder = 0;
            explosionsOrder = -1;
            startCounting = false;
            this.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startup();
        }

        private void FormSMbp_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
            ball.angle = -arc.angle;

            using (Graphics g = Graphics.FromImage(bufl))
            {
                w.drawWorldBefore(g, arc);
                pbBackground.CreateGraphics().DrawImageUnscaled(bufl, 0, 0);
            }



        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(bufl))
            {
                w.drawWorldAfter(g, ball, timer2, states, button1);
                
                pbBackground.CreateGraphics().DrawImageUnscaled(bufl, 0, 0);
            }
            tbScore.Text = w.score.ToString();
            tbLives.Text = w.lives.ToString();
        }

        private void pictureBox1_MouseClick(object sender, EventArgs e)
        {
            if (firstTime)
            {
                timer1.Enabled = false;
<<<<<<< HEAD
                timer2.Interval = 20;
=======
                timer2.Interval = 10;
>>>>>>> e1a9f008927e9d12dcce8a88968053020029f007
                timer2.Enabled = true;
                timer2.Start();
                ball.angle = -arc.angle;
                firstTime = false;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // look for the expected key
            if(timer1.Enabled==true || timer2.Enabled==true){
            if (keyData == Keys.Down)
            {
                // take some action
                //MessageBox.Show("The A key was pressed");

                if (cannonCoordinate.Y < pbBackground.Height-50)
                {
                    ball.coordinate.Y -= 10;
                    arc.c1.Y += 10;
                    arc.c2.Y += 10;
                    cannonCoordinate.Y += 10;
                }
                // eat the message to prevent it from being passed on
                return true;

                // (alternatively, return FALSE to allow the key event to be passed on)
            }
            else if (keyData == Keys.Up)
            {
                // take some action
                //MessageBox.Show("The A key was pressed");
                if (cannonCoordinate.Y > 0)
                {
                    ball.coordinate.Y += 10;
                    arc.c1.Y -= 10;
                    arc.c2.Y -= 10;
                    cannonCoordinate.Y -= 10;
                }
                //MessageBox.Show(ball.coordinate.Y.ToString()+"a topot e: "+(pbBackground.Height-cannonCoordinate.Y-2));
                // eat the message to prevent it from being passed on
                return true;

                // (alternatively, return FALSE to allow the key event to be passed on)
            }
            else if (keyData == Keys.Left)
            {
                // take some action
                //MessageBox.Show("The A key was pressed");
                int newSpeed = (int.Parse(tbSpeed.Text) - 1);
                if (newSpeed > 25)
                {
                    tbSpeed.Text = newSpeed.ToString();
                    ball.velocity--;
                }
                //MessageBox.Show(ball.coordinate.Y.ToString()+"a topot e: "+(pbBackground.Height-cannonCoordinate.Y-2));
                // eat the message to prevent it from being passed on
                return true;

                // (alternatively, return FALSE to allow the key event to be passed on)
            }
            else if (keyData == Keys.Right)
            {
                // take some action
                //MessageBox.Show("The A key was pressed");

                int newSpeed = (int.Parse(tbSpeed.Text) + 1);
                if (newSpeed < 60)
                {
                    tbSpeed.Text = newSpeed.ToString();
                    ball.velocity++;
                }

                //MessageBox.Show(ball.coordinate.Y.ToString()+"a topot e: "+(pbBackground.Height-cannonCoordinate.Y-2));
                // eat the message to prevent it from being passed on
                return true;
            }
                // (alternatively, return FALSE to allow the key event to be passed on)
            }

            // call the base class to handle other key events
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Init(level);
            w.lives = 5;
            w.score = 0;
            tbLives.Text = w.lives.ToString();
            tbScore.Text = w.score.ToString();
<<<<<<< HEAD
            button1.Enabled = true;
=======
>>>>>>> e1a9f008927e9d12dcce8a88968053020029f007
            startup();
        }



    }
}
