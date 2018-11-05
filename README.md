This is an example of creating a platform agnostic serverless function. 

Working deployment targets:
AWS Lambda
Azure Functions

#Setup
Install npm: https://www.npmjs.com/get-npm
npm install -g serverless
dotnet add package Microsoft.NET.Sdk.Functions --version 1.0.23

#Amazon
1. Sign up for Amazon AWS
2. Install AWS CLI: https://docs.aws.amazon.com/cli/latest/userguide/installing.html
3. Set up AWS Credentials: https://serverless.com/framework/docs/providers/aws/guide/credentials/
4. ./build.cmd aws
5. serverless deploy
6. serverless invoke -f hello
7. serverless logs --function hello

#Azure
1. Sign up for Azure Functions (you need an active Azure Functions subscription)
2. Install Azure Functions Core Tools: npm install -g azure-functions-core-tools@core
3. Set up Azure Credentials: https://serverless.com/framework/docs/providers/azure/guide/credentials/
    Note that the Client ID is the "name" attribute (ex "http://azure-cli-2018...")
4. az webapp config appsettings set --name AgnosticHello --resource-group AgnosticHello-rg --settings FUNCTIONS_WORKER_RUNTIME=dotnet
5. ./build.cmd azure
