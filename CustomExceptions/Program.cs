using System;
using CustomExceptions.Entities;
using CustomExceptions.Entities.Exceptions;
namespace CustomExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Room Number:");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Check-in date (dd/mm/yyyy):");
                DateTime checkin = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/mm/yyyy):");
                DateTime checkout = DateTime.Parse(Console.ReadLine());
                Reservation reservation = new Reservation(number, checkin, checkout);
                Console.WriteLine(reservation);

                Console.WriteLine("\nEnder data to update reservation:");
                Console.Write("Check-in date (dd/mm/yyyy):");
                checkin = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/mm/yyyy):");
                checkout = DateTime.Parse(Console.ReadLine());
                reservation.UpdateDates(checkin, checkout);
                Console.WriteLine(reservation);
            }
            catch (DomainException error)
            {
                Console.WriteLine($"Error in reservation: {error.Message}");
            }
            catch (FormatException error)
            {
                Console.WriteLine($"Format error: {error.Message}");
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error: {error.Message}");
            }
        }
    }
}