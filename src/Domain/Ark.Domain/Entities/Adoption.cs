using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ark.Domain.Entities
{
    public class Adoption
    {
        public Adopter Adopter { get; private set; }
        public decimal AdoptionFeeValue { get; private set; }
        public bool AdoptionFeePaid { get; private set; }
        public string Observations { get; private set; }
        public string DonatedBy { get; private set; }
        public DateTime OccurrenceDate { get; private set; }
        public IReadOnlyCollection<Animal> Animals => _animals.AsReadOnly();
        private List<Animal> _animals { get; set; }
    }
}
