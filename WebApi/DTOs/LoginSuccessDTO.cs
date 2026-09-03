using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    public class LoginSuccessDTO
    {
        public LoginSuccessDTO(string token, int playerId, string playerName)
        {
            Token = token;
            PlayerId = playerId;
            PlayerName = playerName;
        }

        [Required]
        public string Token { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
    }
}
