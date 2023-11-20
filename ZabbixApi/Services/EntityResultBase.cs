using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixClient.Services
{
    public abstract class EntityResultBase
    {
        public virtual string[] ids { get; set; }
    }
}
