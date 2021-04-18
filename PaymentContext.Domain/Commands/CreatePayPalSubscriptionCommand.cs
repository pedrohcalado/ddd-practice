using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Commands
{
    public class CreatePayPalSubscriptionCommand : Notifiable<Notification>, ICommand
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string TransactionCode { get; private set; }
        public string PaymentNumber { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Payer { get; private set; }
        public string PayerEmail { get; private set; }
        public string PayerDocument { get; private set; }
        public EDocumentType PayerDocumentType { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract<CreatePayPalSubscriptionCommand>()
                .Requires()
                .IsGreaterThan(FirstName, 3, "Name.FirstName", "O nome deve conter pelo menos 3 caracteres")
                .IsGreaterThan(LastName, 3, "Name.LasttName", "O sobrenome deve conter pelo menos 3 caracteres")
                .IsLowerThan(FirstName, 40, "Name.FirstName", "O nome deve conter até 40 caracteres")
            );
        }
    }
}
