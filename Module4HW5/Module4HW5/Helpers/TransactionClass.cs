namespace Module4HW5.Helpers;

public class TransactionClass
{
    public async Task TransactionVoid(Func<Task> func, string[] args)
    {
        await using (var transaction =
                     await new SampleContextFactory().CreateDbContext(args).Database.BeginTransactionAsync())
        {
            try
            {
                await func();
                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await transaction.RollbackAsync();
            }
        }
    }

    public async Task<T> Transaction<T>(Func<Task<T>> func, string[] args)
    {
        await using (var transaction =
                     await new SampleContextFactory().CreateDbContext(args).Database.BeginTransactionAsync())
        {
            try
            {
                var result = await func();
                await transaction.CommitAsync();
                return result;
            }
            catch
            {
                await transaction.RollbackAsync();
                return default(T);
            }
        }
    }
}