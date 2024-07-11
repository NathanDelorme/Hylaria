namespace API.Conceptuals.ObserverPattern;

public interface IObserver<E>
{
    void Update(E data);
}