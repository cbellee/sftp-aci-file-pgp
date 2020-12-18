#/bin/bash -e

while getopts p: flag
do
    case "${flag}" in
        p) passphrase=${OPTARG};;
    esac
done

# generate a new ssh key pair
echo -e 'y' | ssh-keygen -f scratch -N $passphrase

# create base64 encoded versions of public & private ssh keys
priKey=$(base64 -w 0 ./scratch)
pubKey=$(base64 -w 0 ./scratch.pub)

# echo "sshPublicKey: $pubKey"
# echo "sshPrivateKey: $priKey"

# copy public key to new file
cat 'scratch.pub' > ./id_rsa.pub

# set pipeline evironment variables
echo "##vso[task.setvariable variable=sshPrivateKey]$priKey"
echo "##vso[task.setvariable variable=sshPublicKey]$pubKey"
