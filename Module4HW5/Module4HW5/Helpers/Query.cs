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
}