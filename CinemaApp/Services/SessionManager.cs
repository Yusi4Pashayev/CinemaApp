using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.Models.Enums;
using CinemaApp.Services.Contracts;
using CinemaApp.Utils;
using System.Diagnostics;

namespace CinemaApp.Services
{
    internal class SessionManager : ICrudService<Session>, IPrintService
    {
        public void Add(int sessionId, int cinemaId, int hallId, int filmId, int price, DateTime startTime)
        {
            int cinemaIndex = FindHelper.FindCinemaIndex(cinemaId);
            int filmIndex = FindHelper.FindFilmIndex(filmId);
            Hall hallForSession = new Hall();

            if (cinemaIndex == -1)
            {
                Console.WriteLine("Bu ID de Cinema yoxdur");
                return;
            }
            if (filmIndex == -1)
            {
                Console.WriteLine("Bu id de film yoxdur");
                return;
            }
            for (int i = 0; i < DataContext.Cinemas[cinemaIndex].Halls.Count; i++)
            {
                if (DataContext.Cinemas[cinemaIndex].Halls[i].Id == hallId)
                {
                    hallForSession = DataContext.Cinemas[cinemaIndex].Halls[i];
                }
            }

            Session session1 = new Session()
            {
                Price = price,
                Cinema = DataContext.Cinemas[cinemaIndex],
                Film = DataContext.Films[filmIndex],
                Hall = hallForSession,
                StartTime = startTime,
                Seats = new State[hallForSession.RowCount, hallForSession.ColumnCount],
                Id = sessionId

            };
            Add(session1);
        }

        public void Add(Session session)
        {
            DataContext.Sessions.Add(session);
            Console.WriteLine("Added");
        }

        public void Delete(int id)
        {
            int index = FindHelper.FindSessionIndex(id);

            if (index == -1)
            {
                Console.WriteLine("Not found");

                return;
            }

            DataContext.Sessions.RemoveAt(index);
            Console.WriteLine("Deleted");
        }

        public Session Get(int id)
        {
            int index = FindHelper.FindSessionIndex(id);

            if (index == -1)
            {
                Console.WriteLine("Not found");

                return null;
            }

            return DataContext.Sessions[index];
        }

        public List<Session> GetAll()
        {
            return DataContext.Sessions;
        }

        public void Print()
        {
            foreach (var item in DataContext.Sessions)
            {
                Console.WriteLine(item);
                Console.WriteLine("-".PadRight(20, '-'));
            }
        }
        public void Update(int sessionId, int newSessionId, int cinemaId, int hallId, int filmId, int price, DateTime startTime)
        {
            int cinemaIndex = FindHelper.FindCinemaIndex(cinemaId);
            int filmIndex = FindHelper.FindFilmIndex(filmId);
            Hall hallForSession = new Hall();

            if (cinemaIndex == -1)
            {
                Console.WriteLine("Bu ID de Cinema yoxdur");
                return;
            }
            if (filmIndex == -1)
            {
                Console.WriteLine("Bu id de film yoxdur");
                return;
            }
            for (int i = 0; i < DataContext.Cinemas[cinemaIndex].Halls.Count; i++)
            {
                if (DataContext.Cinemas[cinemaIndex].Halls[i].Id == hallId)
                {
                    hallForSession = DataContext.Cinemas[cinemaIndex].Halls[i];
                }
            }

            Session session1 = new Session()
            {
                Price = price,
                Cinema = DataContext.Cinemas[cinemaIndex],
                Film = DataContext.Films[filmIndex],
                Hall = hallForSession,
                StartTime = startTime,
                Seats = new State[hallForSession.RowCount, hallForSession.ColumnCount],
                Id = newSessionId

            };
            Update(sessionId, session1);

        }
        public void Update(int id, Session newSession)
        {
            int index = FindHelper.FindSessionIndex(id);

            if (index == -1)
            {
                Console.WriteLine("Not found");

                return;
            }

            DataContext.Sessions[index] = newSession;
            Console.WriteLine("Seas Melumatlari deyisdirildi");
        }

        public void PrintSessionSeats(int id)
        {
            int indexSession = FindHelper.FindSessionIndex(id);
            Session session = DataContext.Sessions[indexSession];
            Console.WriteLine(session);
            Console.WriteLine("S/S");
            for (int i = 0; i < session.Seats.GetLength(1); i++)
                Console.Write($"{i + 1,-3}");

            Console.WriteLine();

            for (int i = 0; i < session.Seats.GetLength(0); i++)
            {
                Console.Write($"{i + 1,-3}");

                for (int j = 0; j < session.Seats.GetLength(1); j++)
                {
                    Console.Write($"{(int)session.Seats[i, j],-3}");
                }

                Console.WriteLine();
            }
        }

        public void PrintSessionByCinema(int cinemaId)
        {
            foreach (var item in DataContext.Sessions)
            {
                if (item.Cinema.Id == cinemaId)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("-".PadRight(20, '-'));
                }
            }
        }
    }
}
