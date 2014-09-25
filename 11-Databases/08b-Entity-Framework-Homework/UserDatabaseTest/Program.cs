namespace UserDatabase
{
    using System;
    using System.Linq;
    using System.Transactions;

    using UsersDB.Model;

    public class Program
    {
        public static void Main()
        {
            InsertUser("Bat Goyko");

            using (var db = new ModelContainer())
            {
                var users = db.UserSet;
                foreach (var user in users)
                {
                    Console.WriteLine("User: {0}, Group: {1}", user.Name, user.Groups.Name);
                }
            }
        }

        public static void InsertUser(string userName)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (var context = new ModelContainer())
                {
                    Group adminGroup = new Group { Name = "Admins" };

                    if (context.GroupSet.Count(x => x.Name == "Admins") == 0)
                    {
                        context.GroupSet.Add(adminGroup);
                        context.SaveChanges();
                    }

                    if (context.UserSet.Count(x => x.Name == userName) > 0)
                    {
                        Console.WriteLine("User already exists.");
                        scope.Dispose();
                        return;
                    }

                    Group currentgroup = context.GroupSet.Where(x => x.Name == "Admins").First();

                    User newUser = new User()
                    {
                        Name = userName,
                        Groups = currentgroup
                    };

                    context.UserSet.Add(newUser);
                    context.SaveChanges();

                    scope.Complete();
                }
            }
        }
    }
}

