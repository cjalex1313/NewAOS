using AOS.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOS.DataAccess.DbMappings;

public static class DomainMapping
{
    public static void MapDomain(EntityTypeBuilder<Domain> entity)
    {
        entity.HasKey(entity => entity.Id);
        entity.Property(e => e.Name).IsRequired();
        entity.Property(e => e.Deleted).IsRequired().HasDefaultValue(false);
        entity.Property(e => e.Draft).IsRequired().HasDefaultValue(true);
    }
}
