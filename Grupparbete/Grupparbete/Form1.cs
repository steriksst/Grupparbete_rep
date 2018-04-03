using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;


namespace Grupparbete
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection();

            connect.ConnectionString = "Data Source=LAPTOP-G3E2H49R\\SQL2017;Initial Catalog=grupp;Integrated Security=True";
            connect.Open();

            SqlCommand MyQuery = new SqlCommand("select * from accepted_2007_to_2017", connect);

            SqlDataReader MyReader = MyQuery.ExecuteReader();

            while (MyReader.Read())
            {  
                double loan_amount = Convert.ToDouble(MyReader["loan_amnt"]);
                double int_rate = Convert.ToDouble(MyReader["int_rate"]);
                string grade = MyReader["grade"].ToString();
                string loan_purpose = MyReader["loan_purpose"].ToString();
                double total_rec_int = Convert.ToDouble(MyReader["total_rec_int"]);
            }

            chart1.Titles.Add("Loan Purpose");
            chart1.ChartAreas[0].AxisX.Title = "";
            chart1.ChartAreas[0].AxisY.Title = "";
            chart1.Series["Series1"].ChartType = SeriesChartType.Column;

            chart2.Titles.Add("Average int_rate / loan purpose");
            chart2.ChartAreas[0].AxisX.Title = "";
            chart2.ChartAreas[0].AxisY.Title = "";
            chart2.Series["Series1"].ChartType = SeriesChartType.Point;
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
