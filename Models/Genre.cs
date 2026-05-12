namespace Filmoteka.Models
{
    /// <summary>
    /// Перелік жанрів фільму.
    /// Використовується для обмеження можливих значень жанру та зручної фільтрації.
    /// </summary>
    public enum Genre
    {
        Action,       // бойовик
        Comedy,       // комедія
        Drama,        // драма
        Horror,       // жахи
        SciFi,        // фантастика
        Documentary,  // документальний
        Animation     // анімація
    }
}
