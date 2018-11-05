#!/bin/bash

#install zip on debian OS, since microsoft/dotnet container doesn't have zip by default
if [ -f /etc/debian_version ]
then
  apt -qq update
  apt -qq -y install zip
fi

dotnet restore
if [$1 = "aws"]
then
  dotnet lambda package --configuration release --framework netcoreapp2.0 --output-package bin/release/netcoreapp2.0/deploy-package.zip /p:Provider=aws
  serverless deploy
fi
if [$1 = "azure"]
then
  func azure functionapp publish AgnosticHello --dotnet-cli-params /p:Provider=azure
fi
