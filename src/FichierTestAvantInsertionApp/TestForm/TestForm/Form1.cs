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
    public partial class Form1 : Form
    {
        // Declare the ContextMenuStrip control.
        private ContextMenuStrip contextMenuStrip;
        private TextBox textBox1;
        private bool deleteStatus = false;
        public Form2 Form2;
        private bool firstClick = false;
        private MenuStrip options;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
                // Create a new ContextMenuStrip control.
                //contextMenuStrip = new ContextMenuStrip();

                // Attach an event handler for the 
                // ContextMenuStrip control's Opening event.

                ToolStrip ctrl = new ToolStrip();
                //ctrl.Dock = DockStyle.Right;
                string[] taskOptions = new string[] { "1.Marquer la tâche comme complète",
                "2.Modifier la tâche", "3.Supprimer la tâche"};


                // Create a new MenuStrip control and add a ToolStripMenuItem.
                options = new MenuStrip();
                foreach (var option in taskOptions)
                {
                    ToolStripMenuItem crud = new ToolStripMenuItem(option);
                    if (option == "1.Marquer la tâche comme complète")
                        crud.Click += new EventHandler(markTaskAsDone_Click); //Add of an event to handler further operations
                    if (option == "2.Modifier la tâche")
                        crud.Click += new EventHandler(editTask_Click); //Add of an event to handler further operations
                    if (option == "3.Supprimer la tâche")
                        crud.Click += new EventHandler(deleteTask_Click); //Add of an event to handler further operations
                    options.Items.Add(crud);
                    options.Dock = DockStyle.Right;
                    //crud.DropDown = contextMenuStrip;
                    //contextMenuStrip.Closing += new ToolStripDropDownClosingEventHandler(contextMenuStrip1_Opening);
                
                }
                
                //Link the close button to the menu
                pictureBox1.ContextMenuStrip = contextMenuStrip;
                pictureBox1.Visible = true;
                pictureBox1.Click += new EventHandler(pictureBox1_Click);

                // Assign the ContextMenuStrip to the form's 
                // ContextMenuStrip property.
                ContextMenuStrip = contextMenuStrip;

                // Add the ToolStrip control to the Controls collection.
                Controls.Add(ctrl);
                // Add the MenuStrip control last. This is important for correct placement in the z-order.
                Controls.Add(options);

        }

        private void markTaskAsDone_Click(object sender, EventArgs e)
        {
            Label label11 = new Label();
            label11.Text = label1.Text;
            label11.Visible = true;
            label11.Location = new Point(1, 1);
            Form2.Controls.Add(label11);
            label1.Visible = false;
            Form2.Show();
            Hide();

            //closeMenu.Show();
        }

        private void editTask_Click(object sender, EventArgs e)
        {
            textBox1 = new TextBox();
            textBox1.Text = label1.Text;
            textBox1.Location = label1.Location;
            textBox1.Visible = true;
            label1.Visible = false;
            textBox1.KeyDown += textBox1_KeyDown;

            Controls.Add(textBox1);
            if (!textBox1.Focus())
            {
                label1.Text = textBox1.Text;
                label1.Visible = true;
                textBox1.Visible = false;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                label1.Text = textBox1.Text;
                label1.Visible = true;
                textBox1.Visible = false;
            }
        }

        private void deleteTask_Click(object sender, EventArgs e)
        {
            DialogResult confirmSuppression = MessageBox.Show ("Êtes-vous sûr de vouloir supprimer cette tâche ?", "Confirmation avant suppression", MessageBoxButtons.YesNo);
            switch (confirmSuppression)
            {
                case DialogResult.Yes:
                    deleteStatus = true;
                    label1.Visible = false;
                    break;
                case DialogResult.No:
                    deleteStatus = false;
                    break;
            }

            if (deleteStatus)
                label1.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //contextMenuStrip = null;
            //contextMenuStrip.Close();
            //contextMenuStrip.Hide();
            //contextMenuStrip.Visible = false;
            //contextMenuStrip = new ContextMenuStrip();
            //ContextMenuStrip = contextMenuStrip;
            firstClick = true;
            options.Hide();
            this.pictureBox1.Visible = false;
            ToolStripDropDownClosingEventHandler pictureBox1 = new ToolStripDropDownClosingEventHandler(contextMenuStrip1_Opening);

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, ToolStripDropDownClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void label1_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("Test concluant !");
        }

        private void label1_Enter(object sender, EventArgs e)
        {
            MessageBox.Show("Test intermédiaire !");
        }
    }
}