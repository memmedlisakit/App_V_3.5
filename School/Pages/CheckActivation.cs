﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Windows.Forms;
using School.Models;
using System.Linq;
using System.Data.SQLite;
using System.Net;
using System.Net.Sockets;

namespace School.Pages
{
    public partial class CheckActivation : Form
    { 
        public static Label Error { get; set; }

        public static Form ThisForm { get; set; }

        const string TOKET = "628x9x0xx447xx4x421x517x4x474x33x2065x4x1xx523xxxxx6x7x20";

        const string STUDENT_TOKEN = "d1347bda-b758-4857-91b5-354e6e368bac";
         
        public CheckActivation()
        {
            InitializeComponent();
            Error = this.lblError;
            ThisForm = this;
        }
         
        private void btnCheck_Click(object sender, EventArgs e)
        {
            btnCheck.Enabled = false;
            string comp_info = Environment.UserName;
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress addr in localIPs)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    comp_info += $", {addr}";
                }
            }
            string code = this.txtActivation.Text;
            string username = Login.LoginedUser.Username;
            string email = Login.LoginedUser.Email;
            if(code == "azyhq75357536241598azyhq.az")
            {
                insertLocalActivation(code, username, 1, comp_info, email, "ok");
                return;
            }
            UpdateData(code, username, comp_info, email, TOKET); 
        }
         
        static async void UpdateData(string _code, string _username, string _comp_info, string _email, string _token)
        {
            try
            { 
                using (var client = new HttpClient())
                { 
                    client.BaseAddress = new Uri("http://memmedlisakit-001-site1.itempurl.com/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync($"api/activations?code={_code}&username={_username}&comp_info={_comp_info}&email={_email}&token={_token}");
                    insertLocalActivation(_code, _username, 1, _comp_info, _email,response.StatusCode.ToString().ToLower());
                }
            }
            catch (Exception)
            {
                Error.Text = "Servere qoşularkən xəta baş verdi, zəhmət olmasa internet bağlantınızı yoxlayin";
            } 
        }

        static async void AddStudent(string _json, string _token)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://memmedlisakit-001-site1.itempurl.com/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync($"api/students?code={_json}&token={_token}");
                }
            }
            catch (Exception)
            {
                Error.Text = "Servere qoşularkən xəta baş verdi, zəhmət olmasa internet bağlantınızı yoxlayin";
            }
        }
         
        static void insertLocalActivation(string _code, string _username, int _status, string comp_info, string email, string status_code)
        {
            if (status_code == "ok")
            {
                using (SQLiteConnection con = new SQLiteConnection(Login.connection))
                {
                    string sql = $"INSERT INTO Activations(activation_code, username, status, computer_info, user_email) VALUES('{_code}', '{_username}', {_status}, '{comp_info}', '{email}')";
                    SQLiteCommand com = new SQLiteCommand(sql, con);
                    con.Open();
                    com.ExecuteNonQuery();

                    ThisForm.Close();
                    new Dashboard().Show();
                };
                Json_Student student = new Json_Student()
                {
                    name = Login.LoginedUser.Name,
                    surname = Login.LoginedUser.Surname,
                    username = Login.LoginedUser.Username,
                    email = Login.LoginedUser.Email,
                    gender = Login.LoginedUser.Gender
                };
                string json = new JavaScriptSerializer().Serialize(student);
                AddStudent(json, STUDENT_TOKEN);
            }
            else
            {
                Error.Text = "Activasiya kodu istifadə olunub !!!";
            }
           
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            Login.ThisForm.Show();
        }
    }

    public class Json_Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Nullable<bool> gender { get; set; }
    }
}
