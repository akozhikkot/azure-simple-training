namespace TodoApi.Events
{
    public record TodoItemModifiedEvent(string TodoItemId, bool IsNew);
}
