using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace employeeApi.Model
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string name { get; set; } 
        public string address { get; set; }
        public decimal salary { get; set; }
        public string gender { get; set; }  
        public DateTime dob { get; set; }

        public int departmentId { get; set; }
        public department Department { get; set; }

        public TimeOnly inTime { get; set; }
        public TimeOnly outTime { get; set; }
        public string totalHrs { get; set; }

        // Self-referencing FK (reporting to another employee)
        public int? reportingId { get; set; }

        [ForeignKey("reportingId")]
        public Employee Reporting { get; set; }

        public string roleType { get; set; }


    }
}
