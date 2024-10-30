namespace Translate.AspNetCore.Mvc.Models
{
    public class WordBookModel
    {
        public int Id { get; set; } // Benzersiz ID

        public int WordId { get; set; } // Word tablosunun ID'si
        public int UserId { get; set; } // Users tablosunun ID'si

        // Navigation Properties
        public virtual WordModel Word { get; set; }
        public virtual UserModel User { get; set; } // Users tablosu ile ilişki
    }
}
