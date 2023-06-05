namespace Bryggrens.Models.ViewModels
{
    public class AboutVM
    {
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }

        public string? GetRydasDescription()
        {
            var filePath = Path.Combine("Content", "RydgrenDescription.txt");
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            return null;
        }
    }
}
