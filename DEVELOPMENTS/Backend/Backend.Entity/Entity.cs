using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Backend.Entity
{
    public abstract class  Entity
    {
        public virtual Guid Id { get; set; }
    }
}
