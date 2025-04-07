namespace Demo.Abstraction.Entities
{
    public interface IPrepare
    {
        void Prepare(IDictionary<string, object>? prepParameters);
    }
}
