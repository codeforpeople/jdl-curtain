using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ResizeControl;

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
			thisLabel.BackColor = Color.FromArgb(145, 176, 196);
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
			// Make form resizable
			ResizableControl f = new ResizableControl();
			Control[] children = { topBar, topBarTitle, mainContainer };
			f.MakeControlResizable(this, 
								   10, 
								   children, 
								   ResizeLocation.Bottom | ResizeLocation.Right | ResizeLocation.BottomRight | ResizeLocation.TopLeft, 
								   new Size(300, 170), 
								   Screen.FromControl(this).Bounds.Size);
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
				curtainBtn.BackColor = Color.FromArgb(190, 190, 190);
				isCurtainDeployed = true;
			}
			else
			{
				curtainBtn.Text = "Deploy Awesome Curtain";
				curtainBtn.BackColor = Color.FromArgb(224, 224, 224);
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
					newCurtainForm.Bounds = selectedScreen.Bounds;
					//newCurtainForm.SetBounds(selectedScreen.Bounds.X, selectedScreen.Bounds.Y, selectedScreen.Bounds.Width / 2, selectedScreen.Bounds.Height / 2);
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

namespace ResizeControl
{
	public enum ResizeLocation
	{
		Top = 1,
		Bottom = 1 << 1,
		Left = 1 << 2,
		Right = 1 << 3,
		TopLeft = 1 << 4,
		TopRight = 1 << 5,
		BottomLeft = 1 << 6,
		BottomRight = 1 << 7,
		All = (1<<7) + (1<<6) + (1<<5) + (1<<4) + (1<<3) + (1<<2) + (1<<1) + 1,
		Center = 1 << 8
	}

	public class ResizableControl
	{
		private Control control;
		private int handleSize;
		private Size minSize;
		private Size maxSize;
		private ResizeLocation locations;
		private ResizeLocation draggingLocation;
		private Point bottomRightPos; // Absolute
		private bool isDragging;

		// Too lazy for any overloads
		/// <summary>
		/// Make a control form resizable
		/// </summary>
		/// <param name="form">The control you want to make resizable</param>
		/// <param name="handleSize">Margin size to drag the control</param>
		/// <param name="children">Children controls that respond to mouse events (that will be dragged)</param>
		/// <param name="locations">Which sides/corners can be dragged to resize the control</param>
		/// <param name="minSize">Minimum size</param>
		/// <param name="maxSize">Maximum size</param>
		public void MakeControlResizable(Control control, int handleSize, Control[] children, ResizeLocation resizeHandles, Size minSize, Size maxSize)
		{
			this.control = control;
			this.handleSize = handleSize;
			this.locations = resizeHandles;
			this.minSize = minSize;
			this.maxSize = maxSize;

			// Mouse events for children
			if (children != null)
				if (children.Length > 0)
					foreach (Control child in children)
					{
						child.MouseEnter += mouseEnter;
						child.MouseLeave += mouseLeave;
						child.MouseDown += mouseDown;
						child.MouseUp += mouseUp;
						child.MouseMove += mouseMove;
					}

			// Mouse events for the control itself
			control.MouseEnter += mouseEnter;
			control.MouseLeave += mouseLeave;
			control.MouseDown += mouseDown;
			control.MouseUp += mouseUp;
			control.MouseMove += mouseMove;
		}

		private void mouseEnter(object sender, EventArgs e)
		{
			// Get the control the mouse is over
			Control senderControl;
			try
			{
				senderControl = (Control)sender;
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
					senderControl.Cursor = Cursors.SizeNWSE;
				else if (location == ResizeLocation.TopRight || location == ResizeLocation.BottomLeft)
					senderControl.Cursor = Cursors.SizeNESW;
				else if (location == ResizeLocation.Top || location == ResizeLocation.Bottom)
					senderControl.Cursor = Cursors.SizeNS;
				else if (location == ResizeLocation.Left || location == ResizeLocation.Right)
					senderControl.Cursor = Cursors.SizeWE;
				else
					senderControl.Cursor = Cursors.Default;
			}
			else
			{
				senderControl.Cursor = Cursors.Default;
			}
		}

		private void mouseLeave(object sender, EventArgs e)
		{
			Control senderControl;
			try
			{
				senderControl = (Control)sender;
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
			draggingLocation = getMouseLocation();
			if (Convert.ToBoolean(draggingLocation & locations))
			{
				isDragging = true;
				bottomRightPos = control.PointToScreen(new Point(control.Size));
				mouseMove(sender, e);
			}
		}

		private void mouseMove(object sender, MouseEventArgs e)
		{
			Size controlSize = control.Size;
			// Absolute positions
			Point controlLocation = control.PointToScreen(Point.Empty);
			Point mousePos = Control.MousePosition;

			// Resize if dragging
			if (isDragging)
			{
				switch (draggingLocation)
				{
					case ResizeLocation.Top:
						controlSize.Height = bottomRightPos.Y - mousePos.Y;
						controlLocation.Y = mousePos.Y;
						break;
					case ResizeLocation.Bottom:
						controlSize.Height = mousePos.Y - controlLocation.Y;
						break;
					case ResizeLocation.Left:
						controlSize.Width = bottomRightPos.X - mousePos.X;
						controlLocation.X = mousePos.X;
						break;
					case ResizeLocation.Right:
						controlSize.Width = mousePos.X - controlLocation.X;
						break;

					case ResizeLocation.TopLeft:
						controlSize.Height = bottomRightPos.Y - mousePos.Y;
						controlLocation.Y = mousePos.Y;
						controlSize.Width = bottomRightPos.X - mousePos.X;
						controlLocation.X = mousePos.X;
						break;
					case ResizeLocation.TopRight:
						controlSize.Height = bottomRightPos.Y - mousePos.Y;
						controlLocation.Y = mousePos.Y;
						controlSize.Width = mousePos.X - controlLocation.X;
						break;
					case ResizeLocation.BottomLeft:
						controlSize.Height = mousePos.Y - controlLocation.Y;
						controlSize.Width = bottomRightPos.X - mousePos.X;
						controlLocation.X = mousePos.X;
						break;
					case ResizeLocation.BottomRight:
						controlSize.Height = mousePos.Y - controlLocation.Y;
						controlSize.Width = mousePos.X - controlLocation.X;
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
				if (controlSize.Height < minSize.Height)
				{
					controlSize.Height = minSize.Height;
					dontMoveY = true;
				}
				if (controlSize.Width < minSize.Width)
				{
					controlSize.Width = minSize.Width;
					dontMoveX = true;
				}
				if (controlSize.Height > maxSize.Height)
				{
					controlSize.Height = maxSize.Height;
					dontMoveY = true;
				}
				if (controlSize.Width > maxSize.Width)
				{
					controlSize.Width = maxSize.Width;
					dontMoveX = true;
				}

				// Set new size and location
				ResizeLocation special = ResizeLocation.Top | ResizeLocation.TopLeft | ResizeLocation.BottomLeft | ResizeLocation.TopRight | ResizeLocation.Left;
				if (Convert.ToBoolean(draggingLocation & special))
				{
					if (dontMoveX)
						controlLocation.X = bottomRightPos.X - controlSize.Width;
					if (dontMoveY)
						controlLocation.Y = bottomRightPos.Y - controlSize.Height;
				}

				// Make location relative
				Point relativeToControl = control.PointToClient(controlLocation);
				controlLocation = new Point(control.Location.X + relativeToControl.X, 
											control.Location.Y + relativeToControl.Y);

				// Set new bound
				control.SetBounds(controlLocation.X, controlLocation.Y, controlSize.Width, controlSize.Height);
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
			if (mousePos.X <= handleSize)
			{
				if (mousePos.Y <= handleSize)
					location = ResizeLocation.TopLeft;
				else if (mousePos.Y >= control.Height - handleSize)
					location = ResizeLocation.BottomLeft;
				else
					location = ResizeLocation.Left;
			}
			else if (mousePos.X >= control.Width - handleSize)
			{
				if (mousePos.Y <= handleSize)
					location = ResizeLocation.TopRight;
				else if (mousePos.Y >= control.Height - handleSize)
					location = ResizeLocation.BottomRight;
				else
					location = ResizeLocation.Right;
			}
			else
			{
				if (mousePos.Y <= handleSize)
					location = ResizeLocation.Top;
				else if (mousePos.Y >= control.Height - handleSize)
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
			return new Point(Control.MousePosition.X - control.PointToScreen(Point.Empty).X, 
							 Control.MousePosition.Y - control.PointToScreen(Point.Empty).Y);
		}
	}

}
