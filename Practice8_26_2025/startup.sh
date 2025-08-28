#!/bin/bash
echo "Starting Computer Inventory System..."

# Ensure the database directory exists
mkdir -p /home/site/wwwroot/Data

# Set environment variables
export ASPNETCORE_ENVIRONMENT=Production
export ASPNETCORE_URLS=http://localhost:8080

# Start the application
dotnet Practice8_26_2025_Copy.dll
