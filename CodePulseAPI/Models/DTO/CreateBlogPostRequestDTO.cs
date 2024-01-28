namespace CodePulseAPI.Models.DTO
{
    public class CreateBlogPostRequestDTO
    {
        public Guid Id { get; set; }

        public String Title { get; set; }

        public String ShortDescription { get; set; }

        public String Contnet { get; set; }

        public String FeaturedImageUrl { get; set; }

        public String UrlHandle { get; set; }

        public DateTime PublishedDate { get; set; }

        public String Author { get; set; }

        public bool IsVisible { get; set; }
    }
}
