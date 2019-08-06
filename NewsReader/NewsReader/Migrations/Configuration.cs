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
            context.Country.Add(new Country() { Name = "Russia", Region = "Asia" });

            context.News.Add(new News()
            {
                IdCategory = 4, IdCountry = 6,
                Published =new DateTime(2019,2,1),
                Title = "Huawei is penalized by Trump",
                Content = "Trump's comments at the G20 in Japan came after a widely anticipated meeting with Chinese President Xi Jinping. The two sides met to discuss the impasse in the trade dispute, and Huawei, one of the largest smartphone manufacturers in the world, has become a flash point in the battle.",
                Image = "http://static.t13.cl/images/sizes/1200x675/1558390188-0001go6jg.jpg"
            });
            context.News.Add(new News()
            {
                IdCategory = 2, IdCountry = 3,
                Published =new DateTime(2019,1,16),
                Title = "continuous protests in venezuela",
                Content = "Reporting from Caracas, Venezuela —  Venezuelans poured into the streets for continued mass demonstrations, and protesters again clashed with government forces Wednesday, a day after an opposition leader renewed calls for the military to abandon President Nicolas Maduro.",
                Image = "https://ca-times.brightspotcdn.com/dims4/default/5745279/2147483647/strip/true/crop/2048x1375+0+0/resize/840x564!/quality/90/?url=https%3A%2F%2Fca-times.brightspotcdn.com%2F49%2F1d%2F8172af11bd5e931e4b8b042d6ed6%2Fla-1556742289-z0yuy71737-snap-image"
            });
            context.News.Add(new News()
            {
                IdCategory = 3,
                IdCountry = 1,
                Published = new DateTime(2019, 10, 5),
                Title = "Horror film’ mid-air: Smoke fills British Airways plane, prompts emergency landing (PHOTO, VIDEO)",
                Content = "A British Airways flight from London to Valencia, Spain was forced to make an emergency landing after the craft’s cabin filled with smoke. As of yet, no injuries have been reported.",
                Image = "https://cdni-rt.secure2.footprint.net/files/2019.08/article/5d48757edda4c8a72e8b4600.JPG"
            });
            context.News.Add(new News()
            {
                IdCategory = 3,
                IdCountry = 1,
                Published = new DateTime(2019, 11, 6),
                Title = "China vows retaliation if US deploys mid-range missiles in Asia after ripping up INF treaty",
                Content = "Beijing will move to counter Washington’s potential deployment of intermediate ground-launched missiles in Asia, foreign ministry officials have stated, joining Russia in criticizing the US for triggering a new arms race.",
                Image = "https://cdni-rt.secure2.footprint.net/files/2019.08/l/5d48f8f9fc7e935a4b8b468e.png"
            });
            context.News.Add(new News()
            {
                IdCategory = 2,
                IdCountry = 7,
                Published = new DateTime(2019, 1, 15),
                Title = "All Russian football fans are racist!... When you invent your own headlines",
                Content = "Why wait for a scoop on racism in Russian football when you can invent one? Western media did exactly that, reporting Zenit fans held a “don’t sign black players” banner to greet new signing Malcom (spoiler: that’s not true).",
                Image = "https://cdni-rt.secure2.footprint.net/files/2019.08/l/5d488733dda4c8a62e8b4607.jpg"
            });
            context.News.Add(new News()
            {
                IdCategory = 3,
                IdCountry = 1,
                Published = new DateTime(2019, 3, 17),
                Title = "Facebook shuts down viral ‘Storm Area 51’ event, reigniting UFO hunters’ resolve",
                Content = "Just as the hype seemed to have calmed down, over two million UFO enthusiasts found their Area 51 meme-filled page suddenly blocked by Facebook, under the pretext of ever-elusive “community standards” violations.",
                Image = "https://cdni-rt.secure2.footprint.net/files/2019.08/article/5d48eab7fc7e93cf508b461e.jpg"
            });

        }
    }
}
