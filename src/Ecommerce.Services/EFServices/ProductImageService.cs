using Ecommerce.DataLayer.Context;
using Ecommerce.Entities;
using Ecommerce.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services.EFServices;

public class ProductImageService : GenericService<ProductImage>, IProductImageService
{
    private readonly DbSet<ProductImage> _productImages;
    public ProductImageService(IUnitOfWork uow)
        : base(uow)
    {
        _productImages = uow.Set<ProductImage>();
    }

    public async Task RemoveProductImageByNameAsync(string productImageName)
    {
        var productImage = await _productImages
            .SingleOrDefaultAsync(x => x.Title == productImageName);
        if (productImage is not null)
            this.Remove(productImage);
    }
}
