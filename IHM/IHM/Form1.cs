using System;
using System.Drawing;
using System.Windows.Forms;

namespace IHM
{
    public partial class Form1 : Form
    {
        private Bitmap bitmap;
        private Graphics graphics;
        private Color RectangleColor;
        private Font fontFamily;
        public Form1()
        {
            InitializeComponent();

            bitmap = new Bitmap(640, 480);
            pictureBox1.Image = bitmap;
            graphics = Graphics.FromImage(pictureBox1.Image);
            RectangleColor = Color.Black;
            fontFamily = SystemFonts.DefaultFont;
        }
        /// <summary>
        /// Dessiner Ligne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            graphics.DrawLine(Pens.Red, new Point(int.Parse(segment1X_tb.Text), int.Parse(segment1Y_tb.Text)),
                                        new Point(int.Parse(segment2X_tb.Text), int.Parse(segment2Y_tb.Text)));
            pictureBox1.Invalidate();
        }
        /// <summary>
        /// Effacer les dessins
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            pictureBox1.Invalidate();
        }
        /// <summary>
        /// ColorPicker
        /// </summary>
        private void label7_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            colorPicker_lb.BackColor = colorDialog1.Color;
            RectangleColor = colorDialog1.Color;

        }
        /// <summary>
        /// Bouton dessiner un rectangle
        /// </summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                graphics.DrawRectangle(new Pen(RectangleColor, 2),
                        int.Parse(rectangleX_tb.Text),
                        int.Parse(rectangleY_tb.Text),
                        int.Parse(rectangleSizeX_tb.Text),
                        int.Parse(rectangleSizeY_tb.Text));
            }
            else
            {
                graphics.FillRectangle(new SolidBrush(RectangleColor),
                    int.Parse(rectangleX_tb.Text),
                    int.Parse(rectangleY_tb.Text),
                    int.Parse(rectangleSizeX_tb.Text),
                    int.Parse(rectangleSizeY_tb.Text));
            }

            pictureBox1.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            fontFamily = fontDialog1.Font;
            fontDialog_btn.Text = fontDialog1.Font.FontFamily.Name;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG (.jpg)|*.jpg|BMP (.bmp)|*.bmp";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath_tb.Text = openFileDialog1.SafeFileName;
            }
        }
        /// <summary>
        /// Bouton dessiner du texte (clique)
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button4_Click(object sender, EventArgs e)
        {
            graphics.DrawString(text_tb.Text, fontFamily, Brushes.Black, new Point(int.Parse(textPosX_tb.Text), int.Parse(textPosY_tb.Text)));
            pictureBox1.Invalidate();
        }

        #region Onglet image
        /// <summary>
        /// Bouton dessiner une image (clique)
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button5_Click(object sender, EventArgs e)
        {
            Image img = Image.FromFile(openFileDialog1.FileName);

            graphics.DrawImage(img, int.Parse(ImagePositionX.Text), int.Parse(ImagePositionY.Text), 200, 100);
            pictureBox1.Invalidate();
        }
        #endregion

        #region Menu
        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ligneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void texteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void effacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            pictureBox1.Invalidate();
        }
        #endregion

        private void button6_Click(object sender, EventArgs e)
        {
            graphics.DrawEllipse(new Pen(Brushes.Red, (float)penSize_num.Value), new Rectangle(
                                                        int.Parse(ellipse1X_tb.Text), 
                                                        int.Parse(ellipse1Y_tb.Text),
                                                        int.Parse(ellipseHeight_tb.Text), 
                                                        int.Parse(ellipseHeight_tb.Text)));
            pictureBox1.Invalidate();
        }

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PNG (.png)|*.png";
            saveFileDialog1.ShowDialog();
            pictureBox1.Image.Save(saveFileDialog1.FileName);
        }

    }
}
