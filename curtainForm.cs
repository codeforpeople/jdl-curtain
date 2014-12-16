using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace JDL_Curtain
{
	public partial class curtainForm : Form
	{
		// Whether to fade in or out
		bool showImage;
		// Fade effect length in miliseconds
		public int fadeLength = 1000;

		// Used if form is closed before the fade in animation finishes
		long elapsedMiliseconds = 0;

		// Avoids playing the fade out effect multiple times
		bool closing = false;

		Stopwatch stopWatch = new Stopwatch();

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
			if (!closing)
			{
				closing = true;
				showImage = false;
				elapsedMiliseconds = 0;
				if (stopWatch.IsRunning)
				{
					elapsedMiliseconds = fadeLength - stopWatch.ElapsedMilliseconds;
				}
				stopWatch.Restart();
				updateTimer.Enabled = true;
			}
		}

		private void curtainForm_Shown(object sender, EventArgs e)
		{
			// Fade in
			showImage = true;
			elapsedMiliseconds = 0;
			stopWatch.Restart();
			updateTimer.Enabled = true;
		}

		private void updateTimer_Tick(object sender, EventArgs e)
		{
			double transparency;

			// Calculate transparency
			if (showImage)
			{
				if (fadeLength <= 0)
					transparency = 1;
				else 
					transparency = (stopWatch.ElapsedMilliseconds + elapsedMiliseconds) / (double)fadeLength;

				if (transparency >= 1)
				{
					stopWatch.Stop();
					updateTimer.Enabled = false;
					transparency = 1;
				}
			}
			else
			{
				if (fadeLength <= 0)
					transparency = 0;
				else
					transparency = 1 - (stopWatch.ElapsedMilliseconds + elapsedMiliseconds) / (double)fadeLength;

				if (transparency <= 0)
				{
					stopWatch.Stop();
					updateTimer.Enabled = false;
					transparency = 0;
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
