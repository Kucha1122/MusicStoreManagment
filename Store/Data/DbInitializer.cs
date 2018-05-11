using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Store.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<StoreDbContext>();

                //Przykladowi użytkownicy
                var janusz = new Customer
                {
                    CustomerName = "Janusz",
                    CustomerLastName = "Nowak",
                    Password = "password123",
                    CustomerEmail = "janusz.nowak@o2.pl",
                    ShippingAddress = "Akacjowa 53 Warszawa"
                };

                var andrzej = new Customer
                {
                    CustomerName = "Andrzej",
                    CustomerLastName = "Borowik",
                    Password = "qwertyzxc123",
                    CustomerEmail = "andrzej.borowik@gmail.pl",
                    ShippingAddress = "Złota 59 Warszawa"
                };

                context.Customers.Add(janusz);
                context.Customers.Add(andrzej);

                //Przykladowi tworcy
                var SOAD = new Band
                {
                    BandName = "System of a Down",
                    BandDescription = "System of a Down, często skracane do SOAD czy System – amerykański zespół wykonujący szeroko pojętą muzykę rockową i metalową. Grupa została założona w 1994 roku w Glendale w stanie Kalifornia przez muzyków pochodzenia ormiańskiego.",
                    Albums = new List<Album>()
                    {
                        new Album
                        {
                            Title ="System of a Down",
                            AlbumArtUrl="https://i.ytimg.com/vi/Az11zA__DEU/hqdefault.jpg",
                            AlbumDescription="pierwszy album zespołu System of a Down. Został wydany 30 czerwca 1998 nakładem wytwórni American Recordings.",
                            AlbumPrice=41
                        },
                        new Album
                        {
                            Title ="Hypnotize",
                            AlbumArtUrl="https://najlepszamuzyka.pl/18925-large_default/system-of-a-down-hypnotize-digipack.jpg",
                            AlbumDescription="piąty album zespołu System of a Down, wydany 22 listopada 2005 roku, czyli pół roku po Mezmerize.",
                            AlbumPrice=45
                        }
                    }
                };

                context.Bands.Add(SOAD);
                context.SaveChanges();
            }
        }
    }
}
