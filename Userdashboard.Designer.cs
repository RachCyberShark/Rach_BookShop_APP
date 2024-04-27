using System;

namespace APP_RachST20.componnet
{
    partial class Userdashboard
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
            this.subform = new System.Windows.Forms.Panel();
            this.btn_home = new System.Windows.Forms.Button();
            this.btn_task = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // subform
            // 
            this.subform.BackColor = System.Drawing.Color.White;
            this.subform.Location = new System.Drawing.Point(209, 24);
            this.subform.Name = "subform";
            this.subform.Size = new System.Drawing.Size(1044, 552);
            this.subform.TabIndex = 17;
            // 
            // btn_home
            // 
            this.btn_home.Location = new System.Drawing.Point(22, 97);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(146, 55);
            this.btn_home.TabIndex = 19;
            this.btn_home.Text = "Home";
            this.btn_home.UseVisualStyleBackColor = true;
            this.btn_home.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_task
            // 
            this.btn_task.Location = new System.Drawing.Point(22, 211);
            this.btn_task.Name = "btn_task";
            this.btn_task.Size = new System.Drawing.Size(146, 55);
            this.btn_task.TabIndex = 20;
            this.btn_task.Text = "Cetecory";
            this.btn_task.UseVisualStyleBackColor = true;
            this.btn_task.Click += new System.EventHandler(this.button3_Click);
            // 
            // Userdashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(1265, 605);
            this.Controls.Add(this.btn_task);
            this.Controls.Add(this.btn_home);
            this.Controls.Add(this.subform);
            this.Name = "Userdashboard";
            this.Text = "Userpf";
            this.Load += new System.EventHandler(this.Userdashboard_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel subform;
        private System.Windows.Forms.Button btn_home;
        private System.Windows.Forms.Button btn_task;

        public EventHandler Userpf_Load { get; set; }
    }
}