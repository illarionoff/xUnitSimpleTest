using Moq;
using TestApp.Functionality;
using Xunit;

namespace TestApp.Test;

public class ShoppingCartTest
{
    public readonly Mock<IDbService> _dbService = new ();

    [Fact]
    public void AddProduct_Success()
    {
        _dbService.Setup(x => x.SaveItemToShoppingCart(It.IsAny<Product>())).Returns(true);
        var shoppingCart = new ShoppingCart(_dbService.Object);

        var product = new Product(1, "Shoes", 100);
        var result = shoppingCart.AddProduct(product);

        Assert.True(result);
        _dbService.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Once);
    }

    [Fact]
    public void AddProduct_Fail()
    {
        var shoppingCart = new ShoppingCart(_dbService.Object);

        var result = shoppingCart.AddProduct(null);

        _dbService.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Never);
    }

    [Fact]
    public void RemoveProduct_Success()
    {
        _dbService.Setup(x => x.RemoveItemFromShoppingCart(It.IsAny<int>())).Returns(true);

        var shoppingCart = new ShoppingCart(_dbService.Object);

        var result = shoppingCart.DeleteProduct(1);

        Assert.True(result);
        _dbService.Verify(x => x.RemoveItemFromShoppingCart(It.IsAny<int>()), Times.Once);

    }

    [Fact]
    public void RemoveProduct_Fail()
    {
        var shoppingCart = new ShoppingCart(_dbService.Object);

        var result = shoppingCart.DeleteProduct(0);

        Assert.False(result);
        _dbService.Verify(x => x.RemoveItemFromShoppingCart(It.IsAny<int>()), Times.Never);
    }
}
