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
                return true; // Boş değerler kabul edilebilir
            }

            // Gelen değeri bir dize olarak alın
            string stringValue = value.ToString();

            // Virgülle ayrılmış sayıları dizeyi böler
            string[] numbers = stringValue.Split(',');

            // Her elemanın sayı olup olmadığını kontrol et
            foreach (var number in numbers)
            {
                if (!int.TryParse(number, out _))
                {
                    return false; // Sayı değilse geçersiz
                }
            }

            return true;
        }

    }
}
