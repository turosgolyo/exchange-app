namespace Exchange.Domain.Models.Views;

public class PaginationModel<T>
{
    public List<T> Items { get; set; }
    public int Count { get; set; }
}
