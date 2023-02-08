namespace CinemaApp.Models
{
    internal class Cinema : Entity
    {
        public string Name { get; set; }
        public List<Hall> Halls { get; set; }=new List<Hall>();

        public override string ToString()
        {
            string hall = "";

            foreach (var item in Halls)
            {
                hall += item;
            }
            
            return $"{"Id",-10} {Id}\n{"Name",-10}: {Name}\n {"ZALLAR",10}\n {hall,-10}";
        }
    }
}
