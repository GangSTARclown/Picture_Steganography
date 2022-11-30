using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganography_Tutorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btSource_Click(object sender, EventArgs e)
        {
            //Erstellen einer Instanz des OpenFileDialogs
            OpenFileDialog fileDialog = new OpenFileDialog();
            //Hinzufügen der Filterung nach Dateien des PNG Formates
            fileDialog.Filter = "Bild Dateien (*.png) | *.png";

            fileDialog.InitialDirectory = @"D:\Schule\3_Semester\ALG\Steganographie\Einfaches Beispiel";

            //Öffnen des Dateiexplorers und zwischenspeichern des Pfades in einem Textfeld
            if (fileDialog.ShowDialog() == DialogResult.OK)
                tBSourcePath.Text = fileDialog.FileName.ToString();
        }

        private void btEmbed_Click(object sender, EventArgs e)
        {
            if (File.Exists(tBSourcePath.Text))
            {
                using (Bitmap coverImage = new Bitmap(tBSourcePath.Text))
                {
                    Steganography.EmbedTextInCoverImage(coverImage, rTBSecretText.Text);
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Bild Dateien (*.png) | *.png";
                    saveFileDialog.InitialDirectory = @"D:\Schule\3_Semester\ALG\Steganographie\Einfaches Beispiel\";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        tBSourcePath.Text = saveFileDialog.FileName.ToString();
                        coverImage.Save(tBSourcePath.Text, ImageFormat.Png);
                    }
                }
            }
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            lblSecretMessage.Text = Steganography.ExtractTextFromCoverImage(tBSourcePath.Text);
        }

        private void tBSourcePath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
