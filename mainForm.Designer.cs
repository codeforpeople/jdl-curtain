namespace JDL_Curtain
{
	partial class mainForm
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
			this.topBar = new System.Windows.Forms.Panel();
			this.topBarTitle = new System.Windows.Forms.Label();
			this.exitBtn = new System.Windows.Forms.Label();
			this.mainContainer = new System.Windows.Forms.Panel();
			this.fadeLegthInput = new System.Windows.Forms.NumericUpDown();
			this.fadeLengthLabel = new System.Windows.Forms.Label();
			this.fadeCheckBox = new System.Windows.Forms.CheckBox();
			this.timerBtn = new System.Windows.Forms.Label();
			this.curtainBtn = new System.Windows.Forms.Label();
			this.browseImageBtn = new System.Windows.Forms.Button();
			this.imageFileLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.displayComboBox = new System.Windows.Forms.ComboBox();
			this.openImageFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.topBar.SuspendLayout();
			this.mainContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fadeLegthInput)).BeginInit();
			this.SuspendLayout();
			// 
			// topBar
			// 
			this.topBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.topBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.topBar.Controls.Add(this.topBarTitle);
			this.topBar.Controls.Add(this.exitBtn);
			this.topBar.Location = new System.Drawing.Point(0, 0);
			this.topBar.Name = "topBar";
			this.topBar.Size = new System.Drawing.Size(400, 25);
			this.topBar.TabIndex = 0;
			this.topBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
			this.topBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseMove);
			this.topBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseUp);
			// 
			// topBarTitle
			// 
			this.topBarTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.topBarTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.topBarTitle.Location = new System.Drawing.Point(10, 0);
			this.topBarTitle.Name = "topBarTitle";
			this.topBarTitle.Size = new System.Drawing.Size(359, 25);
			this.topBarTitle.TabIndex = 1;
			this.topBarTitle.Text = "JDL Curtain";
			this.topBarTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.topBarTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
			this.topBarTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseMove);
			this.topBarTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseUp);
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
			// mainContainer
			// 
			this.mainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mainContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mainContainer.Controls.Add(this.fadeLegthInput);
			this.mainContainer.Controls.Add(this.fadeLengthLabel);
			this.mainContainer.Controls.Add(this.fadeCheckBox);
			this.mainContainer.Controls.Add(this.timerBtn);
			this.mainContainer.Controls.Add(this.curtainBtn);
			this.mainContainer.Controls.Add(this.browseImageBtn);
			this.mainContainer.Controls.Add(this.imageFileLabel);
			this.mainContainer.Controls.Add(this.label2);
			this.mainContainer.Controls.Add(this.label1);
			this.mainContainer.Controls.Add(this.displayComboBox);
			this.mainContainer.ForeColor = System.Drawing.SystemColors.ControlText;
			this.mainContainer.Location = new System.Drawing.Point(0, 24);
			this.mainContainer.Name = "mainContainer";
			this.mainContainer.Padding = new System.Windows.Forms.Padding(10);
			this.mainContainer.Size = new System.Drawing.Size(400, 276);
			this.mainContainer.TabIndex = 1;
			// 
			// fadeLegthInput
			// 
			this.fadeLegthInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.fadeLegthInput.Location = new System.Drawing.Point(312, 64);
			this.fadeLegthInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.fadeLegthInput.Name = "fadeLegthInput";
			this.fadeLegthInput.Size = new System.Drawing.Size(73, 20);
			this.fadeLegthInput.TabIndex = 7;
			this.fadeLegthInput.ThousandsSeparator = true;
			this.fadeLegthInput.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			// 
			// fadeLengthLabel
			// 
			this.fadeLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.fadeLengthLabel.AutoSize = true;
			this.fadeLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.fadeLengthLabel.Location = new System.Drawing.Point(201, 66);
			this.fadeLengthLabel.Name = "fadeLengthLabel";
			this.fadeLengthLabel.Size = new System.Drawing.Size(89, 15);
			this.fadeLengthLabel.TabIndex = 6;
			this.fadeLengthLabel.Text = "Length (in ms):";
			// 
			// fadeCheckBox
			// 
			this.fadeCheckBox.AutoSize = true;
			this.fadeCheckBox.Checked = true;
			this.fadeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.fadeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.fadeCheckBox.Location = new System.Drawing.Point(16, 65);
			this.fadeCheckBox.Name = "fadeCheckBox";
			this.fadeCheckBox.Size = new System.Drawing.Size(87, 19);
			this.fadeCheckBox.TabIndex = 5;
			this.fadeCheckBox.Text = "Fade Effect";
			this.fadeCheckBox.UseVisualStyleBackColor = true;
			this.fadeCheckBox.CheckStateChanged += new System.EventHandler(this.fadeCheckBox_CheckStateChanged);
			// 
			// timerBtn
			// 
			this.timerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.timerBtn.BackColor = System.Drawing.Color.Gainsboro;
			this.timerBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.timerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.timerBtn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.timerBtn.Location = new System.Drawing.Point(266, 225);
			this.timerBtn.Name = "timerBtn";
			this.timerBtn.Size = new System.Drawing.Size(119, 39);
			this.timerBtn.TabIndex = 4;
			this.timerBtn.Text = "Launch Timer";
			this.timerBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.timerBtn.Click += new System.EventHandler(this.timerBtn_Click);
			// 
			// curtainBtn
			// 
			this.curtainBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.curtainBtn.BackColor = System.Drawing.Color.Gainsboro;
			this.curtainBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.curtainBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.curtainBtn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.curtainBtn.Location = new System.Drawing.Point(13, 225);
			this.curtainBtn.Name = "curtainBtn";
			this.curtainBtn.Size = new System.Drawing.Size(119, 39);
			this.curtainBtn.TabIndex = 4;
			this.curtainBtn.Text = "Deploy Awesome Curtain";
			this.curtainBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.curtainBtn.Click += new System.EventHandler(this.curtainBtn_Click);
			// 
			// browseImageBtn
			// 
			this.browseImageBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseImageBtn.Location = new System.Drawing.Point(312, 35);
			this.browseImageBtn.Name = "browseImageBtn";
			this.browseImageBtn.Size = new System.Drawing.Size(75, 23);
			this.browseImageBtn.TabIndex = 3;
			this.browseImageBtn.Text = "Browse";
			this.browseImageBtn.UseVisualStyleBackColor = true;
			this.browseImageBtn.Click += new System.EventHandler(this.browseImageBtn_Click);
			// 
			// imageFileLabel
			// 
			this.imageFileLabel.AutoSize = true;
			this.imageFileLabel.Location = new System.Drawing.Point(115, 40);
			this.imageFileLabel.Name = "imageFileLabel";
			this.imageFileLabel.Size = new System.Drawing.Size(33, 13);
			this.imageFileLabel.TabIndex = 2;
			this.imageFileLabel.Text = "None";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(10, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Curtain image:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(10, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Display:";
			// 
			// displayComboBox
			// 
			this.displayComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.displayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.displayComboBox.FormattingEnabled = true;
			this.displayComboBox.Location = new System.Drawing.Point(75, 9);
			this.displayComboBox.Name = "displayComboBox";
			this.displayComboBox.Size = new System.Drawing.Size(312, 21);
			this.displayComboBox.TabIndex = 0;
			this.displayComboBox.SelectedIndexChanged += new System.EventHandler(this.displayComboBox_SelectedIndexChanged);
			// 
			// openImageFileDialog
			// 
			this.openImageFileDialog.Filter = "Image Files|*.png; *.jpg; *.bmp|All files|*.*";
			this.openImageFileDialog.Title = "Choose Image...";
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 300);
			this.Controls.Add(this.mainContainer);
			this.Controls.Add(this.topBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "mainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "JDL Curtain";
			this.Load += new System.EventHandler(this.mainForm_Load);
			this.topBar.ResumeLayout(false);
			this.mainContainer.ResumeLayout(false);
			this.mainContainer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.fadeLegthInput)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel topBar;
		private System.Windows.Forms.Panel mainContainer;
		private System.Windows.Forms.Label exitBtn;
		private System.Windows.Forms.Label topBarTitle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox displayComboBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label imageFileLabel;
		private System.Windows.Forms.Button browseImageBtn;
		private System.Windows.Forms.OpenFileDialog openImageFileDialog;
		private System.Windows.Forms.Label curtainBtn;
		private System.Windows.Forms.CheckBox fadeCheckBox;
		private System.Windows.Forms.Label fadeLengthLabel;
		private System.Windows.Forms.NumericUpDown fadeLegthInput;
		private System.Windows.Forms.Label timerBtn;
	}
}

