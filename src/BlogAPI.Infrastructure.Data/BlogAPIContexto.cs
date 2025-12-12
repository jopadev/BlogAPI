using BlogAPI.Infrastructure.Data.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Infrastructure.Data
{
    public class BlogAPIContexto : DbContext
    {
        public BlogAPIContexto(DbContextOptions<BlogAPIContexto> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogPostConfiguracao());
            modelBuilder.ApplyConfiguration(new CommentConfiguracao());
        }
    }

}
