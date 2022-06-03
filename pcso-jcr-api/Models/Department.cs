namespace pcso_jcr_api.Models
{
    public class Department
    {
        public int id { get; set; }

        public string? name { get; set; }
        
        public int sectorID {  get; set; }

        public int numberOfProject { get; set; }

        public string? percentageProj { get; set; }

        public string remarks { get; set; }

    }
}
