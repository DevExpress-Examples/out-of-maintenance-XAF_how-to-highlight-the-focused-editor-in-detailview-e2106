using System;
using System.Web.UI;
using DevExpress.ExpressApp.Web;
using System.Collections.Generic;
using DevExpress.Web.ASPxClasses;
using DevExpress.ExpressApp.Editors;

namespace WinWebSolution.Module.Web {
    public class HighlightFocusedLayoutItemDetailViewController : HighlightFocusedLayoutItemDetailViewControllerBase {
        private const string scriptKey = "assignStyleScriptKey";
        private const string functionFormat = @"function(s, e){{
                                                    //Appendix Start
                                                    {0} 
                                                    //Appendix End
                                                }}";
        private const string script = @"
        window.lastFocusedElement = undefined;
        window.isLayoutItemRow = function(obj) {
            return obj.className == ""Item"" && obj.tagName == ""DIV"";
        }
        window.isValid = function(obj) {
            return obj != null && obj != undefined;
        }
        window.assignStyle = function(element, color) {
            var curr = element;
            while (window.isValid(curr) && !window.isLayoutItemRow(curr)) {
                curr = curr.parentNode;
            };
            if (window.isValid(curr))
                curr.style.backgroundColor = color;
        }
        window.initEditor = function(s, e) {
            if (s.focused) {
                window.assignStyle(window.lastFocusedElement = s.GetMainElement(), ""#C9E4F0"");
            }
        }
        window.gotFocusEditor = function(s, e) {
            window.assignStyle(window.lastFocusedElement, """");
            window.assignStyle(window.lastFocusedElement = s.GetMainElement(), ""#C9E4F0"");
        }";
        protected override void OnActivated() {
            base.OnActivated();
            foreach(ViewItem item in View.Items) {
                item.ControlCreated += delegate(object sender, EventArgs e) {
                    AssignStyle(((ViewItem)sender).Control);
                };
            }
        }
        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            WebWindow.CurrentRequestWindow.RegisterClientScript(scriptKey, script);
        }
        protected override void AssignStyle(object control) {
            foreach(ASPxWebControl dxEditor in FindNestedControls<ASPxWebControl>(control as Control)) {
                dxEditor.Load += delegate(object s, EventArgs e) {
                    AddEventHandler(dxEditor, "Init", "window.initEditor(s,e);");
                    AddEventHandler(dxEditor, "GotFocus", "window.gotFocusEditor(s,e);");
                };
            }
        }
        private static void AddEventHandler(ASPxWebControl control, string eventName, string handler) {
            string existingHandler = control.GetClientSideEventHandler(eventName);
            if(string.IsNullOrEmpty(existingHandler)) {
                control.SetClientSideEventHandler(eventName, string.Format(functionFormat, handler));
            }
            else {
                existingHandler = existingHandler.Substring(0, existingHandler.LastIndexOf('}')) + handler + "\r\n}";
                control.SetClientSideEventHandler(eventName, existingHandler);
            }
        }
        private static IEnumerable<TNestedControl> FindNestedControls<TNestedControl>(Control container) where TNestedControl : Control {
            if(container != null && container.Controls != null)
                foreach(Control item in container.Controls) {
                    if(item is TNestedControl)
                        yield return (TNestedControl)item;
                    foreach(TNestedControl child in FindNestedControls<TNestedControl>(item))
                        yield return child;
                }
        }
    }
}