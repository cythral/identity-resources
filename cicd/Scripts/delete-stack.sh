#!/bin/bash

set -eo pipefail

resourcesToRetain=$(echo $@ | xargs)
stackName=identity-resources
command="aws cloudformation delete-stack --stack-name $stackName"

if [ "$resourcesToRetain" != "" ]; then
    command="$command --retain-resources $resourcesToRetain"
fi

$command
aws cloudformation wait stack-delete-complete --stack-name $stackName