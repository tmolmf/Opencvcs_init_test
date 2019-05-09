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

                Cv2.Canny(frame, dstframe, 10, 200);

                Bitmap tempimage = BitmapConverter.ToBitmap(dstframe);

                pictureBox1.Image = tempimage;

                //Cv2.WaitKey(10);
            }
            catch (Exception extdf)
            {
                Console.WriteLine(extdf.ToString());
            }
        }
    }
}
