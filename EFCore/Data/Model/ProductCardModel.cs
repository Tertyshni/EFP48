namespace EFP48.EFCore.Data.Model
{ 
    public class ProductCardModel
    {
        public string CategoryName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }

        public override string ToString()
        {
            return $@"
_____________________
    image.png
_____________________
      {Name}
      {Price}
      {CategoryName}
_____________________
";
        }
    }
}
