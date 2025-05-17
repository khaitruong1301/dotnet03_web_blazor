
namespace dotnet03_web_blazor.Models.ViewModels;

using System.ComponentModel.DataAnnotations;



public class UserRegister
{
    [Required(ErrorMessage = "Username cannot be blank !")]
    [MinLength(6, ErrorMessage = "text length 6 - 32 character")]
    [MaxLength(32, ErrorMessage = "text length 6 - 32 character")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Password cannot be blank !")]
    //Password từ 6 -> 32 ký tự phải có tối thiểu 1 chữ in hoa 1 ký tự đặt biệt và tối thiếu 1 số 
    [RegularExpression(
        @"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]).{6,32}$",
        ErrorMessage = "Mật khẩu phải có ít nhất 1 chữ in hoa, 1 chữ số và 1 ký tự đặc biệt.")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Fullname cannot be blank !")]

    public string FullName { get; set; }
    public bool Gender { get; set; } = true; //true name false nữ
    public string Country { get; set; } = "VietNam";
}