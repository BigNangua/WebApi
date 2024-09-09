using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Todo")]
    public class TodoController : ControllerBase
    {

        private readonly ILogger<TodoController> _logger;

        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Test")]
        public string testTodo()
        {
            _logger.LogInformation("================");
            _logger.LogError("================");
            return "Hello World!";
        }

    }
}
