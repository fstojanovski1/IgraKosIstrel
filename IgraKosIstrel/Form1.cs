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
        Graphics drawingArea;
        ShootingBall ball;
        public static double time = 0;
        List<Coordinate> states1;
        List<Coordinate> states2;
        public int a = 0;
        public static int ArrowAngle = 0;
        bool firstTime = true;
        public World w;
        public Arc arc;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            drawingArea = pbBackground.CreateGraphics();
            ball = new ShootingBall(new Coordinate(48, 48), 10, 85, 30);
            w = new World(1, pbBackground.Width, pbBackground.Height);
            arc = new Arc(new Coordinate(18, pbBackground.Height - 78), new Coordinate(23, pbBackground.Height - 73), 60, 50);
            states1 = new List<Coordinate>();
            states2 = new List<Coordinate>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            time = 0;
            timer1.Interval = 10;
            timer1.Enabled = true;
            timer1.Start();
            firstTime = true;
            timer2.Enabled = false;
            ball = new ShootingBall(new Coordinate(48, 48), 10, 85, 30);
            states1 = new List<Coordinate>();
        }

        private void FormSMbp_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap bufl = new Bitmap(pbBackground.Width, pbBackground.Height);


            using (Graphics g = Graphics.FromImage(bufl))
            {
                w.drawWorldBefore(g, arc);
                pbBackground.CreateGraphics().DrawImageUnscaled(bufl, 0, 0);
            }



            textBox1.Text = ball.angle.ToString();
            time += 1.0 / 24;
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (firstTime)
            {
                timer1.Enabled = false;
                timer2.Interval = 10;
                timer2.Enabled = true;
                timer2.Start();
                ball.angle = -arc.angle;
                firstTime = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Bitmap bufl = new Bitmap(pbBackground.Width, pbBackground.Height);

            using (Graphics g = Graphics.FromImage(bufl))
            {
                w.drawWorldAfter(g, ball, timer2, states1);
                
                pbBackground.CreateGraphics().DrawImageUnscaled(bufl, 0, 0);
            }
        }


    }
}
