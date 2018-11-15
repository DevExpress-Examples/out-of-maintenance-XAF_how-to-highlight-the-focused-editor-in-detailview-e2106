<!-- default file list -->
*Files to look at*:

* [HighlightFocusedLayoutItemDetailViewController.cs](./CS/WinWebSolution.Module.Web/HighlightFocusedLayoutItemDetailViewController.cs)
* [HighlightFocusedLayoutItemDetailViewController.cs](./CS/WinWebSolution.Module.Win/HighlightFocusedLayoutItemDetailViewController.cs)
* **[HighlightFocusedLayoutItemDetailViewControllerBase.cs](./CS/WinWebSolution.Module/HighlightFocusedLayoutItemDetailViewControllerBase.cs)**
* [Module.cs](./CS/WinWebSolution.Module/Module.cs)
<!-- default file list end -->
# How to highlight the focused editor in DetailView


<p><strong>S</strong><strong>cenario</strong><br> In this example, it is demonstrated how highlight focused editors in an editable DetailView for both Windows and the Web:</p>
<p><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-highlight-the-focused-editor-in-detailview-e2106/12.1.4+/media/5761ad73-6ab5-4484-8597-32540efc47bd.png"></p>
<p>Additionally, the following Model Editor extensions are implemented for more convenience:<br> <strong>-</strong> The HighlightFocusedLayoutItem attribute at the <em>Application | Options</em> node level allows you to control this functionality globally per application via the Model Editor.<br> <strong>-</strong> The HighlightFocusedLayoutItem attribute at the <em>Views | </em><em>DetailView</em> node level allows you to customize only certain DetailViews via the Model Editor<br><br><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-highlight-the-focused-editor-in-detailview-e2106/12.1.4+/media/0de2f666-0487-11e5-80bf-00155d62480c.png"><br><br></p>
<p><strong>Steps to </strong><strong>implement</strong><strong><br> </strong><strong>1.</strong> Modify <em>YourSolutionName.Module/Module.xx</em> file as shown in the <em>WinWebSolution.Module\Module.xx</em> file of this example.<br><strong>Note</strong>: The approach from the <a href="https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument113169">eXpressApp Framework > Concepts > Application Model > Extend and Customize the Application Model in Code</a> article is used here.</p>
<p><strong>2.</strong> Copy the <em>WinWebSolution.Module\HighlightFocusedLayoutItemDetailViewControllerBase.xx</em> file into the <em>YourSolutionName.Module</em> project.<br><strong>Note</strong>: The approaches from the <a href="https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112810">eXpressApp Framework > Concepts > Application Model > Access the Application Model in Code</a> and <a href="https://documentation.devexpress.com/#eXpressAppFramework/DevExpressExpressAppController_Activetopic">Controller.Active Property</a> articles is used here.</p>
<p><strong>3.</strong> Copy the <em>WinWebSolution.Module.Win\WinHighlightFocusedLayoutItemDetailViewController.xx</em> file into the <em>YourSolutionName.Module.Win</em> project. <br><strong>Note</strong>: In Windows Forms applications, the functionality is provided with the help of the <u><a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument7874">LayoutControl</a></u> and its <a href="https://documentation.devexpress.com/WindowsForms/DevExpressXtraLayoutOptionsView_HighlightDisabledItemtopic.aspx">HighlightDisabledItem</a>  and <a href="https://documentation.devexpress.com/WindowsForms/DevExpressXtraLayoutOptionsView_AllowItemSkinningtopic.aspx">AllowItemSkinning</a> options. The approach from the <a href="https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112817">eXpressApp Framework > Concepts > UI Construction > View Items Layout Customization</a> article is used to access LayoutControl.</p>
<p><strong>4.</strong> Copy the <em>WinWebSolution.Module.Web\WebHighlightFocusedLayoutItemDetailViewController.xx</em> file into the <em>YourSolutionName.Module.Web</em> project. Then copy the <em>WinWebSolution.Web\E2106.js</em> file into the <em>YourSolutionName.Web</em> project.<br>Finally, add the <em><script type="text/javascript" src="E2106.js"></script></em> line into the <em><head></em> element of your <em>YourSolutionName.Web\Default.aspx</em> file.<br><strong>Note</strong>: In ASP.NET applications, the functionality is implemented manually as per <a href="https://www.devexpress.com/Support/Center/p/E1800">How to highlight a focused editor via client-side scripting</a> via client-side events provided by our ASP.NET editors. The approach from the <a href="https://documentation.devexpress.com/#Xaf/CustomDocument2729">eXpressApp Framework > Getting Started > Comprehensive Tutorial (MainDemo Application) > Extend Functionality > Access Editor Settings</a> article is used to access PropertyEditor controls.</p>
<p><br> <strong>IMPORTAN</strong><strong>T NOTES</strong><br> It is possible to register your JavaScript functions at runtime via the <strong>DevExpress.ExpressApp.Web.WebWindow.CurrentRequestWindow.RegisterXXXScript</strong> methods called from a Controller when it is activated or when page controls are created. Refer to the <a href="https://www.devexpress.com/Support/Center/p/KA18958">How to automatically refresh data in a View after a certain period of time on the Web</a> article for an illustration of this approach.</p>

<br/>


