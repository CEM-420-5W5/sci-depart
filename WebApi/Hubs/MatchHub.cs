using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs;

[Authorize]
public class MatchHub : Hub
{
    public MatchHub()
    {
    }
}