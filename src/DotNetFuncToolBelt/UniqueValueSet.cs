using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetFuncToolBelt
{
    public class UniqueValueSet<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private readonly Dictionary<TKey, TValue> _uniqueKeys;
        private readonly Dictionary<TValue, TKey> _uniqueValues;

        public UniqueValueSet()
        {
            _uniqueKeys = new Dictionary<TKey, TValue>();
            _uniqueValues = new Dictionary<TValue, TKey>();
        }

        public void Add(TKey key, TValue value)
        {
            if (_uniqueKeys.ContainsKey(key))
            {
                throw new ArgumentException("Key already exists");
            }

            if (_uniqueValues.ContainsKey(value))
            {
                throw new ArgumentException("Value already exists");
            }

            _uniqueKeys.Add(key, value);
            _uniqueValues.Add(value, key);
        }

        public TValue GetValue(TKey key)
        {
            TValue value;
            if (_uniqueKeys.TryGetValue(key, out value) == false)
            {
                throw new ArgumentException("Key does not exist");
            }

            return value;
        }

        public TKey GetKey(TValue value)
        {
            TKey key;
            if (_uniqueValues.TryGetValue(value, out key) == false)
            {
                throw new ArgumentException("Value does not exist");
            }

            return key;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _uniqueKeys.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _uniqueKeys.GetEnumerator();
        }
    }
}
