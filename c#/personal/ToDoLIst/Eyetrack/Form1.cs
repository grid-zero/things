using System.Threading;
namespace Eyetrack
{
    public partial class Form1 : Form
    {
        int x = 0;
        int y = 0;

        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer(); //Create a timer
            t.Interval = 1000; //interval time in ms
            t.Tick += (s, e) => RunCircles();
            t.Start();
            i love 
        }

        private void RunCircles()
        {
           
            this.Invalidate();
        }
        private void InitializeComponent()
        {
            this.DoubleBuffered = true;
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);

            this.BackColor = Color.Black;
            this.Text = "Form1";
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;

        }

        private void Form1_Paint(object? sender, PaintEventArgs e)
        {
            Thread.Sleep(100);
            int oldx = x;
            int oldy = y;
            y = rnd.Next(200, 881);
            x = rnd.Next(200, 1721);
            if (Math.Sqrt(Math.Pow(oldx - x, 2) + Math.Pow(oldy - y, 2)) < 200)
            {
                y = rnd.Next(200, 881);
                x = rnd.Next(200, 1721);
            }

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(Brushes.White, new Rectangle(new Point(x,y),new Size(150,150)));
            
        }

        private void CheckDist(int oldx, int x, int oldy, int y)
        {
            if (Math.Sqrt(Math.Pow(oldx - x, 2) + Math.Pow(oldy - y, 2)) > 200)
            {
                y = rnd.Next(200, 881);
                x = rnd.Next(200, 1721);
            }

            if (Math.Sqrt(Math.Pow(oldx - x, 2) + Math.Pow(oldy - y, 2)) > 200)
            {
                CheckDist(oldx, x, oldy, y);
            }
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }


    }
}