﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ruleta_api.Data;

#nullable disable

namespace ruleta_api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ruleta_api.Models.Bet", b =>
                {
                    b.Property<string>("User")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.HasKey("User");

                    b.ToTable("Bets");
                });
#pragma warning restore 612, 618
        }
    }
}
