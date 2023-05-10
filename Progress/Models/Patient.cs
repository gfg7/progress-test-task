using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Progress.Models
{
    [XmlRoot(nameof(Patient))]
    public class Patient : BaseStringKeyEntity
    {
        [Required(ErrorMessage ="Введите фамилию")]
        [StringLength(50, ErrorMessage =$"Фамилия не должна быть длинее 50 символов")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="Введите имя")]
        [StringLength(50, ErrorMessage =$"Имя не должно быть длинее 50 символов")]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage =$"Отчество не должно быть длинее 50 символов")]
        public string? Patronymic { get; set; }
        [Required(ErrorMessage ="Введите дату рождения")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [PhoneAttribute(ErrorMessage ="Неверный формат номера телефона")]
        [StringLength(15, ErrorMessage =$"Номер телефона не должен быть длинее 15 символов")]
        public string? PhoneNumber { get; set; }
        [XmlArray]
        [XmlArrayItem(nameof(Visit), typeof(Visit))]
        [ValidateNever]
        public virtual List<Visit> Visits {get;set;} = new();
    }
}