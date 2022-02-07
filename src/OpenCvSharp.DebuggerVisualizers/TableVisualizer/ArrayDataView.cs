using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace OpenCvSharp.DebuggerVisualizers.TableVisualizer
{
    public class ArrayDataView	: IBindingList
    {
        #region Variables

        private readonly ArrayRowView[]	_rows;
        internal	Array			    _data;
        private		string[]		    _colnames;	

        #endregion Variables

        #region Constructors

        public ArrayDataView(Array array)
        {
            _data = array;
            _rows = new ArrayRowView[array.GetLength(0)];
            Parallel.For(0, _rows.Length, i =>
                _rows[i] = new ArrayRowView(this, i));
        }
        
        #endregion Constructors

        #region Properties

        internal string[] ColumnNames
        {
            get
            {
                if (_colnames == null)
                {
                    _colnames = new string[_data.GetLength(1)];
                    for (var i = 0; i < _colnames.Length; i++)
                        _colnames[i] = i.ToString();
                }
                return _colnames;
            }
        }

        #endregion Properties

        #region Methods

        public void Reset()
        {
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset,-1));
        }

        #endregion 

        #region IBindingList Members

        public event ListChangedEventHandler ListChanged;

        public bool               AllowNew                   => false;
        public PropertyDescriptor SortProperty               => null;
        public bool               SupportsSorting            => false;
        public bool               IsSorted                   => false;
        public bool               AllowRemove                => false;
        public bool               SupportsSearching          => false;
        public ListSortDirection  SortDirection              => ListSortDirection.Ascending;
        public bool               AllowEdit                  => true;
        public bool               SupportsChangeNotification => true;

        public void   AddIndex(PropertyDescriptor property) { }
        public void   ApplySort(PropertyDescriptor property, ListSortDirection direction) {}
        public int    Find(PropertyDescriptor property, object key) => 0;
        public void   RemoveSort() { }
        public object AddNew() => null;
        public void   RemoveIndex(PropertyDescriptor property) { }

        private void OnListChanged(ListChangedEventArgs e)
        {
            ListChanged?.Invoke(this, e);
        }

        #endregion IBindingList Members

        #region IList Members

        public bool   IsReadOnly  => true;
        public bool   IsFixedSize => true;

        public object this[int index] { get => _rows[index]; set { } }

        public void RemoveAt(int index) {}
        public void Insert(int index, object value) {}
        public void Remove(object value) {}
        public bool Contains(object value) => false;
        public void Clear() {}
        public int IndexOf(object value) => 0;
        public int Add(object value) => 0;

        #endregion  IList Members

        #region ICollection Members

        public bool IsSynchronized => false;
        public int Count => _rows.Length;

        public void CopyTo(Array array, int index) {}

        public object SyncRoot => null;

        #endregion ICollection Members

        #region IEnumerable Members

        public System.Collections.IEnumerator GetEnumerator() => _rows.GetEnumerator();

        #endregion
    }
}
