using ddd_asp_practice.Data.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Models {
    public class FirmPartyGoerViewModel : IViewModel {

        public int? id { get; set; }

        public int partyRefId { get; set; }

        [Required(ErrorMessage = "Firm name is required.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Firm register number is required.")]
        public int firmNumber { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Firm has to have atleast one participant.")]
        [Required(ErrorMessage = "Firm has to have atleast one participant.")]
        public int firmParticipants { get; set; }

        [Required(ErrorMessage = "Please selecet correct payment type.")]
        public int paymentType { get; set; }

        [MaxLength(5000, ErrorMessage = "Maximum of 5000 characters.")]
        public string extraInfo { get; set; }

        public int? deleted { get; set; }
    }
}
