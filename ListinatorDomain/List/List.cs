namespace ListinatorDomain
{
    public class List
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public virtual ICollection<ListItem> Items { get; set; }

    }
}