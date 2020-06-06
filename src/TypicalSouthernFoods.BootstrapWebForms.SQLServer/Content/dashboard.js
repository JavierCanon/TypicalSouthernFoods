(function () {
    var currentWindowWidth = null, actualPageSize = 1;
    function getPageSizeForWidth(width) {
        if (width >= 1200) return 4;
        if (width >= 992) return 3;
        if (width >= 768) return 2;
        return 1;
    }
    function applyCardViewPageSize(pageSize) {
        CardViewControl.PerformCallback(pageSize);
    }
    (function adjustCardView() {
        requestAnimationFrame(function () {
            if (currentWindowWidth !== null) {
                var newPageSize = getPageSizeForWidth(currentWindowWidth);
                if (actualPageSize != newPageSize) {
                    actualPageSize = newPageSize;
                    applyCardViewPageSize(actualPageSize);
                }
            }
            adjustCardView();
        });
    })();
    function updateCurrentWindowWidth() {
        currentWindowWidth = document.body.offsetWidth;
    }
    ASPxClientControl.GetControlCollection().ControlsInitialized.AddHandler(function pageInitialized(controlCollection) {
        controlCollection.ControlsInitialized.RemoveHandler(pageInitialized);

        updateCurrentWindowWidth();
        controlCollection.BrowserWindowResized.AddHandler(updateCurrentWindowWidth);
    });
})();