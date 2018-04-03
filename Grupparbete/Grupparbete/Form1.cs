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

            connect.ConnectionString = "Data Source=LENOVO-PC;Initial Catalog=grupp;Integrated Security=True";

            
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
                
                LoanList.Add(new Loans(loan_amount, int_rate, grade, loan_purpose, total_rec_int));

            }

            chart1.Titles.Add("Loan Purpose");
            chart1.ChartAreas[0].AxisX.Title = "Int_rate";
            chart1.ChartAreas[0].AxisY.Title = "Loan_amount";
            chart1.Series["Series1"].ChartType = SeriesChartType.Point;

            foreach (Loans loandata in LoanList)
            {
                chart1.Series["Series1"].Points.AddXY(loandata.Int_rate, loandata.Loan_amount);

            }

            chart2.Series["Series1"].ChartType = SeriesChartType.Pie;
            chart2.Series["Series1"].IsValueShownAsLabel = true;
            chart2.Series["Series1"].XValueMember = "Name";
            chart2.Series["Series1"].YValueMembers = "Count";
            chart2.Series["Series1"].Label = "#PERCENT";
            chart2.Series["Series1"].LegendText = "#AXISLABEL";
            chart2.Series["Series1"]["PieDrawingStyle"] = "Concave";

            List<string> lstLoanPurpose = new List<string>();
            List<double> lstLoanPurposePer = new List<double>();

            foreach (var line in  LoanList.GroupBy(x => x.Loan_purpose) 
                .Select(output => new { LoanPurpose = output.Key, Count = output.Count()})
                .OrderBy(x => x.Count))
            {

                //chart2.Series["Series1"].Points.AddY(line.Count);
    
                lstLoanPurpose.Add(line.LoanPurpose);
                lstLoanPurposePer.Add(line.Count);
            }
            chart2.Series["Series1"].Points.DataBindXY(lstLoanPurpose, lstLoanPurposePer);




        }
    }
}
