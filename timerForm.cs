﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ResizeControl;

namespace JDL_Curtain
{
	public partial class timerForm : Form
	{
		// Used for dragging the windows
		bool isDragging = false;
		int draggingX = 0;
		int draggingY = 0;

		// Whether to use miliseconds or not
		bool useMiliseconds = false;

		Stopwatch stopWatch = new Stopwatch();

		public timerForm()
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
			Label thisLabel = (Label)sender;
			thisLabel.BackColor = Color.Azure;
		}

		private void exitBtn_MouseLeave(object sender, EventArgs e)
		{
			Label thisLabel = (Label)sender;
			thisLabel.BackColor = topBar.BackColor;
		}

		private void exitBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void startTimerBtn_Click(object sender, EventArgs e)
		{
			stopWatch.Start();
			updateTimer.Enabled = true;

			startTimerBtn.Enabled = false;
			stopTimerBtn.Enabled = true;
		}

		private void stopTimerBtn_Click(object sender, EventArgs e)
		{
			stopWatch.Stop();
			updateTimeLabel();
			updateTimer.Enabled = false;

			startTimerBtn.Enabled = true;
			stopTimerBtn.Enabled = false;
		}

		private void resetTimerBtn_Click(object sender, EventArgs e)
		{
			stopWatch.Reset();
			updateTimeLabel();
			updateTimer.Enabled = false;

			startTimerBtn.Enabled = true;
			stopTimerBtn.Enabled = false;
		}

		private void updateTimer_Tick(object sender, EventArgs e)
		{
			updateTimeLabel();
		}

		private void timeLabel_DoubleClick(object sender, EventArgs e)
		{
			useMiliseconds = !useMiliseconds;
			updateTimeLabel();
		}

		private void timerForm_Load(object sender, EventArgs e)
		{
			ResizableControl f = new ResizableControl();
			Control[] children = { topBar, topBarTitle, mainContainer };
			f.MakeControlResizable(this, 10, children, ResizeLocation.Bottom | ResizeLocation.Right | ResizeLocation.BottomRight, this.Size, new Size(Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height));
		}

		private void updateTimeLabel()
		{
			if (useMiliseconds)
				timeLabel.Text = String.Format("{0:00}:{1:00}:{2:00}", stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds / 10);
			else
				timeLabel.Text = String.Format("{0:00}:{1:00}", stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds);
		}

	}
}
