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

namespace WindowsFormsOpenCVApplication3
{
    public partial class Form1 : Form
    {
        VideoCapture cap;
        Mat frame = new Mat();
        Mat insert_image_origin = new Mat("Bitmap1.bmp");
        Mat insert_image_origin_gray = new Mat("Bitmap1.bmp", ImreadModes.Grayscale);
        Mat insert_image;
        Mat insert_image_gray;
        Mat imageROI;
        Mat convertedframe = new Mat();
        Rect[] rects;

        Bitmap tempimage1;
        CascadeClassifier facecascade;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                 frame = new Mat();
                 insert_image_origin = new Mat("Bitmap1.bmp");
                 insert_image_origin_gray = new Mat("Bitmap1.bmp", ImreadModes.Grayscale);
                 convertedframe = new Mat();
                cap = VideoCapture.FromCamera(CaptureDevice.Any);
                cap.Open(0);
                cap.Read(frame);
                facecascade = new CascadeClassifier("haarcascade_frontalface_default.xml");
            }
            catch (Exception extdf)
            {
                Console.WriteLine(extdf.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //Console.WriteLine("Tick");

                //Console.WriteLine(System.IO.Directory.GetCurrentDirectory());

                //프레임을 읽어 왔다.
                cap.Read(frame);

                #region facedetect
                rects = facecascade.DetectMultiScale(frame);
                //facecascade.DetectMultiScale(frame);
                if (rects.Length > 0)
                {
                    foreach (Rect rect in rects)
                    {
                        Console.WriteLine("face detected! "+ DateTime.Now);

                        //얼굴 판독된 부분에 네모 칠하기
                        frame.Rectangle(rect, Scalar.Green, 5);

                        //얼굴 판독된 부분이 이미지 덮어 씌우기
                         insert_image = insert_image_origin;
                         insert_image_gray = insert_image_origin_gray;
                        
                        //두 이미지를 얼굴에 해당 하는 영역의 크기로 변환한다.
                        insert_image_gray = insert_image_gray.Resize(rect.Size);
                        insert_image = insert_image.Resize(rect.Size);

                        //카메라에 찍힌 화면인 frame 에서 이미지를 추가하기 위한 영역을 추출해 매트릭스화 한다.
                         imageROI = new Mat(frame, rect);
                        
                        //추출한 매트릭스에 이미지를 추가한다. 그레이 이미지가 왜 필요한지는 잘 모르겠다.
                        insert_image.CopyTo(imageROI, insert_image_gray);

                    }
                }
                #endregion

                OpenCvSharp.Size newsize = new OpenCvSharp.Size(pictureBox1.Width, pictureBox1.Height);
                frame = frame.Resize(newsize);

                 tempimage1 = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);

                pictureBox1.Image = tempimage1;

                imageROI.Release();
                insert_image_gray.Release();
                insert_image.Release();

                //Cv2.WaitKey(10);
                System.GC.Collect(0, GCCollectionMode.Forced);
                System.GC.WaitForFullGCComplete();
            }
            catch (Exception extdf)
            {
                //Console.WriteLine(extdf.ToString());
                Form1_Load(null, null);
            }
        }
    }
}
