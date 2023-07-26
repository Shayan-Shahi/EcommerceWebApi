using Ecommerce.Entities;
using Ecommerce.ViewModels.Sliders;

namespace Ecommerce.Services.Contracts;

public interface ISliderService : IGenericService<Slider>
{
    Task<List<ShowSliderViewModel>> GetPreviewAsync();

    Task<EditSliderViewModel> GetForEdit(int id);

    Task<List<ShowSliderInFrontViewModel>> GetSlidersForFront();
}
