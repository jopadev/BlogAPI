using BlogAPI.Core.Application.Dtos;
using BlogAPI.Core.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Services.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IBlogPostServicoApp _blogPostServicoApp;
        private readonly ICommentServicoApp _commentServicoApp;

        public PostsController(IBlogPostServicoApp blogPostServicoApp, ICommentServicoApp commentServicoApp)
        {
            _blogPostServicoApp = blogPostServicoApp;
            _commentServicoApp = commentServicoApp;
        }

        [HttpGet]
        [Route("/api/posts")]
        public async Task<IActionResult> Todos()
        {
            try
            {
                return Ok(await _blogPostServicoApp.ObterTodosResumo());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um problema inesperado, por favor tente novamente.");
            }
        }

        [HttpGet()]
        [Route("/api/posts/{id}")]
        public async Task<IActionResult> Obter(Guid id)
        {
            try
            {
                return Ok(await _blogPostServicoApp.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um problema inesperado, por favor tente novamente.");
            }

        }

        [HttpPost]
        [Route("/api/posts")]
        public async Task<IActionResult> CriarPost([FromBody] PostCommand command)
        {
            try
            {
                var oBlogPostDto = new BlogPostDto(command.Titulo, command.Conteudo);

                var oResultado = await _blogPostServicoApp.Adicionar(oBlogPostDto);

                return oResultado.Sucesso ? Ok(oResultado.Resultado) : BadRequest(oResultado.Resultado);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um problema inesperado, por favor tente novamente.");
            }
        }

        [HttpPost]
        [Route("/api/posts/{id}/comments")]
        public async Task<IActionResult> AdicionarComentario(Guid id, string? comment)
        {
            try
            {
                var oResultado = await _commentServicoApp.AdicionarComentario(id, comment);

                return oResultado.Sucesso ? Ok(oResultado.Resultado) : BadRequest(oResultado.Resultado);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um problema inesperado, por favor tente novamente.");
            }
        }
    }
}
