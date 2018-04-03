using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace stina_testar
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlConnection connect = new SqlConnection();

            connect.ConnectionString = "Data Source=LAPTOP-G3E2H49R\\SQL2017;Initial Catalog=grupp;Integrated Security=True";
            connect.Open();

            SqlCommand MyQuery = new SqlCommand("select * from accepted_2007_to_2017", connect);

            SqlDataReader MyReader = MyQuery.ExecuteReader();
            while (MyReader.Read())
                {
                // Behöver vi lägga till en check för null-värden, trots att alla columner i SQL är definerade not null?
                int id = (int)MyReader["id"];
                double loan_amount = Convert.ToDouble(MyReader["loan_amnt"]);
                double int_rate = Convert.ToDouble(MyReader["int_rate"]);
                string grade = MyReader["grade"].ToString();
                string loan_purpose = MyReader["loan_purpose"].ToString();
                double total_rec_int = Convert.ToDouble(MyReader["total_rec_int"]);

                // Test för att se att det fungerar
                Console.WriteLine(id);
                Console.WriteLine(loan_amount);
                Console.WriteLine(int_rate);
                Console.WriteLine(grade);
                Console.WriteLine(loan_purpose);
                Console.WriteLine(total_rec_int);
                Console.ReadLine();
                }
        }
    }
}
