const express = require('express');
const path = require('path');

const app = express();
const publicPath = path.join(__dirname, '');

app.use(express.static(publicPath));

app.get('*', (req, res) => {
    res.sendFile(path.join(publicPath, 'index.html'));
});

app.listen(8080, () => {
    console.log("server is running!")
});