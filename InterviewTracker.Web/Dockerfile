#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["InterviewTracker.Web/InterviewTracker.Web.csproj", "InterviewTracker.Web/"]
COPY ["InterviewTracker.BusinessLogic/InterviewTracker.BusinessLogic.csproj", "InterviewTracker.BusinessLogic/"]
COPY ["InterviewTracker.DataAccess/InterviewTracker.DataAccess.csproj", "InterviewTracker.DataAccess/"]
COPY ["InterviewTracker.DataObject/InterviewTracker.DataObject.csproj", "InterviewTracker.DataObject/"]
RUN dotnet restore "InterviewTracker.Web/InterviewTracker.Web.csproj"
COPY . .
WORKDIR "/src/InterviewTracker.Web"
RUN dotnet build "InterviewTracker.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InterviewTracker.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InterviewTracker.Web.dll"]