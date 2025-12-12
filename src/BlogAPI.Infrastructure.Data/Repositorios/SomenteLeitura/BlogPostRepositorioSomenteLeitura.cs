using BlogAPI.Core.Domain.Entidades;
using BlogAPI.Core.Domain.Interfaces.Repositorios.SomenteLeitura;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace BlogAPI.Infrastructure.Data.Repositorios.SomenteLeitura
{
    public class BlogPostRepositorioSomenteLeitura : IBlogPostRepositorioSomenteLeitura
    {
        public IConfiguration _configuration;

        public BlogPostRepositorioSomenteLeitura(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("BlogAPIConnection"));
        }
        public async Task<BlogPost> ObterPorId(Guid id)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    var dicionarioComentarios = new Dictionary<Guid, Comment>();

                    var oBlogPostList = await connection.QueryAsync<BlogPost, Comment, BlogPost>(@"SELECT p.*,c.* 
                                                                        FROM Posts p 
                                                                        LEFT JOIN Comments c ON p.PostId = c.PostId 
                                                                        WHERE p.PostId = @pPostId",
                                                                            (blogPost, comment) =>
                                                                            {
                                                                                if (comment != null && !dicionarioComentarios.ContainsKey(comment.ComentarioId))
                                                                                    dicionarioComentarios.Add(comment.ComentarioId, comment);

                                                                                return blogPost;
                                                                            }, new { pPostId = id }, splitOn: "PostId,ComentarioId");

                    var oBlogPost = oBlogPostList.FirstOrDefault();

                    oBlogPost.Comments = dicionarioComentarios.Values.OrderByDescending(x => x.DataCadastro).ToList();

                    return oBlogPost;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
