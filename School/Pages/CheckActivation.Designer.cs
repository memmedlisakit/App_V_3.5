﻿namespace School.Pages
{
    partial class CheckActivation
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtActivation = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(123, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Activasiya kodu:";
            // 
            // txtActivation
            // 
            this.txtActivation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActivation.Location = new System.Drawing.Point(126, 112);
            this.txtActivation.Multiline = true;
            this.txtActivation.Name = "txtActivation";
            this.txtActivation.Size = new System.Drawing.Size(200, 30);
            this.txtActivation.TabIndex = 5;
            // 
            // btnCheck
            // 
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnCheck.Location = new System.Drawing.Point(126, 178);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(200, 30);
            this.btnCheck.TabIndex = 7;
            this.btnCheck.Text = "Activasiyanı Yoxla";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Yi Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(123, 224);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 16);
            this.lblError.TabIndex = 9;
            // 
            // CheckActivation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 316);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtActivation);
            this.Name = "CheckActivation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yoxlama";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtActivation;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label lblError;
    }
}