namespace API.Conceptuals.BuilderPattern;

public interface IBuilder<out T> where T : class
{
    T Build();
    void Reset();
}