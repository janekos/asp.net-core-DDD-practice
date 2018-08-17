using ddd_asp_practice.Data.Domain.DomainEntities;
using ddd_asp_practice.Data.Domain.SeedWork;
using ddd_asp_practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Data.API.Services {
    public class PersonPartyGoerService : IService<PersonPartyGoerViewModel> {
        private readonly IRepository<PersonPartyGoerDomainEntity> personPartyGoerRepo;

        public PersonPartyGoerService(IRepository<PersonPartyGoerDomainEntity> _personPartyGoerRepo) { personPartyGoerRepo = _personPartyGoerRepo; }

        public void add(PersonPartyGoerViewModel model) => personPartyGoerRepo.add(
            new PersonPartyGoerDomainEntity(
                model.partyRefId,
                model.name,
                model.surname,
                model.personalCode,
                model.paymentType,
                model.extraInfo)
            );

        public void update(PersonPartyGoerViewModel model) => personPartyGoerRepo.update((int)model.id,
            new PersonPartyGoerDomainEntity(
                model.partyRefId,
                model.name,
                model.surname,
                model.personalCode,
                model.paymentType,
                model.extraInfo)
            );

        public void delete(int id) => personPartyGoerRepo.delete(id);

        public IEnumerable<PersonPartyGoerViewModel> getAll() {
            List<PersonPartyGoerViewModel> parties = new List<PersonPartyGoerViewModel>();

            foreach (var entity in personPartyGoerRepo.getAll().Result) {
                parties.Add(new PersonPartyGoerViewModel {
                    id = entity.id,
                    partyRefId = entity.partyRefId,
                    name = entity.name,
                    surname = entity.surname,
                    personalCode = entity.personalCode,
                    paymentType = entity.paymentType,
                    extraInfo = entity.extraInfo,
                    deleted = entity.deleted
                });
            }

            return parties;
        }

        public PersonPartyGoerViewModel getById(int id) {

            var entity = personPartyGoerRepo.getById(id).Result;

            return new PersonPartyGoerViewModel {
                id = entity.id,
                partyRefId = entity.partyRefId,
                name = entity.name,
                surname = entity.surname,
                personalCode = entity.personalCode,
                paymentType = entity.paymentType,
                extraInfo = entity.extraInfo,
                deleted = entity.deleted
            };
        }
    }
}
