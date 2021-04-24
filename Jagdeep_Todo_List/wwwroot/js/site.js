(function () {
    if ('serviceWorker' in navigator) {
        console.log('CLIENT: service worker registration in progress.');
        navigator.serviceWorker.register('/server-worker.js').then(function () {
            console.log('CLIENT: service worker registration complete.');
        }, function () {
            console.log('CLIENT: service worker registration has been failed.');
        });
    } else {
        console.log('CLIENT: service worker is not being supported.');
    }

})();

window.onclick = function (e) {
    //When It is offline then all buttons should not work
    if (!navigator.onLine) {        
        if (e.target.className.indexOf('disable-btns-when-offline') != -1) {
            toastr.error('This operation is not allowed now please check your network!')
            e.preventDefault();
        }
    }
    else {
        /*$('.disable-btns-when-offline').removeClass('hide-buttons')*/
    }
}
function copyTodoTextToClipBoard(text) {
    if ('clipboard' in navigator) {
        debugger
        let canWriteClipboard = false;
        navigator.permissions.query({ name: 'clipboard-read' }).then((perms) => {
            canWriteClipboard = perms.state;
            if (canWriteClipboard === "granted") {
                navigator.clipboard.writeText(text);
                toastr.success('text has been copied clipboard successfully!')
                toastr.clear();
            } else if (canWriteClipboard === "prompt") {
                toastr.error('Please give permission to copy to clipboard !')
                toastr.clear();
            }
            else {
                toastr.error('Please give permission to copy to clipboard !')
                toastr.clear();
                return;
            }
            //$("#copyToClipboard").removeAttr('hidden');
        });
    }
}