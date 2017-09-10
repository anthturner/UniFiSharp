using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniFiSharp.Orchestration.Collections
{
    public abstract class RefreshableCollection<T> : List<T>
    {
        protected UniFiApi API { get; private set; }

        public new T this[int index]
        {
            get => ((IList<T>)this)[index];
            set => throw new Exception("Collection is read-only. Use Refresh() to re-populate items.");
        }

        public abstract Task Refresh();

        public RefreshableCollection(UniFiApi api)
        {
            API = api;
        }

        protected void AddLocal(T item)
        {
            base.Add(item);
        }

        protected void AddLocal(IEnumerable<T> items)
        {
            base.AddRange(items);
        }

        protected void RemoveLocal(T item)
        {
            base.Remove(item);
        }

        protected void ClearLocal()
        {
            base.Clear();
        }

        public new void Add(T item)
        {
            throw new Exception("Collection is read-only. Use Refresh() to re-populate items.");
        }

        public new void Clear()
        {
            throw new Exception("Collection is read-only. Use Refresh() to re-populate items.");
        }

        public new void Insert(int index, T item)
        {
            throw new Exception("Collection is read-only. Use Refresh() to re-populate items.");
        }

        public new bool Remove(T item)
        {
            throw new Exception("Collection is read-only. Use Refresh() to re-populate items.");
        }

        public new void RemoveAt(int index)
        {
            throw new Exception("Collection is read-only. Use Refresh() to re-populate items.");
        }
    }
}