using Ecommerce.DataLayer.Context;
using Ecommerce.Entities;
using Ecommerce.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Services.EFServices;

public class ProductTagService : GenericService<ProductTag>, IProductTagService
{
    private readonly DbSet<ProductTag> _productTags;
    public ProductTagService(IUnitOfWork uow) : base(uow)
    {
        _productTags = uow.Set<ProductTag>();
    }

    public List<ProductTag> GetTags(List<string> splittedTags)
        => _productTags.Where(x => splittedTags.Contains(x.Title)).ToList();
}
