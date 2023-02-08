using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.Services.Contracts;
using CinemaApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services
{
    internal class HallManager : ICrudService<Hall>, IPrintService
    {
        
        public void Add(Hall hall)
        {
            DataContext.Halls.Add(hall);
            Console.WriteLine("Zal elave olundu");
            Console.WriteLine("-".PadRight(20, '-'));
        }
        public void Add(int cinemaId, Hall hall)
        {
            int cinemaIndex = FindHelper.FindCinemaIndex(cinemaId);
            if (cinemaIndex == -1)
            {
                Console.WriteLine("Bu ID de Cinema Yoxdur");
                Console.WriteLine("-".PadRight(20, '-'));
                return;
            }
            DataContext.Cinemas[cinemaIndex].Halls.Add(hall);
            Add(hall);
        }

        public void Delete(int id)
        {
            for (int i = 0; i < DataContext.Cinemas.Count; i++)
            {
                if (DataContext.Cinemas[i] == null)
                {
                    continue;
                }

                for (int j = 0; j < DataContext.Cinemas[i].Halls.Count; j++)
                {
                    if (DataContext.Cinemas[i].Halls[j].Id == id)
                    {
                        DataContext.Cinemas[i].Halls.Remove(DataContext.Cinemas[i].Halls[j]);
                    }
                }
            }

            foreach (var item in DataContext.Halls)
            {
                if (item.Id == id)
                {
                    DataContext.Halls.Remove(item);
                    Console.WriteLine("Zal silindi");
                    Console.WriteLine("-".PadRight(20, '-'));
                    return;
                }
            }
            Console.WriteLine("Zal Tapilmadi");
        }

        public Hall Get(int id)
        {
            int index = FindHelper.FindCinemaIndex(id);

            if (index == -1)
            {
                return null;
            }

            return DataContext.Halls[index];
        }

        public List<Hall> GetAll()
        {
            return DataContext.Halls;
        }

        public void Print()
        {
            foreach (var item in DataContext.Halls)
            {
                Console.WriteLine(item);
                Console.WriteLine("-".PadRight(20, '-'));
            }
        }

        public void Update(int id, Hall entity)
        {
            for (int i = 0; i < DataContext.Cinemas.Count; i++)
            {
                if (DataContext.Cinemas[i] == null)
                {
                    continue;
                }

                for (int j = 0; j < DataContext.Cinemas[i].Halls.Count; j++)
                {
                    if (DataContext.Cinemas[i].Halls[j].Id == id)
                    {
                        DataContext.Cinemas[i].Halls[j] = entity;
                    }
                }
            }

            for (int i = 0; i < DataContext.Halls.Count; i++)
            {
                if (DataContext.Halls[i].Id == id)
                {
                    DataContext.Halls[i] = entity;
                    Console.WriteLine("ugurla deyisdirildi");
                    Console.WriteLine("-".PadRight(20, '-'));
                    return;
                }
            }
            Console.WriteLine("Bu id de Zal yoxdur");
            Console.WriteLine("-".PadRight(20, '-'));
        }
    }
}
