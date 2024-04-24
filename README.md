# Contact Database Application

## Deploying the App using Azure Resource Manager (ARM) Template

Azure Resource Manager (ARM) templates are JSON files that define the resources you need to deploy for your solution. In this case, we are using an ARM template to deploy an App Service and an App Service Plan.

### Prerequisites

- An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/free/).
- Install the [Azure PowerShell](https://docs.microsoft.com/powershell/azure/install-az-ps) module.

### Steps to Deploy

1. Open Azure PowerShell and login to your Azure account using `Connect-AzAccount` and follow the prompts.

2. Navigate to the directory containing the `deploy.json` and `deploy.parameters.json` files.

3. Run the following command to create a new resource group (replace `YourResourceGroupName` and `YourLocation` with your desired resource group name and location):

4. Run the following command to deploy the resources defined in the ARM template:

New-AzResourceGroupDeployment -ResourceGroupName YourResourceGroupName -TemplateFile ./deploy.json -TemplateParameterFile ./deploy.parameters.json

## Setting up GitHub Actions Workflow

GitHub Actions help you automate your software development workflows in the same place you store code and collaborate on pull requests and issues.

### Prerequisites

- A GitHub account.
- Administrator access to a repository where your project is stored.

### Steps to Setup

1. In your repository, create a new file in the `.github/workflows` directory named `ci.yml`.

2. Add the following YAML code to define your workflow:

name: CI
on: push: branches: [ main ] pull_request: branches: [ main ]
jobs: build:
runs-on: ubuntu-latest

steps:
- uses: actions/checkout@v2
- name: Run a one-line script
  run: echo Hello, world!

3. Commit and push your changes to the repository.

This is a basic example of a GitHub Actions workflow. You can customize this workflow to build, test, package, release, or deploy any code project on GitHub. For more information, see the [GitHub Actions documentation](https://docs.github.com/actions).
## Setting up GitHub Actions Workflow

GitHub Actions help you automate your software development workflows in the same place you store code and collaborate on pull requests and issues.

### Prerequisites

- A GitHub account.
- Administrator access to a repository where your project is stored.