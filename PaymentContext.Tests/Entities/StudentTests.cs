using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using Xunit;

namespace PaymentContext.Tests
{
    public class StudentTests
    {
        public StudentTests()
        {
            _name = new Name("Pedro", "Calado");
            _document = new Document("12312312323", EDocumentType.CPF);
            _email = new Email("pedro@gmail.com");
            _address = new Address("Rua 1", "1234", "Nova Suica", "BH", "MG", "BR", "30421318");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;

        [Fact]
        public void ShouldReturnErrorWhenActiveSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.False(_student.IsValid);
        }
        [Fact]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);

            Assert.False(_student.IsValid);
        }
        [Fact]
        public void ShouldReturnSuccessWHenHasNoActiveSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.True(_student.IsValid);
        }
    }
}
