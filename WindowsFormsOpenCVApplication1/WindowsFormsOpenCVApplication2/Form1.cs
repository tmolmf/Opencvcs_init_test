using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsOpenCVApplication2
{
    public partial class Form1 : Form
    {
        VideoCapture cap;
        Mat frame = new Mat();
        Mat dstframe = new Mat();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                cap = VideoCapture.FromCamera(CaptureDevice.Any);
                cap.Open(0);
                cap.Read(frame);
                Form1_Resize(null, null);
                //Window window = new Window("capture");
                //window.ShowImage(frame);
                //Window window0 = new Window("edge0");
                //Window window1 = new Window("edge1");
                //Window window2 = new Window("edge2");
                //Window window3 = new Window("edge3");
                //Window window4 = new Window("edge4");
                //Mat edgeframe0 = new Mat();
                //Mat edgeframe1 = new Mat();
                //Mat edgeframe2 = new Mat();
                //Mat edgeframe3 = new Mat();
                //Mat edgeframe4 = new Mat();
                //Cv2.Canny(frame, edgeframe0, 10, 50);
                //Cv2.Canny(frame, edgeframe1, 10, 70);
                //Cv2.Canny(frame, edgeframe2, 10, 90);
                //Cv2.Canny(frame, edgeframe3, 10, 110);
                //Cv2.Canny(frame, edgeframe4, 10, 130);
                //window0.ShowImage(edgeframe0);
                //window1.ShowImage(edgeframe1);
                //window2.ShowImage(edgeframe2);
                //window3.ShowImage(edgeframe3);
                //window4.ShowImage(edgeframe4);
            }
            catch (Exception extdf)
            {
                Console.WriteLine(extdf.ToString());
            }
            //while (true)
            //{
            //    try
            //    {
            //        Mat convertframe = new Mat(100, 100, MatType.CV_8U);
            //        //Cv2.ImShow("Form1", frame);
            //        frame.ConvertTo(convertframe, MatType.CV_8U);
            //        Bitmap tempimage = BitmapConverter.ToBitmap(convertframe);
            //        pictureBox1.Image = tempimage;
            //        Cv2.WaitKey(10);
            //    }
            //    catch (Exception extdf)
            //    {
            //        Console.WriteLine(extdf.ToString());
            //    }
            //}
            //Console.WriteLine("READ");
            //cap.Read(frame);
            //OpenCvSharp.Size newsize = new OpenCvSharp.Size(pictureBox1.Width, pictureBox1.Height);
            //frame = frame.Resize(newsize);
            //Bitmap tempimage = BitmapConverter.ToBitmap(frame);
            
            //pictureBox1.Image = tempimage;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Tick");

                cap.Read(frame);
                OpenCvSharp.Size newsize = new OpenCvSharp.Size(pictureBox1.Width, pictureBox1.Height);
                frame = frame.Resize(newsize);

                Cv2.Canny(frame, dstframe, 20, 100);

                Bitmap tempimage1 = BitmapConverter.ToBitmap(frame);
                Bitmap tempimage2 = BitmapConverter.ToBitmap(dstframe);

                pictureBox1.Image = tempimage1;
                pictureBox2.Image = tempimage2;

                //Cv2.WaitKey(10);
            }
            catch (Exception extdf)
            {
                Console.WriteLine(extdf.ToString());
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

            try
            {
                pictureBox1.Width = (int)(this.Width / 2);
                pictureBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top);
            }
            catch (Exception extdf)
            {
                Console.WriteLine(extdf.ToString());
            }
            try
            {
                pictureBox2.Width = (int)(this.Width / 2);
                //pictureBox2.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top);
                pictureBox2.Location = new System.Drawing.Point(pictureBox1.Location.X + pictureBox1.Width, pictureBox1.Location.Y);
                //pictureBox2.Location.X = pictureBox1.Location.X + pictureBox1.Width;

            }
            catch (Exception extdf)
            {
                Console.WriteLine(extdf.ToString());
            }
}
    }
}
