using System.ComponentModel.DataAnnotations;

namespace MovimentationsApi.Models
{
    public class MovimentationUsecaseModel
    {
        [Key]
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}
