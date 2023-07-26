using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Entity;

namespace TodoApi.Data
{
    public class TodoTypeConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("todos", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(nameof(TodoItem.Id));
            builder.Property(x => x.Title).HasColumnName(nameof(TodoItem.Title));
            builder.Property(x => x.Description).HasColumnName(nameof(TodoItem.Description));
            builder.Property(x => x.DueBy).HasColumnName(nameof(TodoItem.DueBy));
            builder.Property(x => x.Completed).HasColumnName(nameof(TodoItem.Completed));
        }
    }
}
