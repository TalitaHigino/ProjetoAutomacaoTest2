// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ProjAtividadelUnitTest.Api.Migrations
{
    [DbContext(typeof(AtividadeContext))]
    partial class AtividadeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjAtividadelUnitTest.Api.Models.Atividade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("responsavelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("responsavelId");

                    b.ToTable("Atividade");
                });

            modelBuilder.Entity("ProjAtividadelUnitTest.Api.Models.Responsavel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Responsavel");
                });

            modelBuilder.Entity("ProjAtividadelUnitTest.Api.Models.Atividade", b =>
                {
                    b.HasOne("ProjAtividadelUnitTest.Api.Models.Responsavel", "responsavel")
                        .WithMany()
                        .HasForeignKey("responsavelId");

                    b.Navigation("responsavel");
                });
#pragma warning restore 612, 618
        }
    }
}
