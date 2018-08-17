using ddd_asp_practice.Data.Domain.DomainEntities;
using ddd_asp_practice.Data.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Data.Infrastructure.Repositories
{
    public class FirmPartyGoerRepository : IRepository<FirmPartyGoerDomainEntity> {
        private readonly PartyDBContext context;

        public FirmPartyGoerRepository(PartyDBContext _context) {
            context = _context ?? throw new ArgumentNullException(nameof(context));
        }

        public void add(FirmPartyGoerDomainEntity obj) {
            context.firmPartyGoers.Add(obj);
            context.SaveChanges();
        }

        public void delete(int id) {
            FirmPartyGoerDomainEntity entity = context.firmPartyGoers.FirstOrDefault(item => item.id == id) as FirmPartyGoerDomainEntity ?? throw new ArgumentNullException(id.ToString());
            entity.setDeleted();
            entity.setDateDeleted();
            context.SaveChanges();
        }

        public void update(int id, FirmPartyGoerDomainEntity obj) {
            FirmPartyGoerDomainEntity entity = context.firmPartyGoers.FirstOrDefault(item => item.id == id) as FirmPartyGoerDomainEntity ?? throw new ArgumentNullException(id.ToString());
            entity.setName(obj.name);
            entity.setFirmNumber(obj.firmNumber);
            entity.setFirmParticipants(obj.firmParticipants);
            entity.setPaymentType(obj.paymentType);
            entity.setExtraInfo(obj.extraInfo);
            context.SaveChanges();
        }

        public void purge(int id) {
            context.firmPartyGoers.Remove(context.firmPartyGoers.FirstOrDefault(item => item.id == id));
            context.SaveChanges();
        }

        public async Task<FirmPartyGoerDomainEntity> getById(int id) {
            return await context.firmPartyGoers.FindAsync(id) ?? throw new ArgumentNullException(id.ToString());
        }

        public async Task<IEnumerable<FirmPartyGoerDomainEntity>> getAll() {
            return await Task.FromResult<IEnumerable<FirmPartyGoerDomainEntity>>(context.firmPartyGoers);
        }
    }
}
