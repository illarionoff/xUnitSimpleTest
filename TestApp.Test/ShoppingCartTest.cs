using TestApp.Functionality;
using Xunit;

namespace TestApp.Test;

public class DbServiceMock : IDbService
{
    public bool Result { get; set; }
    public Product  Product{ get; set; }
    public int ProductId { get; set; }
    bool IDbService.RemoveItemFromShoppingCart(int? productId)
    {
        if(productId == null)
        {
            return false; 
        }

        if (productId == 0)
        {
            return false;

        }

        ProductId = Convert.ToInt32(productId);
        Result = true;
        return Result;
    }

    bool IDbService.SaveItemToShoppingCart(Product? product)
    {
        if (product == null)
        {
            return false;
        }

        if (product.Id == 0)
        {
            return false;

        }

        Product = product;
        return true;
    }
}

public class ShoppingCartTest
{
    [Fact]
    public void AddProduct_Success()
    {
        var dbMock = new DbServiceMock();
        dbMock.Result = true;
        var shoppingCart = new ShoppingCart(dbMock);

        var product = new Product(1, "Shoes", 100);
        var result = shoppingCart.AddProduct(product);

        Assert.True(result);
        Assert.Equal(result, dbMock.Result);
        Assert.Equal(dbMock.Product.Id, product.Id);
        Assert.Equal(dbMock.Product.Name, product.Name);
        Assert.Equal(dbMock.Product.Price, product.Price);
    }

    [Fact]
    public void AddProduct_Fail()
    {
        var dbMock = new DbServiceMock();
        dbMock.Result = false;
        var shoppingCart = new ShoppingCart(dbMock);

        var result = shoppingCart.AddProduct(null);

        Assert.False(result);
        Assert.Equal(result, dbMock.Result);
    }

    [Fact]
    public void RemoveProduct_Success()
    {
        var dbMock = new DbServiceMock();
        dbMock.Result = true;
        var shoppingCart = new ShoppingCart(dbMock);

        var result = shoppingCart.DeleteProduct(1);

        Assert.True(result);
        Assert.Equal(result, dbMock.Result);
    }

    [Fact]
    public void RemoveProduct_Fail()
    {
        var dbMock = new DbServiceMock();
        dbMock.Result = false;
        var shoppingCart = new ShoppingCart(dbMock);

        var result = shoppingCart.DeleteProduct(0);

        Assert.False(result);
        Assert.Equal(result, dbMock.Result);
    }
}
