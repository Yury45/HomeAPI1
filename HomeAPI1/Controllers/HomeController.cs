using HomeApi.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;
using System;
using AutoMapper;
using HomeAPI1.Contracts.Home;

namespace HomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class HomeController : ControllerBase
    {
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;

        public HomeController(IOptions<HomeOptions> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        [HttpGet] // Для обслуживания Get-запросов
        [Route("info")] // Настройка маршрута с помощью атрибутов
        public IActionResult Info()
        {
            var infoResponse = _mapper.Map<HomeOptions, InfoResponse>(_options.Value);

            return StatusCode(200, infoResponse);
        }
    }
}
