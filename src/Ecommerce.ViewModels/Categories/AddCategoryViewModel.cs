﻿using Ecommerce.Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels.Categories;

public class AddCategoryViewModel
{
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    [MaxLength(100, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    public string Title { get; set; }

    [Display(Name = "زیر دسته")]
    public int? ParentId { get; set; }
}
