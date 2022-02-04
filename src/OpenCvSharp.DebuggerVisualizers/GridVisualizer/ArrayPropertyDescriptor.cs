using System;
using System.Diagnostics;
using System.ComponentModel;

namespace OpenCvSharp.DebuggerVisualizers.GridVisualizer
{

    public class ArrayPropertyDescriptor : PropertyDescriptor
    {
        private string	_name;
        private Type	_type;
        private int		_index;

        public ArrayPropertyDescriptor(string name,Type type,int index) : base (name,null)
        {
            _name   = name;
            _type   = type;
            _index  = index;
        }

        public override string DisplayName   => _name;
        public override Type   ComponentType => typeof(ArrayRowView);
        public override bool   IsReadOnly    => false;
        public override Type   PropertyType  => _type;
        
        public override object GetValue(object component)
        {
            try
            {
                return ((ArrayRowView)component).GetColumn(_index);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            Debug.Assert(false);
            return null;
        }

        public override void SetValue(object component, object value)
        {
            try
            {
                ((ArrayRowView)component).SetColumnValue(_index, value);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                Debug.Assert(false);
            }
        }

        public override bool CanResetValue       (object component) => false;
        public override bool ShouldSerializeValue(object component) => false;
        public override void ResetValue          (object component) {}
    }
}
