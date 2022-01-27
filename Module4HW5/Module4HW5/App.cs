using Module4HW5.Helpers;

namespace Module4HW5;

public class App
{
    public async Task Run(string[] args)
    {
        await using (var context = new SampleContextFactory().CreateDbContext(args))
        {
            var query = new Query(context);
            await TransactionClass.Transaction(() => query.JoinTables(), args);
            await TransactionClass.Transaction(() => query.DateDiffQuery(), args);
            await TransactionClass.Transaction(() => query.UpdateEntities(), args);
            await TransactionClass.Transaction(() => query.AddEntityEmployee(), args);
            await TransactionClass.Transaction(() => query.DeleteEntityEmployee(), args);
            await TransactionClass.Transaction(() => query.GroupEmployee(), args);
        }
    }
}