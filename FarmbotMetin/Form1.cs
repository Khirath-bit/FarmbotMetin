using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmbotMetin
{
    public partial class Form1 : Form
    {
        private Thread RecordThread;
        private Thread BotThread;
        private bool Analyze = false;
        private NeuralNet Net;
        private int currentProcessId;
        public Form1()
        {
            InitializeComponent();
            RecordThread = new Thread(CaptureScreen);
            Net = new NeuralNet();
            BotThread = new Thread(StartBotting);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var cursor = new Cursor(Cursor.Current.Handle);
            //Cursor.Position = new Point(Cursor.Position.X - 10, Cursor.Position.Y);

            

            //
        }

        private void buttonCapture_Click(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            var g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(0,0,0,0,bitmap.Size);
            pictureBox.Image = bitmap;
            if (Analyze)
                pictureBox.Image = Net.Detect(bitmap);
        }

        private void StartBotting()
        {
            while (true)
            {
                using var bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                using var g = Graphics.FromImage(bitmap);
                g.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

                if (Analyze)
                    pictureBox.Image = Net.Detect(bitmap);
                else
                    pictureBox.Image = bitmap;
                Thread.Sleep(1000);

                var closestMetin = Net.GetClosestBoundingBoxFromCenter();

                if (closestMetin == null)
                    continue;

                Cursor.Position = new Point(closestMetin.Value.X + closestMetin.Value.Width / 2, closestMetin.Value.Y + closestMetin.Value.Height / 2);
                Thread.Sleep(200);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                Thread.Sleep(20);
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                Thread.Sleep(10000);
                Pickup();
                Thread.Sleep(200);
                User.SetForegroundWindow(currentProcessId);
            }
        }

        private void Pickup()
        {
            KeyboardOperations.PressKey(KeyboardOperations.BT7.KEY_Z);
        }

        private void CaptureScreen()
        {
            while (true)
            {
                using var bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                using var g = Graphics.FromImage(bitmap);
                g.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                
                if(Analyze)
                    pictureBox.Image = Net.Detect(bitmap);
                else
                    pictureBox.Image = bitmap;
                Thread.Sleep(1000);
            }
        }

        private void buttonRecord_Click(object sender, EventArgs e)
        {
            RecordThread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RecordThread.Abort();
            RecordThread = new Thread(CaptureScreen);
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            Analyze = !Analyze;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RecordThread.Abort();
        }

        private void buttonHitNextMetin_Click(object sender, EventArgs e)
        {
            var closestMetin = Net.GetClosestBoundingBoxFromCenter();

            if(closestMetin == null)
                return;

            Cursor.Position = new Point(closestMetin.Value.X + closestMetin.Value.Width/2, closestMetin.Value.Y + closestMetin.Value.Height/2);

            Thread.Sleep(200);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            Thread.Sleep(20);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
        }

        private void buttonCollectItems_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            KeyboardOperations.PressKey(KeyboardOperations.BT7.KEY_Z);
        }

        private void buttonStartBotting_Click(object sender, EventArgs e)
        {
            currentProcessId = User.GetForegroundWindow();
            Analyze = true;
            BotThread.Start();
        }

        private void buttonStopBotting_Click(object sender, EventArgs e)
        {
            Analyze = false;
            BotThread.Abort();
            BotThread = new Thread(StartBotting);
        }
    }
}
