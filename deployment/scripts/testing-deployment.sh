#!/usr/bin/env sh

set -x
ansible -m ping awsswarmmanager -vvv 
set +x
