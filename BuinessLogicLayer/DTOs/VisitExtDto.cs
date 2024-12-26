namespace BusinessLogicLayer.DTOs
{
    public class VisitExtDto
    {
        public int Id { get; set; }
        public string? fk_ClientId { get; set; }
        public int? fk_GuestId { get; set; }
        public string fk_BarberId { get; set; }
        public int fk_ServiceId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public string? VisitorFullName { get; set; }
        public string? ServiceTitle { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public VisitExtDto()
        {
            Id = 0;
            fk_ClientId = null;
            fk_GuestId = 0;
            fk_BarberId = "";
            fk_ServiceId = 0;
            Date = new DateOnly();
            Time = new TimeOnly();
            VisitorFullName = "";
            ServiceTitle = "";
            StartTime = new TimeOnly();
            EndTime = new TimeOnly();
        }

        public VisitExtDto(VisitDto visitDto, string visitorFullName, string serviceTitle, TimeOnly serviceDuration)
        {
            Id = visitDto.Id;
            fk_ClientId = visitDto.fk_ClientId;
            fk_GuestId = visitDto.fk_GuestId;
            fk_BarberId = visitDto.fk_BarberId;
            fk_ServiceId = visitDto.fk_ServiceId;
            Date = visitDto.Date;
            Time = visitDto.Time;
            VisitorFullName = visitorFullName;
            ServiceTitle = serviceTitle;
            StartTime = visitDto.Time;
            EndTime = visitDto.Time.Add(serviceDuration.ToTimeSpan());
        }
    }
}
