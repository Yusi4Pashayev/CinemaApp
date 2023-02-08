

using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.Services.Contracts;
using CinemaApp.Utils;

namespace CinemaApp.Services
{
    internal class FilmManager : IPrintService, ICrudService<Film>
    {
        public void Add(Film film)
        {
            DataContext.Films.Add(film);
            Console.WriteLine("Film elave olundu");
            Console.WriteLine("-".PadRight(20, '-'));

        }

        public void Delete(int id)
        {
            foreach (var item in DataContext.Films)
            {
                if (item.Id == id)
                {
                    DataContext.Films.Remove(item);
                    Console.WriteLine("Film silindi");
                    Console.WriteLine("-".PadRight(20, '-'));
                    return;
                }
            }
        }

        public Film Get(int id)
        {
            int index = FindHelper.FindFilmIndex(id);

            if (index == -1)
            {
                return null;
            }

            return DataContext.Films[index];
        }

        public List<Film> GetAll()
        {
            return DataContext.Films;
        }

        public void Print()
        {
            foreach (var item in DataContext.Films)
            {
                Console.WriteLine(item);
                Console.WriteLine("-".PadRight(20, '-'));
            }
        }

        public void Update(int id, Film entity)
        {
            for (int i = 0; i < DataContext.Films.Count; i++)
            {
                if (DataContext.Films[i].Id == id)
                {
                    DataContext.Films[i] = entity;
                    Console.WriteLine("ugurla deyisdirildi");
                    return;
                }
            }
            Console.WriteLine("Bu id de film yoxdur");
        }
    }
}
