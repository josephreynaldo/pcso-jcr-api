namespace pcso_jcr_api.Models
{
    public class Project
    {
        public int id { get; set; }

        public string? name { get; set; }

        public int sectorID { get; set; }

        public int departmentID { get; set; }

        public int projectPercentage { get; set; }
    }
}
