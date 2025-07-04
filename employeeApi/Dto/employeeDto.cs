﻿using employeeApi.Model;

namespace employeeApi.Dto
{
    public class employeeDto
    {
        public int? id {  get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public decimal salary { get; set; }
        public string gender { get; set; }
        public DateTime dob { get; set; }
        public int departmentId { get; set; }
        public TimeOnly inTime { get; set; }
        public TimeOnly outTime { get; set; }
        public string totalHrs { get; set; }
        public int reportingId { get; set; }
        public string roleType { get; set; }
    }
}

