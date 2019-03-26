namespace WebApplication2
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Factory : DbContext
    {
       
        public Factory()
            : base("name=Factory")
        {
            Database.SetInitializer<Factory>(new CustomInit<Factory>());
        }

       

         public virtual DbSet<Worker> Workers { get; set; }
    }

    public class Worker
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public decimal Salary { get; set; }

        public string Gender { get; set; }
    }
}