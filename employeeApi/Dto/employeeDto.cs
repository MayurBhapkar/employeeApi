namespace employeeApi.Dto
{
    public class employeeDto
    {
        public string name { get; set; }
        public string address { get; set; }
        public decimal salary { get; set; }
        public string gender { get; set; }
        public DateTime dob { get; set; }

        public int departmentId { get; set; }
    }
}

