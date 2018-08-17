using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ddd_asp_practice.Models.CustomValidators {
    public class DateEnteredValidator : ValidationAttribute {
        public override bool IsValid(object value) {
            if ((DateTime)value <= DateTime.Now) {
                return false;
            }
            return true;
        }
    }
}
