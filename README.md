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


Premièrement, vous allez voir quatres dossier dans le projet : MQTT, highscore-web, hi2txt_doc et PiScript.
    - Le dossier MQTT contient la solution qui est exécuté sur la machine virtuelle 10.4.1.44 : 707. cette machine est notre broker mqtt
    - Le dossier highscore-web contien notre application react qui vas chercher les hi-scores de tout les jeux d'arcade et les affiche a l'écran
    - Le dossier hi2txt_doc contient une application tierce qui sert a décrypter les fichier de high score dans le rasberry pi.
    - Le dossier PiScript contient les deux scripts qui se font exétuter sur le rasberry pi ansci de la cron table qui exécute ces scripts.

Pour l'installation de Java, il faudra utiliser les commandes "sudo apt update" et "sudo apt install default-jdk"

Pour hi2txt, il faut télécharger une version compatible avec Java (https://greatstoneex.github.io/hi2txt-doc/). Ensuite, il faut avoir un disque ayant un dossier nommé "RetroPie" vide. On prend le disque et on le met dans le Pie. Cela aura pour effet de copier le contenu du Pie dans le disque. Par la suite, il faudra créer un dossier nommé "Hi2txt" à l'endroit home/pi/RetroPie/roms/arcae/fbneo/. Une fois créé, il faudra prendre ce que nous venons de télécharger pour le copier dans le dossier "Hi2txt".
La prochaine fois que le Pie va redémarrer avec le disque de branché, hi2txt sera installé.



La cron table dans le rasberry pi est au chemin var/spool/cron/crontabs/root. Il contient deux lignes qui apellent des scripts a tous les 15 minutes.
Le script FetchHi.sh va chercher les meilleurs scores de tout les jeux d'arcade et les décryptés en fichier txt dans le dossier home/pi/RetroPie/roms/arcae/fbneo/ReadableScore 
Faire attention, il faut créer le dossier "ReadableScore" pour que le cron tab s'effectue correctement.
Le script SendMqttHi.sh va chercher tout les scores décryptés et les envois vers notre broker mqtt. 
Ces deux scripts se trouvent dans le folder home/pi/RetroPie/roms/arcae/fbneo/hi2txt/