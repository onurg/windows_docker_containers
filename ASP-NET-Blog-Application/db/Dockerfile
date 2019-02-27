FROM microsoft/mssql-server-windows-express

# SQL environmental variables
ENV sa_password="Password123"
ENV ACCEPT_EULA="Y"
ENV attach_dbs="[]"

# Copy SQL scripts for setting up blog database and tables
COPY . /

WORKDIR /

# Create blog application database and tables
RUN powershell sqlcmd -S localhost,1433 -i Setup-blogdatabase.sql
RUN powershell sqlcmd -S localhost,1433 -i Setup-blogtables.sql

CMD powershell ./start -ACCEPT_EULA $env:ACCEPT_EULA -sa_password $env:sa_password -attach_dbs \"$env:attach_dbs\" -Verbose
