using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Topic6_Example
{
    [Serializable()]
    public class SerializedClass : Account, ISerializable
    {
        private string name;
        private string address;
        private string email;


        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }   

        public SerializedClass(string an, string p, int b,string name, string address, string email): base(an,p, b) 
        {
            this.Name = name;
            this.Address = address;
            this.Email = email;
        }

        public SerializedClass(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.Name = (string)info.GetValue("Name", typeof(string));
            this.Address = (string)info.GetValue("Address", typeof(string));
            this.Email = (string)info.GetValue("Email", typeof(string));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Name", this.Name);
            info.AddValue("Address", this.Address);
            info.AddValue("Email", this.Email);
        }


    }
}
