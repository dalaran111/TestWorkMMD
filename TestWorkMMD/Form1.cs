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
using Microsoft.IdentityModel.Protocols.OpenIdConnect;


namespace TestWorkMMD
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dalar\source\repos\TestWorkMMD\TestWorkMMD\CountryDB.mdf;Integrated Security=True; MultipleActiveResultSets=True";

        public Form1()
        {
            InitializeComponent(); 
        }

        public List<Country> countriesGLOBAL;
        public ListBox.ObjectCollection collectionGLOBAL;
        private async void Form1_Load(object sender, EventArgs e)
        {            
            //Change this path for your own computer
            //string connectionString = @"Server=(localdb)\\mssqllocaldb;Database=testTaskDB;Trusted_Connection=True;MultipleActiveResultSets=true";

            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Countries]", sqlConnection);

            sqlReader = await command.ExecuteReaderAsync();



            // **************************************************************************************************************** Основной код
            List<Country> countries = await RESTCountriesAPI.GetAllCountriesAsync();
            ListBox.ObjectCollection collection = new ListBox.ObjectCollection(listBox1);
            textBox1.Focus();
            int i = 0;
             foreach (Country country in countries)
             {       
                    collection.Add(country);
                //listBox1.Items.Add(country);
                //listBox1.DisplayMember = "Name";   

                    SqlCommand command1 = new SqlCommand("INSERT INTO [Citiess] (Name) VALUES(@Name)", sqlConnection);
                    SqlCommand command2 = new SqlCommand("INSERT INTO [Regions] (Name) VALUES(@Name)", sqlConnection);
                    SqlCommand command3 = new SqlCommand("INSERT INTO [Countries] (Name, CountryCode, CapitalId, Area, Population, RegionId) VALUES(@Name, @CountryCode,@CapitalID, @Area, @Population, @RegionId)", sqlConnection);
                    SqlCommand command4 = new SqlCommand("SELECT Citiess.Name FROM [Countries] INNER JOIN [Citiess] ON Countries.CapitalId = Cities.Id)", sqlConnection);
                    SqlCommand command5 = new SqlCommand("INSERT INTO [Countries] (RegionId) VALUES (Countries.Id)", sqlConnection);
                command1.Parameters.AddWithValue("Name", country.Capital);
               command2.Parameters.AddWithValue("Name", country.Region);
                if (country.Name == null)
                {
                    country.Name = "NONE";
                    command3.Parameters.AddWithValue("Name", country.Name);
                }
                else
                {
                    command3.Parameters.AddWithValue("Name", country.Name);
                }

                    command3.Parameters.AddWithValue("CountryCode", country.Alpha2Code);
                    command3.Parameters.AddWithValue("CapitalId",i++ );
                    command3.Parameters.AddWithValue("Area", country.Area);
                    command3.Parameters.AddWithValue("Population", country.Population);
                    command3.Parameters.AddWithValue("RegionId", i++);

                //await command3.ExecuteNonQueryAsync();
                //await command4.ExecuteNonQueryAsync();
                //await command5.ExecuteNonQueryAsync();

                //await command5.ExecuteNonQueryAsync();
                //await command1.ExecuteNonQueryAsync();
                //await command2.ExecuteNonQueryAsync();


             } 
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed) sqlConnection.Close();
             CountOfCountriey = collection.Count;            
        }
         

        public string valueCountry;
        int CountOfCountriey;
        //public List<Country> countriesNEW = new List<Country>();   // Использовать для проверки элементов в листе   

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Очищаем список.
            listBox1.Items.Clear();        
            //CountOfCountriey = 250;
            label1.Text = listBox1.Items.Count.ToString();
            label1.Refresh();
            valueCountry = textBox1.Text;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                List<Country> countries = await RESTCountriesAPI.GetAllCountriesAsync();
                
                ListBox.ObjectCollection collection = new ListBox.ObjectCollection(listBox1);
                foreach (Country country in countries)
                {
                    label1.Text = collection.Count.ToString();
                    collection.Add(country);
                    //listBox1.DisplayMember = "Name";
                    label1.Text = collection.Count.ToString();
                }
            }
        }

        public int counter = 0;
        public string stran = "";
        private void button1_Click(object sender, EventArgs e)
        {
            TRYING();
        }


        //Осуществляется проверка на введенные данные и попытка найти заданную страну
        public async void TRYING()
        {
        RepeatFindCountry:
            if (CountOfCountriey == 250)
            {
                //List<Country> countries = await RESTCountriesAPI.GetAllCountriesAsync();
                //ListBox.ObjectCollection collection = new ListBox.ObjectCollection(listBox1);  
                try
                {
                    if (textBox1.Text != "")
                    {
                        //valueCountry = textBox1.Text;
                        listBox1.Items.Clear();
                        List<Country> countries = await RESTCountriesAPI.GetCountriesByNameContainsAsync(textBox1.Text);
                        ListBox.ObjectCollection collection = new ListBox.ObjectCollection(listBox1);

                        foreach (Country country in countries)
                        {
                            collection.Add(country);
                            //listBox1.DisplayMember = "Name";
                            label1.Text = collection.Count.ToString();

                            //Передача данных по стране
                            Strana.Text = country.Name; stran = Strana.Text;
                            KodStrani.Text = country.Alpha2Code;
                            Stolica.Text = country.Capital;

                            double plosh = (double)country.Area;
                            string newplosh = plosh.ToString("#,#", CultureInfo.InvariantCulture);
                            Ploshad.Text = String.Format(CultureInfo.InvariantCulture, "{0:#,#}", newplosh + " км. кв.");

                            int Nasel = (int)country.Population;
                            string newNasel = Nasel.ToString("#,#", CultureInfo.InvariantCulture);
                            Naselenie.Text = String.Format(CultureInfo.InvariantCulture, "{0:#,#}", newNasel + " человек");

                            RegionStrani.Text = country.Region;
                        }
                        listBox1.Items.Clear(); listBox1.Update();
                        foreach (Country country in countries)
                        {
                            label1.Text = (collection.Count).ToString();
                            listBox1.Items.Add(country);
                        }
                        listBox1.SetSelected(0, true);


                    }
                    else
                    {
                        //List<Country> countries = await RESTCountriesAPI.GetAllCountriesAsync();
                        //ListBox.ObjectCollection collection = new ListBox.ObjectCollection(listBox1);
                        //MessageBox.Show("Введите страну!", "Ошибка", MessageBoxButtons.OK);                                                
                    }
                }
                catch
                {
                    Strana.ResetText();
                    KodStrani.ResetText();
                    Stolica.ResetText();
                    Ploshad.ResetText();
                    Naselenie.ResetText();
                    RegionStrani.ResetText();

                    MessageBox.Show("Cтрана не найдена. Проверьте правильность введенных данных!", "Ошибка", MessageBoxButtons.OK);
                    textBox1.Clear();
                    goto RepeatFindCountry;
                }
            }
            //else CountOfCountriey = 251;
        }

        //Осуществляет вывод информации, при смене выбранной страны в ListBoxe-e
        private async void SelectedItem(object sender, EventArgs e)
        {
            label10.Text = listBox1.SelectedIndex.ToString();
            int index1 = Convert.ToInt32(label10.Text);

            List<Country> countries = await RESTCountriesAPI.GetAllCountriesAsync();
            ListBox.ObjectCollection collection = new ListBox.ObjectCollection(listBox1);


            foreach (Country country in countries)
            {
                label1.Text = collection.Count.ToString();
                collection.Add(country);
                //listBox1.DisplayMember = "Name";
                label1.Text = collection.Count.ToString();                 

                if (collection.IndexOf(country) == index1)
                {
                    Strana.Text = country.Name; stran = Strana.Text;
                    KodStrani.Text = country.Alpha2Code;
                    Stolica.Text = country.Capital;
                    try
                    {
                        double plosh = (double)country.Area;
                        string newplosh = plosh.ToString("#,#", CultureInfo.InvariantCulture);
                        Ploshad.Text = String.Format(CultureInfo.InvariantCulture, "{0:#,#}", newplosh + " км. кв.");
                    }
                    catch (Exception)
                    {
                        Ploshad.Text = String.Format(CultureInfo.InvariantCulture, "Площадь не известна!");                        
                    }
                    int Nasel = (int)country.Population;
                    string newNasel = Nasel.ToString("#,#", CultureInfo.InvariantCulture);
                    Naselenie.Text = String.Format(CultureInfo.InvariantCulture, "{0:#,#}", newNasel + " человек");

                    RegionStrani.Text = country.Region;
                }
            }
            listBox1.Items.Clear(); listBox1.Update(); 
            foreach (Country country in countries)
            {
                label1.Text = (collection.Count).ToString();
                listBox1.Items.Add(country);
            }
            listBox1.SetSelected(index1, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form ifrm = new Form2();
            ifrm.Owner = this;
            ifrm.Left = this.Left;
            ifrm.Top = this.Top;
            ifrm.Show();
            //this.Hide(); 
        }

    }

}
