using System.ComponentModel.DataAnnotations;

namespace project2.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
