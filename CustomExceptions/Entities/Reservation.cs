using System;
using CustomExceptions.Entities.Exceptions;

namespace CustomExceptions.Entities
{
    internal class Reservation
    {
        public int RoomNumber { get; private set; }
        public DateTime Checkin { get; private set; }
        public DateTime Checkout { get; private set; }

        //Construtores
        public Reservation()
        {
        }

        public Reservation(int number, DateTime checkin, DateTime checkout)
        {
            DateTime now = DateTime.Now;
            if (checkin < now || checkout < now)
            {
                throw new DomainException("Reservation dates for update must be future dates!");
            }
            if (checkin >= checkout)
            {
                throw new DomainException("Check-out date must be after check-in date");
            }
            RoomNumber = number;
            Checkin = checkin;
            Checkout = checkout;
        }

        //Função duração da hospedagem
        public int Duration()
        {
            TimeSpan duration = Checkin.Subtract(Checkout);
            return (int)duration.TotalDays;
        }

        //Função para atualizara reserva
        public void UpdateDates(DateTime checkin, DateTime checkout)
        {
            DateTime now = DateTime.Now;
            if (checkin < now || checkout < now)
            {
                throw new DomainException("Reservation dates for update must be future dates!");
            }
            if (checkin >= checkout)
            {
                throw new DomainException("Check-out date must be after check-in date");
            }
            Checkin = checkin;
            Checkout = checkout;
        }

        //Imprimir os dados
        public override string ToString()
        {
            return $"Reservation: Room {RoomNumber}, check-in: {Checkin.ToString("dd/MM/yyyy")}," +
                $" check-out: {Checkout.ToString("dd/MM/yyyy")}, {Duration()} nights";
        }
    }
}
