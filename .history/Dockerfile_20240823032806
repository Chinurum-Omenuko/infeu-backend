# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base

# Set the working directory in the container
WORKDIR /app

# Copy the published output from the publish folder to the container
COPY ./publish/ .

# Expose port 80 for the application
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "infeubackend.dll"]
