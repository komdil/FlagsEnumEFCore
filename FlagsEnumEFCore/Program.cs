// See https://aka.ms/new-console-template for more information
using FlagsEnumEFCore;

SeedData();
using (MyDbContext context = new MyDbContext())
{
    var userAsCustomerAndAdmin = context.Set<User>().Single(s => s.Role == (Role.Customer | Role.Admin));
    var userAsEmployeeCustomerAndAdmin = context.Set<User>().Single(s => s.Role == (Role.Customer | Role.Admin | Role.Employee));
    var userAsEmployeeCustomerManagerAndAdmin = context.Set<User>().Single(s => s.Role == (Role.Customer | Role.Admin | Role.Employee | Role.Manager));

    var allAdmins = context.Set<User>().Where(s => s.Role.HasFlag(Role.Admin)).ToList();//3 users
    var allEmployees = context.Set<User>().Where(s => s.Role.HasFlag(Role.Employee)).ToList();//2 users
    var allCustomer = context.Set<User>().Where(s => s.Role.HasFlag(Role.Customer)).ToList();//2 users

    foreach (var user in context.Set<User>())
    {
        Console.WriteLine(user.Role);
    }
}

Console.ReadLine();


void SeedData()
{
    using (MyDbContext context = new MyDbContext())
    {
        if (context.Database.EnsureCreated())
        {
            var userAsCustomerAndAdmin = new User() { Id = Guid.NewGuid(), Role = Role.Customer | Role.Admin };
            context.Add(userAsCustomerAndAdmin);

            var userAsEmployeeCustomerAndAdmin = new User() { Id = Guid.NewGuid(), Role = Role.Customer | Role.Admin | Role.Employee };
            context.Add(userAsEmployeeCustomerAndAdmin);

            var userAsEmployeeCustomerManagerAndAdmin = new User() { Id = Guid.NewGuid(), Role = Role.Customer | Role.Admin | Role.Employee | Role.Manager };
            context.Add(userAsEmployeeCustomerManagerAndAdmin);

            context.SaveChanges();
        }
    }
}