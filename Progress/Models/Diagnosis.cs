using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Progress.Interfaces;
using System.Text.Json.Serialization;

namespace Progress.Models
{
    public class Diagnosis : BaseStringKeyEntity
    {
        [Required]
        public string Name { get; set; }
        public string? ParentId { get; set; }
    }
}