namespace project2.Models
{
    public class Blog
    {
       
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public bool available { get; set; }
        public Category category { get; set; }
    }
}
