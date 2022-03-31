using Microsoft.EntityFrameworkCore;
using MoviesManagement.Domain.Models;
using MoviesManagement.PersistanceDB.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesManagement.PersistanceDB.Seed
{
    public static class MovieSeed
    {
        public static void Migrate(MovieContext context)
        {
            context.Database.Migrate();
        }

        public static async Task SeedMovie(MovieContext context)
        {
            var movies = new List<Movie>()
            {
                new Movie()
                {
                    Name="სიკვდილი ნილოსზე",
                    Genre="კრიმინალური",
                    Director=" კენეტ ბრანა",
                    Actors="გალ გადოტი, კენეტ ბრანა, როუზ ლესლი",
                    StartTime= DateTime.Now.AddHours(1.2),
                    Duration= 127,
                    Story="სიკვდილი ნილოსზე - ბელგიელი სლეუტი," +
                    " ჰერკულ პუაროს ეგვიპტური არდადეგები ნილოსზე," +
                    " გადაიქცევა მკვლელის საშინელ ძიებაში," +
                    " როდესაც იდეალური წყვილის იდილიური თაფლობის თვე ტრაგიკულად შეწყდება.",
                    ImageUrl="https://ufro.ge/uploads/posts/2022-02/1644524161_1920-dotn_payoff-poster-415x614.jpg",
                    IsActive=false,
                    Archive=false


                },
                new Movie()
                {
                     Name="მთვარის დაცემა",
                    Genre="ფანტასტიკა",
                    Director="როლანდ ემერიხი",
                    Actors="ჰოლი ბერი, პატრიკ უილსონი, ჯონ ბრედლი",
                    StartTime= DateTime.Now.AddHours(1.1),
                    Duration= 120,
                    Story="იდუმალი ძალა მთვარეს დედამიწის გარშემო ორბიტიდან აძევებს და მას შეჯახების კურსზე აგზავნის." +
                    " შეჯახებამდე რამდენიმე კვირით ადრე და სამყარო განადგურების პირასაა. ",
                    ImageUrl="https://mondostudio.ge/uploads/posts/2022-02/1643796155_moonfall2022poster.jpg",
                     Archive=false
                }

                //new Movie()
                //{
                //     Name="შურისმაძიებელი",
                //    Genre="მძაფრ-სიუჟეტიანი",
                //    Director="ჯოს უიდონი",
                //    Actors="ქრის ევანსი,სკარლეტ იოჰანსონი,რობერტ დაუნ უმცროსი",
                //    StartTime= DateTime.Now.AddHours(1.1),
                //    Duration= 140,
                //    Story="როდესაც დედამიწას მოულოდნელი საფრთხე დაემუქრება, გლობალური უსაფრთხოების და დაცვის სამსახურის, S.H.I.E.L.D," +
                //    " დირექტორი ნიკ ფური გადაწყვეტს სუპერგმირების გუნდი შეკრიბოს, რათა თავიდან აიცილოს მსოფლიო მასშტაბის კატასტროფა.",
                //    ImageUrl="https://img.redbull.com/images/c_crop,x_1216,y_0,h_2160,w_1620/c_fill,w_400,h_540/q_auto:low,f_auto/redbullcom/2020/8/5/xvwyhthmpx6abefcbdsg/marvels-avengers-header-image",
                //     Archive=false
                //}


            };

            foreach (var movie in movies)
            {
                if (!await context.Movies.AnyAsync(x => x.Name == movie.Name))
                {
                    await context.Movies.AddAsync(movie);
                    await context.SaveChangesAsync();
                }


            }
        }
    }
}
