namespace Filmoteka.Models
{
    /// <summary>
    /// Клас, що описує один фільм у колекції.
    /// Містить усі основні характеристики відеофайлу, суб'єктивну оцінку та статус перегляду.
    /// </summary>
    public class Film
    {
        /// <summary>
        /// Назва фільму. Обов'язкове поле.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Студія-виробник.
        /// </summary>
        public string Studio { get; set; }

        /// <summary>
        /// Жанр фільму. Значення з переліку Genre. Обов'язкове поле.
        /// </summary>
        public Genre Genre { get; set; }

        /// <summary>
        /// Рік випуску. Допустимі значення: від 1888 до поточного року.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Режисер фільму.
        /// </summary>
        public string Director { get; set; }

        /// <summary>
        /// Виконавці головних ролей.
        /// </summary>
        public string Cast { get; set; }

        /// <summary>
        /// Короткий опис сюжету.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Суб'єктивна оцінка фільму. Значення з переліку UserRating.
        /// </summary>
        public UserRating Rating { get; set; }

        /// <summary>
        /// Розташування відеофайлу на диску.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Розмір файлу в мегабайтах. Має бути невід'ємним цілим числом.
        /// </summary>
        public int FileSizeMB { get; set; }

        /// <summary>
        /// Статус перегляду фільму. Значення з переліку WatchStatus.
        /// </summary>
        public WatchStatus Status { get; set; }

        /// <summary>
        /// Повертає зручне для відображення у списку представлення фільму: "Назва (Рік)".
        /// </summary>
        /// <returns>Рядок з назвою та роком випуску.</returns>
        public override string ToString()
        {
            return $"{Title} ({Year})";
        }
    }
}