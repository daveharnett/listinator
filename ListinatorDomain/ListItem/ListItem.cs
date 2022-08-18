namespace ListinatorDomain
{
    public class ListItem
    {
        public Guid Id { get; set; }
        public Guid ListId { get; set; }

        public string Text { get; set; }


        public virtual List List { get; set; }
    }
}
