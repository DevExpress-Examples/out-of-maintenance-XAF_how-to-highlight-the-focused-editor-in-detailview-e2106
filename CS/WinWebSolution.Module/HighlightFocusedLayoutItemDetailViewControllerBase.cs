using DevExpress.ExpressApp;

namespace WinWebSolution.Module {
    public abstract class HighlightFocusedLayoutItemDetailViewControllerBase : ViewController<DetailView> {
        public const string HighlightFocusedLayoutItemAttributeName = "HighlightFocusedLayoutItem";
        public const string EnableHighlightFocusedLayoutItemAttributeName = "EnableHighlightFocusedLayoutItem";
        public const string ActiveKeyHighlightFocusedEditor = "HighlightFocusedLayoutItem";
        protected override void OnViewChanging(View view) {
            base.OnViewChanging(view);
            DetailView dv = view as DetailView;
            if (dv != null)
                Active[ActiveKeyHighlightFocusedEditor] = ((IModelDetailViewHighlightFocusedLayoutItem)dv.Model).HighlightFocusedLayoutItem;
        }
        protected abstract void ApplyFocusedStyle(object element);
    }
}