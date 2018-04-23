using System;
using System.Collections.Generic;
using DevExpress.Web.ASPxClasses;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Web.Editors;
using DevExpress.ExpressApp.Web.Editors.ASPx;

namespace WinWebSolution.Module.Web {
    public class HighlightFocusedLayoutItemDetailViewController : HighlightFocusedLayoutItemDetailViewControllerBase {
        private const string ClientSideEventHandlerFunctionFormat = @"function(s,e){{{0}}}";
        protected override void OnActivated() {
            base.OnActivated();
            if(View.ViewEditMode == ViewEditMode.Edit) {
                foreach(WebPropertyEditor item in View.GetItems<WebPropertyEditor>()) {
                    if(item.Editor != null) {
                        ApplyFocusedStyle(item);
                    }
                    else {
                        item.ControlCreated += (s, e) => {
                            ApplyFocusedStyle(s);
                        };
                    }
                }
            }
        }
        protected override void ApplyFocusedStyle(object element) {
            if(element is ASPxLookupPropertyEditor) {
                ApplyFocusedStyleCore(((ASPxLookupPropertyEditor)element).DropDownEdit.DropDown);
                ApplyFocusedStyleCore(((ASPxLookupPropertyEditor)element).FindEdit.TextBox);
            }
            else if(element is WebPropertyEditor) {
                ApplyFocusedStyleCore(((WebPropertyEditor)element).Editor as ASPxWebControl);
            }
        }
        private void ApplyFocusedStyleCore(ASPxWebControl dxControl) {
            if(dxControl != null) {
                EventHandler loadEventHandler = (s, e) => {
                    ASPxWebControl control = (ASPxWebControl)s;
                    //These JavaScript functions are defined within the E2106.js file.
                    AddEventHandlerSafe(control, "Init", "window.initEditor(s,e);");
                    AddEventHandlerSafe(control, "GotFocus", "window.gotFocusEditor(s,e);");
                };
                EventHandler disposedEventHandler = null;
                disposedEventHandler = (s, e) => {
                    ASPxWebControl control = (ASPxWebControl)s;
                    control.Disposed -= disposedEventHandler;
                    control.Load -= loadEventHandler;
                };
                dxControl.Disposed += disposedEventHandler;
                dxControl.Load += loadEventHandler;
            }
        }
        private static void AddEventHandlerSafe(ASPxWebControl control, string eventName, string handler) {
            string existingHandler = control.GetClientSideEventHandler(eventName);
            if(string.IsNullOrEmpty(existingHandler)) {
                control.SetClientSideEventHandler(eventName, string.Format(ClientSideEventHandlerFunctionFormat, handler));
            }
            else {
                existingHandler = String.Format("{0}{1}\r\n}}", existingHandler.Substring(0, existingHandler.LastIndexOf('}')), handler);
                control.SetClientSideEventHandler(eventName, existingHandler);
            }
        }
    }
}