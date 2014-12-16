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

		private void timerBtn_Click(object sender, EventArgs e)
		{
			foreach (Form form in Application.OpenForms)
			{
				if (form.Name == "timerForm")
				{
					form.Focus();
					return;
				}
			}
			timerForm timerF = new timerForm();
			timerF.Show();
		}

		private void fadeCheckBox_CheckStateChanged(object sender, EventArgs e)
		{
			// Enable or disable fade length input and label
			if (fadeCheckBox.CheckState == CheckState.Checked)
			{
				fadeLengthLabel.Enabled = true;
				fadeLegthInput.Enabled = true;
			}
			else if (fadeCheckBox.CheckState == CheckState.Unchecked)
			{
				fadeLengthLabel.Enabled = false;
				fadeLegthInput.Enabled = false;
			}
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
		public void updateCurtainState()
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
					// Create new form curtain 
					curtainForm newCurtainForm = new curtainForm();

					// Add properties
					// Name
					newCurtainForm.Name = selectedScreen.DeviceName;
					// Bounds
					//newCurtainForm.Bounds = selectedScreen.Bounds;
					newCurtainForm.SetBounds(selectedScreen.Bounds.X, selectedScreen.Bounds.Y, selectedScreen.Bounds.Width / 2, selectedScreen.Bounds.Height / 2);
					// Fade length
					if (fadeCheckBox.CheckState == CheckState.Checked)
					{
						newCurtainForm.fadeLength = (int)fadeLegthInput.Value;
					}
					else if (fadeCheckBox.CheckState == CheckState.Unchecked)
					{
						newCurtainForm.fadeLength = 0;
					}

					// Load image and show form is successful
					if (newCurtainForm.setImageFromPath(imageFilePath))
					{
						newCurtainForm.Show();
					}
					else
					{
						newCurtainForm.Close();
					}
				}
				else
				{
					// The selected screen was disconnected
					MessageBox.Show("Invalid Screen!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					// Refresh list
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
							curtainForm f = (curtainForm)form;

							// Set fade length
							if (fadeCheckBox.CheckState == CheckState.Checked)
							{
								f.fadeLength = (int)fadeLegthInput.Value;
							}
							else if (fadeCheckBox.CheckState == CheckState.Unchecked)
							{
								f.fadeLength = 0;
							}

							// Close the form
							f.closeForm();
							break;
						}
					}
				}
				else
				{
					// The selected screen was disconnected
					MessageBox.Show("Invalid Screen!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					// Refresh list
					scanScreens();
				}
			}

			updateCurtainState();
		}

	}
}
