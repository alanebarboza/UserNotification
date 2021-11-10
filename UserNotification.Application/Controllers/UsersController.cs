using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserNotification.Domain.Commands;
using UserNotification.Domain.Interfaces.Repositories;
using UserNotification.Domain.Interfaces.Services;

namespace UserNotification.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUserServices _userServices;

        public UsersController(IUsersRepository usersRepository, IUserServices userServices)
        {
            _usersRepository = usersRepository;
            _userServices = userServices;
        }

        /// <summary>
        /// Login do Usuário
        /// </summary>
        /// <returns>Se login efetuado com sucesso.</returns>
        /// <response code="200">Login efetuado com sucesso. Em ObjectResult populado com o objecto de Users.</response>
        /// <response code="400">Usuário ou Senha inválidos.</response>
        [HttpPost("DoLogin")]
        public async Task<IActionResult> DoLogin([FromBody] LoginCommand loginCommand) => Ok(await _userServices.DoLogin(loginCommand));

        /// <summary>
        /// Inclusão do Usuário
        /// </summary>
        /// <returns>Se usuário cadastrado com sucesso.</returns>
        /// <response code="200">Usuário cadastrado com sucesso.</response>
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] CreateUserCommand createUserCommand) => Ok(await _userServices.Insert(createUserCommand));

        /// <summary>
        /// Atualização dos dados do Usuário
        /// </summary>
        /// <returns>Se o Usuário foi cadastrado.</returns>
        /// <response code="200">Usuário alterado com sucesso.</response>
        /// <response code="400">Usuário não existe.</response>
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand) =>Ok(await _userServices.Update(updateUserCommand));

        /// <summary>
        /// Exclusão do Usuário
        /// </summary>
        /// <returns>Se o Usuário excluído.</returns>
        /// <response code="200">Usuário excluído com sucesso.</response>
        /// <response code="400">Usuário não existe.</response>
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] IdCommand removeUserCommand) => Ok(await _userServices.Delete(removeUserCommand));

        /// <summary>
        /// Consulta de Usuários
        /// </summary>
        /// <returns>Lista de Usuários cadastrados.</returns>
        /// <response code="200">Lista de Users</response>
        [HttpGet("Select")]
        public async Task<IActionResult> Select() =>  Ok(await _userServices.Select());

        /// <summary>
        /// Consulta de Usuário específico
        /// </summary>
        /// <returns>Usuário cadastrado.</returns>
        /// <response code="200">Objeto de Users</response>
        [HttpGet("Select/{id}")]
        public async Task<IActionResult> Select(int id) => Ok(await _userServices.Select(id));
    }
}
