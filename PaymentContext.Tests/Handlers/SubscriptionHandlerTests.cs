using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;
using System;
using Xunit;

namespace PaymentContext.Tests
{
  public class SubscriptionHandlerTests
  {
    [Fact]
    public void ShouldReturnErrorWhenDocumentExists()
    {
      var handler = new SubscriptionHandler(
        new FakeStudentRepository(),
        new FakeEmailService()
        );

      var command = new CreateBoletoSubscriptionCommand();

      command.FirstName = "Bruce";
      command.LastName = "Wayne";
      command.Document = "12312312312";
      command.Email = "pedro@gmail.com";
      command.BarCode = "123456789";
      command.BoletoNumber = "1234654987";
      command.PaymentNumber = "123121";
      command.PaidDate = DateTime.Now;
      command.ExpireDate = DateTime.Now.AddMonths(1);
      command.Total = 60;
      command.TotalPaid = 60;
      command.Payer = "WAYNE CORP";
      command.PayerDocument = "12345678911";
      command.PayerDocumentType = EDocumentType.CPF;
      command.PayerEmail = "batman@dc.com";
      command.Street = "asdas";
      command.Number = "asdd";
      command.Neighborhood = "asdasd";
      command.City = "as";
      command.State = "as";
      command.Country = "as";
      command.ZipCode = "12345678";

      handler.Handle(command);

      Assert.False(handler.IsValid);
    }
  }
}
