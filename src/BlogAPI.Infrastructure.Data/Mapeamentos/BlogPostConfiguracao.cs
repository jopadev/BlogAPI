using BlogAPI.Core.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Infrastructure.Data.Mapeamentos
{
    public class BlogPostConfiguracao : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.PostId);
            builder.Property(x => x.Titulo).HasMaxLength(int.MaxValue);
            builder.Property(x => x.Conteudo).HasMaxLength(int.MaxValue)
                .HasColumnType("NVarchar(MAX)");
        }
    }


}
