using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Progress.Models
{
    public class Patient : BaseStringKeyEntity
    {
        [StringLength(50)]
        public string Surname {get;set;}
        [StringLength(50)]
        public string Name {get;set;}
        [StringLength(50)]
        public string? Patronimyc {get;set;}
        public DateTime DateOfBirth {get;set;}
        [PhoneAttribute]
        [StringLength(15)]
        public string PhoneNumber {get;set;}
        [JsonIgnore]
        [XmlArray]
        [XmlArrayItem(typeof(Visit))]
        public virtual ICollection<Visit> Visits {get;set;}
    }
}