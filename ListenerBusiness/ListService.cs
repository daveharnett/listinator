using ListinatorDal;


namespace ListinatorDomain
{
    public class ListService : IListService
    {
        private ListContext _context;

        public ListService(ListContext context)
        {
            _context = context;
        }

        public ICollection<ListSummaryDto> GetLists()
        {
            return _context.Lists.Select(l=> new ListSummaryDto { Id = l.Id, Name=l.Name}).ToList();
            // todo: automate this kind of projection using something like automapper.
        }

        public ListDto? GetList(Guid id)
        {
            var list = _context.Lists.SingleOrDefault(l => l.Id == id);
            if (list == null) return null;
            return new ListDto
            {
                Name = list.Name,
                Id = list.Id,
                Items = list.Items.Select(i => i.Text).ToList()
            };
        }

        public CountDto GetCounts()
        {
            CountDto counts = new CountDto
            {
                ItemCount = _context.ListItems.Count(),
                ListCount = _context.Lists.Count()
            };
            return counts;
        }

        public ListItemDto AddItem(Guid listId, string text)
        {
            var list = _context.Lists.SingleOrDefault(l=>l.Id == listId);
            if (list != null)
            {
                var item = new ListItem
                {
                    Text = text,
                    Id = Guid.NewGuid()
                };
                list.Items.Add(item);
                _context.SaveChanges();
                return new ListItemDto { Id = listId, Text = text };
            }
            return null;
        }
    }
}
