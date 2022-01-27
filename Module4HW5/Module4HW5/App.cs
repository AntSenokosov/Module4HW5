using Module4HW5.Helpers;

namespace Module4HW5;

public class App
{
    public async Task Run(string[] args)
    {
        await using (var context = new SampleContextFactory().CreateDbContext(args))
        {
            var query = new Query(context);
            var transaction = new TransactionClass();
            Console.WriteLine("Запрос, который объединяет 3 таблицы и обязательно включает LEFT JOIN");
            var query1 = await query.JoinTables();
            foreach (var item in query1)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} {item.HiredDate} {item.Office.Title} {item.Title.Name}");
            }

            Console.WriteLine("Запрос, который возвращает разницу между CreatedDate/HiredDate и сегодня. Фильтрация должна быть выполнена на сервере.");
            var query2 = await query.DateDiffQuery();
            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Запрос, который обновляет 2 сущности. Сделать в одной  транзакции");
            await transaction.Transaction(() => query.UpdateEntities(), args);

            Console.WriteLine("Запрос, который добавляет сущность Employee с Title и Project");
            await transaction.TransactionVoid(() => query.AddEntityEmployee(), args);

            Console.WriteLine("Запрос, который удаляет сущность Employee");
            await transaction.Transaction(() => query.DeleteEntityEmployee(), args);

            Console.WriteLine("Запрос, который группирует сотрудников по ролям и возвращает название роли (Title) если оно не содержит ‘a’");
            var query6 = await query.GroupEmployee();
            foreach (var item in query6)
            {
                Console.WriteLine(item);
            }
        }
    }
}