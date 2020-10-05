using System;
using Xunit;
using Shouldly;
using CustomerPreferenceCenter.Lib;
namespace CustomerPreferenceCenter.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void Customer_constructor_works_correctly()
        {
            Customer customer = new Customer(1, "John", "Doe");
            customer.Id.ShouldBe(1);
            customer.FirstName.ShouldBe("John");
            customer.LastName.ShouldBe("Doe");
        }

        [Fact]
        public void Customer_ToString_override_works()
        {
            Customer customer = new Customer(1, "John", "Doe");
            customer.Id.ShouldBe(1);
            customer.FirstName.ShouldBe("John");
            customer.ToString().ShouldBe("1 - John Doe");
        }
    }
}
