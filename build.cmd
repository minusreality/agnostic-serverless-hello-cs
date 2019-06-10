dotnet restore
if "%1" == "azure" (
    func azure functionapp publish AgnosticHello --dotnet-cli-params /p:Provider=azure
)
if "%1" == "aws" (
    dotnet lambda package --configuration release --framework netcoreapp2.1 --output-package bin/release/netcoreapp2.1/deploy-package.zip /p:Provider=aws
    serverless deploy -v
)

