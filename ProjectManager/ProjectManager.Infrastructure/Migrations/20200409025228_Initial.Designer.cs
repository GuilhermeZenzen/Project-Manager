// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManager.Infrastructure.Contexts;

namespace ProjectManager.Infrastructure.Migrations
{
    [DbContext(typeof(ProjectManagerContext))]
    [Migration("20200409025228_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectManager.Domain.Aggregates.User.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(512)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ProjectManager.Domain.Aggregates.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("binary(64)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjectManager.Domain.Aggregates.User.UserSubordination", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubordinateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SuperiorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("SubordinateId");

                    b.HasIndex("SuperiorId");

                    b.ToTable("UserSubordinations");
                });

            modelBuilder.Entity("ProjectManager.Domain.Aggregates.User.User", b =>
                {
                    b.OwnsOne("ProjectManager.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Domain")
                                .IsRequired()
                                .HasColumnType("varchar(64)");

                            b1.Property<string>("LocalPart")
                                .IsRequired()
                                .HasColumnType("varchar(64)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("ProjectManager.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnName("FirstName")
                                .HasColumnType("varchar(64)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnName("LastName")
                                .HasColumnType("varchar(64)");

                            b1.Property<string>("Surname")
                                .HasColumnName("Surname")
                                .HasColumnType("varchar(256)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });
                });

            modelBuilder.Entity("ProjectManager.Domain.Aggregates.User.UserSubordination", b =>
                {
                    b.HasOne("ProjectManager.Domain.Aggregates.User.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManager.Domain.Aggregates.User.User", "Subordinate")
                        .WithMany("Superiors")
                        .HasForeignKey("SubordinateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManager.Domain.Aggregates.User.User", "Superior")
                        .WithMany("Subordinates")
                        .HasForeignKey("SuperiorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
