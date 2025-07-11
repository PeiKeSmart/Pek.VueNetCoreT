var sha1Util = require('./sha1.js'); //加密算法引入

function jsonVAL(json)
{
    var v = '';
    for(var i in json){
        v += json[i];
    }
    return v;
}

function getTimestamp()
{
    return Date.parse(new Date());
}

function mtRand(min, max)
{
    var result = Math.random() * (max - min + 1) + min;
    return parseInt(result);
}

function sign(json, server_token)
{
    json.timestamp = getTimestamp();
    json.nonce = mtRand(100000, 999999);
    json.appkey = server_token;

    var s = [json.timestamp.toString(), json.nonce.toString(), json.appkey];
    s.sort();

    json.signature = sha1Util.sha1(jsonVAL(s));
    delete json.appkey;
    return json;
}

var x = {
    sign: sign
};
module.exports = x;