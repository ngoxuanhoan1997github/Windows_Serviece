using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.IO;
using System.Data.SqlClient;
using System.Net.Http;

namespace WindowsFormsApp_Test
{
    public partial class Form1 : Form
    {
        //System.Timers.Timer timer = new System.Timers.Timer();
        public const string ConnectionString = @"Data Source=192.168.24.103;Initial Catalog=DMDGL;User ID=sa;Password=261092";
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            //WriteToFile1("Ghi log lần 1");
        }

        public void btntest_Click(object sender, EventArgs e)
        {
            ////////////////////////////////////
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response =  client.GetAsync("https://www.google.com/");
                }
                catch (HttpRequestException ex)
                {
                }
                catch (Exception ex)
                {
                }
            }
            //////////////////////////////////

            string phut = dateTimePicker1.Value.Minute.ToString();
            string abc = dateTimePicker1.Value.ToString();
            string xyz = dateTimePicker2.Value.DayOfWeek.ToString();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConnectionString;
            conn.Open();
            string sqlinsert = "insert into Test(ID,Time,Date) values('" + phut + "','" + abc + "','" + xyz + "')";
            SqlCommand cmd = new SqlCommand(sqlinsert, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //public void WriteToFile1(string Message)
        //{
        //    string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }
        //    string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
        //    if (!File.Exists(filepath))
        //    {
        //        // Create a file to write to.   
        //        using (StreamWriter sw = File.CreateText(filepath))
        //        {
        //            sw.WriteLine(Message);
        //        }
        //    }
        //    else
        //    {
        //        using (StreamWriter sw = File.AppendText(filepath))
        //        {
        //            sw.WriteLine(Message);
        //        }
        //    }
        //}
    }
}
