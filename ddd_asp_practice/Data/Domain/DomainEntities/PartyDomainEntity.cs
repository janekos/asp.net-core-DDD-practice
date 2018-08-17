using ddd_asp_practice.Data.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Data.Domain.DomainEntities {

    [Table("parties")]
    public class PartyDomainEntity : DomainEntity {

        [Column("date"), Required]
        public DateTime date { get; private set; }

        [Column("location"), Required]
        public string location { get; private set; }

        public virtual ICollection<FirmPartyGoerDomainEntity> firmPartyGoers { get; set; }
        public virtual ICollection<PersonPartyGoerDomainEntity> personPartyGoers { get; set; }

        public PartyDomainEntity() {}
        public PartyDomainEntity(string _name, DateTime _date, string _location, string _extraInfo = "", DateTime? _dateAdded = null, ICollection<FirmPartyGoerDomainEntity> _firmPartyGoers = null, ICollection<PersonPartyGoerDomainEntity> _personPartyGoers = null) {
            dateAdded = _dateAdded ?? DateTime.Now;
            firmPartyGoers = _firmPartyGoers;
            personPartyGoers = _personPartyGoers;
            setName(_name);
            setDate(_date);
            setLocation(_location);
            setExtraInfo(_extraInfo);
        }

        public void setName(string _name) => name = _name.Length > 100 ? throw new ArgumentException("Party name may conatain only 100 characters.") : _name;
        public void setDate(DateTime _date) => date = _date < DateTime.Now.AddMinutes(-1) ? throw new ArgumentException("Party has to happen in the future.") : _date;
        public void setLocation(string _location) => location = _location;
        public void setExtraInfo(string _extraInfo) {
            if (_extraInfo == null) { extraInfo = ""; return; }
            if (_extraInfo.Length > 1000) { throw new ArgumentException("Party extra ifno may contain maximum 1000 characters."); } 
            extraInfo = _extraInfo;
        }
    }
}
