using System.ComponentModel.DataAnnotations;

public class UserLogin
{
    [Required(ErrorMessage = "Username cannot be blank !")]
    public string userName { get; set; }
    [Required(ErrorMessage = "Password cannot be blank !")]
    public string password { get; set; }
}