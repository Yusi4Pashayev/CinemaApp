namespace CinemaApp.Models
{
    internal class Hall : Entity
    {
        public string Name { get; set; }
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }

        public override string ToString()
        {
            return $"{"Id",-10} {Id}\n{"Name",-10}: {Name}\n{"Yer sayi",-10} {RowCount*ColumnCount}\n";
        }
    }
}
