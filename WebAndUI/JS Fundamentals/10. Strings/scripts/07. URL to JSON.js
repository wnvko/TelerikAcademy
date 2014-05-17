function parseURLtoJSON(address) {
    var protocol = [];
    var server = [];
    var resource = [];
    var counter = 0;
    var inProtocol = true;
    var inServer = false;
    var inResource = false;

    while (true) {
        if (counter < address.length) {
            var currentSymbol = address[counter++];

            if (currentSymbol === ':') {
                inProtocol = false;
                inServer = true;
                counter += 2;
            } else if (currentSymbol === '/' && inServer) {
                inServer = false;
                inResource = true;
                resource.push(currentSymbol);
            } else {
                if (inProtocol) {
                    protocol.push(currentSymbol);
                } else if (inServer) {
                    server.push(currentSymbol);
                } else {
                    resource.push(currentSymbol);
                }
            }
        } else {
            break;
        }
    }

    protocol = protocol.join('');
    server = server.join('');
    resource = resource.join('');

    var JSONstring = "{protocol: '" + protocol + "', server: '" + server + "', resource: '" + resource + "'}";
    return JSONstring;
}

var address = 'http://downloads.academy.telerik.com/svn/js-part1/2014/Lectures/10.%20Strings/Strings.pdf';
var parsed = parseURLtoJSON(address);

console.log(address);
console.log(parsed);