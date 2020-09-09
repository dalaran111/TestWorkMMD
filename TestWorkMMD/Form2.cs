using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RESTCountries.Constants;
using RESTCountries.Models;
using RESTCountries.Services;
using RestSharp;
using RestSharp.Extensions;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppREstCountries.Helpers;
using System.CodeDom;
using System.Globalization;
using System.Collections.Specialized;
using System.Reflection;
using System.Net.Mail;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace TestWorkMMD
{
    public partial class Form2 : Form
    {
        SqlConnection sqlConnection;
        public Form2()
        {
            InitializeComponent();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dalar\source\repos\TestWorkMMD\TestWorkMMD\CountryDB.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command2 = new SqlCommand("SELECT * FROM [Countries]", sqlConnection);

            sqlReader = await command2.ExecuteReaderAsync();



            List<string[]> data = new List<string[]>();


            while (sqlReader.Read())
            {
                data.Add(new string[7]);

                data[data.Count - 1][0] = sqlReader[0].ToString();
                data[data.Count - 1][1] = sqlReader[1].ToString();
                data[data.Count - 1][2] = sqlReader[2].ToString();
                data[data.Count - 1][3] = sqlReader[3].ToString();
                data[data.Count - 1][4] = sqlReader[4].ToString();
                data[data.Count - 1][5] = sqlReader[5].ToString();
                data[data.Count - 1][6] = sqlReader[6].ToString();
            }

            sqlReader.Close();

            sqlConnection.Close(); textBox1.Text = "Страна"; 

            foreach (string[] s in data)
            {
                try
                {
                    dataGridView1.Rows.Add(s);
                }
                catch (Exception)
                {

                    throw;
                }
                
            }                   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int trigger = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[1].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true; trigger = i;
                            break;
                        }
                        
                    }
            }
            if (dataGridView1.Rows[trigger].Selected == false)
            {                
                DialogResult dialogResult = MessageBox.Show("Страна не найдена! Добавить страну в базу данных?", "Ошибка", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Form ifrm = new Form3();
                    ifrm.Owner = this;
                    ifrm.Left = this.Left + 700; // задаём открываемой форме позицию слева равную позиции текущей формы
                    ifrm.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
                    ifrm.Show(); // отображаем Form2
                    this.Hide(); // скрываем Form2 (this - текущая форма)
                }
                else if (dialogResult == DialogResult.No)
                {
                    
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form ifrm = new Form1();
            ifrm.Owner = this;
            ifrm.Left = this.Left; 
            ifrm.Top = this.Top;
            ifrm.Show();
            this.Close();
            
        }
    }
}

