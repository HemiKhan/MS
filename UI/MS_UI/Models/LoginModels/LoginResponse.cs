namespace MS_UI.Models.LoginModels
{
    public class LoginResponse
    {
        public string UserId { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int EmployeeCode { get; set; }
        public int DepartmentCode { get; set; }
    }
}
