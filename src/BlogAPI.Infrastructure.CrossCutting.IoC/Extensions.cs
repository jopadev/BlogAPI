using BlogAPI.Core.Application.Interfaces;
using BlogAPI.Core.Application.Mapeamentos;
using BlogAPI.Core.Application.Servicos;
using BlogAPI.Core.Domain.Interfaces.Repositorios;
using BlogAPI.Core.Domain.Interfaces.Repositorios.SomenteLeitura;
using BlogAPI.Core.Domain.Interfaces.Servicos;
using BlogAPI.Core.Domain.Servicos;
using BlogAPI.Core.Domain.Validadores;
using BlogAPI.Infrastructure.Data;
using BlogAPI.Infrastructure.Data.Repositorios;
using BlogAPI.Infrastructure.Data.Repositorios.SomenteLeitura;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogAPI.Infrastructure.CrossCutting.IoC
{
    public static class Extensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<BlogAPIContexto>(options => options.UseSqlServer(configuration.GetConnectionString("BlogAPIConnection")));

            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<IBlogPostRepositorio, BlogPostRepositorio>();
            services.AddScoped<ICommentRepositorio, CommentRepositorio>();

            services.AddScoped<IBlogPostRepositorioSomenteLeitura, BlogPostRepositorioSomenteLeitura>();

            services.AddScoped(typeof(IServicoBase<>), typeof(ServicoBase<>));
            services.AddScoped<IBlogPostServico, BlogPostServico>();
            services.AddScoped<ICommentServico, CommentServico>();

            services.AddScoped<IBlogPostServicoApp, BlogPostServicoApp>();
            services.AddScoped<ICommentServicoApp, CommentServicoApp>();

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            services.AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters()
                    .AddValidatorsFromAssemblyContaining<BlogPostValidator>();

            return services;
        }
    }

}
