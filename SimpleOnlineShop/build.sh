#!/bin/bash
osascript -e 'tell application "Terminal" to activate' -e 'tell application "System Events" to tell process "Terminal" to keystroke "t" using command down' -e 'tell application "Terminal" to do script "
cd simpleonlineshop
dotnet clean
dotnet restore
dotnet build
" in selected tab of the front window'
osascript -e 'tell application "Terminal" to activate' -e 'tell application "System Events" to tell process "Terminal" to keystroke "t" using command down' -e 'tell application "Terminal" to do script "
cd simpleonlineshop.auth
dotnet clean
dotnet restore
dotnet build
" in selected tab of the front window'
osascript -e 'tell application "Terminal" to activate' -e 'tell application "System Events" to tell process "Terminal" to keystroke "t" using command down' -e 'tell application "Terminal" to do script "
cd simpleonlineshop.webapi
dotnet clean
dotnet restore
dotnet build
" in selected tab of the front window'
osascript -e 'tell application "Terminal" to activate' -e 'tell application "System Events" to tell process "Terminal" to keystroke "t" using command down' -e 'tell application "Terminal" to do script "
cd simpleonlineshop.test
dotnet clean
dotnet restore
dotnet build
" in selected tab of the front window'