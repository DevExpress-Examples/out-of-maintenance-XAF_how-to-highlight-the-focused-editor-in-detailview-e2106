//This is a modified version of the solution for DevExpress ASP.NET editors described at https://www.devexpress.com/Support/Center/Example/Details/E1800
//The background color and the capability to highlight the parent layout element is dynamically passed from the server in the WebHighlightFocusedLayoutItemDetailViewController class.
window.E2106 = window.E2106 || {};
window.E2106.HighlightFocusedLayoutItem = new function () {
    var NoColor = "";
    this.onGotFocus = function (s, e) {
        var mainElement = s.GetMainElement();
        var targetElement = e.highlightParent === true ? findParentLayoutItem(mainElement) : mainElement;
        highlightElement(targetElement, e.backColor);
    };
    this.onLostFocus = function (s, e) {
        var mainElement = s.GetMainElement();
        var targetElement = e.highlightParent === true ? findParentLayoutItem(mainElement) : mainElement;
        highlightElement(targetElement, NoColor);
    };
    var highlightElement = function (element, backgroundColor) {
        if (element) {
            element.style.backgroundColor = backgroundColor;
        }
    }
    var findParentLayoutItem = function (element) {
        var allParents = document.querySelectorAll('div.Item');
        for (var i = 0, l = allParents.length; i < l; i++) {
            if (allParents[i].contains(element)) {
                return allParents[i];
            }
        }
        return null;
    };
};