using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.Services.Contracts;
using CinemaApp.Utils;

namespace CinemaApp.Services
{
    internal class CinemaManager : ICrudService<Cinema>,IPrintService
    {
        public void Add(Cinema cinema)
        {
            DataContext.Cinemas.Add(cinema);
            Console.WriteLine("Cinema Elave olundu");
            Console.WriteLine("-".PadRight(20, '-'));
        }

        public void Delete(int id)
        {
            foreach (var item in DataContext.Cinemas)
            {
                if (item.Id == id)
                {
                    DataContext.Cinemas.Remove(item);
                    Console.WriteLine("Cinema silindi");
                    Console.WriteLine("-".PadRight(20, '-'));
                    return;
                }
            }
            Console.WriteLine("bu id ile cinema yoxdu");
        }

        public Cinema Get(int id)
        {
            int index = FindHelper.FindCinemaIndex(id);

            if (index == -1)
            {
                return null;
            }

            return DataContext.Cinemas[index];
        }

        public List<Cinema> GetAll()
        {
            return DataContext.Cinemas;
        }

        public void Print()
        {
            foreach (var item in DataContext.Cinemas)
            {
                Console.WriteLine(item);
                Console.WriteLine("-".PadRight(20, '-'));
            }
        }

        public void Update(int id, Cinema entity)
        {
            for (int i = 0; i < DataContext.Cinemas.Count; i++)
            {
                if (DataContext.Cinemas[i].Id == id)
                {
                    DataContext.Cinemas[i] = entity;
                    Console.WriteLine("ugurla deyisdirildi");
                    return;
                }
            }
            Console.WriteLine("Bu id de cinema yoxdur");
        }
    }
}
