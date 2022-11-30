using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControllerGame : ControllerBase
    {
        private readonly ILogger<ControllerGame> _logger;
        private readonly Client client;

        public ControllerGame(ILogger<ControllerGame> logger, Client client)
        {
            _logger = logger;
            this.client = client;
        }

        [HttpGet("galaga")]
        public IActionResult Getgalaga()
        {
            return Ok("{\"content\":" + "\"" + client.galaga?.Replace("\n", "@") + "\"" + "}");
        }

        [HttpGet("altbeast")]
        public IActionResult Getaltbeast()
        {
            return Ok("{\"content\":" + "\"" + client.altbeast?.Replace("\n", "@") + "\"" + "}");
        }

        [HttpGet("ddonpach")]
        public IActionResult Getddonpach()
        {
            return Ok("{\"content\":" + "\"" + client.ddonpach?.Replace("\n", "@") + "\"" + "}");
        }

        [HttpGet("ffight")]
        public IActionResult Getffight()
        {
            return Ok("{\"content\":" + "\"" + client.ffight?.Replace("\n", "@") + "\"" + "}");
        }

        [HttpGet("frogger")]
        public IActionResult Getfrogger()
        {
            return Ok("{\"content\":" + "\"" + client.frogger?.Replace("\n", "@") + "\"" + "}");
        }

        [HttpGet("goldenaxe")]
        public IActionResult Getgoldenaxe()
        {
            return Ok("{\"content\":" + "\"" + client.goldenaxe?.Replace("\n", "@") + "\"" + "}");
        }

        [HttpGet("mmancp2u")]
        public IActionResult Getmmancp2u()
        {
            return Ok("{\"content\":" + "\"" + client.mmancp2u?.Replace("\n", "@") + "\"" + "}");
        }

        [HttpGet("pacman")]
        public IActionResult Getpacman()
        {
            return Ok("{\"content\":" + "\"" + client.pacman?.Replace("\n", "@") + "\"" + "}");
        }

        [HttpGet("raiden2")]
        public IActionResult Getraiden2()
        {
            return Ok("{\"content\":" + "\"" + client.raiden2?.Replace("\n", "@") + "\"" + "}");
        }
    }
}