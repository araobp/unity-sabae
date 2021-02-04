const fs = require('fs');
const https = require('https');
const express = require('express');

const PORT = 9001;

const app = express();
app.use(express.static(__dirname))

const options = {
  key: fs.readFileSync('cert/my.key'),
  cert: fs.readFileSync('cert/cert.pem'),
  passphrase: 'webrtc'
}

const server = https.createServer(options, app);

server.listen(PORT);
console.log('started');
