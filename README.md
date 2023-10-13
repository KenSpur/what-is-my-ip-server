# 🌐 What Is My IP Server

Retrieve your public IP address with a simple HTTP GET request using **What Is My IP Server**. This lightweight, containerized solution is invaluable for scripts and applications requiring knowledge of their public-facing IP.

> 🖥️ Employed by [Azure DDNS Client](https://github.com/KenSpur/azure-ddns-client) to acquire the host's current public IP address.

## ☁️ Effortless Deployment in Azure 
Deploying **what-is-my-ip-server** in Azure as a container app presents a dependable, low-maintenance mechanism for obtaining your public IP.

### 🚀 Azure Deployment Made Easy
Owing to its containerized architecture, **what-is-my-ip-server** can be swiftly set up as an Azure Container App. This ensures a dedicated IP retrieval endpoint without the complexities of server management. Leverage the accompanying Terraform examples to automate and scale deployment as per your needs.

## 🛠️ Terraform Deployment in Azure 

Efficiently deploy What Is My IP Server to Azure utilizing Terraform.

### 1️⃣ Example Terraform Deployment
Below is an example setup using Terraform to deploy your app in an Azure Container Instance:

```hcl
resource "azurerm_resource_group" "example" {
  name     = "rg-example"
  location = "West Europe"
}

resource "azurerm_container_app_environment" "example" {
  name                       = "cae-example"
  location                   = azurerm_resource_group.example.location
  resource_group_name        = azurerm_resource_group.example.name
}

resource "azurerm_container_app" "example" {
  name                         = "ca-example"
  container_app_environment_id = azurerm_container_app_environment.example.id
  resource_group_name          = azurerm_resource_group.example.name
  revision_mode                = "Single"

  template {
    container {
      name   = "what-is-my-ip-server"
      image  = "ghcr.io/kenspur/what-is-my-ip-server:v0.1.2"
      cpu    = 0.25
      memory = "0.5Gi"
    }
  }
}
```

⚠️ Ensure that all placeholder values are appropriately replaced before deploying with Terraform.

## 🔄 API Endpoint

### Endpoint Details:

- **URL**: `/`
- **Method**: `GET`

### Successful Response

Upon a successful GET request, the server responds with a JSON object containing the public IP address.

- **Code**: `200 OK`
- **Content-Type**: `application/json`
- **Body**:

```json
{
  "ipAddress": "1.1.1.1"
}

```

### Usage Example:

Utilize a simple cURL command to fetch the IP address:

```shell
curl https://[your-deployment-url]/
```

⚠️ Ensure to substitute [your-deployment-url] with the actual URL where what-is-my-ip-server is deployed.
