using System;
using System.Collections.Generic;
using System.Linq;

namespace Leanwork.CodePack.Dynamic
{
    /// <summary>
    /// A class with dynamic property
    /// </summary>
    [Serializable]
    public class CustomObject
    {
        dynamic _custom;
        public dynamic Custom
        {
            get { return _custom ?? (_custom = new ExpandableObject()); }
            set { _custom = value; }
        }

        public object this[string name]
        {
            get { return ((ExpandableObject)Custom)[name]; }
            set { ((ExpandableObject)Custom)[name] = value; }
        }
    }
}
