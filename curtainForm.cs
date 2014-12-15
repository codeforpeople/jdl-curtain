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
	public partial class curtainForm : Form
	{
		// Used for fading the curtain in or out (from 0 to 1)
		double transparency = 0;
		bool showImage;
		// Fade effect length in miliseconds
		public int fadeLength = 1000;


		public curtainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Load the image
		/// </summary>
		/// <param name="path">Path to image file</param>
		/// <returns>true if succesfull, false if not.</returns>
		public bool setImageFromPath(string path)
		{
			try
			{
				imageBox.Image = Image.FromFile(path);
			}
			catch (System.IO.FileNotFoundException)
			{
				MessageBox.Show("Image not found. Please make sure the file exists.", "JDL Curtain", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			catch
			{
				MessageBox.Show("Invalid image file. Please select another image.", "JDL Curtain", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		private void curtainForm_Click(object sender, EventArgs e)
		{
			closeForm();
		}

		public void closeForm()
		{
			// Fade out
			showImage = false;
			effectTimer.Enabled = true;
		}

		private void curtainForm_Shown(object sender, EventArgs e)
		{
			// Fade in
			showImage = true;
			effectTimer.Enabled = true;
		}

		private void effectTimer_Tick(object sender, EventArgs e)
		{
			double step;
			if (fadeLength > 0)
			{
				step = effectTimer.Interval / (double)fadeLength;
			}
			else
			{
				step = 1;
			}
			// Calculate transparency
			if (showImage)
			{
				if (transparency < 1 - step)
				{
					transparency += step;
				}
				else
				{
					transparency = 1;
					effectTimer.Enabled = false;
				}
			}
			else
			{
				if (transparency > step)
				{
					transparency -= step;
				}
				else
				{
					transparency = 0;
					effectTimer.Enabled = false;
				}
			}
			// Set transparency
			this.Opacity = transparency;

			// Close form after fade out
			if (transparency == 0 && !showImage)
			{
				this.Close();
			}
		}

		private void curtainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Call updateCurtainState from main form
			mainForm form = (mainForm)Application.OpenForms["mainForm"];
			form.updateCurtainState();
		}

	}

}
