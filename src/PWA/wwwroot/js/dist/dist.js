/*
 * ATTENTION: The "eval" devtool has been used (maybe by default in mode: "development").
 * This devtool is neither made for production nor for readable output files.
 * It uses "eval()" calls to create a separate source file in the browser devtools.
 * If you are trying to read the output file, select a different devtool (https://webpack.js.org/configuration/devtool/)
 * or disable the default devtool with "devtool: false".
 * If you are looking for production-ready output files, see mode: "production" (https://webpack.js.org/configuration/mode/).
 */
/******/ (() => { // webpackBootstrap
/******/ 	var __webpack_modules__ = ({

/***/ "./src/PWA/wwwroot/js/src/indexedDb.js":
/*!*********************************************!*\
  !*** ./src/PWA/wwwroot/js/src/indexedDb.js ***!
  \*********************************************/
/***/ (() => {

eval("// Add this to your wwwroot/js/indexedDb.js file\r\nlet db;\r\n\r\n// \r\nwindow.initializeIndexedDb = async () => {\r\n    return new Promise((resolve, reject) => {\r\n        const request = indexedDB.open('WeatherDb', 1);\r\n\r\n        request.onerror = () => reject(request.error);\r\n        request.onsuccess = () => {\r\n            db = request.result;\r\n            resolve();\r\n        };\r\n\r\n        request.onupgradeneeded = (event) => {\r\n            const db = event.target.result;\r\n            if (!db.objectStoreNames.contains('forecasts')) {\r\n                db.createObjectStore('forecasts', { keyPath: 'id', autoIncrement: true });\r\n            }\r\n        };\r\n    });\r\n};\r\n\r\nwindow.saveToIndexedDb = async (storeName, data) => {\r\n    return new Promise((resolve, reject) => {\r\n        const transaction = db.transaction(storeName, 'readwrite');\r\n        const store = transaction.objectStore(storeName);\r\n\r\n        // Clear existing data\r\n        store.clear();\r\n\r\n        // Add new data\r\n        data.forEach(item => {\r\n            store.add(item);\r\n        });\r\n\r\n        transaction.oncomplete = () => resolve();\r\n        transaction.onerror = () => reject(transaction.error);\r\n    });\r\n};\r\n\r\nwindow.addToIndexedDb = async (storeName, data) => {\r\n    return new Promise((resolve, reject) => {\r\n        const transaction = db.transaction(storeName, 'readwrite');\r\n        const store = transaction.objectStore(storeName);\r\n        const request = store.add(data);\r\n\r\n        request.onsuccess = () => resolve();\r\n        request.onerror = () => reject(request.error);\r\n    });\r\n};\r\n\r\nwindow.getFromIndexedDb = async (storeName) => {\r\n    return new Promise((resolve, reject) => {\r\n        const transaction = db.transaction(storeName, 'readonly');\r\n        const store = transaction.objectStore(storeName);\r\n        const request = store.getAll();\r\n\r\n        request.onsuccess = () => resolve(request.result);\r\n        request.onerror = () => reject(request.error);\r\n    });\r\n};\n\n//# sourceURL=webpack://dotnetpwa/./src/PWA/wwwroot/js/src/indexedDb.js?");

/***/ }),

/***/ "./src/PWA/wwwroot/js/src/onlineManager.js":
/*!*************************************************!*\
  !*** ./src/PWA/wwwroot/js/src/onlineManager.js ***!
  \*************************************************/
/***/ (() => {

eval("﻿document.addEventListener(\"DOMContentLoaded\", (event) => {\r\n    window.isOnline = navigator.onLine;\r\n\r\n    window.addEventListener('online', function () {\r\n        console.log(\"online\");\r\n        DotNet.invokeMethodAsync('PWA', 'isOnlineStatusChanged');\r\n        DotNet.invokeMethodAsync('PWA', 'UpdateSQLDb', indexedDB);\r\n\r\n    });\r\n\r\n    window.addEventListener('offline', function () {\r\n        console.log(\"offline\");\r\n        DotNet.invokeMethodAsync('PWA', 'isNotOnlineStatusChanged');\r\n    });\r\n});\n\n//# sourceURL=webpack://dotnetpwa/./src/PWA/wwwroot/js/src/onlineManager.js?");

/***/ }),

/***/ "./src/PWA/wwwroot/js/src/src.js":
/*!***************************************!*\
  !*** ./src/PWA/wwwroot/js/src/src.js ***!
  \***************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony import */ var _onlineManager_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./onlineManager.js */ \"./src/PWA/wwwroot/js/src/onlineManager.js\");\n/* harmony import */ var _onlineManager_js__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_onlineManager_js__WEBPACK_IMPORTED_MODULE_0__);\n/* harmony import */ var _indexedDb_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./indexedDb.js */ \"./src/PWA/wwwroot/js/src/indexedDb.js\");\n/* harmony import */ var _indexedDb_js__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(_indexedDb_js__WEBPACK_IMPORTED_MODULE_1__);\n\r\n\r\n// import './../../service-worker.js';\r\n// import './../../service-worker.published.js';\r\n\r\n\r\n\r\n\r\nnavigator.serviceWorker.register('service-worker.js');\r\n\r\nconsole.log('Hello from src.js');\r\n\r\n\n\n//# sourceURL=webpack://dotnetpwa/./src/PWA/wwwroot/js/src/src.js?");

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	// The module cache
/******/ 	var __webpack_module_cache__ = {};
/******/ 	
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/ 		// Check if module is in cache
/******/ 		var cachedModule = __webpack_module_cache__[moduleId];
/******/ 		if (cachedModule !== undefined) {
/******/ 			return cachedModule.exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = __webpack_module_cache__[moduleId] = {
/******/ 			// no module.id needed
/******/ 			// no module.loaded needed
/******/ 			exports: {}
/******/ 		};
/******/ 	
/******/ 		// Execute the module function
/******/ 		__webpack_modules__[moduleId](module, module.exports, __webpack_require__);
/******/ 	
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/ 	
/************************************************************************/
/******/ 	/* webpack/runtime/compat get default export */
/******/ 	(() => {
/******/ 		// getDefaultExport function for compatibility with non-harmony modules
/******/ 		__webpack_require__.n = (module) => {
/******/ 			var getter = module && module.__esModule ?
/******/ 				() => (module['default']) :
/******/ 				() => (module);
/******/ 			__webpack_require__.d(getter, { a: getter });
/******/ 			return getter;
/******/ 		};
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/define property getters */
/******/ 	(() => {
/******/ 		// define getter functions for harmony exports
/******/ 		__webpack_require__.d = (exports, definition) => {
/******/ 			for(var key in definition) {
/******/ 				if(__webpack_require__.o(definition, key) && !__webpack_require__.o(exports, key)) {
/******/ 					Object.defineProperty(exports, key, { enumerable: true, get: definition[key] });
/******/ 				}
/******/ 			}
/******/ 		};
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/hasOwnProperty shorthand */
/******/ 	(() => {
/******/ 		__webpack_require__.o = (obj, prop) => (Object.prototype.hasOwnProperty.call(obj, prop))
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/make namespace object */
/******/ 	(() => {
/******/ 		// define __esModule on exports
/******/ 		__webpack_require__.r = (exports) => {
/******/ 			if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 				Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 			}
/******/ 			Object.defineProperty(exports, '__esModule', { value: true });
/******/ 		};
/******/ 	})();
/******/ 	
/************************************************************************/
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module can't be inlined because the eval devtool is used.
/******/ 	var __webpack_exports__ = __webpack_require__("./src/PWA/wwwroot/js/src/src.js");
/******/ 	
/******/ })()
;