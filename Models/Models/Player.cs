using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Models.Interfaces;

namespace Models.Models
{
	public class Player : IModel
    {
		public Player()
		{
		}

		public int Id { get; set; }
		public string Name { get; set; } = "";
		public required string UserId { get; set; }
		[JsonIgnore]
		public virtual IdentityUser User { get; set; }
    }
}

