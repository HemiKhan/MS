namespace MS_UI.Models.Common
{
    public class SessionData
    {
        public int DeptCode { get; set; }
        public int EmployeeCode { get; set; }
        public string UserId { get; set; }

        public SessionData(ISession session)
        {
            DeptCode = Convert.ToInt32(session.GetInt32("DepartmentCode"));
            EmployeeCode = Convert.ToInt32(session.GetInt32("EmployeeCode"));
            UserId = Convert.ToString(session.GetString("UserId")!);
        }
    }
}
