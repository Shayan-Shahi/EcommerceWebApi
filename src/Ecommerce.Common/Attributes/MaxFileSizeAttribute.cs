﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Common.Attributes;

//[AttributeUsage(AttributeTargets.Property)]
public class MaxFileSizeAttribute : BaseValidationAttribute, IClientModelValidator
{
    private readonly int _maxFileSize;
    private readonly string _errorMessage;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="maxFileSize">By MG</param>
    /// <param name="displayName"></param>
    public MaxFileSizeAttribute(string displayName, int maxFileSize)
    {
        _maxFileSize = maxFileSize * 1024 * 1024;
        _errorMessage = $"اندازه {displayName} نباید بیشتر از {maxFileSize} مگابایت باشد";
    }

    protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
    {
        //var propertyDisplayName = validationContext.DisplayName;
        var file = value as IFormFile;
        if (file != null && file.Length > 0)
        {
            if (file.Length > _maxFileSize)
            {
                return new ValidationResult(_errorMessage);
            }
        }

        return ValidationResult.Success;
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        //var propertyDisplayName = context.ModelMetadata.DisplayName;
        MergeAttribute(context.Attributes, "data-val", "true");
        MergeAttribute(context.Attributes, "data-val-maxFileSize", _errorMessage);
        MergeAttribute(context.Attributes, "data-val-maxsize", _maxFileSize.ToString());
    }
    //public bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
    //{
    //    if (attributes.ContainsKey(key))
    //    {
    //        return false;
    //    }
    //    attributes.Add(key, value);
    //    return true;
    //}
}
