using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsOpenCVApplication4
{
    public partial class Form1 : Form
    {
        VideoCapture cap;
        Mat frame;

        const int frameWidth = 640;
        const int frameHeight = 360;

        Window window;
        CascadeClassifier facecascade;
        Rect[] rects;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frame = new Mat();
            cap = VideoCapture.FromFile("D:\\Downloads\\프리스틴.mp4");
                        
            cap.Read(frame);

            OpenCvSharp.Size newsize = new OpenCvSharp.Size(frameWidth, frameHeight);
            frame = frame.Resize(newsize);

            var window = new Window("capture");
            facecascade = new CascadeClassifier("haarcascade_frontalface_default.xml");

            Mat last = null;
            // When the movie playback reaches end, Mat.data becomes NULL.
            while (true)
            {
                try
                {
                    Console.WriteLine("READ");
                    cap.Read(frame);

                    newsize = new OpenCvSharp.Size(frameWidth, frameHeight);
                    frame = frame.Resize(newsize);

                    rects = facecascade.DetectMultiScale(frame);
                    foreach (Rect rect in rects)
                    {
                        frame.Rectangle(rect, Scalar.Green, 3);
                    }

                    //Mat dstmat = new Mat();
                    //Cv2.Canny(frame, dstmat, 50, 200);
                    //window.ShowImage(dstmat);

                    window.ShowImage(frame);

                    //System.GC.Collect(0, GCCollectionMode.Forced);
                    System.GC.Collect();
                    Cv2.WaitKey(10);
                }
                catch (Exception extdf)
                {
                    Console.WriteLine(extdf.ToString());
                }
            }
        }
    }
}
