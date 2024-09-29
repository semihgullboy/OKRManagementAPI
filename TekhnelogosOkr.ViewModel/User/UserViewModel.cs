namespace TekhnelogosOkr.ViewModel.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentName { get; set; }
        public string ManagerName { get; set; }
        public DateTime? StartWorkDate { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public List<string> Role {  get; set; }
    }
}
