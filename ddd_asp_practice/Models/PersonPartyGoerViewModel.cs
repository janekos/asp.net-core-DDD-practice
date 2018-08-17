using ddd_asp_practice.Data.Domain.SeedWork;
using ddd_asp_practice.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Models {
    public class PersonPartyGoerViewModel : IViewModel {

        public int? id { get; set; }

        public int partyRefId { get; set; }

        [Required(ErrorMessage = "Person name is required.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Person surname is required.")]
        public string surname { get; set; }
        
        [Required(ErrorMessage = "Person personal code is required.")]
        [PersonalCodeEnteredValidator(ErrorMessage = "Personal code is incorrect.")]
        public long personalCode { get; set; }

        [Required(ErrorMessage = "Please select correct payment type.")]
        public int paymentType { get; set; }

        [MaxLength(1500, ErrorMessage = "Maximum 1500 characters.")]
        public string extraInfo { get; set; }

        public int? deleted { get; set; }
    }
}
