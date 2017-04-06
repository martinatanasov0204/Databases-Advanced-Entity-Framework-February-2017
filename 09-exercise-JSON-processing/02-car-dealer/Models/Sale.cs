namespace _02_car_dealer.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int Discount { get; set; }
        public Car Car { get; set; }
        public Customer Customer { get; set; }
    }
}
