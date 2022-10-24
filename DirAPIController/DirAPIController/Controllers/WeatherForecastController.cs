using Dir.DAL.Context;
using Dir.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DirAPIController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        FolderRepository r;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, DirectoryContext context)
        {
           r = new FolderRepository(context);

            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<Folder>> Get()
        {

            return r.GetAll();
        }
    }
}