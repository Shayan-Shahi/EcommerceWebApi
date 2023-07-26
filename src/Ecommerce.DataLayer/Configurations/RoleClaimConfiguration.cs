﻿using Ecommerce.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.DataLayer.Configurations;

public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.HasOne(roleClaim => roleClaim.Role)
            .WithMany(roleClaim => roleClaim.RoleClaims)
            .HasForeignKey(roleClaim => roleClaim.RoleId);

        builder.ToTable("RoleClaims");
    }
}
