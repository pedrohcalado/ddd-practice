using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PaymentContext.Tests
{
  public class StudentQueriesTests
  {

    private IList<Student> _students;

    public StudentQueriesTests()
    {
      for (var i = 0; i <= 10; i++)
      {
        _students.Add(
          new Student(
            new Name("Aluno", i.ToString()),
            new Document("12312312312" + i.ToString(), EDocumentType.CPF),
            new Email(i.ToString() + "@gmail.com")
            ));
      }
    }

    [Fact]
    public void ShouldReturnNullWhenDocumentNotExists()
    {
      var exp = StudentQueries.GetStudentInfo("12312312312");
      var student = _students.AsQueryable().Where(exp).FirstOrDefault();

      Assert.NotEqual(null, student);
    }
  }
}
