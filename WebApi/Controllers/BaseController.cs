using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private PlayersService playersService;

        public BaseController(PlayersService playersService)
        {
            this.playersService = playersService;
        }

        private Player? player = null;

        public Player CurrentPlayer
        {
            get
            {
                if(player == null)
                {
                    player = playersService.GetPlayerFromUserId(UserId);
                }
                return player;
            }
        }

        public string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier)!; ;
            }
        }
    }
}

