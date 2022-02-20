rm -rf  /home/runner/dotnet
mkdir -p  /home/runner/dotnet
cd /home/runner/dotnet

wget https://download.visualstudio.microsoft.com/download/pr/43f3a3bd-3df2-41e6-beca-3ec4952ca6c4/30fe7779249607d1bb3bb4b20d61a479/dotnet-sdk-3.0.103-linux-x64.tar.gz

tar -zxf dotnet-sdk-3.0.103-linux-x64.tar.gz

export DOTNET_ROOT=/home/runner/dotnet
export PATH=$PATH:/home/runner/dotnet

~/dotnet/dotnet run --project ~/TicTacToe/TicTacToe/Console.csproj