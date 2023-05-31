namespace MovimentationsApi.Models
{
    public class MovimentationUsecaseModel
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}
