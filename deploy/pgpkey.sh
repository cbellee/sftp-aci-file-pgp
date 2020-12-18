#/bin/bash -e

while getopts p:o: flag
do
    case "${flag}" in
        p) passphrase=${OPTARG};;
		o) outputpath=${OPTARG};;
    esac
done

# generate a new pgp key pair
$PIPELINE_WORKSPACE/console_app_drop/consoleApp $passphrase $outputpath

# create base64 encoded versions of public & private ssh keys
priKey=$(cat $outputpath/private_base64.asc)
pubKey=$(cat $outputpath/public_base64.asc)

# echo "pgpPublicKey: $pubKey"
# echo "pgpPrivateKey: $priKey"

# set pipeline evironment variables
echo "##vso[task.setvariable variable=pgpPrivateKey]$priKey"
echo "##vso[task.setvariable variable=pgpPublicKey]$pubKey"