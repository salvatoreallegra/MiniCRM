using MiniCRM.Api.Models;

namespace MiniCRM.Tests.Unit;

public class CustomerTests
{
    [Fact]
    public void Customer_CanStoreNameAndEmail()
    {
        // Arrange
        var customer = new Customer
        {
            Name = "Acme Plumbing",
            Email = "info@acme.com"
        };

        // Act
        string name = customer.Name;
        string email = customer.Email;

        // Assert
        Assert.Equal("Acme Plumbing", name);
        Assert.Equal("info@acme.com", email);
    }
}