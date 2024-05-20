using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model.DatabaseViews
{
    public class ClientDetailsViewItem
    {
        public long ClientUniqueId { get; set; }

        public long? AddressUniqueId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ContactNumber { get; set; }

        public string? AddressDescription { get; set; }  
    }
}
