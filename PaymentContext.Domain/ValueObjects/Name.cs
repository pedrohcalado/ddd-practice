using Flunt.Validations;
using Flunt.Localization;
using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Name>()
                .Requires()
                .IsGreaterThan(FirstName, 3, "Name.FirstName", "O nome deve conter pelo menos 3 caracteres")
                .IsGreaterThan(LastName, 3, "Name.LasttName", "O sobrenome deve conter pelo menos 3 caracteres")
                .IsLowerThan(FirstName, 40, "Name.FirstName", "O nome deve conter até 40 caracteres")
            );

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
