using ddd_asp_practice.Data.Domain.DomainEntities;
using ddd_asp_practice.Data.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Data.Infrastructure.Repositories
{
    public class PersonPartyGoerRepository : IRepository<PersonPartyGoerDomainEntity> {
        private readonly PartyDBContext context;

        public PersonPartyGoerRepository(PartyDBContext _context) {
            context = _context ?? throw new ArgumentNullException(nameof(context));
        }

        public void add(PersonPartyGoerDomainEntity obj) {
            context.personPartyGoers.Add(obj);
            context.SaveChanges();
        }

        public void delete(int id) {
            PersonPartyGoerDomainEntity entity = context.personPartyGoers.FirstOrDefault(item => item.id == id) as PersonPartyGoerDomainEntity ?? throw new ArgumentNullException(id.ToString());
            entity.setDeleted();
            entity.setDateDeleted();
            context.SaveChanges();
        }

        public void update(int id, PersonPartyGoerDomainEntity obj) {
            PersonPartyGoerDomainEntity entity = context.personPartyGoers.FirstOrDefault(item => item.id == id) as PersonPartyGoerDomainEntity ?? throw new ArgumentNullException(id.ToString());
            entity.setName(obj.name);
            entity.setSurname(obj.surname);
            entity.setPersonalCode(obj.personalCode);
            entity.setPaymentType(obj.paymentType);
            entity.setExtraInfo(obj.extraInfo);
            context.SaveChanges();
        }

        public void purge(int id) {
            context.personPartyGoers.Remove(context.personPartyGoers.FirstOrDefault(item => item.id == id));
            context.SaveChanges();
        }

        public async Task<PersonPartyGoerDomainEntity> getById(int id) {
            return await context.personPartyGoers.FindAsync(id) ?? throw new ArgumentNullException(id.ToString());
        }

        public async Task<IEnumerable<PersonPartyGoerDomainEntity>> getAll() {
            return await Task.FromResult<IEnumerable<PersonPartyGoerDomainEntity>>(context.personPartyGoers);
        }
    }
}
