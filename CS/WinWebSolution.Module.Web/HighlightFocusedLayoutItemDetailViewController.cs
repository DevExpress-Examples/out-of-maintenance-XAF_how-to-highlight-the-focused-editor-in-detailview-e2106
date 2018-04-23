using System;
using System.Web.UI;
using System.Collections.Generic;
using DevExpress.Web.ASPxClasses;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Web;

namespace WinWebSolution.Module.Web {
    public class HighlightFocusedLayoutItemDetailViewController : HighlightFocusedLayoutItemDetailViewControllerBase {
        private const string ScriptKey = "assignStyleScriptKey";
        const string ScriptFunction = @"
                    window.lastFocusedElement = undefined;
                    window.isLayoutItemRow = function(obj) {
                        return obj.className == ""Item"" && obj.tagName == ""DIV"";
                    };
                    window.isValid = function (obj) {
                        return obj != null && obj != undefined; 
                    };
                    window.assignStyle = function (element, color){
                        var curr = element;
                        while (isValid(curr) && !isLayoutItemRow(curr)){
                            curr = curr.parentNode;
                        };
                        if (isValid(curr)) 
                            curr.style.backgroundColor = color;
                    };";
        protected override void OnActivated() {
            base.OnActivated();
            if (View.ViewEditMode == ViewEditMode.Edit)
                foreach (ViewItem item in View.Items) {
                    item.ControlCreated += delegate(object sender, EventArgs e) {
                        AssignStyle(((ViewItem)sender).Control);
                    };
                }
            WebWindow.CurrentRequestWindow.RegisterClientScript(ScriptKey, ScriptFunction);
        }
        protected override void AssignStyle(object control) {
            foreach (ASPxWebControl dxEditor in FindNestedControls<ASPxWebControl>(control as Control)) {
                string functionInit = @"
                function (s, e){
                    if (s.focused) {
                        window.assignStyle(window.lastFocusedElement = s.GetMainElement(), ""#C9E4F0"");
                    }
                }";
                string functionGotFocus = @"
                function (s, e){
                    window.assignStyle(window.lastFocusedElement, """");
                    window.assignStyle(window.lastFocusedElement = s.GetMainElement(), ""#C9E4F0"");
                }";
                if (string.IsNullOrEmpty(dxEditor.GetClientSideEventHandler("Init")))
                    dxEditor.SetClientSideEventHandler("Init", functionInit);
                if (string.IsNullOrEmpty(dxEditor.GetClientSideEventHandler("GotFocus")))
                    dxEditor.SetClientSideEventHandler("GotFocus", functionGotFocus);
            }
        }
        private static IEnumerable<TNestedControl> FindNestedControls<TNestedControl>(Control container) where TNestedControl : Control {
            if (container != null && container.Controls != null)
                foreach (Control item in container.Controls) {
                    if (item is TNestedControl)
                        yield return (TNestedControl)item;
                    foreach (TNestedControl child in FindNestedControls<TNestedControl>(item))
                        yield return child;
                }
        }
    }
}