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
using System.Web.UI.WebControls;

namespace TestWorkMMD
{
    public partial class Form3 : Form
    {
        SqlConnection sqlConnection;
        public Form3()
        {
            
            InitializeComponent();
        }

        private async void Form3_Load(object sender, EventArgs e)
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

            sqlConnection.Close(); textBox1.Text = "asd";

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string triggerStolica = "";
            string triggerKod ="";
            string triggerStrana = "";
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[3].Value.ToString() != textBox1.Text)
                        {
                            triggerStolica = textBox1.Text;
                        }
                        else
                        {
                            triggerStolica = dataGridView1.Rows[i].Cells[3].Value.ToString();

                        }

                        if (dataGridView1.Rows[i].Cells[6].Value.ToString() != textBox1.Text)
                        {
                            triggerKod = textBox2.Text;
                        }
                        else
                        {
                            triggerKod = dataGridView1.Rows[i].Cells[6].Value.ToString();

                        }

                        if (dataGridView1.Rows[i].Cells[1].Value.ToString() != textBox1.Text)
                        {
                            triggerStrana = textBox3.Text;
                        }
                        else
                        {
                            triggerStrana = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        }
                    }

                }

                SqlCommand command4 = new SqlCommand("INSERT INTO [Cities] (Name) VALUES(@Name)", sqlConnection);
                command4.Parameters.AddWithValue("Name", triggerStolica);

                SqlCommand command5 = new SqlCommand("INSERT INTO [Region] (Name) VALUES(@Name)", sqlConnection);
                command4.Parameters.AddWithValue("Name", triggerKod);

                SqlCommand command6 = new SqlCommand("INSERT INTO [Countries] (Name) VALUES(@Name)", sqlConnection);
                command4.Parameters.AddWithValue("Name", triggerStrana);
            }
            else
            {
               // label7.Visible = true;

                //label7.Text = "Поля 'Имя' и 'Цена' должны быть заполнены!";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }    
}
