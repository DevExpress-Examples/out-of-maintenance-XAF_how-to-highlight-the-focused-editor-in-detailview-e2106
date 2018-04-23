using System;
using System.ComponentModel;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace WinWebSolution.Module {
    [DefaultClassOptions]
    public class HighlightFocusedLayoutItemObject : BaseObject {
        public HighlightFocusedLayoutItemObject(Session session) : base(session) { }
        public string Name {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue<string>("Name", value); }
        }
        public string StringProperty {
            get { return GetPropertyValue<string>("StringProperty"); }
            set { SetPropertyValue<string>("StringProperty", value); }
        }
        public int IntegerProperty {
            get { return GetPropertyValue<int>("IntegerProperty"); }
            set { SetPropertyValue<int>("IntegerProperty", value); }
        }
        public bool BooleanProperty {
            get { return GetPropertyValue<bool>("BooleanProperty"); }
            set { SetPropertyValue<bool>("BooleanProperty", value); }
        }
        public HighlightFocusedLayoutItemObject ReferencedProperty {
            get { return GetPropertyValue<HighlightFocusedLayoutItemObject>("ReferencedProperty"); }
            set { SetPropertyValue<HighlightFocusedLayoutItemObject>("ReferencedProperty", value); }
        }
    }
}
