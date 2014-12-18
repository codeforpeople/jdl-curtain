using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ResizeForm;

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
			Control c = (Control)sender;
			if (isDragging && c.Cursor == Cursors.Default)
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
			ResizableForm f = new ResizableForm();
			Control[] controls = {mainContainer, topBar, topBarTitle};
			f.MakeFormResizable(this, 10, controls, ResizeLocation.Bottom | ResizeLocation.Right | ResizeLocation.BottomRight, new Size(300, 170), new Size(Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height));
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

namespace ResizeForm
{
	public enum ResizeLocation
	{
		Top = 1, // Buggy
		Bottom = 1 << 1,
		Left = 1 << 2, // Buggy
		Right = 1 << 3,
		TopLeft = 1 << 4, // Very buggy
		TopRight = 1 << 5, // Buggy
		BottomLeft = 1 << 6, // Buggy
		BottomRight = 1 << 7,
		All = (1<<7) + (1<<6) + (1<<5) + (1<<4) + (1<<3) + (1<<2) + (1<<1) + 1,
		Center = 1 << 8 // Not used
	}

	public class ResizableForm
	{
		private Form form;
		private int margin;
		private Control[] controls;
		private Size minSize;
		private Size maxSize;
		private ResizeLocation locations;
		private ResizeLocation draggingLocation;
		private bool isDragging;

		// Too lazy for any overloads
		/// <summary>
		/// Make a borderless form resizable!
		/// </summary>
		/// <param name="form">The form you want to make resizable</param>
		/// <param name="margin">Margin to drag the form</param>
		/// <param name="controls">Controls that respond to mouse events (that will be dragged)</param>
		/// <param name="locations">Which sides/corners can be dragged to resize the form</param>
		/// <param name="minSize">The form will not be smaller than this</param>
		/// <param name="maxSize">The form will not be bigger than this</param>
		public void MakeFormResizable(Form form, int margin, Control[] controls, ResizeLocation locations, Size minSize, Size maxSize)
		{
			this.form = form;
			this.controls = controls;
			this.margin = margin;
			this.minSize = minSize;
			this.maxSize = maxSize;
			this.locations = locations;

			// Mouse events for controls
			foreach (Control control in this.controls)
			{
				control.MouseEnter += mouseEnter;
				control.MouseLeave += mouseLeave;
				control.MouseDown += mouseDown;
				control.MouseUp += mouseUp;
				control.MouseMove += mouseMove;
			}

			// Mouse events form the form
			form.MouseEnter += mouseEnter;
			form.MouseLeave += mouseLeave;
			form.MouseDown += mouseDown;
			form.MouseUp += mouseUp;
			form.MouseMove += mouseMove;
		}

		private void mouseEnter(object sender, EventArgs e)
		{
			// Get the control the mouse is over
			Control control;
			try
			{
				control = (Control)sender;
			}
			catch
			{
				return;
			}

			// Figure out what cursor to use
			ResizeLocation location = getMouseLocation();
			if (Convert.ToBoolean(location & locations))
			{
				if (location == ResizeLocation.TopLeft || location == ResizeLocation.BottomRight)
					control.Cursor = Cursors.SizeNWSE;
				else if (location == ResizeLocation.TopRight || location == ResizeLocation.BottomLeft)
					control.Cursor = Cursors.SizeNESW;
				else if (location == ResizeLocation.Top || location == ResizeLocation.Bottom)
					control.Cursor = Cursors.SizeNS;
				else if (location == ResizeLocation.Left || location == ResizeLocation.Right)
					control.Cursor = Cursors.SizeWE;
				else
					control.Cursor = Cursors.Default;
			}
			else
			{
				control.Cursor = Cursors.Default;
			}
		}

		private void mouseLeave(object sender, EventArgs e)
		{
			Control control;
			try
			{
				control = (Control)sender;
			}
			catch
			{
				return;
			}
			control.Cursor = Cursors.Default;
		}

		private void mouseUp(object sender, MouseEventArgs e)
		{
			isDragging = false;
		}

		private void mouseDown(object sender, MouseEventArgs e)
		{
			isDragging = true;
			draggingLocation = getMouseLocation();
			mouseMove(sender, e);
		}

		private void mouseMove(object sender, MouseEventArgs e)
		{
			// Resize if dragging
			Size formSize = form.Size;
			Point formLocation = form.Location;
			Point mousePos = Control.MousePosition;
			if (isDragging)
			{
				switch (draggingLocation)
				{
					case ResizeLocation.Top:
						formSize.Height += formLocation.Y - mousePos.Y;
						formLocation.Y = mousePos.Y;
						break;
					case ResizeLocation.Bottom:
						formSize.Height = mousePos.Y - formLocation.Y;
						break;
					case ResizeLocation.Left:
						formSize.Width += formLocation.X - mousePos.X;
						formLocation.X = mousePos.X;
						break;
					case ResizeLocation.Right:
						formSize.Width = mousePos.X - formLocation.X;
						break;

					case ResizeLocation.TopLeft:
						formSize.Height += formLocation.Y - mousePos.Y;
						formLocation.Y = mousePos.Y;
						formSize.Width += formLocation.X - mousePos.X;
						formLocation.X = mousePos.X;
						break;
					case ResizeLocation.TopRight:
						formSize.Height += formLocation.Y - mousePos.Y;
						formLocation.Y = mousePos.Y;
						formSize.Width = mousePos.X - formLocation.X;
						break;
					case ResizeLocation.BottomLeft:
						formSize.Height = mousePos.Y - formLocation.Y;
						formSize.Width += formLocation.X - mousePos.X;
						formLocation.X = mousePos.X;
						break;
					case ResizeLocation.BottomRight:
						formSize.Height = mousePos.Y - formLocation.Y;
						formSize.Width = mousePos.X - formLocation.X;
						break;
					case ResizeLocation.Center:
						// Nothing
						break;
					default:
						// Same here
						break;
				}

				// Size must be inside bounds
				bool dontMoveX = false, dontMoveY = false;
				if (formSize.Height < minSize.Height)
				{
					formSize.Height = minSize.Height;
					dontMoveY = true;
				}
				if (formSize.Width < minSize.Width)
				{
					formSize.Width = minSize.Width;
					dontMoveX = true;
				}
				if (formSize.Height > maxSize.Height)
				{
					formSize.Height = maxSize.Height;
					dontMoveY = true;
				}
				if (formSize.Width > maxSize.Width)
				{
					formSize.Width = maxSize.Width;
					dontMoveX = true;
				}

				// Set new size and location
				if (!dontMoveX) form.Location = new Point(formLocation.X, form.Location.Y);
				if (!dontMoveY) form.Location = new Point(form.Location.X, formLocation.Y);
				form.Size = formSize;
			}
			// Else update cursor
			else
			{
				mouseEnter(sender, e);
			}
		}

		/// <summary>
		/// Gets mouse "ResizeLocation"
		/// </summary>
		/// <returns>The mouse "ResizeLocation"</returns>
		private ResizeLocation getMouseLocation()
		{
			Point mousePos = getRelativeMousePoint();
			ResizeLocation location;
			if (mousePos.X <= margin)
			{
				if (mousePos.Y <= margin)
					location = ResizeLocation.TopLeft;
				else if (mousePos.Y >= form.Height - margin)
					location = ResizeLocation.BottomLeft;
				else
					location = ResizeLocation.Left;
			}
			else if (mousePos.X >= form.Width - margin)
			{
				if (mousePos.Y <= margin)
					location = ResizeLocation.TopRight;
				else if (mousePos.Y >= form.Height - margin)
					location = ResizeLocation.BottomRight;
				else
					location = ResizeLocation.Right;
			}
			else
			{
				if (mousePos.Y <= margin)
					location = ResizeLocation.Top;
				else if (mousePos.Y >= form.Height - margin)
					location = ResizeLocation.Bottom;
				else
					location = ResizeLocation.Center;
			}
			return location;
		}
		
		/// <summary>
		/// Get mouse position relative to the form
		/// </summary>
		/// <returns>The mouse position relative to the form</returns>
		private Point getRelativeMousePoint()
		{
			return new Point(Control.MousePosition.X - form.Location.X, Control.MousePosition.Y - form.Location.Y);
		}
	}
}
