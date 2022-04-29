using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniFiSharp.Orchestration.Collections
{
    /// <summary>
    /// Mutable collection which calls back to the originating data service to make live changes
    /// </summary>
    /// <typeparam name="T">Type of element tracked by this collection</typeparam>
    internal interface IMutableRemotedDataCollection<T>
    {
        /// <summary>
        /// Add an element to the collection and immediately commit changes to the controller
        /// </summary>
        /// <param name="item">Item to add</param>
        /// <returns></returns>
        Task Add(T item);

        /// <summary>
        /// Clear the collection and immediately commit changes to the controller
        /// </summary>
        /// <returns></returns>
        Task Clear();

        /// <summary>
        /// Remove an element from the collection and immediately commit changes to the controller
        /// </summary>
        /// <param name="item">Item to remove</param>
        /// <returns></returns>
        Task<bool> Remove(T item);

        /// <summary>
        /// Remove an element from the collection by its index and immediately commit changes to the controller
        /// </summary>
        /// <param name="index">Index of item to remove</param>
        /// <returns></returns>
        Task RemoveAt(int index);
    }

    /// <summary>
    /// Collection of data objects which can be refreshed from a remote source
    /// </summary>
    /// <typeparam name="T">Type of element tracked by this collection</typeparam>
    public abstract class RemotedDataCollection<T> : IEnumerable<T>
    {
        /// <summary>
        /// API object which holds the data connection for this collection
        /// </summary>
        protected UniFiApi API { get; private set; }

        /// <summary>
        /// Backing collection for this remoted collection
        /// </summary>
        protected List<T> CachedCollection { get; set; }

        /// <summary>
        /// Refresh the data objects contained in this collection from their upstream source
        /// </summary>
        /// <returns></returns>
        public abstract Task Refresh();

        /// <summary>
        /// Create a data collection that uses a UniFiApi object to retrieve its underlying objects
        /// </summary>
        /// <param name="api">API object for this collection's data connection</param>
        protected RemotedDataCollection(UniFiApi api)
        {
            API = api;
            CachedCollection = new List<T>();
        }

        /// <summary>
        /// Retrieve an element from this collection
        /// </summary>
        /// <param name="index">Index of element to retrieve</param>
        /// <returns></returns>
        public T this[int index] { get => CachedCollection[index]; set => CachedCollection[index] = value; }

        /// <summary>
        /// Count of elements in this collection
        /// </summary>
        public int Count => CachedCollection.Count;

        /// <summary>
        /// If the collection is read-only
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// If the collection contains a given item.
        /// </summary>
        /// <param name="item">Item to check for the presence of in this collection</param>
        /// <returns><c>TRUE</c> if the item exists, otherwise <c>FALSE</c></returns>
        public bool Contains(T item)
        {
            return CachedCollection.Contains(item);
        }

        /// <summary>
        /// Copy the contents of this collection into an array
        /// </summary>
        /// <param name="array">Array to copy into</param>
        /// <param name="arrayIndex">Array index to start copying</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            CachedCollection.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Get the enumerator for this collection
        /// </summary>
        /// <returns>Generic IEnumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return CachedCollection.GetEnumerator();
        }

        /// <summary>
        /// Get the index of a given item from this collection
        /// </summary>
        /// <param name="item">Item to locate the index of</param>
        /// <returns>Index of the item</returns>
        public int IndexOf(T item)
        {
            return CachedCollection.IndexOf(item);
        }

        /// <summary>
        /// Get the enumerator for this collection
        /// </summary>
        /// <returns>Non-generic IEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
