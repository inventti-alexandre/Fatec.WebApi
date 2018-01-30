using Fatec.Bussiness;
using Fatec.Dominio.Input;
using Fatec.Dominio.Modelos;
using Fatec.Dominio.ViewModel;
using Microsoft.AspNetCore.JsonPatch;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Fatec.WebApi.Controllers
{
    [RoutePrefix("api/Aluno")]
    public class AlunoController : ApiController
    {
        AlunoNegocio _appAluno;
        public AlunoController()
        {
            _appAluno = new AlunoNegocio();
        }

        /// <summary>
        /// Método que insere um novo aluno
        /// </summary>
        /// <param name="usuario">Input de alunos</param>
        /// <remarks>Insere um novo usuário</remarks>
        /// <response code="201">Created</response>
        /// <response code="400">BadRequest</response>
        /// <response code="500">InternalServerError</response>
        [SwaggerResponse(HttpStatusCode.Created)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "InternalServerError")]
        [ResponseType(typeof(AlunoViewModel))]
        [HttpPost]
        public IHttpActionResult Post([FromBody] AlunoInput input)
        {
            var obj = _appAluno.Adicionar(input);
            return Created(Request.RequestUri + "/" + obj.Id, obj);
        }

        /// <summary>
        /// Método que altera um aluno....
        /// </summary>
        /// <param name="id">Id do aluno</param>
        /// <returns></returns>
        /// <remarks>Deleta um aluno</remarks>
        /// <response code="202">Accepted</response>
        /// <response code="404">BadRequest</response>
        /// <response code="500">InternalServerError</response>
        [SwaggerResponse(HttpStatusCode.Accepted)]
        [SwaggerResponse(HttpStatusCode.NotFound, "NotFound")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "InternalServerError")]
        [ResponseType(typeof(AlunoViewModel))]
        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] AlunoInput input)
        {
            var obj = _appAluno.Atualizar(id, input);
            return Content(HttpStatusCode.Accepted, obj);
        }

        /// <summary>
        /// Método que altera um aluno....
        /// </summary>
        /// <param name="id">Id do aluno</param>
        /// <returns></returns>
        /// <remarks>Deleta um aluno</remarks>
        /// <response code="202">Accepted</response>
        /// <response code="404">BadRequest</response>
        /// <response code="500">InternalServerError</response>
        [SwaggerResponse(HttpStatusCode.Accepted)]
        [SwaggerResponse(HttpStatusCode.NotFound, "NotFound")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "InternalServerError")]
        [ResponseType(typeof(AlunoViewModel))]
        [Route("{id}")]
        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody] JsonPatchDocument<Aluno> input)
        {
            var obj = _appAluno.Atualizar(id, input);
            return Content(HttpStatusCode.Accepted, obj);
        }


        /// <summary>
        /// Método que exclui um aluno....
        /// </summary>
        /// <param name="id">Id do aluno</param>
        /// <returns></returns>
        /// <remarks>Deleta um aluno</remarks>
        /// <response code="200">Ok</response>
        /// <response code="404">BadRequest</response>
        /// <response code="500">InternalServerError</response>
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound, "NotFound")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "InternalServerError")]
        [ResponseType(typeof(AlunoViewModel))]
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _appAluno.Deletar(id);
            return Ok();
        }


        /// <summary>
        /// Método que obtem um aluno....
        /// </summary>
        /// <param name="id">Id do aluno</param>
        /// <returns></returns>
        /// <remarks>Insere um novo aluno</remarks>
        /// <response code="200">Ok</response>
        /// <response code="400">BadRequest</response>
        /// <response code="500">InternalServerError</response>
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest, "BadRequest")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "InternalServerError")]
        [ResponseType(typeof(AlunoViewModel))]
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_appAluno.SelecionarPorId(id));
        }
    }
}
