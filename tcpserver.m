clc
clear all
tcpipServer = tcpserver('localhost',55000);
while(1)
read(tcpipServer,10,"char")
end
