using CinemaApp.Data;
using CinemaApp.Models;
using CinemaApp.Models.Enums;
using CinemaApp.Services;
using System;

namespace CinemaApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var venera = new Hall
            {
                Id = 1,
                Name = "Venera",
                RowCount = 10,
                ColumnCount = 12
            };

            var mercuri = new Hall
            {
                Id = 2,
                Name = "Mercuri",
                RowCount = 6,
                ColumnCount = 6
            };

            var yupiter = new Hall
            {
                Id = 3,
                Name = "Yupiter",
                RowCount = 6,
                ColumnCount = 6
            };

            var cinemaPlus = new Cinema
            {
                Id = 1,
                Name = "CinemaPlus",
            };

            var nizamiKino = new Cinema
            {
                Id = 2,
                Name = "Nizami kinoteatr",
            };

            var filmSeven = new Film
            {
                Id = 1,
                Name = "Seven",
                Director = "Nolan",
                TimeInMinute = 95
            };

            var filmZodiac = new Film
            {
                Id = 2,
                Name = "Zodiac",
                Director = "Nolan",
                TimeInMinute = 135
            };

            var cinemaManager = new CinemaManager();


            var hallManager = new HallManager();
            var filmManager = new FilmManager();
            var sessionManager = new SessionManager();
            var ticketManager = new TicketManager(sessionManager, cinemaManager);

            string command;
            int id, cinemaId, hallId, filmId, day, hour, minute, price,id1;

            while (true)
            {
                do
                {
                    Console.Write("Write command:");
                    command = (Console.ReadLine().ToLower()).Trim();
                    id = 0;

                    switch (command)
                    {
                        case "add cinema":
                            cinemaManager.Add(cinemaPlus);
                            cinemaManager.Add(nizamiKino);

                            break;
                        case "delete cinema":
                            Console.Write("Silmek istediyniz cinemanin id sini daxil edin:");
                            id = int.Parse(Console.ReadLine());
                            cinemaManager.Delete(id);
                            break;
                        case "update cinema":
                            Console.Write("Deyismek istediyniz cinemanin id sini daxil edin:");
                            id = int.Parse(Console.ReadLine());
                            /*inemaManager.Update(id, flameTowrs);*/
                            break;
                        case "print cinemas":
                            cinemaManager.Print();
                            break;
                        case "add hall":
                            id = int.Parse(Console.ReadLine());
                            hallManager.Add(id, venera);
                            hallManager.Add(id, yupiter);
                            hallManager.Add(id, mercuri);
                            break;
                        case "delete hall":
                            Console.Write("Silmek istediyniz zalin id sini daxil edin:");
                            id = int.Parse(Console.ReadLine());
                            hallManager.Delete(id);
                            break;
                        case "update hall":
                            Console.Write("Deyismek istediyniz zalin id sini daxil edin:");
                            id = int.Parse(Console.ReadLine());
                            //hallManager.Update(id,);
                            break;
                        case "print halls":
                            hallManager.Print();
                            break;
                        case "add film":
                            filmManager.Add(filmSeven);
                            filmManager.Add(filmZodiac);
                            break;
                        case "delete film":
                            Console.Write("Silmek istediyiniz filmin id sini daxil edin:");
                            id = int.Parse(Console.ReadLine());
                            filmManager.Delete(id);
                            break;
                        case "update film":
                            Console.Write("Deyismek istediyiniz filmin id sini daxil edin:");
                            id = int.Parse(Console.ReadLine());
                            //filmManager.Update(id, filmForUpdate);
                            break;
                        case "print films":
                            filmManager.Print();
                            break;
                        case "add session":
                            Console.Write("Seans ucun Id daxil edin:");
                            id = int.Parse(Console.ReadLine());
                            cinemaManager.Print();
                            Console.Write("Hansi Cinema ucun seans elave etmek isteyirsiniz?\n ID:");
                            cinemaId = int.Parse(Console.ReadLine());
                            Console.Write("Zal Secin\n ID:");
                            hallId = int.Parse(Console.ReadLine());
                            Console.Write("Film Secin\n ID:");
                            filmManager.Print();
                            filmId = int.Parse(Console.ReadLine());
                            Console.Write("Seans ucun gun secin:");
                        day:
                            day = int.Parse(Console.ReadLine());
                            if (day < 0 || day > 28)
                            {
                                Console.WriteLine("gunu dogru daxil et");
                                goto day;
                            }
                            Console.Write("Seansin baslama vaxtini qeyd edin\nSaat:");
                        hour:
                            hour = int.Parse(Console.ReadLine());
                            if (hour < 0 || hour > 59)
                            {
                                Console.WriteLine("saati dogru daxil et");
                                goto hour;
                            }
                            Console.Write("deqiqe:");
                            minute = int.Parse(Console.ReadLine());
                            Console.Write("Bura qeder gelmisen. qiymetini de yaz:");
                        price:
                            price = int.Parse(Console.ReadLine());
                            if (price > 15)
                            {
                                Console.WriteLine("insafin olsun");
                                goto price;
                            }
                            if (price < 0)
                            {
                                Console.WriteLine("havayi oldu");
                                goto price;
                            }

                            var time1 = new DateTime(2023, 2, day, hour, minute, 0);
                            sessionManager.Add(id, cinemaId, hallId, filmId, price, time1);
                            break;
                        case "update session":
                            Console.Write("Hasni seasni deyisdirek\nID:");
                            id = int.Parse(Console.ReadLine());
                            Console.Write("Teze seansin Id si ne olsun?  :");
                            id1 = int.Parse(Console.ReadLine());
                            cinemaManager.Print();
                            Console.Write("Hansi Cinema ucun seans elave etmek isteyirsiniz?\n ID:");
                            cinemaId = int.Parse(Console.ReadLine());
                            Console.Write("Zal Secin\n ID:");
                            hallId = int.Parse(Console.ReadLine());
                            Console.Write("Film Secin\n ID:");
                            filmManager.Print();
                            filmId = int.Parse(Console.ReadLine());
                            Console.Write("Seans ucun gun secin:");
                        day1:
                            day = int.Parse(Console.ReadLine());
                            if (day < 0 || day > 28)
                            {
                                Console.WriteLine("gunu dogru daxil et");
                                goto day1;
                            }
                            Console.Write("Seansin baslama vaxtini qeyd edin\nSaat:");
                        hour1:
                            hour = int.Parse(Console.ReadLine());
                            if (hour < 0 || hour > 59)
                            {
                                Console.WriteLine("saati dogru daxil et");
                                goto hour1;
                            }
                            Console.Write("deqiqe:");
                            minute = int.Parse(Console.ReadLine());
                            Console.Write("Bura qeder gelmisen. qiymetini de yaz:");
                        price1:
                            price = int.Parse(Console.ReadLine());
                            if (price > 15)
                            {
                                Console.WriteLine("insafin olsun");
                                goto price;
                            }
                            if (price < 0)
                            {
                                Console.WriteLine("havayi oldu");
                                goto price1;
                            }

                            var time2 = new DateTime(2023, 2, day, hour, minute, 0);
                            sessionManager.Update(id ,id1, cinemaId, hallId, filmId, price, time2);
                            break;
                        case "print sessions":
                            sessionManager.Print();
                            break;
                        case "print session with id":
                            Console.Write("Baxmaq istediyiniz seansin id sini daxil edin:");
                            id = int.Parse(Console.ReadLine());
                            sessionManager.PrintSessionSeats(id);
                            break;
                        case "buy ticket":
                            ticketManager.BuyTicket();
                            break;
                    }

                } while (command == "quit");
            }
        }
    }
}