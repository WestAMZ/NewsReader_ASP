namespace NewsReader.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using NewsReader.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<NewsReader.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NewsReader.Models.Context context)
        {
            context.Category.Add(new Category() { Name = "Sport", Description = "Have the ultimate news about sport oround the world" });
            context.Category.Add(new Category() { Name = "Politic", Description = "Know about the global scene in the principals goberments in the world" });
            context.Category.Add(new Category() { Name = "top trends", Description = "Various themes of world trends" });
            context.Category.Add(new Category() { Name = "Economy", Description = "Global panoram of the commerce" });

            context.Country.Add(new Country() { Name = "United States", Region = "North America" });
            context.Country.Add(new Country() { Name = "Mexico", Region = "North America" });
            context.Country.Add(new Country() { Name = "Venezuela", Region = "LATAN" });
            context.Country.Add(new Country() { Name = "Brazil", Region = "LATAN" });
            context.Country.Add(new Country() { Name = "Pakistan", Region = "Emiratos" });
            context.Country.Add(new Country() { Name = "China", Region = "Asia" });

            context.News.Add(new News() { IdCategory = 4, IdCountry = 6,Published=new DateTime(2019,2,1), Title = "Huawei is penalized by Trump",
                Content = "Trump's comments at the G20 in Japan came after a widely anticipated meeting with Chinese President Xi Jinping. The two sides met to discuss the impasse in the trade dispute, and Huawei, one of the largest smartphone manufacturers in the world, has become a flash point in the battle.",
                Image = "http://static.t13.cl/images/sizes/1200x675/1558390188-0001go6jg.jpg" });
            context.News.Add(new News() { IdCategory = 2, IdCountry = 3,Published=new DateTime(2019,1,16), Title = "continuous protests in venezuela",
                Content = "Reporting from Caracas, Venezuela —  Venezuelans poured into the streets for continued mass demonstrations, and protesters again clashed with government forces Wednesday, a day after an opposition leader renewed calls for the military to abandon President Nicolas Maduro.",
                Image = "https://ca-times.brightspotcdn.com/dims4/default/5745279/2147483647/strip/true/crop/2048x1375+0+0/resize/840x564!/quality/90/?url=https%3A%2F%2Fca-times.brightspotcdn.com%2F49%2F1d%2F8172af11bd5e931e4b8b042d6ed6%2Fla-1556742289-z0yuy71737-snap-image" });
        }
    }
}
