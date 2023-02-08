using CinemaApp.Models.Enums;

namespace CinemaApp.Models
{
    internal class Session : Entity
    {
        public Film Film { get; set; }
        public Hall Hall { get; set; }
        public State[,] Seats { get; set; }
        public double Price { get; set; }
        public Cinema Cinema { get; set; }
        public DateTime StartTime { get; set; }

        public override string ToString()
        {
            return $"{"ID:",-7} {Id}\n{"Cinema:",-7}{Cinema.Name}\n{"Film:"}\n{Film}\n{"Hall:"}\n{Hall}\n{"Price:",-7} {Price:C}";
        }
    }
}
