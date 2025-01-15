'use strict';

const path = require('path');

module.exports = {
  mode: 'development',
  entry: './src/PWA/wwwroot/js/src/src.js',
  output: {
    filename: 'dist.js',
    path: path.resolve(__dirname, './src/PWA/wwwroot/js/dist'),
  }
};
