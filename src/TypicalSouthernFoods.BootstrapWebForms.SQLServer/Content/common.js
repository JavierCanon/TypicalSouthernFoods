(function () {
    var currentWindowWidth = null,
        isSideNavCollapsed = null,
        toastSampleElement = document.createElement("DIV"),
        toastContainer = document.querySelector(".demo-toast-container"),
        toastAutocloseDelay = 5000,
        toastAnimationDelay = 300,
        toastStackMaxSize = 4,
        toastCloseCallbacksBuffer = [],
        toastHtml =
            '<div class="toast">' +
                '<div class="toast-header">' +
                    '<strong class="mr-auto">Action notification</strong>' +
                    '<button type="button" class="ml-2 close">' +
                        '<span aria-hidden="true">&times;</span>' +
                    '</button>' +
                '</div>' +
                '<div class="toast-body"><span></span> action has been invoked</div>' +
            '</div>';
    toastSampleElement.innerHTML = toastHtml;
    toastSampleElement = toastSampleElement.firstElementChild;

    function setupTabControl(tabControl) {
        var container = ASPxClientUtils.GetParentByClassName(tabControl.GetMainElement(), "demo-tab-container");
        var currentClassName = null;
        tabControl.ActiveTabChanging.AddHandler(function (s, e) {
            var className = "demo-tab-state-" + s.GetActiveTabIndex() + "-" + e.tab.index;
            requestAnimationFrame(function () {
                if (currentClassName !== null)
                    container.classList.remove(currentClassName);
                container.classList.add(currentClassName = className);
            });
        });
    }
    function updateToggleSideNavButtonState() {
        HeaderToolbar.GetItemByName("SideNavToggleBtn").SetChecked(isSideNavCollapsed === null ? currentWindowWidth >= 992 : !isSideNavCollapsed);
    }
    function updateSideNavState(sideNavEl) {
        sideNavEl.classList.toggle("demo-side-nav-shown", !isSideNavCollapsed);
        sideNavEl.classList.toggle("demo-side-nav-hidden", isSideNavCollapsed);
    }
    function changeToast(callback, onEnd) {
        requestAnimationFrame(function () {
            callback();
            setTimeout(function () {
                requestAnimationFrame(onEnd);
            }, toastAnimationDelay);
        });
    }
    function showActionToast(actionName) {
        var toastElement = toastSampleElement.cloneNode(true),
            autoCloseTimeoutId = -1;
        toastElement.querySelector(".toast-body span").appendChild(document.createTextNode(actionName));
        function closeToast() {
            clearTimeout(autoCloseTimeoutId);
            var index = toastCloseCallbacksBuffer.indexOf(closeToast);
            if (index > -1)
                toastCloseCallbacksBuffer.splice(index);
            changeToast(function () { toastElement.classList.add("removing"); }, function () { toastContainer.removeChild(toastElement); });
        }
        autoCloseTimeoutId = setTimeout(closeToast, toastAutocloseDelay);

        toastCloseCallbacksBuffer.push(closeToast);
        while (toastCloseCallbacksBuffer.length > toastStackMaxSize)
            toastCloseCallbacksBuffer.shift()();

        ASPxClientUtils.AttachEventToElement(toastElement.querySelector("button.close"), "click", closeToast);
        changeToast(function () { toastContainer.appendChild(toastElement); }, function () { toastElement.classList.add("show"); });
    }
    function setupHeaderToolbar(toolbar) {
        var sideNavEl = document.querySelector(".demo-side-nav"),
            themeLink = document.getElementById("themeLink");
        ASPxClientUtils.AttachEventToElement(sideNavEl, "click", function (e) {
            if (e.srcElement === sideNavEl && !isSideNavCollapsed) {
                requestAnimationFrame(function () {
                    isSideNavCollapsed = true;
                    updateToggleSideNavButtonState();
                    updateSideNavState(sideNavEl);
                });
            }
        });
        toolbar.ItemClick.AddHandler(function (s, e) {
            switch (e.item.name) {
                case "SideNavToggleBtn":
                    isSideNavCollapsed = !e.item.GetChecked();
                    updateSideNavState(sideNavEl);
                    break;
                case "theme-light":
                case "theme-dark":
                    if (e.item.GetChecked()) {
                        requestAnimationFrame(function () {
                            document.documentElement.classList.add("demo-theme-switching");
                            setTimeout(function () {
                                requestAnimationFrame(function () {
                                    themeLink.href = themeLink.getAttribute("data-" + e.item.name + "-url");
                                    document.documentElement.classList.toggle("theme-dark", e.item.name === "theme-dark");
                                    document.documentElement.classList.toggle("theme-light", e.item.name === "theme-light");
                                    setTimeout(function () {
                                        requestAnimationFrame(function () {
                                            document.documentElement.classList.remove("demo-theme-switching");
                                        });
                                    }, 200);
                                });
                            });
                        });
                    }
                    break;
                default:
                    if(e.item.name)
                        showActionToast(e.item.name);
                    break;
            }
        });
    }
    function updateCurrentWindowWidth() {
        currentWindowWidth = document.body.offsetWidth;
        updateToggleSideNavButtonState();
    }
    ASPxClientControl.GetControlCollection().ControlsInitialized.AddHandler(function pageInitialized(controlCollection) {
        controlCollection.ControlsInitialized.RemoveHandler(pageInitialized);

        updateCurrentWindowWidth();
        controlCollection.BrowserWindowResized.AddHandler(updateCurrentWindowWidth);
        controlCollection.GetControlsByType(dx.BootstrapClientTabControl).forEach(setupTabControl);
        setupHeaderToolbar(HeaderToolbar);
        requestAnimationFrame(function () {
            document.documentElement.classList.remove("demo-loading-process");
        });
    });
})();