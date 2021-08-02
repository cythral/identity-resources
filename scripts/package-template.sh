#!/bin/bash

cwd=$(dirname "${BASH_SOURCE[0]}")

if [ "$CODEBUILD_GIT_BRANCH" != "master" ]; then
    exit 0
fi

mkdir -p bin
aws cloudformation package \
    --template-file $cwd/../deploy/identity-resources.template.yml \
    --s3-bucket $ARTIFACT_STORE \
    --s3-prefix template-objects \
    --output-template-file $cwd/../bin/identity-resources.template.yml