using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model.Entities.Base
{
    interface IBaseEntity
    {
        long Id { get; set; }
        DateTime CreatedOn { get; set; }
    }
    public class BaseEntity: IBaseEntity
    {
        [Column("UniqueId")]
        public long Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
