using System;
using System.ComponentModel;

namespace OpenCvSharp.DebuggerVisualizers.GridVisualizer
{
	public class ArrayRowView : ICustomTypeDescriptor, IEditableObject, IDataErrorInfo
	{
		private ArrayDataView	_owner;
		private int				_index;
		string					_error;

		public int Index => _index;


		internal ArrayRowView(ArrayDataView owner,int index)
		{
			_owner = owner;
			_index = index;
		}

		

		internal object GetColumn(int index) => _owner._data.GetValue(_index, index);

		internal void SetColumnValue(int index, object value)
		{
			try
			{
				_owner._data.SetValue(value, _index,index);
			}
			catch(Exception e)
			{
				_error = e.ToString();
			}
		}

		#region ICustomTypeDescriptor Members

		public TypeConverter GetConverter() => null;
		public EventDescriptorCollection GetEvents(Attribute[] attributes) => EventDescriptorCollection.Empty;
		EventDescriptorCollection ICustomTypeDescriptor.GetEvents() => EventDescriptorCollection.Empty;
		public string GetComponentName() => null;
		public object GetPropertyOwner(PropertyDescriptor pd) => _owner;
		public AttributeCollection GetAttributes() => AttributeCollection.Empty;

		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			var col  = _owner._data.GetLength(1);
			var type = _owner._data.GetType().GetElementType();
			var prop = new PropertyDescriptor[col];
			for (var i = 0; i < col; i++)
				prop[i] = new ArrayPropertyDescriptor(_owner.ColumnNames[i], type, i);
			return new PropertyDescriptorCollection(prop);
		}

		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties() => GetProperties(null);

		public object GetEditor(Type editorBaseType) => null;
		public PropertyDescriptor GetDefaultProperty() => null;
		public EventDescriptor GetDefaultEvent() => null;
		public string GetClassName() => GetType().Name;

		#endregion ICustomTypeDescriptor Members

		#region IEditableObject Members

		public void EndEdit() {}

		public void CancelEdit() { }

		public void BeginEdit() { }

		#endregion IEditableObject Members

		#region IDataErrorInfo Members

		public string this[string columnName] => null;

		public string Error => null;

		#endregion IDataErrorInfo Members
	}
}
