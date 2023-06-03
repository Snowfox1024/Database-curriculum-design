namespace BookStore
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.panel4 = new System.Windows.Forms.Panel();
            this.Backlb = new System.Windows.Forms.Label();
            this.Shut = new System.Windows.Forms.Button();
            this.btCheck = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.log = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.GhostWhite;
            this.panel4.Controls.Add(this.Backlb);
            this.panel4.Controls.Add(this.Shut);
            this.panel4.Controls.Add(this.btCheck);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.tbPassword);
            this.panel4.Controls.Add(this.log);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Location = new System.Drawing.Point(15, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(781, 471);
            this.panel4.TabIndex = 3;
            // 
            // Backlb
            // 
            this.Backlb.AutoSize = true;
            this.Backlb.Font = new System.Drawing.Font("微软雅黑", 10.71429F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Backlb.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Backlb.Location = new System.Drawing.Point(357, 377);
            this.Backlb.Name = "Backlb";
            this.Backlb.Size = new System.Drawing.Size(67, 35);
            this.Backlb.TabIndex = 11;
            this.Backlb.Text = "返回";
            this.Backlb.Click += new System.EventHandler(this.Backlb_Click);
            // 
            // Shut
            // 
            this.Shut.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Shut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Shut.Font = new System.Drawing.Font("微软雅黑", 10.71429F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Shut.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Shut.Location = new System.Drawing.Point(719, 15);
            this.Shut.Name = "Shut";
            this.Shut.Size = new System.Drawing.Size(38, 42);
            this.Shut.TabIndex = 10;
            this.Shut.Text = "X";
            this.Shut.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Shut.UseVisualStyleBackColor = false;
            this.Shut.Click += new System.EventHandler(this.Shut_Click);
            // 
            // btCheck
            // 
            this.btCheck.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCheck.Font = new System.Drawing.Font("微软雅黑", 10.71429F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCheck.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btCheck.Location = new System.Drawing.Point(327, 283);
            this.btCheck.Name = "btCheck";
            this.btCheck.Size = new System.Drawing.Size(130, 46);
            this.btCheck.TabIndex = 8;
            this.btCheck.Text = "确认";
            this.btCheck.UseVisualStyleBackColor = false;
            this.btCheck.Click += new System.EventHandler(this.btCheck_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.71429F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(144, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 35);
            this.label2.TabIndex = 7;
            this.label2.Text = "密码";
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPassword.Location = new System.Drawing.Point(260, 199);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(280, 39);
            this.tbPassword.TabIndex = 5;
            // 
            // log
            // 
            this.log.AutoSize = true;
            this.log.Font = new System.Drawing.Font("幼圆", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.log.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.log.Location = new System.Drawing.Point(308, 129);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(185, 34);
            this.log.TabIndex = 3;
            this.log.Text = "管理员登录";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(363, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(811, 495);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button Shut;
        private System.Windows.Forms.Button btCheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label log;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Backlb;
    }
}