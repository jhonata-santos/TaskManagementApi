using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TaskManagementApi.Data;

namespace TaskManagementApi.Migrations;

[DbContext(typeof(TaskContext))]
partial class TaskContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasAnnotation("ProductVersion", "8.0.7")
            .HasAnnotation("Relational:MaxIdentifierLength", 64);

        MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

        modelBuilder.Entity("TaskManagementApi.Models.Task", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<DateTime>("EndDate")
                    .HasColumnType("datetime(6)");

                b.Property<string>("Owner")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                b.Property<DateTime>("StartDate")
                    .HasColumnType("datetime(6)");

                b.Property<string>("Status")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<string>("Title")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                b.HasKey("Id");

                b.ToTable("Tasks");
            });
    }
}