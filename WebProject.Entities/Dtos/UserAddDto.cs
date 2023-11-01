using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Entities.Dtos
{
    public class UserAddDto
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılamaz")]
        [Display(Name = "Kullanıcı Adı:")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Email Formatı Yanlıştır")]
        [Required(ErrorMessage = "Mail Boş Bırakılamaz")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

       
        [DataType(DataType.Password)]
        [Display(Name = "Şifre:")]
        [Required(ErrorMessage = "Şifre Boş Bırakılamaz")]
        [MinLength(6, ErrorMessage = "Şifreniz En az 6 Karakter olmalıdır")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar:")]
        [Required(ErrorMessage = "Şifre Tekrar AlanıBoş Bırakılamaz")]
        [Compare(nameof(Password), ErrorMessage = "Girmiş Olduğunuz Şifre Aynı Değildir")]
        [MinLength(6, ErrorMessage = "Şifreniz En az 6 Karakter olmalıdır")]
        public string PasswordConfirm { get; set; }
    }
}
