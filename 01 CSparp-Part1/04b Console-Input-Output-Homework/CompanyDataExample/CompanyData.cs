namespace CompanyDataExample
{
    using System;

    class CompanyData
    {
        // A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number. Write a program that reads the information about a company and its manager and prints them on the console.
        
        static void Main()
        {
            Console.Write("\t Enter company name:");
            string companyName = Console.ReadLine();

            Console.Write("\t Enter company adress:");
            string companyAddress = Console.ReadLine();
            
            uint companyPhone;
            while (true)
            {
                Console.Write("\t Enter company phone number:");
                if (uint.TryParse(Console.ReadLine(), out companyPhone))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            uint companyFax;
            while (true)
            {
                Console.Write("\t Enter company fax number:");
                if (uint.TryParse(Console.ReadLine(), out companyFax))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            Console.Write("\t Enter company web site:");
            string companyWeb = Console.ReadLine();

            Console.Write("\t Enter manager first name:");
            string managerFirstName = Console.ReadLine();

            Console.Write("\t Enter manager last name:");
            string managerLastName = Console.ReadLine();

            uint managerAge;
            while (true)
            {
                Console.Write("\t Enter manager age:");
                if (uint.TryParse(Console.ReadLine(), out managerAge))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            uint managerPhone;
            while (true)
            {
                Console.Write("\t Enter manager phone number:");
                if (uint.TryParse(Console.ReadLine(), out managerPhone))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t\t Invalid value. Try again");
                }
            }

            Console.WriteLine();
            Console.WriteLine("\t Company: {0}", companyName);
            Console.WriteLine("\t Adress: {0}", companyAddress);
            Console.WriteLine("\t Phone number: {0}, Fax number: {1}", companyPhone, companyFax);
            Console.WriteLine("\t Web site: {0}", companyWeb);
            Console.WriteLine("\t Manager: {0} {1}, Age: {2}", managerFirstName, managerLastName, managerAge);
            Console.WriteLine("\t Manager phone number: {0}", managerPhone);
            Console.WriteLine();
        }
    }
}
