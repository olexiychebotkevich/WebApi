using System.Data.Entity;

namespace WebApplication2
{
    internal class CustomInit<T> : DropCreateDatabaseIfModelChanges<Factory>
    {

        protected override void Seed(Factory context)
        {
            base.Seed(context);

            context.Workers.Add(new Worker { FirstName = "Vasyan", LastName = "Vasyanchuck", Adress = "Dubno Rivnenska srt 109", Gender = "Male", Salary = 20000m });


            context.Workers.Add(new Worker { FirstName = "Petro", LastName = "Petrenko", Adress = "Rivne Soborna str 56", Gender = "Male", Salary = 9999m });


            context.Workers.Add(new Worker { FirstName = "Anna", LastName = "Klichko", Adress = "Kiew Maidan Nezalegnosti str 16", Gender = "Female", Salary = 10000m });


            context.SaveChanges();
        }
    }
}