using Filmoteka.Models;
using System.Text.Json;

namespace Filmoteka.Services
{
    /// <summary>
    /// Клас, відповідальний за збереження та завантаження колекції фільмів у файл формату JSON.
    /// Використовує вбудовану бібліотеку System.Text.Json.
    /// </summary>
    public class FileManager
    {
        /// <summary>
        /// Шлях до файлу, в якому зберігаються дані колекції.
        /// Файл розташовується у тій самій папці, що й виконуваний файл програми.
        /// </summary>
        private string filePath;

        /// <summary>
        /// Конструктор класу. Визначає шлях до файлу films.json.
        /// </summary>
        public FileManager()
        {
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "films.json");
        }

        /// <summary>
        /// Зберігає список фільмів у файл формату JSON.
        /// Виконує серіалізацію об'єктів у текстовий формат і записує його на диск.
        /// </summary>
        /// <param name="films">Список фільмів для збереження.</param>
        public void Save(List<Film> films)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(films, options);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Завантажує список фільмів із файлу JSON.
        /// Якщо файл не існує, повертає порожній список.
        /// Якщо файл пошкоджений, виводить повідомлення про помилку та повертає порожній список.
        /// </summary>
        /// <returns>Список фільмів, завантажений із файлу.</returns>
        public List<Film> Load()
        {
            if (!FileExists())
                return new List<Film>();

            try
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Film>>(json) ?? new List<Film>();
            }
            catch (JsonException)
            {
                // Файл пошкоджений, повертаємо порожню колекцію
                return new List<Film>();
            }
        }

        /// <summary>
        /// Перевіряє, чи існує файл із даними.
        /// </summary>
        /// <returns>true, якщо файл існує; інакше false.</returns>
        public bool FileExists()
        {
            return File.Exists(filePath);
        }
    }
}