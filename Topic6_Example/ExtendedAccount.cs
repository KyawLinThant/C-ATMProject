using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Topic6_Example
{
    [Serializable()]
    public class ExtendedAccount:Account , ISerializable   
    {
        private double interestrate;

        public double InterestRate;

        public ExtendedAccount(string a, string p, int b, double i):base(a, p, b)
        {
            this.InterestRate = i;
        }
        public ExtendedAccount(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.InterestRate = (double)info.GetValue("InterestRate", typeof(double));

        }

        public override void getInterest()
        {
            double interest = this.Balance * this.InterestRate;
            this.Balance =this.Balance+(int)interest;
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("InterestRate", this.InterestRate);
        }

        public override string queryType()
        {
            return "Extended";
        }
    }
}
