using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Web.DAL
{
    [DataContract]
    public class Student
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "firstname", EmitDefaultValue = false)]
        public string Firstname { get; set; }
        [DataMember(Name = "lastname", EmitDefaultValue = false)]
        public string Lastname { get; set; }
    }
}
