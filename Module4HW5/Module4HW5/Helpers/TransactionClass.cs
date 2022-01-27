namespace Module4HW5.Helpers;

public class TransactionClass
{
    public async Task Transaction(Func<Task> func, string[] args)
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
}