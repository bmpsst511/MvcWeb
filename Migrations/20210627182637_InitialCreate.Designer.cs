// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MvcWeb.Migrations
{
    [DbContext(typeof(MvcWebContext))]
    [Migration("20210627182637_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("MvcMovie.Models.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("TEXT");

                    b.Property<string>("bannerContentDown")
                        .HasColumnType("TEXT");

                    b.Property<string>("bannerContentUp")
                        .HasColumnType("TEXT");

                    b.Property<int>("bannerIndex")
                        .HasColumnType("INTEGER");

                    b.Property<int>("bannerState")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Banner");
                });
#pragma warning restore 612, 618
        }
    }
}
