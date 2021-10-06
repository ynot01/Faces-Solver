using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace Faces
{

    public partial class FormY : Form
    {
        public FormY()
        {
            InitializeComponent();
        }

        int dir = 270; //Facing south or towards commander
        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            speedInput.Enabled = false;
            textBox1.Enabled = false;
            pictureBox1.Image = pictureBox2.Image;

            /*
            switch (dir % 360)
            {
                case 0:
                    pictureBox1.Image = RotateImage(pictureBox1.Image, -90);
                    break;
                case 360:
                    pictureBox1.Image = RotateImage(pictureBox1.Image, -90);
                    break;
                case -360:
                    pictureBox1.Image = RotateImage(pictureBox1.Image, -90);
                    break;
                case 90:
                    pictureBox1.Image = RotateImage(pictureBox1.Image, 180);
                    break;
                case -270:
                    pictureBox1.Image = RotateImage(pictureBox1.Image, 180);
                    break;
                case 180:
                    pictureBox1.Image = RotateImage(pictureBox1.Image, 90);
                    break;
                case -180:
                    pictureBox1.Image = RotateImage(pictureBox1.Image, 90);
                    break;
                default:
                    break;
            }
            */

            dir = 270;
            float waitln = 500;
            string finalface = "";
            string curfaceext = "";
            curface.Text = "Facing: ";
            lastfacetxt.Text = "The final face is: ";
            noIntErr.Visible = false;
            angleDis.Text = "Angle: " + dir;
            label6.Text = "Last face: ";



            try
            {
                float parsed = float.Parse(speedInput.Text);
                if (parsed <= 0){
                    noNegErr.Visible = true;
                }
                else
                {
                    waitln = 500 / parsed;
                }
            }
            catch (FormatException)
            {
                noIntErr.Visible = true;
            }

            switch (dir % 360)
            {
                case 270:
                    curfaceext = "Commander";
                    break;
                case -90:
                    curfaceext = "Commander";
                    break;
                case 0:
                    curfaceext = "Left";
                    break;
                case 360:
                    curfaceext = "Left";
                    break;
                case -360:
                    curfaceext = "Left";
                    break;
                case 90:
                    curfaceext = "Away from commander";
                    break;
                case -270:
                    curfaceext = "Away from commander";
                    break;
                case 180:
                    curfaceext = "Right";
                    break;
                case -180:
                    curfaceext = "Right";
                    break;
            }
            curface.Text = "Facing: " + curfaceext;


            progressBar1.Maximum = textBox1.Text.Length;
            progressBar1.Value = 0;
            progressBar1.Visible = true;

            int loop_position = -1;
            int facesinloop = 0;
            foreach (char i in textBox1.Text)
            {
                if (i == 'L' || i == 'l' || i == 'R' || i == 'r' || i == 'A' || i == 'a' || i == 'F' || i == 'f')
                {
                    facesinloop++;
                }
            }
            label11.Text = "Faces left: " + facesinloop;

            foreach (char i in textBox1.Text)
            {
                progressBar1.PerformStep();
                loop_position++;
                if (i != 'L' && i != 'l' && i != 'R' && i != 'r' && i != 'A' && i != 'a' && i != 'F' && i != 'f')
                {
                    continue;
                }
                await Task.Delay((int)waitln);
                facesinloop--;
                label11.Text = "Faces left: " + facesinloop;
                dir %= 360;
                if (dir == 270 || dir == -90)
                {
                    pictureBox1.Image = pictureBox2.Image;
                }

                char next;
                try
                {
                    bool foundface = false;
                    int temploop = loop_position;

                    do
                    {
                        next = textBox1.Text[temploop + 1];

                        if (next == 'L' || next == 'l')
                        {
                            label7.Text = "Next face: Left";
                            foundface = true;
                        }
                        if (next == 'R' || next == 'r')
                        {
                            label7.Text = "Next face: Right";
                            foundface = true;
                        }
                        if (next == 'A' || next == 'a')
                        {
                            label7.Text = "Next face: About";
                            foundface = true;
                        }
                        if (next == 'F' || next == 'f')
                        {
                            label7.Text = "Next face: Front";
                            foundface = true;
                        }
                        temploop++;
                    } while (foundface == false);
                }
                catch (IndexOutOfRangeException)
                {
                    label7.Text = "Next face: ";
                }

                if (i == 'L' || i == 'l') {
                    label6.Text = "Last face: Left";
                    dir += 90;
                    dir %= 360;
                    pictureBox1.Image = RotateImage(pictureBox1.Image, -90);
                }
                if (i == 'R' || i == 'r')
                {
                    label6.Text = "Last face: Right";
                    dir -= 90;
                    dir %= 360;
                    pictureBox1.Image = RotateImage(pictureBox1.Image, 90);
                }
                if (i == 'A' || i == 'a')
                {
                    label6.Text = "Last face: About";
                    dir -= 180;
                    dir %= 360;
                    pictureBox1.Image = RotateImage(pictureBox1.Image, 180);
                }
                if (i == 'F' || i == 'f')
                {
                    label6.Text = "Last face: Front";
                    switch (dir % 360)
                    {
                        case 0:
                            pictureBox1.Image = RotateImage(pictureBox1.Image, -90);
                            break;
                        case 360:
                            pictureBox1.Image = RotateImage(pictureBox1.Image, -90);
                            break;
                        case -360:
                            pictureBox1.Image = RotateImage(pictureBox1.Image, -90);
                            break;
                        case 90:
                            pictureBox1.Image = RotateImage(pictureBox1.Image, 180);
                            break;
                        case -270:
                            pictureBox1.Image = RotateImage(pictureBox1.Image, 180);
                            break;
                        case 180:
                            pictureBox1.Image = RotateImage(pictureBox1.Image, 90);
                            break;
                        case -180:
                            pictureBox1.Image = RotateImage(pictureBox1.Image, 90);
                            break;
                        default:
                            break;
                    }
                    dir = 270;
                    dir %= 360; // i know
                }


                switch (dir)
                {
                    case 270:
                        curfaceext = "Commander";
                        break;
                    case -90:
                        curfaceext = "Commander";
                        break;
                    case 0:
                        curfaceext = "Left";
                        break;
                    case 360:
                        curfaceext = "Left";
                        break;
                    case -360:
                        curfaceext = "Left";
                        break;
                    case 90:
                        curfaceext = "Away from commander";
                        break;
                    case -270:
                        curfaceext = "Away from commander";
                        break;
                    case 180:
                        curfaceext = "Right";
                        break;
                    case -180:
                        curfaceext = "Right";
                        break;
                }
                curface.Text = "Facing: " + curfaceext;
                angleDis.Text = "Angle: " + dir;



            }
            progressBar1.Value = progressBar1.Maximum;
            switch (dir)
            {
                case 270:
                    finalface = "Facing commander";
                    break;
                case -90:
                    finalface = "Facing commander";
                    break;
                case 0:
                    finalface = "Facing left";
                    break;
                case 360:
                    finalface = "Facing left";
                    break;
                case -360:
                    finalface = "Facing left";
                    break;
                case 90:
                    finalface = "Facing away from commander";
                    break;
                case -270:
                    finalface = "Facing away from commander";
                    break;
                case 180:
                    finalface = "Facing right";
                    break;
                case -180:
                    finalface = "Facing right";
                    break;
            }

            foreach (char i in textBox1.Text)
            {
                if (i == 'L' || i == 'l' || i == 'R' || i == 'r' || i == 'A' || i == 'a' || i == 'F' || i == 'f')
                {
                    facesinloop++;
                }
            }
            label11.Text = "Faces left: " + facesinloop;

            lastfacetxt.Text = "The final face is: " + finalface;
            label7.Text = "Next face: ";
            progressBar1.Visible = false;
            button1.Enabled = true;
            speedInput.Enabled = true;
            textBox1.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            noIntErr.Visible = false;
            noNegErr.Visible = false;
            if (speedInput.Text != "")
            {
                try
                {
                    float.Parse(speedInput.Text);
                    if (float.Parse(speedInput.Text) <= 0)
                    {
                        noNegErr.Visible = true;
                    }
                }
                catch (FormatException)
                {
                    noIntErr.Visible = true;
                }
            }
        }

        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.NearestNeighbor;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void curface_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackBar1.FindForm().Opacity = (float)trackBar1.Value / 100.0;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label8.Text = "Length of input: " + textBox1.Text.Length;
            int facespresent = 0;
            foreach (char i in textBox1.Text)
            {
                if (i == 'L' || i == 'l' || i == 'R' || i == 'r' || i == 'A' || i == 'a' || i == 'F' || i == 'f')
                {
                    facespresent++;
                }
            }
            label9.Text = "Faces in input: " + facespresent;
            label10.Text = "Non-faces in input: " + (textBox1.Text.Length - facespresent);
            label11.Text = "Faces left: " + facespresent;
        }

        private void angleDis_Click(object sender, EventArgs e)
        {

        }
    }
}
