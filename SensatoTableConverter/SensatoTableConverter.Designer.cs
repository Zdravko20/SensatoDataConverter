namespace TableConverter
{
    partial class SensatoTableConverter
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
            this.DropLocation = new System.Windows.Forms.Panel();
            this.SelectFramesButton = new System.Windows.Forms.Button();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DropLocation
            // 
            this.DropLocation.AllowDrop = true;
            this.DropLocation.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DropLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DropLocation.Location = new System.Drawing.Point(23, 38);
            this.DropLocation.Name = "DropLocation";
            this.DropLocation.Size = new System.Drawing.Size(387, 193);
            this.DropLocation.TabIndex = 0;
            this.DropLocation.DragDrop += new System.Windows.Forms.DragEventHandler(this.DropLocation_DragDrop);
            this.DropLocation.DragEnter += new System.Windows.Forms.DragEventHandler(this.DropLocation_DragEnter);
            this.DropLocation.Paint += new System.Windows.Forms.PaintEventHandler(this.DropLocation_Paint);
            // 
            // SelectFramesButton
            // 
            this.SelectFramesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectFramesButton.Location = new System.Drawing.Point(23, 248);
            this.SelectFramesButton.Name = "SelectFramesButton";
            this.SelectFramesButton.Size = new System.Drawing.Size(136, 37);
            this.SelectFramesButton.TabIndex = 0;
            this.SelectFramesButton.Text = "Select Frames\r\n";
            this.SelectFramesButton.UseVisualStyleBackColor = true;
            this.SelectFramesButton.Click += new System.EventHandler(this.SelectFramesButton_Click);
            // 
            // ConvertButton
            // 
            this.ConvertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConvertButton.Location = new System.Drawing.Point(274, 248);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(136, 37);
            this.ConvertButton.TabIndex = 1;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // SensatoTableConverter
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 302);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.SelectFramesButton);
            this.Controls.Add(this.DropLocation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 340);
            this.MinimumSize = new System.Drawing.Size(450, 340);
            this.Name = "SensatoTableConverter";
            this.Text = "Sensato Table Converter";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TableConverter_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DropLocation;
        private System.Windows.Forms.Button SelectFramesButton;
        private System.Windows.Forms.Button ConvertButton;
    }
}

