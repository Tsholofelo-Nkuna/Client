using Client.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model.Entities
{
    [Table("Address")]
    public class AddressEntity: BaseEntity
    {
        public string Description { get; set; } = string.Empty;

        public long ClientUniqueId { get; set; }
    }
}
