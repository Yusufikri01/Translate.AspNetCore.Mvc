namespace Translate.AspNetCore.Mvc.Models
{
    public class WordLevelModel
    {
        public int Id { get; set; } // Benzersiz ID
        public string Level { get; set; } // Seviye adı (örneğin: Başlangıç, Orta, İleri)

        // Navigation Property
        public virtual ICollection<WordModel> Words { get; set; }
    }
}
