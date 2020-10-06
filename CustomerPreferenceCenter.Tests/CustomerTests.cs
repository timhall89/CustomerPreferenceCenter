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
            Customer customer = new Customer(1, "John Doe");
            customer.Id.ShouldBe(1);
            customer.Name.ShouldBe("John Doe");
        }


        [Fact]
        public void Customer_equality_overrides_work()
        {
            Customer customer = new Customer(1, "John Doe");
            customer.GetHashCode().ShouldBe(1);

            Customer anotherCustomer = new Customer(1, "John Doe");
            customer.Equals(anotherCustomer).ShouldBeTrue();
        }

        [Fact]
        public void Customer_ToString_override_works()
        {
            Customer customer = new Customer(1, "John Doe");
            customer.Id.ShouldBe(1);
            customer.ToString().ShouldBe("1 - John Doe");
        }
    }
}
