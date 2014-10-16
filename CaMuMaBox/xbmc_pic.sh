#!/bin/sh
echo Display $1
/usr/bin/curl --request POST --data '{"jsonrpc":"2.0","method":"Player.Open","params":{"item":{"file":"'$1'"}}}' -H "Content-type:application/json"  http://localhost/jsonrpc
