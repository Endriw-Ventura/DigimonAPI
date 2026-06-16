namespace DigimonAPI.Domain.Entities
{
    public class Digimon
    {
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;

        public Digimon(string name, string level, string img)
        {
            Name = name;
            Level = level;
            Img = img;
        }
    }
}
