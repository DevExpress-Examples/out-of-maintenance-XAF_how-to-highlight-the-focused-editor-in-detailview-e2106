using System;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;


namespace WinWebSolution.Module {
    public sealed partial class WinWebSolutionModule : ModuleBase {
        public WinWebSolutionModule() {
            InitializeComponent();
        }
        public override void ExtendModelInterfaces(DevExpress.ExpressApp.Model.ModelInterfaceExtenders extenders) {
            base.ExtendModelInterfaces(extenders);
            extenders.Add<IModelOptions, IModelOptionsHighlightFocusedLayoutItem>();
            extenders.Add<IModelDetailView, IModelDetailViewHighlightFocusedLayoutItem>();
        }
    }
    public interface IModelOptionsHighlightFocusedLayoutItem : IModelNode {
        [DefaultValue(true)]
        [Category("Behavior")]
        bool EnableHighlightFocusedLayoutItem { get;set;}
    }
    public interface IModelDetailViewHighlightFocusedLayoutItem : IModelNode {
        [Category("Behavior")]
        bool HighlightFocusedLayoutItem { get;set;}
    }
    [DomainLogic(typeof(IModelDetailViewHighlightFocusedLayoutItem))]
    public class ModelDetailViewHighlightFocusedLayoutItemLogic {
        public static bool Get_HighlightFocusedLayoutItem(IModelDetailViewHighlightFocusedLayoutItem model) {
            if (model != null)
                return ((IModelOptionsHighlightFocusedLayoutItem)model.Application.Options).EnableHighlightFocusedLayoutItem;
            return false;
        }
    }
}
