using Ecommerce.Entities;

namespace Ecommerce.Services.Contracts;

public interface IProductTagService : IGenericService<ProductTag>
{
    List<ProductTag> GetTags(List<string> splittedTags);
}
