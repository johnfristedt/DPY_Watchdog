var server = window.location.protocol + "//" + window.location.host + "/";
var api = server + "api/v1/private/";
var watchdog = "http://localhost:26282/";

var loginUri = watchdog + "Login?redirecturi=" + encodeURI(server) + "authenticate";