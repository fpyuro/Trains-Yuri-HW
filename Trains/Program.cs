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
                    $"Время отправления {i.DepartureTime}\n" +
                    $"Пункт назначения {i.NameOfDestination}\n\n");
                }
            }
        }
        public void sortTrainByNumbers() //сортировка по номеру поезда
        {
            trains.Sort();
        }
        public void SortByDestinationAndTime() //сортировка по пункту назначения и времени отпрвления
        {
            //закончить list sort
        }
    }
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            string[] station = {"station 1" , "station 2", "station 3", "station 4",
                "station 5", "station 6","station 7","station 8", "station 9",
                "station 10","station 11"};
            Trains trainsReady = new Trains();
            DateTime endTime = new DateTime(2020, 12, 31);
            int range = (endTime - DateTime.Today).Days;

            for (uint i = 0; i < 5; ++i)
            {
                DateTime d = DateTime.Today.AddDays(rand.Next(range)); //случайная дата
                trainsReady.addTrain(new Train(i + 1, station[rand.Next(10)], d));
            }



            trainsReady.Show();
            trainsReady.infoAboutTrain(2);

            

            Console.ReadLine();
        }
    }
}
