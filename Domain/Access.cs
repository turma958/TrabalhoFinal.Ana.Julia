using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit.UI.Domain
{
    public sealed class Access
    {
        public string User { get; set; }
        public DateTime AccessDateTime { get; set; }

        public Access(string user, DateTime access)
        {
            User = user;
            AccessDateTime = access;
        }

    }
}
