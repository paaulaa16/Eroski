using System.ComponentModel.DataAnnotations;
namespace ApiEroski.Models
{
    public class Eroski
    {
        [Key]
        public string Seccion { get; set; }
        public int Ticket { get; set; }
      
    
    }
}