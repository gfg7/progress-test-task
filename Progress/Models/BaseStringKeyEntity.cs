using System.ComponentModel.DataAnnotations;
using Progress.Interfaces;

namespace Progress.Models
{
    public abstract class BaseStringKeyEntity : IEntity<string>
    {
        [KeyAttribute]
        [StringLength(36)]
        public string Id { get; set; }
        public BaseStringKeyEntity()
        {
            SetKey();
        }

        public string GetKey() => Id;

        public bool IdEquals(string key)
        {
            return Id==key;
        }

        public string SetKey()
        {
            Id = Guid.NewGuid().ToString();
            return Id;
        }
    }
}