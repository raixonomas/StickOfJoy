# StickOfJoy

# Documentation
Pour le project React
Après avoir installer les node-modules, vous devez aller dans le dossier MQTT. 
Créer le fichier webpack.config.js

```javascript
const webpack = require('webpack')

module.exports = {

    entry: "./lib/connect/index.js",

    //mode: "development",

    output: {
        library:  {
            type: "commonjs2"
        },
        filename: "mqtt.browser.js"
    },
    
    plugins: [
        // fix "process is not defined" error:
        // (do "npm install process" before running the build)
        new webpack.ProvidePlugin({
          process: 'process/browser',
        }),
        new webpack.ProvidePlugin({
            Buffer: [ 'buffer', 'Buffer' ],
        }),
    ],

    resolve: {
        fallback: {
            assert: require.resolve('assert'),
            buffer: require.resolve('buffer'),
            console: require.resolve('console-browserify'),
            constants: require.resolve('constants-browserify'),
            crypto: require.resolve('crypto-browserify'),
            domain: require.resolve('domain-browser'),
            events: require.resolve('events'),
            http: require.resolve('stream-http'),
            https: require.resolve('https-browserify'),
            os: require.resolve('os-browserify/browser'),
            path: require.resolve('path-browserify'),
            punycode: require.resolve('punycode'),
            process: require.resolve('process/browser'),
            querystring: require.resolve('querystring-es3'),
            stream: require.resolve('stream-browserify'),
            string_decoder: require.resolve('string_decoder'),
            sys: require.resolve('util'),
            timers: require.resolve('timers-browserify'),
            tty: require.resolve('tty-browserify'),
            url: require.resolve('url'),
            util: require.resolve('util'),
            vm: require.resolve('vm-browserify'),
            zlib: require.resolve('browserify-zlib'),
        }
    }
}
```

Dans node_modules/mqtt/package.json
Sous "browser" changer "./mqtt.js": "./lib/connect/index.js" à "./mqtt.js": "./dist/mqtt.browser.js"

Dans node_modules/mqtt executer 
npm i 
npm i buffer process
npm i webpack webpack-cli
npx webpack

Supprimer 
Supprimer le dossier node_modules/.cache

Rebuilder l'application