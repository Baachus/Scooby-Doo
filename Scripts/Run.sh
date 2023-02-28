#!/usr/bin/env sh

set -e
set -x

project="e2etest"

cd "$(dirname "$0")/.."

docker-compose -p "$project" build


mkdir -m 777 -p Reports

docker-compose -p "$project" up -d scooby_api scooby_webapp scooby_db selenium-hub firefox chrome edge
docker-compose -p "$project" up --no-deps scooby_test

search_dir=/src/ScoobTestBDD
for entry in "$search_dir"/*
do
  echo "$entry"
done

docker cp scooby_test:/src/ScoobTestBDD/LivingDoc.html ./Reports
echo "Specflow living document report is copied to ./Reports"
ls -l ./Reports

exit_code=$(docker inspect scooby_test -f '{{.State.ExitCode}}')

if [ $exit_code -eq 0 ]; then
    exit $exit_code
else
    echo "Test failed"
fi
