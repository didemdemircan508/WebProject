using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Entities.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public  class CommaSeparatedAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true; 
            }
             string stringValue = value.ToString();

            string[] numbers = stringValue.Split(',');

            foreach (var number in numbers)
            {
                if (!int.TryParse(number, out _))
                {
                    return false; 
                }
            }

            return true;
        }

    }
}
