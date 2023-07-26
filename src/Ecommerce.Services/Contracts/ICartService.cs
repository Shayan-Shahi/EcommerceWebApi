using Ecommerce.Entities;
using Ecommerce.ViewModels.Cart;

namespace Ecommerce.Services.Contracts;

public interface ICartService : IGenericService<Cart>
{
    Task<Cart> GetUserCartAsync(int userId);
    Task<List<ShowCartPreviewForClientViewModel>> GetUserCartsForClient(int userId);
    Task<List<ShowCartPreviewForAdminViewModel>> GetUserCartsForAdmin();
}
