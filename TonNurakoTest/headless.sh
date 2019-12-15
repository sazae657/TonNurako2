#!/bin/bash
export LANG="ja_JP.UTF-8" 
export DISPLAY=:9
XPID=""

function kill_server {
    kill ${XPID}
}

function run_server {
    Xvfb ${DISPLAY} -screen 0 320x240x24 &
    XPID=$!
}

function bailout {
   kill_server
   exit 9
}

run_server

dotnet test TonNurakoTest/TonNurakoTest.csproj
dotnet test TonNurakoTestEx/TonNurakoTestEx.csproj
kill_server
