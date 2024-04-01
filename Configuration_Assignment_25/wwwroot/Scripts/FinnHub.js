
const finnHubToken = document.getElementById("FinnHubToken").value;
const webSocket = new WebSocket(`wss://ws.finnhub.io?token=${finnHubToken}`)
var stocksSymbol = document.getElementById("StockSymbol").value;

webSocket.addEventListener('open', function (event) {
    webSocket.send(JSON.stringify({'type' : 'subscribe', 'symbol' : stockSymbol}))
});


webSocket.addEventListener('message', function (event) {

    var eventData = JSON.parse(event.data);

    var newStockPrice = JSON.parse(event.data).data[0];

    $(".stockPrice").text(newStockPrice.toFixed(2));

});

var unSubscribe = function (symbol) {
    webSocket.send(JSON.stringify({ 'type': 'unsubscribe', 'symbol' : symbol}))
}

window.onunload = function () {
    unSubscribe(stocksSymbol);
};
