using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Data.Domain.SeedWork
{
    public abstract class DomainEntity {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id"), Required]
        public int id { get; protected set; }

        [Column("name"), Required]
        public string name { get; protected set; }

        [Column("date_added")]
        public DateTime dateAdded { get; protected set; }

        [Column("date_deleted")]
        public DateTime? dateDeleted { get; protected set; }

        [Column("deleted")]
        public int deleted { get; protected set; }

        [Column("extra_info")]
        public string extraInfo { get; protected set; }

        public void setDateDeleted() => dateDeleted = DateTime.Now;
        public void setDeleted() => deleted = 1;
    }
}
