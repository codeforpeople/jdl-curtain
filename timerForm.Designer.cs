namespace JDL_Curtain
{
	partial class timerForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.mainContainer = new System.Windows.Forms.Panel();
			this.resetTimerBtn = new System.Windows.Forms.Button();
			this.stopTimerBtn = new System.Windows.Forms.Button();
			this.startTimerBtn = new System.Windows.Forms.Button();
			this.timeLabel = new System.Windows.Forms.Label();
			this.topBar = new System.Windows.Forms.Panel();
			this.exitBtn = new System.Windows.Forms.Label();
			this.topBarTitle = new System.Windows.Forms.Label();
			this.updateTimer = new System.Windows.Forms.Timer(this.components);
			this.mainContainer.SuspendLayout();
			this.topBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainContainer
			// 
			this.mainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mainContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mainContainer.Controls.Add(this.resetTimerBtn);
			this.mainContainer.Controls.Add(this.stopTimerBtn);
			this.mainContainer.Controls.Add(this.startTimerBtn);
			this.mainContainer.Controls.Add(this.timeLabel);
			this.mainContainer.ForeColor = System.Drawing.SystemColors.ControlText;
			this.mainContainer.Location = new System.Drawing.Point(0, 24);
			this.mainContainer.Name = "mainContainer";
			this.mainContainer.Padding = new System.Windows.Forms.Padding(10);
			this.mainContainer.Size = new System.Drawing.Size(400, 196);
			this.mainContainer.TabIndex = 3;
			// 
			// resetTimerBtn
			// 
			this.resetTimerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.resetTimerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.resetTimerBtn.Location = new System.Drawing.Point(275, 136);
			this.resetTimerBtn.Name = "resetTimerBtn";
			this.resetTimerBtn.Size = new System.Drawing.Size(100, 40);
			this.resetTimerBtn.TabIndex = 1;
			this.resetTimerBtn.Text = "Reset";
			this.resetTimerBtn.UseVisualStyleBackColor = true;
			this.resetTimerBtn.Click += new System.EventHandler(this.resetTimerBtn_Click);
			// 
			// stopTimerBtn
			// 
			this.stopTimerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.stopTimerBtn.Enabled = false;
			this.stopTimerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.stopTimerBtn.ForeColor = System.Drawing.Color.Maroon;
			this.stopTimerBtn.Location = new System.Drawing.Point(150, 136);
			this.stopTimerBtn.Name = "stopTimerBtn";
			this.stopTimerBtn.Size = new System.Drawing.Size(100, 40);
			this.stopTimerBtn.TabIndex = 1;
			this.stopTimerBtn.Text = "Stop";
			this.stopTimerBtn.UseVisualStyleBackColor = true;
			this.stopTimerBtn.Click += new System.EventHandler(this.stopTimerBtn_Click);
			// 
			// startTimerBtn
			// 
			this.startTimerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.startTimerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.startTimerBtn.ForeColor = System.Drawing.Color.DarkGreen;
			this.startTimerBtn.Location = new System.Drawing.Point(25, 136);
			this.startTimerBtn.Name = "startTimerBtn";
			this.startTimerBtn.Size = new System.Drawing.Size(100, 40);
			this.startTimerBtn.TabIndex = 1;
			this.startTimerBtn.Text = "Start";
			this.startTimerBtn.UseVisualStyleBackColor = true;
			this.startTimerBtn.Click += new System.EventHandler(this.startTimerBtn_Click);
			// 
			// timeLabel
			// 
			this.timeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.timeLabel.Font = new System.Drawing.Font("Courier New", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.timeLabel.Location = new System.Drawing.Point(10, 30);
			this.timeLabel.Name = "timeLabel";
			this.timeLabel.Size = new System.Drawing.Size(380, 76);
			this.timeLabel.TabIndex = 0;
			this.timeLabel.Text = "00:00";
			this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.timeLabel.DoubleClick += new System.EventHandler(this.timeLabel_DoubleClick);
			// 
			// topBar
			// 
			this.topBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.topBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.topBar.Controls.Add(this.exitBtn);
			this.topBar.Controls.Add(this.topBarTitle);
			this.topBar.Location = new System.Drawing.Point(0, 0);
			this.topBar.Name = "topBar";
			this.topBar.Size = new System.Drawing.Size(400, 25);
			this.topBar.TabIndex = 2;
			this.topBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
			this.topBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseMove);
			this.topBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseUp);
			// 
			// exitBtn
			// 
			this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.exitBtn.Location = new System.Drawing.Point(375, 0);
			this.exitBtn.Name = "exitBtn";
			this.exitBtn.Size = new System.Drawing.Size(25, 25);
			this.exitBtn.TabIndex = 0;
			this.exitBtn.Text = "X";
			this.exitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
			this.exitBtn.MouseEnter += new System.EventHandler(this.exitBtn_MouseEnter);
			this.exitBtn.MouseLeave += new System.EventHandler(this.exitBtn_MouseLeave);
			// 
			// topBarTitle
			// 
			this.topBarTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.topBarTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.topBarTitle.Location = new System.Drawing.Point(10, 0);
			this.topBarTitle.Name = "topBarTitle";
			this.topBarTitle.Size = new System.Drawing.Size(365, 25);
			this.topBarTitle.TabIndex = 1;
			this.topBarTitle.Text = "JDL Timer";
			this.topBarTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.topBarTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
			this.topBarTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseMove);
			this.topBarTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseUp);
			// 
			// updateTimer
			// 
			this.updateTimer.Interval = 30;
			this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
			// 
			// timerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 220);
			this.Controls.Add(this.mainContainer);
			this.Controls.Add(this.topBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "timerForm";
			this.Text = "Timer";
			this.Load += new System.EventHandler(this.timerForm_Load);
			this.mainContainer.ResumeLayout(false);
			this.topBar.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel mainContainer;
		private System.Windows.Forms.Panel topBar;
		private System.Windows.Forms.Label exitBtn;
		private System.Windows.Forms.Label topBarTitle;
		private System.Windows.Forms.Label timeLabel;
		private System.Windows.Forms.Button resetTimerBtn;
		private System.Windows.Forms.Button stopTimerBtn;
		private System.Windows.Forms.Button startTimerBtn;
		private System.Windows.Forms.Timer updateTimer;
	}
}