using Microsoft.EntityFrameworkCore;
using System;
using Vote.Data;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var option = new DbContextOptions<VoteDb>();
            option.

            var dbContext  = new VoteDb(option.UseSqlServer(builder.Configuration.GetConnectionString("VoteDbConnectionString"))




            Console.WriteLine("Hello World!");
        }
    }
}