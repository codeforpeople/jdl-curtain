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
		// Used for dragging the windows
		bool isDragging = false;
		int draggingX = 0;
		int draggingY = 0;

		// Whether the curtain is deployed on selected screen
		bool isCurtainDeployed = false;

		// Path to selected image
		string imageFilePath = "";

		public mainForm()
		{
			InitializeComponent();
		}

		#region Events

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
				// Get path
				string fileName = openImageFileDialog.FileName;

				// Save file path
				imageFilePath = fileName;

				// Display only the file name, not the whole path
				fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
				imageFileLabel.Text = fileName;
			}
		}

		private void mainForm_Load(object sender, EventArgs e)
		{
			scanScreens();
		}

		private void displayComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			updateCurtainState();
		}

		private void curtainBtn_Click(object sender, EventArgs e)
		{
			toggleCurtain();
		}

		private void curtainForm_Click(object sender, EventArgs e)
		{
			// Close form
			Form f = (Form)sender;
			f.Close();
			updateCurtainState();
		}

		private void curtainFormControl_Click(object sender, EventArgs e)
		{
			// Close form
			Control c = (Control)sender;
			c.FindForm().Close();
			updateCurtainState();
		}

		#endregion

		/// <summary>
		/// Scan all screens, update dropbox and select first item
		/// </summary>
		private void scanScreens() 
		{
			// Add all screens to combo box
			displayComboBox.Items.Clear();
			foreach (Screen screen in Screen.AllScreens)
			{
				displayComboBox.Items.Add(screen.DeviceName);
			}

			if (displayComboBox.Items.Count > 0)
			{
				// Select first Item
				displayComboBox.SelectedIndex = 0;
			}

			updateCurtainState();
		}

		/// <summary>
		/// Updates the button and isCurtainDeployed variable
		/// </summary>
		private void updateCurtainState()
		{
			// Search for a curtain on the selected screen
			bool exists = false;
			if (displayComboBox.SelectedIndex >= 0) {
				foreach (Form form in Application.OpenForms)
				{
					if (form.Name == displayComboBox.SelectedItem.ToString())
					{
						exists = true;
						break;
					}
				}
			}

			// Update button respectively
			if (exists)
			{
				curtainBtn.Text = "Conceal Awesome Curtain";
				curtainBtn.BackColor = Color.Silver;
				isCurtainDeployed = true;
			}
			else
			{
				curtainBtn.Text = "Deploy Awesome Curtain";
				curtainBtn.BackColor = Color.Gainsboro;
				isCurtainDeployed = false;
			}
		}

		/// <summary>
		/// Deploy or conceal curtain on selected screen
		/// </summary>
		private void toggleCurtain()
		{
			// If no display is selected
			if (displayComboBox.SelectedIndex < 0)
			{
				MessageBox.Show("No display selected. Please select a display.", "JDL Curtain", MessageBoxButtons.OK);
				return;
			}

			if (!isCurtainDeployed)
			{
				// If no image is selected
				if (imageFilePath == "")
				{
					MessageBox.Show("No image selected. Please select an image.", "You had one thing to do", MessageBoxButtons.OK);
					return;
				}

				// Find selected screen
				Screen selectedScreen = null;
				foreach (Screen screen in Screen.AllScreens)
				{
					if (displayComboBox.SelectedItem.ToString() == screen.DeviceName)
					{
						selectedScreen = screen;
						break;
					}
				}

				if (selectedScreen != null)
				{
					// Create overlay form
					Form curtainForm = new Form();
					curtainForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

					// Form is just a quarter of the screen (because I only have one screen to test on)
					curtainForm.SetBounds(selectedScreen.Bounds.X, selectedScreen.Bounds.Y, selectedScreen.Bounds.Width / 2, selectedScreen.Bounds.Height / 2);
					//curtainForm.WindowState = FormWindowState.Maximized;

					curtainForm.StartPosition = FormStartPosition.Manual;
					curtainForm.TopMost = true;
					// Name is used to identify on which screeen the form is
					curtainForm.Name = selectedScreen.DeviceName;
					curtainForm.Click += new EventHandler(curtainForm_Click);

					// Create simple label
					Label screenNameLabel = new Label();
					screenNameLabel.Text = selectedScreen.DeviceName;
					screenNameLabel.Font = new Font(screenNameLabel.Font.FontFamily, 10);
					screenNameLabel.Left = curtainForm.Width / 2 - screenNameLabel.Width / 2;
					screenNameLabel.Top = curtainForm.Height / 2 - screenNameLabel.Height / 2;
					screenNameLabel.BackColor = Color.Transparent;
					screenNameLabel.Click += new EventHandler(curtainFormControl_Click);

					// Create image
					PictureBox image = new PictureBox();
					image.Image = Image.FromFile(imageFilePath);
					image.Location = new Point(0, 0);
					image.Width = curtainForm.Width;
					image.Height = curtainForm.Height;
					image.SizeMode = PictureBoxSizeMode.Zoom;
					image.Click += new EventHandler(curtainFormControl_Click);
				
					// Add label and image
					curtainForm.Controls.Add(image);
					curtainForm.Controls.SetChildIndex(image, 0);
					curtainForm.Controls.Add(screenNameLabel);
					curtainForm.Controls.SetChildIndex(screenNameLabel, 1);

					// Show form
					curtainForm.Show();
				}
				else
				{
					// This should only execute if the selected screen was disconnected
					MessageBox.Show("Invalid Screen!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					scanScreens();
				}
			}
			else
			{
				// Find selected screen
				Screen selectedScreen = null;
				foreach (Screen screen in Screen.AllScreens)
				{
					if (displayComboBox.SelectedItem.ToString() == screen.DeviceName)
					{
						selectedScreen = screen;
						break;
					}
				}

				if (selectedScreen != null)
				{
					// Search for a form named as the screen and close it
					foreach (Form form in Application.OpenForms)
					{
						if (form.Name == selectedScreen.DeviceName)
						{
							form.Close();
							break;
						}
					}
				}
				else
				{
					// This should only execute if the selected screen was disconnected
					MessageBox.Show("Invalid Screen!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					scanScreens();
				}
			}

			updateCurtainState();
		}

	}
}
