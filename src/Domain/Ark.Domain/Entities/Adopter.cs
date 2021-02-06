using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ark.Domain.Entities
{
    public class Adopter
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public IReadOnlyCollection<Phone> Phones => _phones.AsReadOnly();
        private List<Phone> _phones { get; set; }
        public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();
        private List<Address> _addresses { get; set; }
        public History History { get; private set; }
        
    }
}
