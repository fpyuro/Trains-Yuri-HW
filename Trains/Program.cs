using System;
using System.Collections.Generic;

#region задание
//Создайте структуру с именем train, содержащую поля: название пункта назначения, номер поезда, время отправления. 
//Ввести данные в массив из пяти элементов типа train, упорядочить элементы по номерам поездов. 
//Добавить возможность вывода информации о поезде, номер которого введен пользователем. 
//Добавить возможность сортировки массив по пункту назначения, причем поезда с одинаковыми
//пунктами назначения должны быть упорядочены по времени отправления.
#endregion

namespace Trains
{
    class Train
    {
        private uint trainNumber;
        private string nameOfDestination;
        private DateTime departureTime;
        public uint TrainNumber { get => trainNumber; set => trainNumber = value; }
        public string NameOfDestination { get => nameOfDestination; set => nameOfDestination = value; }
        public DateTime DepartureTime { get => departureTime; set => departureTime = value; }
        public Train(uint number, string dest, DateTime time)
        {
            this.TrainNumber = number;
            this.NameOfDestination = dest;
            this.DepartureTime = time;
        }
    }

    class Trains
    {
        List<Train> trains = new List<Train>();
        public void addTrain(Train train)
        {
            trains.Add(train);
        }
        public void Show() //вывод информации о всех поездах
        {
            foreach (Train i in trains)
            {
                infoAboutTrain(i.TrainNumber);
            }
        }
        public void infoAboutTrain(uint trNmb)
        {
            foreach (Train i in trains)
            {
                if (i.TrainNumber == trNmb)
                {
                    Console.WriteLine($"Поезд номер: {i.TrainNumber}\n" +
                    $"Дата отправления {i.DepartureTime.Day}" + "." + $"{i.DepartureTime.Month}" + "." + $"{i.DepartureTime.Year}\n" +
                    $"Пункт назначения {i.NameOfDestination}");
                }
            }
        }
        public void sortTrainByNumbers() //сортировка по номеру поезда
        {
            trains.Sort((x,y)=> { return (int)x.TrainNumber - (int)y.TrainNumber; });
        }
        public void SortByDestinationAndTime() //сортировка по пункту назначения и времени отпрвления
        {
            trains.Sort((x, y) =>
            {
                if(x.NameOfDestination.Equals(y.NameOfDestination))
                {
                    if (x.DepartureTime < y.DepartureTime) return -1;
                    else return 1;
                }
                else
                {
                    for(int i = 0; i < (x.NameOfDestination.Length < y.NameOfDestination.Length ? x.NameOfDestination.Length : y.NameOfDestination.Length); ++i)
                    {
                        if (x.NameOfDestination[i] < y.NameOfDestination[i]) return -1;
                        if (x.NameOfDestination[i] > y.NameOfDestination[i]) return 1;
                        if (i == (x.NameOfDestination.Length < y.NameOfDestination.Length ? x.NameOfDestination.Length : y.NameOfDestination.Length) - 1) return 1;
                    }
                    return 1;
                }
            });
        }
    }
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            string[] station = {"station 1" , "station 2", "station 3", "station 4",
                "station 5", "station 6","station 7","station 8", "station 9"};
            Trains trainsReady = new Trains();
            DateTime endTime = new DateTime(2020, 12, 31); //сстроки 74-75 написаны для создания даты со случайным начением дня
            int range = (endTime - DateTime.Today).Days;

            for (uint i = 20; i > 0; --i)
            {
                DateTime d = DateTime.Today.AddDays(rand.Next(range)); //случайная дата(случайныйтолько день месяца)
                trainsReady.addTrain(new Train(i + 1, station[rand.Next(9)], d));
            }


            Console.WriteLine("\nСоздали штук 20 поездов, с отпракой в разные дни:\n");
            trainsReady.Show();
            Console.WriteLine("Информация о 4 поезде:\n");
            trainsReady.infoAboutTrain(2);
            Console.WriteLine("Сортируем поезда по номерам:\n");
            trainsReady.sortTrainByNumbers();
            trainsReady.Show();
            Console.WriteLine("Сортируем поезда по станции назначения и дате отправки:\n");
            trainsReady.SortByDestinationAndTime();
            trainsReady.Show();
            Console.ReadLine();
        }
    }
}
