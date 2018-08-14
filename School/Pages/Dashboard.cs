﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace School.Pages
{
    public partial class Dashboard : Form
    {
        public static Form ThisForm { get; set; }

        public Dashboard()
        {
            InitializeComponent();
            ThisForm = this;
            this.pctMain.Image = School.Properties.Resources.dashboard;
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            Login.ThisForm.Show();
        }

        private void QuationClick(object sender, EventArgs e)
        {
            this.Hide();
            new StuQuation().Show();
        }

        private void TicketClick(object sender, EventArgs e)
        {
            this.Hide();
            new StuTicket().Show();
        }

        private void UpdateProfile(object sender, EventArgs e)
        {
            this.txtEmail.Text = Login.LoginedUser.Email;
            this.txtName.Text = Login.LoginedUser.Name;
            this.txtPassword.Text = Login.LoginedUser.Password;
            this.txtSurname.Text = Login.LoginedUser.Surname;
            this.txtUsername.Text = Login.LoginedUser.Username;
            if (Login.LoginedUser.Gender)
            {
                this.ckbMale.Checked = true;
            }
            else
            {
                this.ckbFemale.Checked = true;
            }
            this.grpStuProfile.Visible = !this.grpStuProfile.Visible;
            this.grpInfo.Visible = !this.grpStuProfile.Visible;
            this.pnlAbout.Visible = false;
        }

        void cleaner()
        {
            this.txtName.Text = "";
            this.txtSurname.Text = "";
            this.txtUsername.Text = "";
            this.txtEmail.Text = "";
            this.txtPassword.Text = "";
            this.ckbMale.Checked = false;
            this.ckbFemale.Checked = false;
            this.lblName.Text = "";
            this.lblSurname.Text = "";
            this.lblUsername.Text = "";
            this.lblEmail.Text = "";
            this.lblPassword.Text = "";
            this.lblGender.Text = "";
        }

        bool isNotEmpty()
        {
            if (this.txtName.Text == "")
            {
                this.lblName.Text = "name is required !!!";
                this.ActiveControl = this.txtName;
                return false;
            }
            if (this.txtSurname.Text == "")
            {
                this.lblSurname.Text = "surname is required !!!";
                this.ActiveControl = this.txtSurname;
                return false;
            }
            if (this.txtUsername.Text == "")
            {
                this.lblUsername.Text = "username is required !!!";
                this.ActiveControl = this.txtUsername;
                return false;
            }
            if (this.txtEmail.Text == "")
            {
                this.lblEmail.Text = "email is required !!!";
                this.ActiveControl = this.txtEmail;
                return false;
            }
            if (this.txtPassword.Text == "")
            {
                this.lblPassword.Text = "password is required !!!";
                this.ActiveControl = this.txtPassword;
                return false;
            }
            if (!(this.ckbMale.Checked || this.ckbFemale.Checked))
            {
                this.lblGender.Text = "gender is required !!!";
                return false;
            }
            return true;
        }


        private void FormResize(object sender, EventArgs e)
        { 
            this.grpStuProfile.Left = ((this.Width - this.grpStuProfile.Width) / 2 - 8);
            this.grpInfo.Left = ((this.Width - this.grpInfo.Width) / 2 - 8);
            this.pnlAbout.Left = ((this.Width - this.pnlAbout.Width) / 2 - 8);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        { 
            this.grpStuProfile.Left = ((this.Width - this.grpStuProfile.Width) / 2 - 8);
            this.grpInfo.Left = ((this.Width - this.grpInfo.Width) / 2 - 8);
            this.grpInfo.Top = 50;
            this.pnlAbout.Left = ((this.Width - this.pnlAbout.Width) / 2 - 8);
            this.pnlAbout.Top = 100;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.grpStuProfile.Visible = false;
            this.grpInfo.Visible = false;
            this.pnlAbout.Visible = true;
        }
    }
}
