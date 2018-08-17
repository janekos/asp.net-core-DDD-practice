using ddd_asp_practice.Data.Domain.DomainEntities;
using ddd_asp_practice.Data.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Data.Infrastructure.Repositories
{
    public class PartyRepository : IRepository<PartyDomainEntity> {

        private readonly PartyDBContext context;

        public PartyRepository(PartyDBContext _context) {
            context = _context ?? throw new ArgumentNullException(nameof(context));
        }

        public void add(PartyDomainEntity obj) {
            context.parties.Add(obj);
            context.SaveChanges();
        }

        public void delete(int id) {
            PartyDomainEntity entity = context.parties.FirstOrDefault(item => item.id == id) as PartyDomainEntity ?? throw new ArgumentNullException(id.ToString());
            entity.setDeleted();
            entity.setDateDeleted();

            foreach (var subEntity in entity.firmPartyGoers) {
                subEntity.setDateDeleted();
                subEntity.setDeleted();
            }

            foreach (var subEntity in entity.personPartyGoers) {
                subEntity.setDateDeleted();
                subEntity.setDeleted();
            }

            context.SaveChanges();
        }

        public void purge(int id) {
            var entity = context.parties.FirstOrDefault(item => item.id == id);

            foreach (var subEntity in entity.firmPartyGoers) { context.firmPartyGoers.Remove(subEntity); }
            foreach (var subEntity in entity.personPartyGoers) { context.personPartyGoers.Remove(subEntity); }
            context.parties.Remove(entity);

            context.SaveChanges();
        }

        public void update(int id, PartyDomainEntity obj) {
            PartyDomainEntity entity = context.parties.FirstOrDefault(item => item.id == id) as PartyDomainEntity ?? throw new ArgumentNullException(id.ToString());
            entity.setName(obj.name);
            entity.setDate(obj.date);
            entity.setLocation(obj.location);
            entity.setExtraInfo(obj.extraInfo);
            context.SaveChanges();
        }

        public async Task<PartyDomainEntity> getById(int id) {
            return await context.parties.FindAsync(id) ?? throw new ArgumentNullException(id.ToString()); 
        }

        public async Task<IEnumerable<PartyDomainEntity>> getAll() {
            return await Task.FromResult<IEnumerable<PartyDomainEntity>>(context.parties);
        }
    }
}
