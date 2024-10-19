using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Translate.AspNetCore.Mvc.Models
{
	public class RegisterModel
	{
		[Key]
		public int Id { get; set; }	

		[Required(ErrorMessage ="İSİM ALANI ZORUNLU")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "SOYİSİM ALANI ZORUNLU")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "E-POSTA ALANI ZORUNLU")]
		public string Email { get; set; }
		[Required(ErrorMessage = "ŞİFRE ALANI ZORUNLU")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
