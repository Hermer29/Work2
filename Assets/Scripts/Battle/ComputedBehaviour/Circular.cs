using System.Collections.Generic;

namespace Work2.Battle.ComputedBehaviour.ContextTypes
{
    public class Circular<T>
    {
        private IEnumerable<T> _source;
        private IEnumerator<T> _enumerator;

        public Circular(IEnumerable<T> source) 
        {
            _source = source;
            _enumerator = source.GetEnumerator();
        }

        public T GetNext()
        {
            if (_enumerator.MoveNext())
                return _enumerator.Current;

            _enumerator = _source.GetEnumerator();
            return GetNext();
        }
    }
}
