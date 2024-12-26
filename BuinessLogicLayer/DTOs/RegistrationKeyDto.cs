using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public class RegistrationKeyDto
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public DateTime Timestamp { get; set; }

        public RegistrationKeyDto() 
        {
            Id = 0;
            Key = "";
            Timestamp = DateTime.Now;
        }

        public RegistrationKeyDto(RegistrationKey registrationKey)
        {
            Id = registrationKey.Id;
            Key = registrationKey.Key;
            Timestamp = registrationKey.Timestamp;
        }

        public RegistrationKey ToEntity()
        {
            RegistrationKey registrationKey = new RegistrationKey()
            {
                Id = this.Id,
                Key = this.Key,
                Timestamp = this.Timestamp,
            };

            return registrationKey;
        }
    }
}
