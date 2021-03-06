﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using guidStore.Data;

namespace guidStore.Migrations
{
    [DbContext(typeof(GuidDbContext))]
    partial class GuidDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("guidStore.Data.Models.GuidModel", b =>
                {
                    b.Property<string>("guid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("expire");

                    b.Property<string>("user");

                    b.HasKey("guid");

                    b.ToTable("guids");
                });
#pragma warning restore 612, 618
        }
    }
}
