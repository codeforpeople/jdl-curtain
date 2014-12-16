namespace JDL_Curtain
{
	partial class curtainForm
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
			this.updateTimer = new System.Windows.Forms.Timer(this.components);
			this.imageBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
			this.SuspendLayout();
			// 
			// updateTimer
			// 
			this.updateTimer.Interval = 20;
			this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
			// 
			// imageBox
			// 
			this.imageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.imageBox.Location = new System.Drawing.Point(0, 0);
			this.imageBox.Name = "imageBox";
			this.imageBox.Size = new System.Drawing.Size(300, 300);
			this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imageBox.TabIndex = 0;
			this.imageBox.TabStop = false;
			this.imageBox.Click += new System.EventHandler(this.curtainForm_Click);
			// 
			// curtainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ClientSize = new System.Drawing.Size(300, 300);
			this.Controls.Add(this.imageBox);
			this.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "curtainForm";
			this.Opacity = 0D;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.curtainForm_FormClosed);
			this.Shown += new System.EventHandler(this.curtainForm_Shown);
			this.Click += new System.EventHandler(this.curtainForm_Click);
			((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer updateTimer;
		private System.Windows.Forms.PictureBox imageBox;
	}
}