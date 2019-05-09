using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using System.Drawing.Imaging;
using OpenCvSharp.Extensions;

namespace WindowsFormsOpenCVApplication1
{
    public partial class Form1 : Form
    {
        VideoCapture cap;
        Mat frame;

        const int frameWidth = 640;
        const int frameHeight = 480;

        Window window;
        Window window2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region 로컬 파일 읽기
            //로컬 파일 읽기
            {
                //frame = new Mat();
                //cap = VideoCapture.FromCamera(CaptureDevice.Any, 0);

                //var window = new Window("capture");

                //// When the movie playback reaches end, Mat.data becomes NULL.
                //while (true)
                //{
                //    try
                //    {
                //        Console.WriteLine("READ");
                //        cap.Read(frame); // same as cvQueryFrame

                //        window.ShowImage(frame);
                //        Cv2.WaitKey();
                //    }
                //    catch (Exception extdf)
                //    {
                //        Console.WriteLine(extdf.ToString());
                //    }
                //}
            }
            #endregion

            #region 카메라 영상 읽기
            {
                frame = new Mat();
                for (int i = 0; i < 1; i++)
                {
                    cap = VideoCapture.FromCamera(CaptureDevice.Any, 0);
                    Console.WriteLine(cap.IsOpened());
                }
                //cap = VideoCapture.FromFile("D:\\Downloads\\modet_2018-10-12_07-55.mkv");

                //cap.FrameWidth = frameWidth;
                //cap.FrameHeight = frameHeight;
                //cap.Open(0);
                //cap.Read(frame);
                //pictureBoxIpl1.ImageIpl = frame;

                //Console.WriteLine(cap.Fps);
                //int sleepTime = (int)Math.Round(1000 / cap.Fps);
                //Console.WriteLine(sleepTime);

                window = new Window("capture");
                //window2 = new Window("edge");
                // Frame image buffer

                // When the movie playback reaches end, Mat.data becomes NULL.
                while (true)
                {
                    try
                    {
                        Console.WriteLine("READ");
                        cap.Read(frame); // same as cvQueryFrame

                        Mat dst = new Mat();
                        //Cv2.Canny(frame, dst, 10, 100);

                        window.ShowImage(frame);
                        //window2.ShowImage(dst);
                        Cv2.WaitKey();
                    }
                    catch (Exception extdf)
                    {
                        Console.WriteLine(extdf.ToString());
                    }
                }
                //while (!cap.IsOpened());
            }
            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    Console.WriteLine("READ");
            //    cap.Read(frame); // same as cvQueryFrame

            //    window.ShowImage(frame);
            //    Cv2.WaitKey();
            //}
            //catch (Exception extdf)
            //{
            //    Console.WriteLine(extdf.ToString());
            //}
        }
    }
}
