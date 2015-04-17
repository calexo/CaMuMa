#!/usr/bin/python

import subprocess
from mpd import MPDClient
import re


from BaseHTTPServer import BaseHTTPRequestHandler
import urlparse

client = MPDClient()
#client.timeout = 10                # network timeout in seconds (floats allowed), default: None
client.idletimeout = None          # timeout for fetching the result of the idle command is handled seperately, default: None
client.connect("localhost", 6600)  # connect to localhost:6600
print(client.mpd_version)          # print the MPD version
client.disconnect()


class Handler(BaseHTTPRequestHandler):

    def parseRequest(self):
        self.parsed_path = urlparse.urlparse(self.path)
        self.parsedQuery = urlparse.parse_qs(self.parsed_path.query)
        message_parts = [
                'CLIENT VALUES:',
                'client_address=%s (%s)' % (self.client_address,
                                            self.address_string()),
                'command=%s' % self.command,
                'path=%s' % self.path,
                'real path=%s' % self.parsed_path.path,
                'query=%s' % self.parsed_path.query,
                'request_version=%s' % self.request_version,
                '',
                'SERVER VALUES:',
                'server_version=%s' % self.server_version,
                'sys_version=%s' % self.sys_version,
                'protocol_version=%s' % self.protocol_version,
                '',
                'HEADERS RECEIVED:',
                ]
        for name, value in sorted(self.headers.items()):
            message_parts.append('%s=%s' % (name, value.rstrip()))
        message_parts.append('')
        message = '\r\n'.join(message_parts)

        return message
    def do_POST(self):
        self.message = self.parseRequest()

        try:
            client.ping()
        except:
            try:
                client.disconnect()
            except:
                pass
            try:
                client.connect("localhost", 6600)
                client.ping()
                print("connected to MPD")
            except:
                print("failed to connect to MPD" )
        
        self.send_response(200)
        self.end_headers()
        cmd = self.parsed_path.path.strip('/')

        if 'poweron'==cmd:
            subprocess.check_call(["/home/pi/camuma.sh", "poweron"])
        if 'poweroff'==cmd:
            subprocess.check_call(["/home/pi/camuma.sh", "poweroff"])
        if "toggle" == cmd:
            print "Toggle from " + client.status()['state']
            if client.status()['state'] in ('play'):
                client.pause()
            else:
                client.play()
        if "next" == cmd:
            client.next()
        if "prev" == cmd:
            client.previous()
        if "shuffle" == cmd:
            client.shuffle()
        if "random" == cmd:
            if client.status()['random'] == "1":
                client.random( 0 )
            else:
                client.random( 1 )
        if "play" == cmd:
            client.play()
        if "stop" == cmd:
            client.stop()
        if "update" == cmd:
            subprocess.check_call(["/home/pi/camuma.sh", "update"])

        reres = re.search("([0-9]{6})",cmd)
        if reres:
            subprocess.check_call(["/home/pi/camuma.sh", reres.group(1)])

        self.wfile.write(self.message)
        return

    def do_GET(self):
        self.message = self.parseRequest()
        cmd = self.parsed_path.path.strip('/')


        if "stats" == cmd:
            stats = open("/home/pi/stat_file","rb").read()
            self.message = 'RET\nSTATS\n' + stats + '\n'
        if "listalbums" == cmd:
            listalbums = open("/home/pi/camuma.lst.unix","rb").read()
            self.message = 'RET\nLIST\n' + listalbums + '\nEND\n'

        self.send_response(200)
        self.end_headers()
        self.wfile.write(self.message)

        return

if __name__ == '__main__':
    from BaseHTTPServer import HTTPServer
    server = HTTPServer(('', 8080), Handler)
    print 'Starting CaMuMa http server, use <Ctrl-C> to stop'
    server.serve_forever()
