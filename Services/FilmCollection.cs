using Filmoteka.Models;

namespace Filmoteka.Services
{
    /// <summary>
    /// Клас, що керує колекцією об'єктів Film.
    /// Інкапсулює список фільмів та надає методи для додавання, видалення, редагування, пошуку та фільтрації.
    /// </summary>
    public class FilmCollection
    {
        /// <summary>
        /// Приватний список, у якому зберігаються всі фільми.
        /// </summary>
        private List<Film> films;

        /// <summary>
        /// Повертає загальну кількість фільмів у колекції.
        /// </summary>
        public int Count => films.Count;

        /// <summary>
        /// Конструктор класу. Ініціалізує порожній список фільмів.
        /// </summary>
        public FilmCollection()
        {
            films = new List<Film>();
        }

        /// <summary>
        /// Додає новий фільм до колекції.
        /// </summary>
        /// <param name="film">Об'єкт Film для додавання.</param>
        public void Add(Film film)
        {
            if (film == null)
                throw new ArgumentNullException(nameof(film), "Фільм не може бути null.");

            films.Add(film);
        }

        /// <summary>
        /// Видаляє вказаний фільм з колекції.
        /// </summary>
        /// <param name="film">Об'єкт Film для видалення.</param>
        /// <returns>true, якщо фільм успішно видалено; false, якщо фільм не знайдено.</returns>
        public bool Remove(Film film)
        {
            return films.Remove(film);
        }

        /// <summary>
        /// Замінює існуючий фільм новим.
        /// </summary>
        /// <param name="oldFilm">Фільм, який потрібно замінити.</param>
        /// <param name="newFilm">Новий фільм, що замінить старий.</param>
        /// <returns>true, якщо заміна виконана успішно; false, якщо старий фільм не знайдено.</returns>
        public bool Update(Film oldFilm, Film newFilm)
        {
            int index = films.IndexOf(oldFilm);
            if (index == -1)
                return false;

            films[index] = newFilm ?? throw new ArgumentNullException(nameof(newFilm), "Новий фільм не може бути null.");
            return true;
        }

        /// <summary>
        /// Повертає повний список усіх фільмів у колекції.
        /// </summary>
        /// <returns>Копія списку фільмів.</returns>
        public List<Film> GetAll()
        {
            return new List<Film>(films); // повертаємо копію, щоб оригінал не змінили ззовні
        }

        /// <summary>
        /// Шукає фільми, які містять заданий рядок у назві, режисері або студії. Пошук регістронезалежний.
        /// </summary>
        /// <param name="query">Рядок для пошуку.</param>
        /// <returns>Список знайдених фільмів.</returns>
        public List<Film> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return GetAll();

            string lowerQuery = query.ToLower();
            return films.Where(f =>
                (f.Title != null && f.Title.ToLower().Contains(lowerQuery)) ||
                (f.Director != null && f.Director.ToLower().Contains(lowerQuery)) ||
                (f.Studio != null && f.Studio.ToLower().Contains(lowerQuery))
            ).ToList();
        }

        /// <summary>
        /// Фільтрує фільми за вказаним жанром.
        /// </summary>
        /// <param name="genre">Жанр для фільтрації.</param>
        /// <returns>Список фільмів обраного жанру.</returns>
        public List<Film> FilterByGenre(Genre genre)
        {
            return films.Where(f => f.Genre == genre).ToList();
        }

        /// <summary>
        /// Фільтрує фільми за статусом перегляду.
        /// </summary>
        /// <param name="status">Статус для фільтрації.</param>
        /// <returns>Список фільмів з обраним статусом.</returns>
        public List<Film> FilterByStatus(WatchStatus status)
        {
            return films.Where(f => f.Status == status).ToList();
        }

        /// <summary>
        /// Перевіряє, чи існує фільм із вказаною назвою.
        /// </summary>
        /// <param name="title">Назва фільму.</param>
        /// <returns>true, якщо фільм з такою назвою існує; інакше false.</returns>
        public bool Exists(string title)
        {
            return films.Any(f => f.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
    }
}