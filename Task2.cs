using System;

namespace OOP4Vardzar
{
    internal class Task2
    {
        public static void Run()
        {
            User olga = new User("Ольга", "olga@example.com", "@olga");
            User max = new User("Максим", "max@example.com", "@max");
            User anna = new User("Анна", "anna@example.com", "@anna");

            FillMaxPosts(max);
            FillOlgaPosts(olga);
            FillAnnaPosts(anna); 

            Console.WriteLine("=== Перегляд останніх 5 постів ===");
            olga.ShowLastPosts(max);

            Post target = max.GetLastPosts(1)[0];

            Console.WriteLine("=== Лайки й коментарі ===");
            Report(olga.LikePost(target), "@olga поставила лайк", "Лайк не вдався");
            Report(anna.LikePost(target), "@anna поставила лайк", "Лайк не вдався");
            Report(olga.WriteComment(target, "Круто!"), "@olga залишила коментар", "Коментар не вдався");
            Report(anna.WriteComment(target, "Дякую за пораду"), "@anna залишила коментар", "Коментар не вдався");
            Report(max.LikePost(target), "@max поставив лайк", "@max не може лайкати власний пост");
            anna.ShowLastPosts(max);

            Console.WriteLine("=== Створення поста ===");
            Post newPost = olga.CreatePost("Мій перший пост у мережі!");
            Report(newPost != null, "@olga створила пост", "Пост не створено");
            anna.ShowLastPosts(olga);

            Console.WriteLine("=== Видалення поста ===");
            Report(anna.DeletePost(newPost), "@anna видалила пост", "@anna не може видалити чужий пост");
            Report(olga.DeletePost(newPost), "@olga видалила свій пост", "Пост не видалено");
            anna.ShowLastPosts(olga);
        }

        private static void FillMaxPosts(User user)
        {
            user.AddPost("Пост 1: Теперішні відключення світла мене дратують", new DateTime(2026, 11, 1, 10, 0, 0));
            user.AddPost("Пост 2: Сьогодні відбулася важлива зустріч", new DateTime(2026, 11, 3, 12, 30, 0));
            user.AddPost("Пост 3: Планую відпочити", new DateTime(2026, 11, 5, 9, 15, 0));
            user.AddPost("Пост 4: Сьогодні випав перший сніг в цьому році", new DateTime(2026, 11, 8, 18, 45, 0));
            user.AddPost("Пост 5: Не знаю що приготувати на обід", new DateTime(2026, 11, 12, 14, 0, 0));
            user.AddPost("Пост 6: Матуся відправила мені листа", new DateTime(2026, 11, 18, 20, 10, 0));
            user.AddPost("Пост 7: На сьогодні я виконав сввій список справ", new DateTime(2026, 11, 24, 11, 5, 0));
        }

        private static void FillOlgaPosts(User user)
        {
            user.AddPost("Пост 1: сьогодні гарна погода", new DateTime(2026, 11, 2, 9, 0, 0));
            user.AddPost("Пост 2: читаю нову книгу", new DateTime(2026, 11, 6, 19, 20, 0));
            user.AddPost("Пост 3: готую вечерю", new DateTime(2026, 11, 14, 18, 30, 0));
            user.AddPost("Пост 4: ходила на прогулянку", new DateTime(2026, 11, 20, 16, 40, 0));
        }

        private static void FillAnnaPosts(User user)
        {
            user.AddPost("Пост 1: почала вчити C#", new DateTime(2026, 11, 4, 11, 10, 0));
            user.AddPost("Пост 2: склала розклад на тиждень", new DateTime(2026, 11, 9, 8, 30, 0));
            user.AddPost("Пост 3: зустрілась із друзями", new DateTime(2026, 11, 16, 20, 0, 0));
        }

        private static void Report(bool success, string okMessage, string failMessage)
        {
            if (success)
            {
                Console.WriteLine("Успішно: " + okMessage);
            }
            else
            {
                Console.WriteLine("Не вийшло: " + failMessage);
            }
        }
    }
}