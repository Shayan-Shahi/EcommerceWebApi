﻿using Ecommerce.ViewModels.TestWebApi;

namespace Ecommerce.Services.Contracts.WebApi;

public interface IUserServiceWebApi
{
    Task<OperationResult<string>> Add(AddUserViewModel input);
    Task<OperationResult<List<ShowUserViewModel>>> GetAllAsync();
    Task<OperationResult<string>> Login(LoginViewModel input);
}
