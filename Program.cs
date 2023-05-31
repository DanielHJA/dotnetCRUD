using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore;

class Program
{
    public static void Main(string[] args)
    {
        RegisterServices(args);
    }

    private static void RegisterServices(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();
        var studentSQLService = host.Services.GetRequiredService<ISQLService<Student>>();
        var dbContext = host.Services.GetRequiredService<SchoolContext>();
        studentSQLService.initializeWithContext(dbContext);

        /*var student = new Student();
        student.FirstName = "Adam";
        student.LastName = "Andersson";
        student.EnrollmentDate = DateTime.Now;
        
        studentSQLService.Add(student);*/

        /*var res = studentSQLService.getAll();

        foreach(Student s in res)
        {
            Console.WriteLine(s.FirstName + " " + s.LastName);
        }*/

        studentSQLService.Remove(1);
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        string connectionString = "Server=localhost;Database=CTestDatabase;Uid=root;Pwd=root;";

        return Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
        {
            services.AddDbContext<SchoolContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            services.AddTransient(typeof(ISQLService<>), typeof(SQLService<>));
            services.AddScoped<SchoolContext>();
        });
    }
}