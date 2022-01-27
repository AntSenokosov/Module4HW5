using Microsoft.EntityFrameworkCore;
using Module4HW5.Entities;

namespace Module4HW5.Helpers;

public class Query
{
    private readonly ApplicationContext _context;

    public Query(ApplicationContext context)
    {
        _context = context;
    }

    // Запрос, который объединяет 3 таблицы и обязательно включает LEFT JOIN
    public async Task<List<Employee>> JoinTables()
    {
        var data = await _context.Employees
            .Include(e => e.Office)
            .Include(e => e.Title)
            .ToListAsync();

        return data;
    }

    // Запрос, который возвращает разницу между CreatedDate/HiredDate и сегодня. Фильтрация должна быть выполнена на сервере.
    public async Task<List<string>> DateDiffQuery()
    {
        var data = await _context.Employees
            .AsNoTracking()
            .Select(s => s.HiredDate)
            .ToListAsync();

        var result = data.Select(r => (DateTime.UtcNow - r).ToString());

        return result.ToList();
    }

    // Запрос, который обновляет 2 сущности. Сделать в одной  транзакции
    public async Task<bool> UpdateEntities()
    {
        var title = await _context.Titles.FirstOrDefaultAsync(t => t.Id == 2);

        if (title == null)
        {
            return false;
        }

        title.Name = title.Name + Guid.NewGuid();

        var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == 3);
        project.ClientId = 2;

        await _context.SaveChangesAsync();

        return true;
    }

    // Запрос, который добавляет сущность Employee с Title и Project
    public async Task AddEntityEmployee()
    {
        var employee = new Employee()
        {
            FirstName = "Firstname",
            LastName = "Lastname",
            HiredDate = new DateTime(2021, 6, 29),
            OfficeId = 2,
            TitleId = 4
        };

        await _context.AddAsync(employee);

        await _context.SaveChangesAsync();
    }

    // Запрос, который удаляет сущность Employee
    public async Task<bool> DeleteEntityEmployee()
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == 8);

        if (employee == null)
        {
            return false;
        }

        _context.Employees.Remove(employee);

        await _context.SaveChangesAsync();

        return true;
    }

    // Запрос, который группирует сотрудников по ролям и возвращает название роли (Title) если оно не содержит ‘a’
    public async Task<List<string>> GroupEmployee()
    {
        var data = await _context.Employees
            .AsNoTracking()
            .Include(e => e.Title)
            .GroupBy(t => t.Title.Name)
            .Select(g => new
            {
                Name = g.Key,
                Count = g.Count()
            })
            .Where(g => !g.Name.Contains("a"))
            .ToListAsync();

        var result = data.Select(e => $"{e.Name} {e.Count}".ToString());

        return result.ToList();
    }
}