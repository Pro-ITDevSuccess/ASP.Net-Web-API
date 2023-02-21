using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entity
{
    public class Contacts : Entity
    {
        public virtual string Email { get; set; }
        public virtual string Number { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
