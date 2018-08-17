using System.Collections.Generic;
using System.Threading.Tasks;
using ddd_asp_practice.Data.Domain.DomainEntities;
using ddd_asp_practice.Data.Domain.SeedWork;
using ddd_asp_practice.Models;

namespace ddd_asp_practice.Data.API.Services {
    public class FirmPartyGoerService : IService<FirmPartyGoerViewModel> {
        private readonly IRepository<FirmPartyGoerDomainEntity> firmPartyGoerRepo;

        public FirmPartyGoerService(IRepository<FirmPartyGoerDomainEntity> _firmPartyGoerRepo) { firmPartyGoerRepo = _firmPartyGoerRepo; }

        public void add(FirmPartyGoerViewModel model) => firmPartyGoerRepo.add(
            new FirmPartyGoerDomainEntity(
                model.partyRefId, 
                model.name, 
                model.firmNumber, 
                model.firmParticipants, 
                model.paymentType, 
                model.extraInfo)
            );

        public void update(FirmPartyGoerViewModel model) => firmPartyGoerRepo.update((int)model.id, 
            new FirmPartyGoerDomainEntity(
                model.partyRefId, 
                model.name, 
                model.firmNumber, 
                model.firmParticipants, 
                model.paymentType, 
                model.extraInfo)
            );

        public void delete(int id) => firmPartyGoerRepo.delete(id);

        public IEnumerable<FirmPartyGoerViewModel> getAll() {
            List<FirmPartyGoerViewModel> parties = new List<FirmPartyGoerViewModel>();

            foreach (var entity in firmPartyGoerRepo.getAll().Result) {
                parties.Add(new FirmPartyGoerViewModel {
                    id = entity.id,
                    partyRefId = entity.partyRefId,
                    name = entity.name,
                    firmNumber = entity.firmNumber,
                    firmParticipants = entity.firmParticipants,
                    paymentType = entity.paymentType,
                    extraInfo = entity.extraInfo,
                    deleted = entity.deleted
                });
            }

            return parties;
        }

        public FirmPartyGoerViewModel getById(int id) {

            var entity = firmPartyGoerRepo.getById(id).Result;

            return new FirmPartyGoerViewModel {
                id = entity.id,
                partyRefId = entity.partyRefId,
                name = entity.name,
                firmNumber = entity.firmNumber,
                firmParticipants = entity.firmParticipants,
                paymentType = entity.paymentType,
                extraInfo = entity.extraInfo,
                deleted = entity.deleted
            };
        }
    }
}
