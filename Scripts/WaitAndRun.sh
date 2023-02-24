#!/usr/bin/env sh

set -e
set -x

# Wait for .NET to be up and running
until dotnet "$1" &> /dev/null; do
  sleep 1
done

# Wait for the Selenium hub to be up and running
while ! curl -f "http://selenium-hub:4444/wd/hub/status" &> /dev/null; do
  sleep 30
done

# Check if livingdoc is installed and install it if necessary
if ! command -v livingdoc &> /dev/null; then
  dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
  export PATH="$PATH:/root/.dotnet/tools"
fi

# Generate the SpecFlow LivingDoc report
echo "Starting SpecFlow LivingDoc Report Generation"
livingdoc test-assembly "/src/ScoobTestBDD/bin/Debug/net7.0/ScoobTestBDD.dll" -t "/src/ScoobTestBDD/bin/Debug/net7.0/TestExecution.json"
