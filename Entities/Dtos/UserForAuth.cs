using Core.Entities;

namespace Entities.Dtos
{
    public class UserForAuth : IDto
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}