using System.ComponentModel.DataAnnotations;

namespace FlightService.Api.Dtos.Passenger
{
    public class UpdatePassengerDto
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
    }
}
