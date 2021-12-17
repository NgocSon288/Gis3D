﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.EF;

namespace WebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211217072111_AddAnotherColor")]
    partial class AddAnotherColor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApp.Entities.Body", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bodies");
                });

            modelBuilder.Entity("WebApp.Entities.Face", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BodyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FaceTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Lod")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BodyId");

                    b.HasIndex("FaceTypeId");

                    b.ToTable("Faces");
                });

            modelBuilder.Entity("WebApp.Entities.FaceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FaceTypes");
                });

            modelBuilder.Entity("WebApp.Entities.FaceTypeOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FaceTypeId")
                        .HasColumnType("int");

                    b.Property<int>("OptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FaceTypeId");

                    b.HasIndex("OptionId");

                    b.ToTable("FaceTypeOptions");
                });

            modelBuilder.Entity("WebApp.Entities.FaceTypeOptionValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FaceId")
                        .HasColumnType("int");

                    b.Property<int>("FaceTypeOptionId")
                        .HasColumnType("int");

                    b.Property<double>("ValueN")
                        .HasColumnType("float");

                    b.Property<string>("ValueS")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FaceId");

                    b.ToTable("FaceTypeOptionValues");
                });

            modelBuilder.Entity("WebApp.Entities.Line", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BodyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LineTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Lod")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BodyId");

                    b.HasIndex("LineTypeId");

                    b.ToTable("Lines");
                });

            modelBuilder.Entity("WebApp.Entities.LineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LineTypes");
                });

            modelBuilder.Entity("WebApp.Entities.LineTypeOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LineTypeId")
                        .HasColumnType("int");

                    b.Property<int>("OptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LineTypeId");

                    b.HasIndex("OptionId");

                    b.ToTable("LineTypeOptions");
                });

            modelBuilder.Entity("WebApp.Entities.LineTypeOptionValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LineId")
                        .HasColumnType("int");

                    b.Property<int>("LineTypeOptionId")
                        .HasColumnType("int");

                    b.Property<double>("ValueN")
                        .HasColumnType("float");

                    b.Property<string>("ValueS")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LineId");

                    b.ToTable("LineTypeOptionValues");
                });

            modelBuilder.Entity("WebApp.Entities.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FaceId")
                        .HasColumnType("int");

                    b.Property<int?>("LineId")
                        .HasColumnType("int");

                    b.Property<int?>("PointId")
                        .HasColumnType("int");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.Property<double>("Z")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FaceId");

                    b.HasIndex("LineId");

                    b.HasIndex("PointId")
                        .IsUnique()
                        .HasFilter("[PointId] IS NOT NULL");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("WebApp.Entities.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Options");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsNumber = false,
                            Name = "color"
                        },
                        new
                        {
                            Id = 2,
                            IsNumber = true,
                            Name = "sizeWidth"
                        },
                        new
                        {
                            Id = 3,
                            IsNumber = true,
                            Name = "sizeHeight"
                        },
                        new
                        {
                            Id = 4,
                            IsNumber = true,
                            Name = "sizeDepth"
                        },
                        new
                        {
                            Id = 5,
                            IsNumber = true,
                            Name = "rotateX"
                        },
                        new
                        {
                            Id = 6,
                            IsNumber = true,
                            Name = "rotateY"
                        },
                        new
                        {
                            Id = 7,
                            IsNumber = true,
                            Name = "rotateZ"
                        },
                        new
                        {
                            Id = 8,
                            IsNumber = true,
                            Name = "minHeight"
                        },
                        new
                        {
                            Id = 9,
                            IsNumber = true,
                            Name = "maxHeight"
                        },
                        new
                        {
                            Id = 10,
                            IsNumber = true,
                            Name = "n"
                        },
                        new
                        {
                            Id = 11,
                            IsNumber = true,
                            Name = "width"
                        },
                        new
                        {
                            Id = 12,
                            IsNumber = false,
                            Name = "outlineColor"
                        },
                        new
                        {
                            Id = 13,
                            IsNumber = true,
                            Name = "outlineWidth"
                        },
                        new
                        {
                            Id = 14,
                            IsNumber = true,
                            Name = "m"
                        },
                        new
                        {
                            Id = 15,
                            IsNumber = true,
                            Name = "count"
                        },
                        new
                        {
                            Id = 16,
                            IsNumber = true,
                            Name = "start"
                        },
                        new
                        {
                            Id = 17,
                            IsNumber = true,
                            Name = "end"
                        },
                        new
                        {
                            Id = 18,
                            IsNumber = false,
                            Name = "anotherColor"
                        },
                        new
                        {
                            Id = 19,
                            IsNumber = true,
                            Name = "offset"
                        });
                });

            modelBuilder.Entity("WebApp.Entities.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BodyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Lod")
                        .HasColumnType("int");

                    b.Property<int>("PointTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BodyId");

                    b.HasIndex("PointTypeId");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("WebApp.Entities.PointType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PointTypes");
                });

            modelBuilder.Entity("WebApp.Entities.PointTypeOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OptionId")
                        .HasColumnType("int");

                    b.Property<int>("PointTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OptionId");

                    b.HasIndex("PointTypeId");

                    b.ToTable("PointTypeOptions");
                });

            modelBuilder.Entity("WebApp.Entities.PointTypeOptionValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PointId")
                        .HasColumnType("int");

                    b.Property<int>("PointTypeOptionId")
                        .HasColumnType("int");

                    b.Property<double>("ValueN")
                        .HasColumnType("float");

                    b.Property<string>("ValueS")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PointId");

                    b.ToTable("PointTypeOptionValues");
                });

            modelBuilder.Entity("WebApp.Entities.Face", b =>
                {
                    b.HasOne("WebApp.Entities.Body", "Body")
                        .WithMany("Faces")
                        .HasForeignKey("BodyId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WebApp.Entities.FaceType", "FaceType")
                        .WithMany("Faces")
                        .HasForeignKey("FaceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Body");

                    b.Navigation("FaceType");
                });

            modelBuilder.Entity("WebApp.Entities.FaceTypeOption", b =>
                {
                    b.HasOne("WebApp.Entities.FaceType", "FaceType")
                        .WithMany("FaceTypeOptions")
                        .HasForeignKey("FaceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Entities.Option", "Option")
                        .WithMany("FaceTypeOptions")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FaceType");

                    b.Navigation("Option");
                });

            modelBuilder.Entity("WebApp.Entities.FaceTypeOptionValue", b =>
                {
                    b.HasOne("WebApp.Entities.Face", "Face")
                        .WithMany("FaceTypeOptionValues")
                        .HasForeignKey("FaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Face");
                });

            modelBuilder.Entity("WebApp.Entities.Line", b =>
                {
                    b.HasOne("WebApp.Entities.Body", "Body")
                        .WithMany("Lines")
                        .HasForeignKey("BodyId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WebApp.Entities.LineType", "LineType")
                        .WithMany("Lines")
                        .HasForeignKey("LineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Body");

                    b.Navigation("LineType");
                });

            modelBuilder.Entity("WebApp.Entities.LineTypeOption", b =>
                {
                    b.HasOne("WebApp.Entities.LineType", "LineType")
                        .WithMany("LineTypeOptions")
                        .HasForeignKey("LineTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Entities.Option", "Option")
                        .WithMany("LineTypeOptions")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LineType");

                    b.Navigation("Option");
                });

            modelBuilder.Entity("WebApp.Entities.LineTypeOptionValue", b =>
                {
                    b.HasOne("WebApp.Entities.Line", "Line")
                        .WithMany("LineTypeOptionValues")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Line");
                });

            modelBuilder.Entity("WebApp.Entities.Node", b =>
                {
                    b.HasOne("WebApp.Entities.Face", "Face")
                        .WithMany("Nodes")
                        .HasForeignKey("FaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApp.Entities.Line", "Line")
                        .WithMany("Nodes")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApp.Entities.Point", "Point")
                        .WithOne("Node")
                        .HasForeignKey("WebApp.Entities.Node", "PointId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Face");

                    b.Navigation("Line");

                    b.Navigation("Point");
                });

            modelBuilder.Entity("WebApp.Entities.Point", b =>
                {
                    b.HasOne("WebApp.Entities.Body", "Body")
                        .WithMany("Points")
                        .HasForeignKey("BodyId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("WebApp.Entities.PointType", "PointType")
                        .WithMany("Points")
                        .HasForeignKey("PointTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Body");

                    b.Navigation("PointType");
                });

            modelBuilder.Entity("WebApp.Entities.PointTypeOption", b =>
                {
                    b.HasOne("WebApp.Entities.Option", "Option")
                        .WithMany("PointTypeOptions")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Entities.PointType", "PointType")
                        .WithMany("PointTypeOptions")
                        .HasForeignKey("PointTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Option");

                    b.Navigation("PointType");
                });

            modelBuilder.Entity("WebApp.Entities.PointTypeOptionValue", b =>
                {
                    b.HasOne("WebApp.Entities.Point", "Point")
                        .WithMany("PointTypeOptionValues")
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Point");
                });

            modelBuilder.Entity("WebApp.Entities.Body", b =>
                {
                    b.Navigation("Faces");

                    b.Navigation("Lines");

                    b.Navigation("Points");
                });

            modelBuilder.Entity("WebApp.Entities.Face", b =>
                {
                    b.Navigation("FaceTypeOptionValues");

                    b.Navigation("Nodes");
                });

            modelBuilder.Entity("WebApp.Entities.FaceType", b =>
                {
                    b.Navigation("Faces");

                    b.Navigation("FaceTypeOptions");
                });

            modelBuilder.Entity("WebApp.Entities.Line", b =>
                {
                    b.Navigation("LineTypeOptionValues");

                    b.Navigation("Nodes");
                });

            modelBuilder.Entity("WebApp.Entities.LineType", b =>
                {
                    b.Navigation("Lines");

                    b.Navigation("LineTypeOptions");
                });

            modelBuilder.Entity("WebApp.Entities.Option", b =>
                {
                    b.Navigation("FaceTypeOptions");

                    b.Navigation("LineTypeOptions");

                    b.Navigation("PointTypeOptions");
                });

            modelBuilder.Entity("WebApp.Entities.Point", b =>
                {
                    b.Navigation("Node");

                    b.Navigation("PointTypeOptionValues");
                });

            modelBuilder.Entity("WebApp.Entities.PointType", b =>
                {
                    b.Navigation("Points");

                    b.Navigation("PointTypeOptions");
                });
#pragma warning restore 612, 618
        }
    }
}
