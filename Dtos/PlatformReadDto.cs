using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos // Gelen bütün dataları okuyacak olan class
{
    public class PlatformReadDto
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Cost { get; set; }
    }
}