using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceList
{
    public class Face2
    {
        public String faceId;
        public double width;
        public double height;
        public double left;
        public double top;

        public double pupil_left_x;
        public double pupil_right_x;
        public double nose_tip_x;
        public double mouth_left_x;
        public double mouth_right_x;
        public double eyebrow_left_outer_x;
        public double eyebrow_left_inner_x;
        public double eye_left_outer_x;
        public double eye_left_top_x;
        public double eye_left_bottom_x;
        public double eye_left_inner_x;
        public double eyebrow_right_inner_x;
        public double eyebrow_right_outer_x;
        public double eye_right_outer_x;
        public double eye_right_top_x;
        public double eye_right_bottom_x;
        public double eye_right_inner_x;
        public double nose_root_left_x;
        public double nose_root_right_x;
        public double nose_left_alar_top_x;
        public double nose_right_alar_top_x;
        public double nose_left_alar_out_tip_x;
        public double nose_right_alar_out_tip_x;
        public double lip_upper_top_x;
        public double lip_upper_bottom_x;
        public double lip_under_top_x;
        public double lip_under_bottom_x;

        public double pupil_left_y;
        public double pupil_right_y;
        public double nose_tip_y;
        public double mouth_left_y;
        public double mouth_right_y;
        public double eyebrow_left_outer_y;
        public double eyebrow_left_inner_y;
        public double eye_left_outer_y;
        public double eye_left_top_y;
        public double eye_left_bottom_y;
        public double eye_left_inner_y;
        public double eyebrow_right_inner_y;
        public double eyebrow_right_outer_y;
        public double eye_right_outer_y;
        public double eye_right_top_y;
        public double eye_right_bottom_y;
        public double eye_right_inner_y;
        public double nose_root_left_y;
        public double nose_root_right_y;
        public double nose_left_alar_top_y;
        public double nose_right_alar_top_y;
        public double nose_left_alar_out_tip_y;
        public double nose_right_alar_out_tip_y;
        public double lip_upper_top_y;
        public double lip_upper_bottom_y;
        public double lip_under_top_y;
        public double lip_under_bottom_y;


        public String gender;
        public String headpose;
        public String facialhair;

        // 20
        public double age;

        // 2
        public double smile;

        // 3
        public String glasses;

        //eye, 15
        public double c_eye_left_size;
        public double c_eye_right_size;
        public double c_eye_left_width;
        public double c_eye_right_width;

        //align eye - nose
        public double c_eye_nose_align;

        //nose, 15
        public double c_nose_root_width;
        public double c_nose_alar_width;
        public double c_nose_height;

        //eyebrow, 5
        public double c_eyebrow_left_width;
        public double c_eyebrow_right_width;

        //lip, 5
        public double c_lip_upper_height;
        public double c_lip_under_height;
        public double c_lip_width;
    }
}
