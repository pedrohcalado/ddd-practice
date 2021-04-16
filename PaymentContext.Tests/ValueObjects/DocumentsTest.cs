using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using Xunit;

namespace PaymentContext.Tests
{
    public class DocumentTests
    {
        [Fact]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var document = new Document("123", EDocumentType.CNPJ);
            Assert.False(document.IsValid);
        }
        [Fact]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var document = new Document("12345678912345", EDocumentType.CNPJ);
            Assert.True(document.Validate());
        }
        [Fact]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var document = new Document("123", EDocumentType.CPF);
            Assert.False(document.Validate());
        }
        [Fact]
        public void ShouldReturnSuccessWhenCPFIsValid()
        {
            var document = new Document("39293049237", EDocumentType.CPF);
            Assert.True(document.Validate());
        }
    }
}
