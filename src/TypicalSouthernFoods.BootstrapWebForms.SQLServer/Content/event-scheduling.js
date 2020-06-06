(function () {
    ASPxClientControl.GetControlCollection().ControlsInitialized.AddHandler(function init(collection) {
        collection.ControlsInitialized.RemoveHandler(init);

        resourcesListBox.SelectedIndexChanged.AddHandler(onResourcesListBoxSelectedIndexChanged);
        
        scheduler.EndCallback.AddHandler(onSchedulerEndCallback);
    });
    

    var postponedCallbackRequired = false;
    function onResourcesListBoxSelectedIndexChanged(s, e) {
        if (scheduler.InCallback())
            postponedCallbackRequired = true;
        else
            scheduler.Refresh();
    }
    function onSchedulerEndCallback(s, e) {
        if (postponedCallbackRequired) {
            scheduler.Refresh();
            postponedCallbackRequired = false;
        }
    }
})();