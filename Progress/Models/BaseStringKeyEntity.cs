using System.ComponentModel.DataAnnotations;
using Progress.Interfaces;

namespace Progress.Models
{
    public abstract class BaseStringKeyEntity : IEntity<string>
    {
        [KeyAttribute]
        [StringLength(36)]
        public string Id { get; private set; }

        public string GetKey() => Id;

        public string SetKey()
        {
            Id = Guid.NewGuid().ToString();
            return Id;
        }
    }
}