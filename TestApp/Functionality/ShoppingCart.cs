namespace TestApp.Functionality;

public record Product(int Id, string Name, double Price);

public interface IDbService
{
    bool SaveItemToShoppingCart(Product? product);
    bool RemoveItemFromShoppingCart(int? productId);
}

public class ShoppingCart
{
    private readonly IDbService _bService;

    public ShoppingCart(IDbService bService)
    {
        _bService = bService;
    }

    public bool AddProduct(Product? product)
    {
        if (product == null)
        {
            return false;
        }

        if(product.Id == 0)
        {
            return false;
        }

        return _bService.SaveItemToShoppingCart(product);
    }

    public bool DeleteProduct(int? id)
    {
        if (id == null)
        {
            return false;
        }

        if (id == 0)
        {
            return false;
        }

        return _bService.RemoveItemFromShoppingCart(Convert.ToInt32(id));
    }
}
