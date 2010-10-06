namespace NullReference.Data
{
    public interface IStateHolder
    {
        object this[string key] { get; set; }
    }
}