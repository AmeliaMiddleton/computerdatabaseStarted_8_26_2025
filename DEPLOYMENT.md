# Azure Web App Deployment Guide

This guide explains how to deploy the Computer Inventory System to Azure Web App using GitHub Actions.

## Prerequisites

1. **Azure Subscription** - Active Azure subscription
2. **Azure Web App** - Create a web app named "alphageek"
3. **GitHub Repository** - This repository pushed to GitHub

## Step 1: Create Azure Web App

1. Go to Azure Portal (https://portal.azure.com)
2. Create a new Web App with these settings:
   - **Name**: `alphageek`
   - **Runtime stack**: `.NET 8 (LTS)`
   - **Operating System**: Windows
   - **Region**: Choose your preferred region
   - **App Service Plan**: Create new or use existing

## Step 2: Get Publish Profile

1. In your Azure Web App, go to **Overview**
2. Click **Get publish profile**
3. Download the `.publishsettings` file
4. Open the file and copy the content

## Step 3: Add GitHub Secret

1. Go to your GitHub repository
2. Navigate to **Settings** → **Secrets and variables** → **Actions**
3. Click **New repository secret**
4. **Name**: `AZURE_WEBAPP_PUBLISH_PROFILE`
5. **Value**: Paste the content from the publish profile file
6. Click **Add secret**

## Step 4: Configure Database

For production, consider using Azure SQL Database instead of SQLite:

1. Create Azure SQL Database
2. Update `appsettings.Production.json` with connection string:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=your-server.database.windows.net;Database=alphageek;User Id=your-username;Password=your-password;"
   }
   ```

## Step 5: Deploy

The application will automatically deploy when you:
- Push to `main` or `master` branch
- Create a pull request
- Manually trigger the workflow

## Workflow Files

- `azure-deploy.yml` - Basic deployment workflow
- `azure-deploy-complete.yml` - Comprehensive workflow with testing

## Monitoring

After deployment, monitor your application:
- Azure Portal → Web App → Monitoring
- Application Insights (if enabled)
- GitHub Actions → Actions tab

## Troubleshooting

Common issues:
1. **Build fails**: Check .NET version compatibility
2. **Deploy fails**: Verify publish profile secret
3. **Runtime errors**: Check connection strings and environment variables
4. **Database issues**: Ensure database is accessible from Azure

## Environment Variables

Set these in Azure Web App Configuration:
- `ASPNETCORE_ENVIRONMENT`: `Production`
- `ConnectionStrings__DefaultConnection`: Your database connection string
