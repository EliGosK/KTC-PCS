/* Create by: Mr. Teerayut Sinlan
 * Create on: 2009-08-21
 * Company: CSI Groups (Thailand)
 * Group: SI-EVO
 */

using System;
using System.Collections.Generic;

namespace EVOFramework.Data
{
    /// <summary>
    /// Collection that can replace same key. It's sealed class.
    /// </summary>
    [Serializable]
    public sealed class Map<K, V>
    {
        /// <summary>
        /// Collection to store MapKeyValue.
        /// </summary>
        private readonly MapKeyValueCollection<K, V> m_list = new MapKeyValueCollection<K, V>();

        #region Indexer
        /// <summary>
        /// Get MapKeyValue by index.
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public MapKeyValue<K, V> this[int index]
        {
            get { return m_list[index]; }        
        }

        public MapKeyValue<K, V> this[object keyName] {
            get {
                object objText = keyName.ToString();
                return m_list[(K)objText];
            }
        }
        /// <summary>
        /// Get MapKeyValue by key name.
        /// </summary>
        /// <param name="key">key name.</param>
        /// <returns></returns>
        public MapKeyValue<K, V> this[K key]
        {
            get { return m_list[key];}
        }
        #endregion

        #region Collection Operation
        /// <summary>
        /// Put key and value into collection. If key has duplicate it will replace value to old key.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void Put(K key, V value) {
            MapKeyValue<K, V> newItem = new MapKeyValue<K, V>(key, value);            

            MapKeyValue<K, V> item = m_list[key];
            if (item != null) {
                m_list.Remove(item);                
            }
                
            m_list.Add(newItem);
        }        
        /// <summary>
        /// Put key and value into collection. If key has duplicate it will replace value to old key.
        /// </summary>
        /// <param name="item"></param>
        public void Put(MapKeyValue<K, V> item) {
            Put(item.Key, item.Value);
        }
        /// <summary>
        /// Copy all element on the given parameter. If key has duplicate it will replace value all.
        /// </summary>
        /// <param name="map"></param>
        public void PutAll(Map<K, V> map)
        {
            for (int i=0; i<map.Count; i++) {
                this.Put(map[i]);
            }
        }
        /// <summary>
        /// Copy all element on the given parameter. If key has duplicate it will replace value all.
        /// </summary>
        /// <param name="maps"></param>
        public void PutAll(MapKeyValueCollection<K, V> maps) {
            for (int i=0; i< maps.Count; i++) {
                Put(maps[i]);
            }
        }
        /// <summary>
        /// Remove element.
        /// </summary>
        /// <param name="key"></param>
        public void Remove(K key)
        {
            MapKeyValue<K, V> item = m_list[key];
            if (item != null)
                m_list.Remove(item);
        }
        /// <summary>
        /// Remove all element.
        /// </summary>
        public void RemoveAll() {
            m_list.Clear();
        }
        /// <summary>
        /// Get count element.
        /// </summary>
        public int Count {
            get { return m_list.Count; }
        }
        #endregion

        #region Extractor Operation
        /// <summary>
        /// Extract value from specified key name.
        /// </summary>
        /// <typeparam name="T">Type that want to extract.</typeparam>
        /// <param name="key">Key.</param>
        /// <returns></returns>
        public T ExtractValue<T>(K key) {
            MapKeyValue<K, V> keyVal = this[key];
            if (keyVal == null)
                return default( T );

            return keyVal.ConvertValueTo<T>();
        }
        #endregion

        #region Find
        /// <summary>
        /// Check if found a specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool FoundKey(K key) {
            return ( this[key] != null );
        }
        #endregion

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return "Count: " + m_list.Count.ToString();            
        }
    }

    /// <summary>
    /// Key and Value.
    /// </summary>
    /// <typeparam name="K">Key</typeparam>
    /// <typeparam name="V">Value</typeparam>
    [Serializable]
    public class MapKeyValue<K, V>
    {
        /// <summary>
        /// Key
        /// </summary>
        public K Key;

        /// <summary>
        /// Value
        /// </summary>
        public V Value;        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public MapKeyValue(K key, V value) {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Determines whether the specified item to has key is equals.
        /// </summary>
        /// <param name="item">Item to compare equals.</param>
        /// <returns></returns>
        public bool EqualsKey(MapKeyValue<K,V> item)
        {
            return item != null && item.Key.Equals(this.Key);
        }

        /// <summary>
        /// Check that can convert to specified type.
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public bool CanConvertValueTo(Type targetType) {
            try {
                Type valueType = this.Value.GetType();
                if (valueType == targetType ||
                    valueType.IsSubclassOf(targetType))
                    return true;

                return false;                
            } catch {
                return false;
            }            
        }

        /// <summary>
        /// Convert value to specified type.
        /// </summary>
        /// <typeparam name="T">Type of target object.</typeparam>
        /// <returns>target object.</returns>
        /// <exception cref="InvalidCastException"><c>InvalidCastException</c>.</exception>
        public T ConvertValueTo<T>() {
            if (CanConvertValueTo(typeof (T))) {
                object obj = this.Value;
                return (T) obj;

            }

            if (Equals(this.Value, null)) {
                return default( T );
            }

            throw new InvalidCastException(
                String.Format(ResourceBundle.ALL.S_INVALID_CAST_TYPE,
                              this.Value.GetType().FullName
                              , typeof (T).FullName
                    ));

        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param><exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (obj is MapKeyValue<K, V>)
            {
                MapKeyValue<K, V> item = obj as MapKeyValue<K, V>;
                if (item.Key.Equals(this.Key) && item.Value.Equals(this.Value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return String.Format("Key: \"{0}\", Value: \"{1}\"", Key.ToString(), Value.ToString());
        }
    }

    /// <summary>
    /// Collection pair of Key and Value.
    /// </summary>
    /// <typeparam name="K">Key.</typeparam>
    /// <typeparam name="V">Value.</typeparam>
    [Serializable]
    public class MapKeyValueCollection<K, V> : List<MapKeyValue<K, V>>
    {
        public MapKeyValue<K,V> this[K key]
        {
            get
            {                
                for (int i = 0; i < this.Count; i++)
                {
                    MapKeyValue<K, V> item = this[i];
                    if (item.Key.Equals(key))
                        return item;
                }
                return null;
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return "Count: " + this.Count.ToString();
        }
    }
}
