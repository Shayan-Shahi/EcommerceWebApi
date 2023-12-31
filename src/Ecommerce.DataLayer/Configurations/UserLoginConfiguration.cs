﻿using Ecommerce.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.DataLayer.Configurations;

public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.HasOne(userLogin => userLogin.User)
            .WithMany(userLogin => userLogin.UserLogins)
            .HasForeignKey(userClaim => userClaim.UserId);

        builder.ToTable("UserLogins");
    }
}
