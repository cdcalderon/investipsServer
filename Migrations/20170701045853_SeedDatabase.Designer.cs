using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using investips.Persistence;

namespace Investips.Migrations
{
    [DbContext(typeof(InvestipsDbContext))]
    [Migration("20170701045853_SeedDatabase")]
    partial class SeedDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("investips.Models.Porfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Porfolios");
                });

            modelBuilder.Entity("investips.Models.Security", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PorfolioId");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("PorfolioId");

                    b.ToTable("Securities");
                });

            modelBuilder.Entity("investips.Models.Security", b =>
                {
                    b.HasOne("investips.Models.Porfolio")
                        .WithMany("Securities")
                        .HasForeignKey("PorfolioId");
                });
        }
    }
}
