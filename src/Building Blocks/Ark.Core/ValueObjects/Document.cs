using System.Threading.Tasks;

namespace Ark.Core.ValueObjects
{
    public record Document : IValueObject
    {
        public string Value { get; }

        EDocumentType Type { get; }

        private Document(string value, EDocumentType type)
        {
            Value = value;
            Type = type;
        }

        public Document Create(string value)
        {
            var type = EDocumentType.CNPJ;

            return new Document(value, type);
        }
    }

    public enum EDocumentType
    {
        CNPJ = 1,
        CPF = 2
    }
}
