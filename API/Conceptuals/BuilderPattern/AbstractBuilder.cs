namespace API.Conceptuals.BuilderPattern;

public abstract class AbstractBuilder<T> : IBuilder<T> where T : class, new()
{
    protected T _object = new T();
    
    public abstract T Build();

    public void Reset()
    {
        _object = new T();
    }
}