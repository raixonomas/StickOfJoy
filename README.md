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


premièrement, vous allez voir quatres folder dans le projet : MQTT, highscore-web, hi2txt_doc et PiScript.
    le dossier MQTT contient la solution qui est exécuté sur la machine virtuelle 10.4.1.44 : 707. cette machine est notre broker mqtt
    le dossier highscore-web contien notre application react qui vas chercher les hi-scores de tout les jeux d'arcade et les affiche a l'écran
    le dossier hi2txt_doc contient une application tierce qui sert a décrypter les fichier de high score dans le rasberry pi.
    le dossier PiScript contient les deux scripts qui se font exétuter sur le rasberry pi ansci de la cron table qui exécute ces scripts.

la cron table dans le rasberry pi est au chemin var/spool/cron/crontabs/root il contient deux lignes qui apellent des scripts a tout les 15 minutes
le script FetchHi.sh va chercher les meilleur scores de tout les jeux d'arcade et les decrypte dans des fichiers txt lisible par un humain dans le folder home/pi/RetroPie/roms/arcae/fbneo/ReadableScore
le script SendMqttHi.sh va chercher tout les scores decrypte et les envoi vers notre broker mqtt. 
ces deux scripts se trouvent dans le folder home/pi/RetroPie/roms/arcae/fbneo/hi2txt/