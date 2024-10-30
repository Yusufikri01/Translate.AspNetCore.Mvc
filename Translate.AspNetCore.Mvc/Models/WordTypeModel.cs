namespace Translate.AspNetCore.Mvc.Models
{
    public class WordTypeModel
    {
        public int Id { get; set; } // Benzersiz ID
        public string Type { get; set; } // Kelime türü (örneğin: isim, fiil)

        // Navigation Property
        public virtual ICollection<WordModel> Words { get; set; }
    }
}
