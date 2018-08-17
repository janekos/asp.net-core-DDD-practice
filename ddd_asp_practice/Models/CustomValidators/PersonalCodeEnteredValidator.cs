using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Models.CustomValidators {
    public class PersonalCodeEnteredValidator : ValidationAttribute {
        public override bool IsValid(object value) {
            if ((long)value > 9999_9999_999 || (long)value < 1000_0000_000) {
                return false;
            }
            return true;
        }
    }
}
