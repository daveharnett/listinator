using ListinatorDomain;

namespace ListinatorDal
{
    public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ListContext>
    {
        protected override void Seed(ListContext context)
        {
            var todoListId = Guid.NewGuid();
            var doneListId = Guid.NewGuid();

            var lists = new List<List>
            {
                new ListinatorDomain.List{Id = todoListId, Name = "Todo"},
                new ListinatorDomain.List{Id = doneListId, Name = "Done"},
            };
            lists.ForEach(l => context.Lists.Add(l));
            context.SaveChanges();

            var listItems = new List<ListItem>
            {
                new ListItem{Id=Guid.NewGuid(), ListId = todoListId, Text = "Tidy the office"},
                new ListItem{Id=Guid.NewGuid(), ListId = todoListId, Text = "Paint the stairs"},

                new ListItem{Id=Guid.NewGuid(), ListId = doneListId, Text = "Install storage heater in living room"},
                new ListItem{Id=Guid.NewGuid(), ListId = doneListId, Text = "Store batteries in the attic"},
            };
            listItems.ForEach(i => context.ListItems.Add(i));
            context.SaveChanges();

            base.Seed(context);

        }
    }
}
