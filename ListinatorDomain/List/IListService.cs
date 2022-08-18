namespace ListinatorDomain
{
    public interface IListService
    {
        CountDto GetCounts();
        ListDto? GetList(Guid id);
        ICollection<ListSummaryDto> GetLists();
        ListItemDto AddItem(Guid listId, string text);
    }
}