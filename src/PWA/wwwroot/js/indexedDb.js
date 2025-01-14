// Add this to your wwwroot/js/indexedDb.js file
let db;

// 
window.initializeIndexedDb = async () => {
    return new Promise((resolve, reject) => {
        const request = indexedDB.open('WeatherDb', 1);

        request.onerror = () => reject(request.error);
        request.onsuccess = () => {
            db = request.result;
            resolve();
        };

        request.onupgradeneeded = (event) => {
            const db = event.target.result;
            if (!db.objectStoreNames.contains('forecasts')) {
                db.createObjectStore('forecasts', { keyPath: 'id', autoIncrement: true });
            }
        };
    });
};

window.saveToIndexedDb = async (storeName, data) => {
    return new Promise((resolve, reject) => {
        const transaction = db.transaction(storeName, 'readwrite');
        const store = transaction.objectStore(storeName);

        // Clear existing data
        store.clear();

        // Add new data
        data.forEach(item => {
            store.add(item);
        });

        transaction.oncomplete = () => resolve();
        transaction.onerror = () => reject(transaction.error);
    });
};

window.addToIndexedDb = async (storeName, data) => {
    return new Promise((resolve, reject) => {
        const transaction = db.transaction(storeName, 'readwrite');
        const store = transaction.objectStore(storeName);
        const request = store.add(data);

        request.onsuccess = () => resolve();
        request.onerror = () => reject(request.error);
    });
};

window.getFromIndexedDb = async (storeName) => {
    return new Promise((resolve, reject) => {
        const transaction = db.transaction(storeName, 'readonly');
        const store = transaction.objectStore(storeName);
        const request = store.getAll();

        request.onsuccess = () => resolve(request.result);
        request.onerror = () => reject(request.error);
    });
};