using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private int nbOfData = 6;
        private Button btn;
        private int index;
        private int indexData;
        private int x = 14;
        private int y = 14;

        private void Form4_Load(object sender, EventArgs e)
        {
            //for (int a = 0; a < data.Length / 2; a++)
            //{
            //    textBox = new TextBox();
            //    textBox.Text = "Site";
            //    textBox.ReadOnly = true;
            //    textBox.Height = 28;
            //    textBox.Width = 156;
            //    textBox.Visible = true;
            //    textBox.Location = new Point(xTextBox, yTextBox);
            //    xTextBox += 156;
            //}
            //yTextBox += 28;

            //for (int i = 0; i < data.Length; i++)
            //{
            //    textBox = new TextBox();
            //    textBox.Text = data[i];
            //    textBox.ReadOnly = true;
            //    textBox.Height = 28;
            //    textBox.Width = 156;
            //    textBox.Location = new Point(xTextBox, yTextBox);
            //    xTextBox += 156;
            //}

            List<string> webSites = new List<string>();
            string[] titles = { "1", "2", "3" };
            string[] data = { "encore", "du", "texte", "essaie", "une", "fois",  "essaie", "une", "fois"};
            int nbOfColumns;
            int nbOfBtns;
            nbOfData = data.Length;
            nbOfBtns = 2;
            Label lbl;
            x = 12;
            y = 153;

            nbOfColumns = titles.Length;
            for (int i = 0; i < titles.Length; i++)
            {
                lbl = new Label();
                lbl.Text = titles[i];
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.Width = 158;
                lbl.Height = 28;
                lbl.Location = new Point(x, y);
                Controls.Add(lbl);
                x += 158;
            }
            y += 28; //Consider the heigth of the textbox for incrementation
            x = 12; //Reinitialisation of the position

            index = 0;
            indexData = 0;
            int j;
            for (int i = 0; i < nbOfData / nbOfColumns; i++) // As we intialize the variable to 1 instead of 0
            {
                for (j = 0; j < nbOfColumns; j++)
                {
                    // j = i * nbOfColumns;
                    lbl = new Label();
                    //btn.Name = "dataLbl" + index;
                    lbl.Text = data[j];
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                    lbl.Width = 158;
                    lbl.Height = 28;
                    lbl.Location = new Point(x, y); //128, 300
                    Controls.Add(lbl);
                    x += 158; //Consider the width of the textbox for incrementation
                }

                for (int k = 0; k < nbOfBtns; k++) //...
                {
                    btn = new Button();
                    //btn.BackColor = randomSolution[m];
                    btn.FlatStyle = FlatStyle.Popup;
                    if (k == 0)
                    {
                        btn.Name = "btn" + "ShowPassword" + index;
                        btn.Text = "Afficher";
                    }
                    else
                    {
                        btn.Name = "btn" + "UpdateData" + index;
                        btn.Text = "Update";
                        index++; //Increment of index for both type of buttons
                    }

                    Controls.Add(btn);
                    btn.Height = 28;
                    btn.Width = 58;
                    btn.Location = new Point(x, y);
                    x += 58;
                }

                PictureBox deleteBtn = new PictureBox()
                {
                    Name = "deleteBtn" + index,
                    Size = new Size(26, 24),
                    Location = new Point(x, y),
                    Image = Image.FromFile(@"C:\Users\sardongmo\Desktop\P_PasswordManager\resources\images\deleteBtn.png"),
                    SizeMode = PictureBoxSizeMode.Zoom //PictureBoxSizeMode.CenterImage
                };
                Controls.Add(deleteBtn);
                indexData += 3;
                y += 28;
                x = 12;
            }
        }
    }
}
