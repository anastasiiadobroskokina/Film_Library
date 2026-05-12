namespace Filmoteka.Models
{
    /// <summary>
    /// Перелік статусів перегляду фільму.
    /// Дозволяє відстежувати, чи переглянуто фільм, чи він у процесі перегляду.
    /// </summary>
    public enum WatchStatus
    {
        Watched,      // переглянуто
        NotWatched,   // не переглянуто
        InProgress    // дивлюся зараз
    }
}