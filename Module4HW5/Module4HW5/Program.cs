// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Module4HW5;

public class Program
{
    public static async Task Main(string[] args)
    {
        var app = new App();
        await app.Run(args);
    }
}