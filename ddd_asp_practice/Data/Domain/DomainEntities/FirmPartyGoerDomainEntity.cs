using ddd_asp_practice.Data.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Data.Domain.DomainEntities {

    [Table("firm_party_goers")]
    public class FirmPartyGoerDomainEntity : DomainEntity {

        [Column("firm_number"), Required]
        public int firmNumber { get; private set; }

        [Column("firm_participants"), Required]
        public int firmParticipants { get; private set; }

        [Column("payment_type"), Required]
        public int paymentType { get; private set; }

        [Column("party_ref_id"), Required]
        public int partyRefId { get; private set; }

        [ForeignKey("partyRefId")]
        public virtual PartyDomainEntity party { get; set; }

        public FirmPartyGoerDomainEntity() { }

        public FirmPartyGoerDomainEntity(int _partyRefId, string _name, int _firmNumber, int _firmParticipants, int _paymentType, string _extraInfo = "", DateTime? _dateAdded = null) {
            partyRefId = _partyRefId;
            dateAdded = _dateAdded ?? DateTime.Now;
            setName(_name);
            setFirmNumber(_firmNumber);
            setFirmParticipants(_firmParticipants);
            setPaymentType(_paymentType);
            setExtraInfo(_extraInfo);
        }

        public void setName(string _name) => name = _name;
        public void setFirmNumber(int _firmNumber) => firmNumber = _firmNumber > 9999_9999_9 || _firmNumber < 1000_0000 ? throw new ArgumentException("Firm register number can contain only 8 numbers.") : _firmNumber;
        public void setFirmParticipants(int _firmParticipants) => firmParticipants = _firmParticipants < 1 ? throw new ArgumentException("Firm has to have at least one participant.") : _firmParticipants;
        public void setPaymentType(int _paymentType) => paymentType = _paymentType != 0 && _paymentType != 1 ? throw new ArgumentException("Please choose correct payment type.") : _paymentType; 
        public void setExtraInfo(string _extraInfo) {
            if (_extraInfo == null) { extraInfo = ""; return; }
            if (_extraInfo.Length > 5000) { throw new ArgumentException("Extra info may contain only 5000 characters."); }
            extraInfo = _extraInfo;
        }
    }
}
