#!/usr/bin/env sh

set -e
set -x

project="e2etest"

cd "$(dirname "$0")/.."

docker-compose -p "$project" -f path/to/docker-compose.yml build

mkdir -m 777 -p "$(pwd)/Reports"

docker-compose -p "$project" -f path/to/docker-compose.yml up -d scooby_api scooby_webapp scoob_db selenium-hub firefox chrome edge
docker-compose -p "$project" -f path/to/docker-compose.yml up --no-deps scoob_test

container_id=$(docker ps -aqf "name=scoob_test")
docker cp "$container_id:/src/ScoobTestBDD/LivingDoc.html" "$(pwd)/Reports"
echo "SpecFlow LivingDoc report is copied to ./Reports"
ls -l "$(pwd)/Reports"

exit_code=$(docker inspect "$container_id" -f '{{.State.ExitCode}}')

if [ "$exit_code" -eq 0 ]; then
    exit "$exit_code"
else
    echo "Test failed"
fi
