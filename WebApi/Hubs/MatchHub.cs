using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs;

// [Authorize] TODO à décommenter pendant le merge du TP1
public class MatchHub : Hub
{
    public MatchHub()
    {
    }
}