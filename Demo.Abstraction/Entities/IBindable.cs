namespace Demo.Abstraction.Entities
{
    public interface IBindable
    {
        IDictionary<string, IList<Action>> BindingSet { get; }
        void AddBinding(string propertyName, Action propertyChanged);
    }
}
