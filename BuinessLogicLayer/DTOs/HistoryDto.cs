using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public class HistoryDto
    {
        public int Id { get; set; }
        public string ClientPhone { get; set; }
        public string BarberPhone { get; set; }
        public string Service { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }

        public HistoryDto() 
        {
            Id = 0;
            ClientPhone = "";
            BarberPhone = "";
            Service = "";
            Date = new DateOnly();
            Time = new TimeOnly();
        }

        public HistoryDto(History history)
        {
            Id = history.Id;
            ClientPhone = history.ClientPhone;
            BarberPhone = history.BarberPhone;
            Service = history.Service;
            Date = history.Date;
            Time = history.Time;
        }

        public History ToEntity()
        {
            History history = new History()
            {
                Id = this.Id,
                ClientPhone = this.ClientPhone,
                BarberPhone = this.BarberPhone,
                Service = this.Service,
                Date = this.Date,
                Time = this.Time
            };

            return history;
        }
    }
}
