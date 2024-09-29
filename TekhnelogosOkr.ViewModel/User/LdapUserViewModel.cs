namespace TekhnelogosOkr.ViewModel.User
{
    public class LdapUserViewModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? StartWorkDate { get; set; }
        public int? DepartmentID { get; set; }
        public int? ManagerID { get; set; }
        public string? EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public int? RoleID { get; set; }
    }
}
