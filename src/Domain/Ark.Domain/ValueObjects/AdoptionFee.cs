using Ark.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ark.Domain.ValueObjects
{
    public class AdoptionFee : IValueObject
    {
        public decimal Value { get; private set; }
        public bool Paid { get; private set; }
        public bool Free { get; private set; }
        public string AuthorizedBy { get; private set; }

        public AdoptionFee(decimal value)
        {
            this.Value = value;
            this.Paid = true;
        }

        public AdoptionFee(string authorizedBy)
        {
            this.AuthorizedBy = authorizedBy;
            this.Free = true;
            this.Paid = false;
        }
    }
}
