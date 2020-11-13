﻿using Core.Domain.Entities;
using Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(i => i.ID).HasName("PersonID");
            //builder.OwnsOne(i => i.HomeAddress);

            var address = new Address("70 Sta. Maria St.", "Muntinlupa City", "Metro manila", "Philippines", "1772");
            builder.HasData(new[]
            {
                new Person
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Birthday = DateTimeOffset.Parse("29/12/1986"),
                    //HomeAddress = address,
                    ID = Guid.NewGuid(),
                }
            });
        }
    }
}
