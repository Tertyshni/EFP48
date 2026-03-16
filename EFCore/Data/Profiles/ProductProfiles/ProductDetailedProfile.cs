namespace EFP48.EFCore.Data.Profiles.ProductProfiles
{
    public class ProductDetailedProfile
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;
        public override string ToString()
        {
            return $@"
 _____________________
     image.png
 _____________________
       {Name}
       {Price}
       {Description}
       {CategoryName}
       {BrandName}
 _____________________
 ";
        }
    }
}
