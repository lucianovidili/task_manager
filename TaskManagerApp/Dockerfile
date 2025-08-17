# --- Build stage ---
    FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
    WORKDIR /src
    
    # copy csproj and restore (better cache)
    COPY *.csproj ./
    RUN dotnet restore
    
    # copy everything and publish
    COPY . .
    RUN dotnet publish -c Release -o /app/publish
    
    # --- Runtime stage ---
    FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
    WORKDIR /app
    
    # copy published output
    COPY --from=build /app/publish .
    
    # expose the usual .NET container port (container listens on 8080 by default)
    EXPOSE 8080
    
    # run the app (replace TaskManagerApp.dll with your real DLL name if different)
    ENTRYPOINT ["dotnet", "TaskManagerApp.dll"]