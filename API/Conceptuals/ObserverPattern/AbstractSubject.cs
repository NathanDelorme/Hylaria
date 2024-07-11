namespace API.Conceptuals.ObserverPattern
{
    public abstract class AbstractSubject<T,E> : ISubject<E>
    {
        private List<IObserver<E>> observers = new List<IObserver<E>>();
        private readonly object lockObject = new object();
        
        public void AddObserver(IObserver<E> observer)
        {
            lock (lockObject)
            {
                observers.Add(observer);
            }
        }
        
        public void RemoveObserver(IObserver<E> observer)
        {
            lock (lockObject)
            {
                observers.Remove(observer);
            }
        }

        public void NotifyObservers(E data)
        {
            List<IObserver<E>> observersSnapshot;
            lock (lockObject)
            {
                observersSnapshot = new List<IObserver<E>>(observers);
            }
            
            foreach (IObserver<E> observer in observersSnapshot)
                observer.Update(data);
        }
    }
}