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
  dotnet lambda package --configuration release --framework netcoreapp2.1 --output-package bin/release/netcoreapp2.1/deploy-package.zip /p:Provider=aws
  # serverless deploy --config serverless.aws.yml -v
  cp serverless.aws.yml serverless.yml
  serverless deploy -v
fi
if [$1 = "azure"]
then
  # func azure functionapp publish AgnosticHello --dotnet-cli-params /p:Provider=azure
  dotnet lambda package --configuration release --framework netcoreapp2.1 --output-package bin/release/netcoreapp2.1/deploy-package.zip /p:Provider=azure
  # serverless deploy --config serverless.azure.yml -v
  cp serverless.azure.yml serverless.yml
  serverless deploy -v
fi
