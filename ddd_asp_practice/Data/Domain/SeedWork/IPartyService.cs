using ddd_asp_practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Data.Domain.SeedWork {
    public interface IPartyService : IService<PartyViewModel> {
        Tuple<List<PersonPartyGoerViewModel>, List<FirmPartyGoerViewModel>> getAllPartyGoers(int partyId);
    }
}
