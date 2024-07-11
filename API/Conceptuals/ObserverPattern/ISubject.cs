namespace API.Conceptuals.ObserverPattern;

public interface ISubject<E>
{
    void AddObserver(IObserver<E> observer);
    void RemoveObserver(IObserver<E> observer);
    void NotifyObservers(E data);
}