document.addEventListener("DOMContentLoaded", (event) => {
    window.isOnline = navigator.onLine;

    window.addEventListener('online', function () {
        console.log("online");
        DotNet.invokeMethodAsync('PWA', 'OnOnlineStatusChanged', true);
    });

    window.addEventListener('offline', function () {
        console.log("offline");
        DotNet.invokeMethodAsync('PWA', 'OnOnlineStatusChanged', false);
    });
});