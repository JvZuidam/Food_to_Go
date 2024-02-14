namespace Food_to_go.Models
{
    public class MealPackage
    {
        public int Id { get; set; }
        
        public string Description { get; set; }

        public Product[] Products { get; set; }
        
        public DateTime ReservedFrom { get; set; }

        public DateTime ReservedTill { get; set; }

        public bool AdultPackage { get; set; }

        public decimal Price { get; set; }

        public string MealType { get; set; }

        public Student? ReservedBy { get; set; }
    }
}
