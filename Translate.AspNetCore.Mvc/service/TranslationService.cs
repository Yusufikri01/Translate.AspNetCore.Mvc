using Translate.AspNetCore.Mvc.Entities;
using Translate.AspNetCore.Mvc.Models;

public interface ITranslationService
{
    string Translate(string word, string fromLang, string toLang);
}

public class TranslationService : ITranslationService
{
    private readonly AppDbContext _context;

    public TranslationService(AppDbContext context)
    {
        _context = context;
    }

    public string Translate(string word, string fromLang, string toLang)
    {
        if (string.IsNullOrWhiteSpace(word) || string.IsNullOrWhiteSpace(fromLang) || string.IsNullOrWhiteSpace(toLang))
        {
            return "Lütfen tüm alanları doldurun.";
        }

        WordModel translation = null;
        if (fromLang == "tr" && toLang == "en")
        {
            translation = _context.Words.FirstOrDefault(w => w.Turkish == word);
        }
        else if (fromLang == "en" && toLang == "tr")
        {
            translation = _context.Words.FirstOrDefault(w => w.English == word);
        }

        return translation != null
            ? (toLang == "tr" ? translation.Turkish : translation.English)
            : "Çeviri bulunamadı.";
    }
}
