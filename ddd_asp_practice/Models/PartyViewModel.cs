using ddd_asp_practice.Data.Domain.SeedWork;
using ddd_asp_practice.Models.CustomValidators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Models {
    public class PartyViewModel : IViewModel{
        public int? id { get; set; }
        [Required(ErrorMessage = "Party name is required.")]
        public string name { get; set; }
        [DateEnteredValidator(ErrorMessage = "Party must happen in the future.")]
        public DateTime date { get; set; }
        [Required(ErrorMessage = "Party location is required.")]
        public string location { get; set; }
        [MaxLength(1000, ErrorMessage = "Maximum 1000 characters.")]
        public string extraInfo { get; set; }
        public int? participants { get; set; }
        public int? deleted { get; set; }
    }
}
