namespace Translate.AspNetCore.Mvc.Models
{
    public class WordModel
    {
        public int Id { get; set; } // Benzersiz ID
        public string English { get; set; } // İngilizce kelime
        public string Turkish { get; set; } // Türkçe kelime
        public int WordTypeId { get; set; } // Kelime türü ID
        public int WordLevelId { get; set; } // Kelime seviyesi ID

        // Navigation Property
        public virtual WordTypeModel WordType { get; set; }
        public virtual WordLevelModel WordLevel { get; set; }
    }
}
