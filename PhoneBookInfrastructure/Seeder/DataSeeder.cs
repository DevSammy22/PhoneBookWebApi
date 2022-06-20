using PhoneBookInfrastructure.Context;
using PhoneBookInfrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookInfrastructure.Seeder
{
    public class DataSeeder
    {
        public static void Seeder(AppDbContext context)
        {
            if (!context.PhoneBooks.Any())
            {
                var phonebooks = new List<PhoneBook>()
                {
                    new PhoneBook
                    {
                        Name = "Home",
                        Entries = new List<Entry>
                        {
                            new Entry() { Name = "Nerry Yurith", PhoneNumber = "3456768834" },
                            new Entry() { Name = "Kuimiyi Derry", PhoneNumber = "0456789456" },
                            new Entry() { Name = "Green Jack", PhoneNumber = "4789095322" },
                            new Entry() { Name = "Rest Jumiay", PhoneNumber = "0823456789" }
                        }
                    },
                    new PhoneBook
                    {
                        Name = "Work",
                        Entries = new List<Entry>
                        {
                            new Entry() { Name = "Gerry Kyien", PhoneNumber = "4567800452" },
                            new Entry() { Name = "Red Guy", PhoneNumber = "4514545678" },
                            new Entry() { Name = "Jurry Haimue", PhoneNumber = "0345674386" }
                        }
                    },

                     new PhoneBook
                    {
                        Name = "Other",
                        Entries = new List<Entry>
                        {
                            new Entry() { Name = "John Muyer", PhoneNumber = "0214321252" },
                            new Entry() { Name = "Ruimy Fred", PhoneNumber = "6789049633" },
                            new Entry() { Name = "Terry Kelly", PhoneNumber = "0267890286" }
                        }
                    }
                };
                context.PhoneBooks.AddRange(phonebooks);
                context.SaveChanges();
            }
        }
    }
}
