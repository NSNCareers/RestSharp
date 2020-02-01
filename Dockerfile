FROM mcr.microsoft.com/dotnet/core/sdk:latest
ENV DOTNET_USE_POLLING_FILE_WATCHER 1
    
COPY . /app

WORKDIR /app

RUN ["dotnet","restore"]

RUN ["dotnet","build"]

EXPOSE 5001/tcp

ENTRYPOINT [ "dotnet", "watch", "run", "--no-restore", "--urls", "https://0.0.0.0:5001"]
