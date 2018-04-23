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
    public class DemoObject : BaseObject {
        public DemoObject(Session session) : base(session) { }
        public string Name { get; set; }
        public string StringProperty { get; set; }
        public int IntegerProperty { get; set; }
        public bool BooleanProperty { get; set; }
        public DemoObject LookupReferenceProperty { get; set; }
        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public DemoObject AggregatedReferenceProperty { get; set; }
    }
}
