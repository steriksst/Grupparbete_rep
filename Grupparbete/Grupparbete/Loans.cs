using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete
{
    class Loans
    {
        double loan_amount;
        double int_rate;
        string grade;
        string loan_purpose;
        double total_rec_int;

        public Loans(double loan_amount, double int_rate, string grade, string loan_purpose,double total_rec_int)
        {
            this.loan_amount = loan_amount;
            this.int_rate = int_rate;
            this.grade = grade;
            this.loan_purpose = loan_purpose;
            this.total_rec_int = total_rec_int;
        }

        public double Loan_amount { get => loan_amount; set => loan_amount = value; }
        public double Int_rate { get => int_rate; set => int_rate = value; }
        public string Grade { get => grade; set => grade = value; }
        public string Loan_purpose { get => loan_purpose; set => loan_purpose = value; }
        public double Total_rec_int { get => total_rec_int; set => total_rec_int = value; }
    }
}
