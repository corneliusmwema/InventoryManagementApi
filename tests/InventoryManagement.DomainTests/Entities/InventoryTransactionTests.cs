using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Enums;

namespace InventoryManagement.DomainTests.Entities;

public class InventoryTransactionTests
{
    [Fact]
    public void Constructor_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        var productId = 1;
        var type = TransactionType.Addition;
        var quantity = 10;
        var notes = "Test notes";

        // Act
        var transaction = new InventoryTransaction(productId, type, quantity, notes);

        // Assert
        Assert.Equal(productId, transaction.ProductId);
        Assert.Equal(type, transaction.Type);
        Assert.Equal(quantity, transaction.Quantity);
        Assert.Equal(notes, transaction.Notes);
        Assert.True(DateTime.UtcNow.Subtract(transaction.TransactionDate).TotalSeconds < 1);
    }

    [Fact]
    public void Constructor_WithoutNotes_ShouldSetDefaultEmptyNotes()
    {
        // Arrange
        var productId = 1;
        var type = TransactionType.Addition;
        var quantity = 5;

        // Act
        var transaction = new InventoryTransaction(productId, type, quantity);

        // Assert
        Assert.Equal(string.Empty, transaction.Notes);
    }

    [Fact]
    public void Constructor_ShouldSetTransactionDateToCurrentUtcTime()
    {
        // Arrange
        var productId = 1;
        var type = TransactionType.Withdrawal;
        var quantity = 10;

        // Act
        var before = DateTime.UtcNow;
        var transaction = new InventoryTransaction(productId, type, quantity);
        var after = DateTime.UtcNow;

        // Assert
        Assert.True(transaction.TransactionDate >= before);
        Assert.True(transaction.TransactionDate <= after);
    }
}