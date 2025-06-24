namespace employeeApi.Dto
{
    public class InTimeUpdateDto
    {
        public string name { get; set; }
        public TimeOnly inTime { get; set; }
        public TimeOnly outTime { get; set; }
        public string totalHrs { get; set; }
    }
}
