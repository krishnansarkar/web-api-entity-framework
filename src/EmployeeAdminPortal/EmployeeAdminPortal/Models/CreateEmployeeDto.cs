namespace EmployeeAdminPortal.Models {
    public class CreateEmployeeDto {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public decimal Salary { get; set; }
    }
}
