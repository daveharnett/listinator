namespace ListinatorDomain
{
    public class ListDto
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public virtual ICollection<string> Items { get; set; }

    }
}
