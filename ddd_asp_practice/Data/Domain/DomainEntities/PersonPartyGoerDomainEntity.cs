using ddd_asp_practice.Data.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Data.Domain.DomainEntities {

    [Table("person_party_goers")]
    public class PersonPartyGoerDomainEntity : DomainEntity {

        [Column("surname"), Required]
        public string surname { get; private set; }

        [Column("personal_code"), Required]
        public long personalCode { get; private set; }

        [Column("payment_type"), Required]
        public int paymentType { get; private set; }

        [Column("party_ref_id"), Required]
        public int partyRefId { get; private set; }

        [ForeignKey("partyRefId")]
        public virtual PartyDomainEntity party { get; set; }

        public PersonPartyGoerDomainEntity() { }

        public PersonPartyGoerDomainEntity(int _partyRefId, string _name, string _surname, long _personalCode, int _paymentType, string _extraInfo = "", DateTime? _dateAdded = null) {
            partyRefId = _partyRefId;
            dateAdded = _dateAdded ?? DateTime.Now;
            setName(_name);
            setSurname(_surname);
            setPersonalCode(_personalCode);
            setPaymentType(_paymentType);
            setExtraInfo(_extraInfo);
        }

        public void setName(string _name) => name = _name;
        public void setSurname(string _surname) => surname = _surname;
        public void setPersonalCode(long _personalCode) => personalCode = _personalCode > 9999_9999_999 || _personalCode < 1000_0000_000 ? throw new ArgumentException("Please insert correct personcal code.") : _personalCode;
        public void setPaymentType(int _paymentType) => paymentType = _paymentType != 0 && _paymentType != 1 ? throw new ArgumentException("Please insert correct payment type.") : _paymentType;
        public void setExtraInfo(string _extraInfo) {
            if (_extraInfo == null) { extraInfo = ""; return; }
            if (_extraInfo.Length > 1500) { throw new ArgumentException("Party extra info may contain maximum 1500 chracters."); }
            extraInfo = _extraInfo;
        }
    }
}
