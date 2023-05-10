using System.Xml.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Progress.Models
{
    public class Visit : BaseStringKeyEntity
    {
        [Required(ErrorMessage ="Введите дату посещения")]
        [DataType(DataType.DateTime, ErrorMessage = "Неверный формат даты")]
        public DateTime Time { get; set; }
        [StringLength(36)]
        [DescriptionAttribute("Справочник МКБ10")]
        [Required(ErrorMessage ="Выберите диагноз")]
        public string Diagnosis { get; set; }
        [StringLength(36)]
        [XmlIgnore]
        [Required]
        [ForeignKeyAttribute(nameof(PatientId))]
        public string PatientId { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        [ValidateNever]
        public virtual Patient? Patient { get; set; }
        [ForeignKeyAttribute(nameof(Diagnosis))]
        [XmlIgnore]
        [ValidateNever]
        public virtual Diagnosis? Reason { get; set; }
    }
}