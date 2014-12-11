using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDL_Curtain
{
    public partial class mainForm : Form
    {

        bool isDragging = false;
        int draggingX = 0;
        int draggingY = 0;
        bool curtainIsDeployed = false;

        public mainForm()
        {
            InitializeComponent();
        }

        private void topBar_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            draggingX = MousePosition.X - this.Location.X;
            draggingY = MousePosition.Y - this.Location.Y;
        }

        private void topBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Location = new Point(MousePosition.X - draggingX, MousePosition.Y - draggingY);
            }
        }

        private void topBar_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void exitBtn_MouseEnter(object sender, EventArgs e)
        {
            Label thisLabel = (Label) sender;
            thisLabel.BackColor = Color.Azure;
        }

        private void exitBtn_MouseLeave(object sender, EventArgs e)
        {
            Label thisLabel = (Label) sender;
            thisLabel.BackColor = topBar.BackColor;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void browseImageBtn_Click(object sender, EventArgs e)
        {
            if (openImageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Display only the file name, not the whole path
                string fileName = openImageFileDialog.FileName;
                fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
                imageFileLabel.Text = fileName;
            }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            // Add all screens to combo box
            foreach(Screen screen in Screen.AllScreens) {
                displayComboBox.Items.Add(screen.DeviceName);
            }
        }

        private void curtainBtn_Click(object sender, EventArgs e)
        {
            // If no display is selected
            if (displayComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("No display selected. Please select a display", "You had one thing to do", MessageBoxButtons.OK);
                return;
            }

            if (!curtainIsDeployed)
            {
                curtainIsDeployed = 1 == 1; // Because I can!

                // Find selected screen
                Screen selectedScreen = null;
                foreach (Screen screen in Screen.AllScreens)
                {
                    if (displayComboBox.SelectedItem.ToString() == screen.DeviceName)
                    {
                        selectedScreen = screen;
                    }
                }

                if (selectedScreen != null)
                {
                    // Change button
                    curtainBtn.Text = "Conceal Awesome Curtain";
                    curtainBtn.BackColor = Color.Silver;

                    // Create overlay form
                    Form curtainForm = new Form();
                    curtainForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    curtainForm.SetBounds(selectedScreen.Bounds.X, selectedScreen.Bounds.Y, selectedScreen.Bounds.Width, selectedScreen.Bounds.Height);
                    curtainForm.StartPosition = FormStartPosition.Manual;
                    curtainForm.WindowState = FormWindowState.Maximized;
                    curtainForm.TopMost = true;
                    curtainForm.Click += new EventHandler(curtainForm_Click);

                    // Add screen name
                    Label screenNameLabel = new Label();
                    screenNameLabel.Text = selectedScreen.DeviceName;
                    screenNameLabel.Font = new Font(screenNameLabel.Font.FontFamily, 10);
                    screenNameLabel.Left = curtainForm.Width / 2 - screenNameLabel.Width / 2;
                    screenNameLabel.Top = curtainForm.Height / 2 - screenNameLabel.Height / 2;

                    curtainForm.Controls.Add(screenNameLabel);
                    curtainForm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Screen!", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                // Magic will be entered here soon
            }
        }

        void curtainForm_Click(object sender, EventArgs e)
        {
            // Close form
            Form f = (Form)sender;
            f.Close();
        }
    }
}
