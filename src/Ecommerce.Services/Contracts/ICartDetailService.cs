using Ecommerce.Entities;
using Ecommerce.ViewModels.Cart;

namespace Ecommerce.Services.Contracts;

public interface ICartDetailService : IGenericService<CartDetail>
{
    Task<CartDetail> GetCartDetailsBy(int productId, int userId);
    Task<int> CalculateUserCartTotalPrice(int userId);
    Task<List<CartDetailPreviewViewModel>> GetCartDetailsBy(int userId);
    Task<CartDetail> FindBy(int productId, int userId);
    Task<List<CartDetailPreviewViewModel>> GetCartDetails(int userId, int cartId);
    Task<List<CartDetailPreviewForAdminViewModel>> GetCartDetailsForAdmin(int cartId);
}
