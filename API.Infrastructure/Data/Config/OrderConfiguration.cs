﻿using API.Core.DbModels.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace API.Infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(o => o.ShiptToAddress, a =>
            {
                a.WithOwner();
            });

            builder.Property(s => s.Status)
                .HasConversion(

                o => o.ToString(),
                o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o));

            builder.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}