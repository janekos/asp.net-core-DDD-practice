using ddd_asp_practice.Data.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Data.Infrastructure
{
    public class PartyDBContext : DbContext {
        public PartyDBContext() : base("name=PartyDB") { Database.SetInitializer<PartyDBContext>(null); }

        public DbSet<PartyDomainEntity> parties { get; set; }
        public DbSet<FirmPartyGoerDomainEntity> firmPartyGoers { get; set; }
        public DbSet<PersonPartyGoerDomainEntity> personPartyGoers { get; set; }
    }
}
