using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Web.Editors;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Web;

namespace WinWebSolution.Module.Web {
    public class WebHighlightFocusedLayoutItemDetailViewController : HighlightFocusedLayoutItemDetailViewControllerBase {
        public bool HighlightParent { get; set; }
        public string BackColor { get; set; }
        public WebHighlightFocusedLayoutItemDetailViewController() {
            HighlightParent = true;
            BackColor = "#C9E4F0";
        }
        //Access Web property editors and their controls in DetailView as per https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112729
        protected override void OnActivated() {
            base.OnActivated();
            foreach (WebPropertyEditor item in View.GetItems<WebPropertyEditor>()) {
                if (item.Editor != null) {
                    ApplyFocusedStyle(item);
                }
                else {
                    item.ControlCreated += (s, e) => {
                        ApplyFocusedStyle(s);
                    };
                }
            }
        }
        //Access the underlying controls of each WebPropertyEditor. Special handling is required for look editors due to their complex inner structure.
        protected override void ApplyFocusedStyle(object element) {
            if (View.ViewEditMode == ViewEditMode.Edit) {
                if (element is ASPxLookupPropertyEditor) {
                    ApplyFocusedStyleCore(((ASPxLookupPropertyEditor)element).DropDownEdit.DropDown);
                    ApplyFocusedStyleCore(((ASPxLookupPropertyEditor)element).FindEdit.Editor);
                }
                else if (element is WebPropertyEditor) {
                    ApplyFocusedStyleCore(((WebPropertyEditor)element).Editor as ASPxWebControl);
                }
            }
        }
        //Configure the client side event handlers for the control based on the scripts defined in the E2106.js file.
        private void ApplyFocusedStyleCore(ASPxWebControl dxControl) {
            if (dxControl != null) {
                dxControl.SetClientSideEventHandler("GotFocus", 
                    string.Format("function(s,e){{e.highlightParent = {0};e.backColor = '{1}';E2106.HighlightFocusedLayoutItem.onGotFocus(s,e);}}", 
                        HighlightParent.ToString().ToLower(), BackColor));
                dxControl.SetClientSideEventHandler("LostFocus", 
                    string.Format("function(s,e){{e.highlightParent = {0};E2106.HighlightFocusedLayoutItem.onLostFocus(s,e);}}", 
                        HighlightParent.ToString().ToLower()));
            }
        }
    }
}