namespace EDM.PlugInUI
{
    partial class MainForm
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
            this.btnSyncWith3D = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSyncWith3D
            // 
            this.btnSyncWith3D.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSyncWith3D.Location = new System.Drawing.Point(167, 12);
            this.btnSyncWith3D.Name = "btnSyncWith3D";
            this.btnSyncWith3D.Size = new System.Drawing.Size(167, 150);
            this.btnSyncWith3D.TabIndex = 0;
            this.btnSyncWith3D.Text = "&Sync With 3D";
            this.btnSyncWith3D.UseVisualStyleBackColor = true;
            this.btnSyncWith3D.Click += new System.EventHandler(this.btnSyncWith3D_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EDM.PlugInUI.Properties.Resources.isel;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 150);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 173);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSyncWith3D);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = ".: ISEL - EDM Sync With 3D :.";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSyncWith3D;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

