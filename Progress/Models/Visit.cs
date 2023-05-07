using System.Xml.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Progress.Models
{
    public class Visit : BaseStringKeyEntity
    {
        public DateTime Time {get;set;}
        [StringLength(36)]
        [DescriptionAttribute("Справочник МКБ10")]
        public string Diagnosis {get;set;}
        [StringLength(36)]
        [XmlIgnoreAttribute]
        public string PatientId {get;set;}
        [ForeignKeyAttribute(nameof(PatientId))]
        [XmlIgnoreAttribute]
        public virtual Patient? Patient {get;set;}
    }
}