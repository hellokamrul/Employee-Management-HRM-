using System.ComponentModel.DataAnnotations;

namespace Employee.Management.Api.Models.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="User Name Is Required..!")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password Is Required..!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email Is Required..!")]
        public string Email { get; set; }

    }
}
