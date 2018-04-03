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

            connect.ConnectionString = "Data Source=LAPTOP-4R563C6G\\SQL2017;Initial Catalog=grupp;Integrated Security=True";
            connect.Open();

            SqlCommand MyQuery = new SqlCommand("select * from accepted_2007_to_2017", connect);

            SqlDataReader MyReader = MyQuery.ExecuteReader();

            List<Loans> LoanList = new List<Loans>();

            double loan_amount;
            double int_rate;
            string grade;
            string loan_purpose;
            double total_rec_int;

            while (MyReader.Read())
            {  
                loan_amount = Convert.ToDouble(MyReader["loan_amnt"]);
                int_rate = Convert.ToDouble(MyReader["int_rate"]);
                grade = MyReader["grade"].ToString();
                loan_purpose = MyReader["loan_purpose"].ToString();
                total_rec_int = Convert.ToDouble(MyReader["total_rec_int"]);

                LoanList.Add(new Loans(
                    loan_amount,
                    int_rate,
                    grade,
                    loan_purpose,
                    total_rec_int
                    ));
            }

            chart1.Titles.Add("Loan Purpose");
            chart1.ChartAreas[0].AxisX.Title = "";
            chart1.ChartAreas[0].AxisY.Title = "";
            chart1.Series["Series1"].ChartType = SeriesChartType.Column;

            chart2.Titles.Add("Average int_rate / loan purpose");
            chart2.ChartAreas[0].AxisX.Title = "";
            chart2.ChartAreas[0].AxisY.Title = "";
            chart2.Series["Series1"].ChartType = SeriesChartType.Point; 

            foreach (Loans L in LoanList.Where(x => x.Loan_purpose == "Other"))
            {
                chart1.Series["Series1"].Points.AddY(L.Loan_purpose);
            }

            //Stina testar igen 
        }
    }
}
