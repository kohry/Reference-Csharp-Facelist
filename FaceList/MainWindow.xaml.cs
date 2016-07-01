using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using Elysium;

namespace FaceList
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IFaceServiceClient faceServiceClient = new FaceServiceClient("3d6fc3ff7a224c769dffa6eff6259c44");
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var openDlg = new Microsoft.Win32.OpenFileDialog();

            openDlg.Multiselect = true;

            bool? result = openDlg.ShowDialog(this);
            if (!(bool)result) return;

            string[] filePath = openDlg.FileNames;
            
            foreach(var file in filePath)
            {
                listBox.Items.Add(file);
            }

            Title = "Detecting...";
            ArrayList faces = await getFaces(filePath);
            Title = "고락가락 얼굴 인식기";

            foreach (Face face in faces)
            {
                textAll.Text += JsonConvert.SerializeObject(face) ;
                textAll.AppendText("\r\n");
            }
            
        }

        private async Task<ArrayList> getFaces(string[] filePath)
        {

            ArrayList faceList = new ArrayList();

            foreach (var file in filePath) {
                Stream imageFileStream = File.OpenRead(file);
                Face[] faces = await faceServiceClient.DetectAsync(imageFileStream, true, true, new FaceAttributeType[] { FaceAttributeType.Gender, FaceAttributeType.Age, FaceAttributeType.Smile, FaceAttributeType.Glasses });

                foreach (var face in faces)
                {
                    faceList.Add(face);
                }

            }
            return faceList;
        }

        private Face3 getExactPoint(Face face)
        {
            var face3 = new Face3();

            double x = face.FaceRectangle.Width;
            double y = face.FaceRectangle.Height;

            face3.faceId = face.FaceId.ToString();
            face3.width = face.FaceRectangle.Width;
            face3.height = face.FaceRectangle.Height;
            face3.left = face.FaceRectangle.Left;
            face3.top = face.FaceRectangle.Top;

            face3.pupil_left_x = face.FaceLandmarks.PupilLeft.X - x;
            face3.pupil_right_x = face.FaceLandmarks.PupilRight.X - x;
            face3.nose_tip_x = face.FaceLandmarks.NoseTip.X - x;
            face3.mouth_left_x = face.FaceLandmarks.MouthLeft.X - x;
            face3.mouth_right_x = face.FaceLandmarks.MouthRight.X - x;
            face3.eyebrow_left_outer_x = face.FaceLandmarks.EyebrowLeftOuter.X - x;
            face3.eyebrow_left_inner_x = face.FaceLandmarks.EyebrowLeftInner.X - x;
            face3.eye_left_outer_x = face.FaceLandmarks.EyeLeftOuter.X - x;
            face3.eye_left_top_x = face.FaceLandmarks.EyeLeftTop.X - x;
            face3.eye_left_bottom_x = face.FaceLandmarks.EyeLeftBottom.X - x;
            face3.eye_left_inner_x = face.FaceLandmarks.EyeLeftInner.X - x;
            face3.eyebrow_right_inner_x = face.FaceLandmarks.EyebrowRightInner.X - x;
            face3.eyebrow_right_outer_x = face.FaceLandmarks.EyebrowRightOuter.X - x;
            face3.eye_right_outer_x = face.FaceLandmarks.EyeRightOuter.X - x;
            face3.eye_right_top_x = face.FaceLandmarks.EyeRightTop.X - x;
            face3.eye_right_bottom_x = face.FaceLandmarks.EyeRightBottom.X - x;
            face3.eye_right_inner_x = face.FaceLandmarks.EyeRightInner.X - x;
            face3.nose_root_left_x = face.FaceLandmarks.NoseRootLeft.X - x;
            face3.nose_root_right_x = face.FaceLandmarks.NoseRootRight.X - x;
            face3.nose_left_alar_top_x = face.FaceLandmarks.NoseLeftAlarTop.X - x;
            face3.nose_right_alar_top_x = face.FaceLandmarks.NoseRightAlarTop.X - x;
            face3.nose_left_alar_out_tip_x = face.FaceLandmarks.NoseLeftAlarOutTip.X - x;
            face3.nose_right_alar_out_tip_x = face.FaceLandmarks.NoseRightAlarOutTip.X - x;
            face3.lip_upper_top_x = face.FaceLandmarks.UpperLipTop.X - x;
            face3.lip_upper_bottom_x = face.FaceLandmarks.UpperLipBottom.X - x;
            face3.lip_under_top_x = face.FaceLandmarks.UnderLipTop.X - x;
            face3.lip_under_bottom_x = face.FaceLandmarks.UnderLipBottom.X - x;

            face3.pupil_left_y = face.FaceLandmarks.PupilLeft.Y - y;
            face3.pupil_right_y = face.FaceLandmarks.PupilRight.Y - y;
            face3.nose_tip_y = face.FaceLandmarks.NoseTip.Y - y;
            face3.mouth_left_y = face.FaceLandmarks.MouthLeft.Y - y;
            face3.mouth_right_y = face.FaceLandmarks.MouthRight.Y - y;
            face3.eyebrow_left_outer_y = face.FaceLandmarks.EyebrowLeftOuter.Y - y;
            face3.eyebrow_left_inner_y = face.FaceLandmarks.EyebrowLeftInner.Y - y;
            face3.eye_left_outer_y = face.FaceLandmarks.EyeLeftOuter.Y - y;
            face3.eye_left_top_y = face.FaceLandmarks.EyeLeftTop.Y - y;
            face3.eye_left_bottom_y = face.FaceLandmarks.EyeLeftBottom.Y - y;
            face3.eye_left_inner_y = face.FaceLandmarks.EyeLeftInner.Y - y;
            face3.eyebrow_right_inner_y = face.FaceLandmarks.EyebrowRightInner.Y - y;
            face3.eyebrow_right_outer_y = face.FaceLandmarks.EyebrowRightOuter.Y - y;
            face3.eye_right_outer_y = face.FaceLandmarks.EyeRightOuter.Y - y;
            face3.eye_right_top_y = face.FaceLandmarks.EyeRightTop.Y - y;
            face3.eye_right_bottom_y = face.FaceLandmarks.EyeRightBottom.Y - y;
            face3.eye_right_inner_y = face.FaceLandmarks.EyeRightInner.Y - y;
            face3.nose_root_left_y = face.FaceLandmarks.NoseRootLeft.Y - y;
            face3.nose_root_right_y = face.FaceLandmarks.NoseRootRight.Y - y;
            face3.nose_left_alar_top_y = face.FaceLandmarks.NoseLeftAlarTop.Y - y;
            face3.nose_right_alar_top_y = face.FaceLandmarks.NoseRightAlarTop.Y - y;
            face3.nose_left_alar_out_tip_y = face.FaceLandmarks.NoseLeftAlarOutTip.Y - y;
            face3.nose_right_alar_out_tip_y = face.FaceLandmarks.NoseRightAlarOutTip.Y - y;
            face3.lip_upper_top_y = face.FaceLandmarks.UpperLipTop.Y - y;
            face3.lip_upper_bottom_y = face.FaceLandmarks.UpperLipBottom.Y - y;
            face3.lip_under_top_y = face.FaceLandmarks.UnderLipTop.Y - y;
            face3.lip_under_bottom_y = face.FaceLandmarks.UnderLipBottom.Y - y;

            face3.gender = face.FaceAttributes.Gender;
            face3.headpose = face.FaceAttributes.HeadPose.ToString();
            face3.facialhair = face.FaceAttributes.FacialHair.ToString();
            face3.age = face.FaceAttributes.Age;
            face3.smile = face.FaceAttributes.Smile;
            // face3.glasses = face.faceAttributes.glasses; //버전업필요한부분

            face3.c_eye_left_size = face3.eye_left_top_y - face3.eye_left_bottom_y;
            face3.c_eye_right_size = face3.eye_right_top_y - face3.eye_right_bottom_y;

            face3.c_eye_left_width = face3.eye_left_outer_x - face3.eye_left_inner_x;
            face3.c_eye_right_width = face3.eye_right_outer_x - face3.eye_right_inner_x;

            face3.c_eye_nose_align = face3.pupil_left_y - face3.nose_root_left_y; //nose_root로?

            face3.c_nose_root_width = face3.nose_root_left_x - face3.nose_root_right_x;
            face3.c_nose_alar_width = face3.nose_left_alar_out_tip_x - face3.nose_right_alar_out_tip_x;

            face3.c_nose_height = face3.nose_root_left_y - face3.nose_tip_y;

            face3.c_eyebrow_left_width = face3.eyebrow_left_outer_x - face3.eyebrow_left_inner_x;
            face3.c_eyebrow_right_width = face3.eyebrow_right_inner_x = face3.eyebrow_right_outer_x;

            face3.c_lip_upper_height = face3.lip_upper_top_y - face3.lip_upper_bottom_y;
            face3.c_lip_under_height = face3.lip_under_top_y - face3.lip_under_bottom_y;

            face3.c_lip_width = face3.mouth_left_x - face3.mouth_right_x;


            return face3;
        }

        private void getCalcResult(Face face)
        {
            //      var fieldnames = new[] { "itemtype", "etc etc " };
            //        Attribute[] attrs = Attribute.GetCustomAttributes(typeof(Face));
            //       foreach (Attribute attr in attrs) textCalc.Text += attr.ToString();
            
            





              
       //     {
        //        var temp = face.GetType().GetProperty(fieldnames[i]);
        //        face.GetType().GetProperty(fieldnames[i]).SetValue(face, temp - face.FaceRectangle);
        //    }


        }

        private async void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string filePath = listBox.SelectedItem.ToString();
            string[] curItems = { filePath };
            
            ArrayList faces = await getFaces(curItems);

            //디테일 정보
            foreach (Face face in faces)
            {
                textDetail.Text = JsonConvert.SerializeObject(face);
                
                Face3 face3 = getExactPoint(face);
                textCalc.Text = JsonConvert.SerializeObject(face3);
            }
            


            //이미지 설정
            Uri fileUri = new Uri(filePath);
            BitmapImage bitmapSource = new BitmapImage();

            bitmapSource.BeginInit();
            bitmapSource.CacheOption = BitmapCacheOption.None;
            bitmapSource.UriSource = fileUri;
            bitmapSource.EndInit();

            image.Source = bitmapSource;

        }
    }

    


}
