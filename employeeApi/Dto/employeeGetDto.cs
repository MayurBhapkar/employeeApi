namespace employeeApi.Dto
{
    public class employeeGetDto
    {
        public int id { get; set; }
        public string name { get; set; }

        public string address { get; set; }
        public decimal salary { get; set; }
        public string gender { get; set; }
        public DateTime dob { get; set; }
        public string roleType { get; set; }
        public string departmentName { get; set; }
        public string reportingName { get; set; }

        public TimeOnly inTime { get; set; }
        public TimeOnly outTime { get; set; }
        public string totalHrs { get; set; }
    }

    
    
   
    
   
}
