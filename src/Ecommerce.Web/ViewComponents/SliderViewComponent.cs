﻿using Ecommerce.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.ViewComponents;

public class SliderViewComponent : ViewComponent
{
    private readonly ISliderService _sliderService;

    public SliderViewComponent(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("", await _sliderService.GetSlidersForFront());
    }
}
