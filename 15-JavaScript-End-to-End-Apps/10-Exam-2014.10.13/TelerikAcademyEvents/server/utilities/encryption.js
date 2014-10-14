'use strict';
var crypto = require('crypto');

module.exports = {
    generateSalt: function () {
        return crypto.randomBytes(128).toString('base64');
    },
    generateHashedPassword: function (salt, text) {
        var hmac = crypto.createHmac('sha1', salt);
        return hmac.update(text).digest('hex');
    },
    generateHash: function (text) {
        return this.generateHashedPassword(this.generateSalt(),text);
    },
    encrypt: function(text, key) {
        var cipher = crypto.createCipher('aes256', key);
        var encryptedData = cipher.update(text, "binary", "hex");
        return (encryptedData + cipher.final("hex"));
    },
    decrypt: function(cipher, key) {
        var decipher = crypto.createDecipher("aes256", key);
        var decryptedData = decipher.update(cipher, "hex", "binary");
        return (decryptedData + decipher.final("binary"));
    }
};
