namespace Demo.Abstraction.Entities
{
    public interface IBindable
    {
        IDictionary<string, IList<Action>> BindingSet { get; }
        void AddBinding<T>(string propertyName, Action<T> propertyChanged);
    }
}
