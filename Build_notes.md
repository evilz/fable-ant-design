yarn build
cd .\src\Fable.Ant.Design\
dotnet pack -c release
dotnet nuget push .\Fable.Ant.Design.0.0.0-beta-1.nupkg -s https://www.nuget.org -k TO-CHANGE




OU 

=> mettre a jour la version dans le projet
dotnet pack .\src\Fable.Ant.Design\ -c release