using Ecommerce.Entities;

namespace Ecommerce.Services.Contracts;

public interface IProductImageService : IGenericService<ProductImage>
{
    Task RemoveProductImageByNameAsync(string productImageName);
}
