// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MvcWeb.Migrations
{
    [DbContext(typeof(MvcWebContext))]
    [Migration("20210627203608_SubBoardCreate")]
    partial class SubBoardCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("LMcomposite.Models.SubBoard", b =>
                {
                    b.Property<int>("Sub_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sub_Index")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sub_Link")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sub_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Sub_Id");

                    b.ToTable("SubBoard");
                });

            modelBuilder.Entity("MvcWeb.Models.Banner", b =>
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
