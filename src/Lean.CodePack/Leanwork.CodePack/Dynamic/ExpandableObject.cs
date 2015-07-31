using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Leanwork.CodePack.Dynamic
{
    /// <summary>
    /// Implementation of DynamicObject
    /// </summary>
    [Serializable]
    public sealed class ExpandableObject : DynamicObject
    {
        private IDictionary<string, object> _properties;

        public object this[string memberName]
        {
            get 
            {
                if (_properties.ContainsKey(memberName))
                {
                    return _properties[memberName]; 
                }
                return null;
            }
            set
            {
                if (_properties.ContainsKey(memberName))
                {
                    _properties[memberName] = value;
                }
                else
                {
                    _properties.Add(memberName, value);
                }
            }
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _properties.Keys;
        }

        public IEnumerable<string> GetMemberNames()
        {
            return _properties.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            _properties.TryGetValue(binder.Name, out result);
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _properties[binder.Name] = value;
            return true;
        }

        public IDictionary<string, object> GetProperties()
        {
            return _properties;
        }

        public ExpandableObject()
            : this(new Dictionary<string, object>())
        {
        }

        public ExpandableObject(IDictionary<string, object> attributes)
        {
            _properties = attributes;
        }
    }
}
