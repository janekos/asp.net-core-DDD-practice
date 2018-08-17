using ddd_asp_practice.Data.Domain.DomainEntities;
using ddd_asp_practice.Data.Domain.SeedWork;
using ddd_asp_practice.Data.Infrastructure.Repositories;
using ddd_asp_practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Data.API.Services {
    public class PartyService : IPartyService{

        private readonly IRepository<PartyDomainEntity> partyRepo;

        public PartyService(IRepository<PartyDomainEntity> _partyRepo) { partyRepo = _partyRepo; }

        public void add(PartyViewModel model) => partyRepo.add(new PartyDomainEntity(model.name, model.date, model.location, model.extraInfo));
        public void update(PartyViewModel model) => partyRepo.update((int) model.id, new PartyDomainEntity(model.name, model.date, model.location, model.extraInfo));
        public void delete(int partyId) => partyRepo.delete(partyId);

        public IEnumerable<PartyViewModel> getAll() {
            List<PartyViewModel> parties = new List<PartyViewModel>();

            foreach (var entity in partyRepo.getAll().Result) {
                parties.Add(new PartyViewModel {
                    id = entity.id,
                    name = entity.name,
                    date = entity.date,
                    location = entity.location,
                    extraInfo = entity.extraInfo,
                    participants = getFullPartyGoersCount(entity.id),
                    deleted = entity.deleted
                });
            }

            return parties;
        }

        public PartyViewModel getById(int partyId) {

            var entity = partyRepo.getById(partyId).Result;

            return new PartyViewModel {
                id = entity.id,
                name = entity.name,
                date = entity.date,
                location = entity.location,
                extraInfo = entity.extraInfo,
                participants = getFullPartyGoersCount(entity.id)
            };
        }

        public int getFullPartyGoersCount(int partyId) {
            return partyRepo
                    .getById(partyId).Result
                    .firmPartyGoers
                    .Where(item => item.deleted == 0)
                    .Sum(item => item.firmParticipants) +
                    partyRepo
                    .getById(partyId).Result
                    .personPartyGoers
                    .Where(item => item.deleted == 0)
                    .Count();
        }

        public Tuple<List<PersonPartyGoerViewModel>, List<FirmPartyGoerViewModel>> getAllPartyGoers(int partyId) {
            var party = partyRepo.getById(partyId).Result;
            var partyGoers = new Tuple<List<PersonPartyGoerViewModel>, List<FirmPartyGoerViewModel>> (
                new List<PersonPartyGoerViewModel>(),
                new List<FirmPartyGoerViewModel>()
            );

            foreach (var personPartyGoer in party.personPartyGoers) {
                partyGoers.Item1.Add(new PersonPartyGoerViewModel {
                    partyRefId = party.id,
                    id = personPartyGoer.id,
                    name = personPartyGoer.name,
                    surname = personPartyGoer.surname,
                    personalCode = personPartyGoer.personalCode,
                    paymentType = personPartyGoer.paymentType,
                    extraInfo = personPartyGoer.extraInfo,
                    deleted = personPartyGoer.deleted
                });
            }

            foreach (var firmPartyGoer in party.firmPartyGoers) {
                partyGoers.Item2.Add(new FirmPartyGoerViewModel {
                    partyRefId = party.id,
                    id = firmPartyGoer.id,
                    name = firmPartyGoer.name,
                    firmNumber = firmPartyGoer.firmNumber,
                    firmParticipants = firmPartyGoer.firmParticipants,
                    paymentType = firmPartyGoer.paymentType,
                    extraInfo = firmPartyGoer.extraInfo,
                    deleted = firmPartyGoer.deleted
                });
            }

            return partyGoers;
        }
    }
}
