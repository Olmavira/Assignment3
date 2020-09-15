using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/players")]
public class PlayersController : ControllerBase
{
    private readonly ILogger<PlayersController> _logger;
    private readonly IRepository _repository;

    public PlayersController(ILogger<PlayersController> logger, IRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    [Route("getall")]
   public Task<Player[]> GetAll()
        {
            return _repository.GetAll();
        }

    [HttpGet]
    [Route("{playerId}")]
    public Task<Player> Get(string playerId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route("create")]
    public async Task<Player> Create([FromBody] NewPlayer newPlayer)
    {
        _logger.LogInformation("Creating player with name " + newPlayer.Name);
        Player player = new Player()
        {
            Id = Guid.NewGuid(),
            Name = newPlayer.Name
        };
        await _repository.Create(player);
        return player;
    }
}
