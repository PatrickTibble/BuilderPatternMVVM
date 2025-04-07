using Demo.Abstraction.Models;

namespace Demo.Abstraction.Entities
{
    public interface ISemanticViewModel
    {
        SemanticOptions SemanticLevel { get; set; }
        string SemanticDescription { get; set; }
    }
}
