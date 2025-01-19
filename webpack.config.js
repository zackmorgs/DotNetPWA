'use strict';

const path = require('path');
const TerserPlugin = require('terser-webpack-plugin');

module.exports = {
  mode: 'development',
  entry: './src/PWA/wwwroot/js/src/src.js',
  output: {
    filename: 'dist.js',
    path: path.resolve(__dirname, './src/PWA/wwwroot/js/dist'),
  },
  optimization: {
    minimize: true,
    minimizer: [
      new TerserPlugin({
        terserOptions: {
          compress: true, // Enable compression
          mangle: false  // Enable name mangling
        },
      }),
    ],
  },
};
