using DevExpress.XtraLayout;

namespace WinWebSolution.Module.Win {
    public class HighlightFocusedLayoutItemDetailViewController : HighlightFocusedLayoutItemDetailViewControllerBase {
        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            AssignStyle(View.LayoutManager.Container);
        }
        protected override void AssignStyle(object control) {
            LayoutControl layoutControl = control as LayoutControl;
            if (layoutControl != null) {
                layoutControl.BeginUpdate();
                layoutControl.OptionsView.HighlightFocusedItem = true;
                layoutControl.OptionsView.AllowItemSkinning = true;
                layoutControl.EndUpdate();
            }
        }
    }
}