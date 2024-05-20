using Client.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model.Entities
{
    [Table("Client")]
    public class ClientEntity: BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string ContactNumber { get;set; } = string.Empty;
        public Gender Gender { get; set; }

    }

    public enum Gender
    {
        Male = 1,
        Female
    }
}
