document.addEventListener("DOMContentLoaded", (event) => {
    window.isOnline = navigator.onLine;

    window.addEventListener('online', function () {
        console.log("online");
        DotNet.invokeMethodAsync('PWA', 'isOnlineStatusChanged');
        DotNet.invokeMethodAsync('PWA', 'UpdateSQLDb', indexedDB);

    });

    window.addEventListener('offline', function () {
        console.log("offline");
        DotNet.invokeMethodAsync('PWA', 'isNotOnlineStatusChanged');
    });
});