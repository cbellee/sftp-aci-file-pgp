# sftp-aci-file-pgp

Automated deployment of SFTP container instnace (ACI), Key Vault & Azure Functions to Encrypt/Decrypt file using PGP.

## Deployment
- Fork this repo into your own GitHub account
- Create a new Azure DevOps YAML Pipeline
  - choose your forked repo as the source repository
  - select the azure-pipelines.yml file in the repo root
  - modify the following lines in the azure-pipelines.yml file
    - `azureSubscription: 'azure_service_connection_name' # change to match a valid Azure service connection in Azure DevOps`
    - `sftpUserName: 'username' # change to your desired username`
    - `passPhrase: '********' # change this to your desired PGP + SSH private key password`
    - `userObjectId: '57963f10-818b-406d-a2f6-6e758d86e259' # change this to a valid user objectId for it to access keyvault`
   
