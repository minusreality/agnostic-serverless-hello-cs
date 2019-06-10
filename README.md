This is an example of creating a platform agnostic serverless function. The instructions below are meant to be performed in the CLI on your platform and not necessarily in visual studio.

Working deployment targets:
- AWS Lambda
- Azure Functions

# Setup
- Install .NET SDK: https://www.microsoft.com/net/download
- dotnet add package Microsoft.NET.Sdk.Functions --version 1.0.23
- Install npm: https://www.npmjs.com/get-npm
- npm install -g serverless


# AWS Lambda
- Sign up for Amazon AWS
- Install AWS CLI: https://docs.aws.amazon.com/cli/latest/userguide/installing.html
- Set up AWS Credentials: https://serverless.com/framework/docs/providers/aws/guide/credentials/
- ./build.cmd aws
- serverless deploy
- serverless invoke -f hello
- serverless logs --function hello

# Azure Functions
- Sign up for Azure Functions (you need an active Azure Functions subscription)
- Install Azure Functions Core Tools: npm install -g azure-functions-core-tools@core
- Install Azure CLI: https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest
- az login
- Set up Azure Credentials: https://serverless.com/framework/docs/providers/azure/guide/credentials/
    Note that the Client ID is the "name" attribute (ex "http://azure-cli-2018...")
- az webapp config appsettings set --name AgnosticHello --resource-group AgnosticHello-rg --settings FUNCTIONS_WORKER_RUNTIME=dotnet
- ./build.cmd azure
