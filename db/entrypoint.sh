echo "Starting SQL Server..."
/opt/mssql-tools/bin/sqlcmd -S localhost -l 60 -U SA -P "Sql2019isfast" -i setup.sql & /opt/mssql/bin/sqlservr