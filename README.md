# sftp-aci-file-pgp

Automated deployment of SFTP container instance (ACI), Key Vault & Azure Functions to Encrypt/Decrypt file using PGP.

## Deployment
- Fork this repo into your own GitHub account
- Create a new Azure DevOps YAML Pipeline
  - choose your forked repo as the source repository
  - select the azure-pipelines.yml file in the repo root
  - modify the following lines in the azure-pipelines.yml file
    - `azureSubscription: 'azure_service_connection_name' # change to a valid ADO service connection name`
    - `resourceGroupName: 'rg name' # change to desired RG name`
    - `location: 'australiaeast' # change  to desired Azure region`
    - `sftpUserName: 'username' # change to your desired username`
    - `passPhrase: '********' # change this to desired PGP + SSH private key password`
    - `userObjectId: '57963f10-818b-406d-a2f6-6e758d86e259' # change this to a valid user objectId for it to access keyvault`
   
