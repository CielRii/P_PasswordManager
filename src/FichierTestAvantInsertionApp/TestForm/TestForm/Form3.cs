using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestForm.Properties;

namespace TestForm
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Code taken online
            ListView ListView1 = new ListView();
            ListView1.Scrollable = false; //we cannot scroll
            ListView1.GridLines = false;
            ListView1.Location = new Point(537, 77); //537; 77
            ListView1.Name = "ListView1";
            ListView1.Size = new Size(162, 127); //162; 127 // 245; 200
            ListView1.BackColor = Color.Orange;
            ListView1.ForeColor = Color.Black;


            // create image list and fill it 
            var imageList = new ImageList();
            Image imageFromFile = Image.FromFile("C:\\Users\\sardongmo\\Desktop\\P_PasswordManager\\resources\\images\\logOut.png"); //To edit... 36; 35
            Bitmap bitmap = new Bitmap(imageFromFile);
            Image resized = (new Bitmap(bitmap, new Size(236, 35))); //Resize the picture - src : https://www.delftstack.com/fr/howto/csharp/resize-an-image-in-csharp/

            //Bitmap bitmap = new Bitmap(imageFromFile.Width, imageFromFile.Height);
            //imageFromFile.Size = new Size(36, 35);
            imageList.Images.Add("itemImageKey", resized); //Resources.options
            //D:\\PROJETS\\4.P_Security\\Passwords\\" + _webSiteName + ".txt
            // tell your ListView to use the new image list
            ListView1.LargeImageList = imageList;

            // add an item
            var listViewItem = ListView1.Items.Add(""); //No need to enter a text, but this part of code help to display the picture
            // and tell the item which image to use
            listViewItem.ImageKey = "itemImageKey";




            //ListView1.Columns.Add("- Mon coffre fort", "- Sauvegarder un mot de passe", "- Générer un mot de passe");
            ListView1.Items.Add("- Sauvegarder un mot de passe");
            ListView1.Items.Add("- Générer un mot de passe");
            //ListView1.Items.Add("- Raj Beniwal");
           // ListView1.Items.Add("- Raj Beniwal");
            Controls.Add(ListView1);
            //"Mon coffre fort", "Générer un mot de passe", "Sauvegarder un mot de passe"
        }

        //private void GetItemsButton_Click(object sender, EventArgs e)
        //{
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    foreach (object item in ListView1.Items)
        //    {
        //        sb.Append(item.ToString());
        //        sb.Append(" ");
        //    }
        //    MessageBox.Show(sb.ToString());
        //}
    }
}
