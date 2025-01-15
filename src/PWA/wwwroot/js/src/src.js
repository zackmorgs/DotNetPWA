'use strict';

// import './../../service-worker.js';
// import './../../service-worker.published.js';

import './lib/onlineManager.js';
import './lib/indexedDb.js';
import './lib/syncManager.js';

navigator.serviceWorker.register('service-worker.js');

console.log('Hello from src -> dist.js');

