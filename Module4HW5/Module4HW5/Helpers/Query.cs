using Microsoft.EntityFrameworkCore;

namespace Module4HW5.Helpers;

public class Query
{
    private readonly ApplicationContext _context;

    public Query(ApplicationContext context)
    {
        _context = context;
    }

    // Запрос, который возвращает разницу между CreatedDate/HiredDate и сегодня. Фильтрация должна быть выполнена на сервере.
    public async Task DateDiffQuery()
    {
        var data = await _context.Employees
            .AsNoTracking()
            .Select(s => s.HiredDate)
            .ToListAsync();
    }

    // Запрос, который обновляет 2 сущности. Сделать в одной  транзакции
    public async Task UpdateEntities()
    {
        var title = await _context.Titles.FirstOrDefaultAsync(t => t.Id == 2);
        title.Name = title.Name + Guid.NewGuid();

        var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == 3);
        project.ClientId = 2;

        await _context.SaveChangesAsync();
    }
}