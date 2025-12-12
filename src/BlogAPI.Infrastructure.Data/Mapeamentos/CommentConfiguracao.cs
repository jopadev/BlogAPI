using BlogAPI.Core.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogAPI.Infrastructure.Data.Mapeamentos
{
    public class CommentConfiguracao : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.ComentarioId);
            builder.Property(x => x.Conteudo).HasMaxLength(int.MaxValue)
                .HasColumnType("NVarchar(MAX)");
            builder.HasOne(x => x.Post)
                .WithMany(y => y.Comments)
                .HasForeignKey(z => z.PostId);
        }
    }


}
