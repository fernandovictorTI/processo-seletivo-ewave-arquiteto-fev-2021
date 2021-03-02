echo "Starting SQL Server..."
#!/bin/bash
# Run init-script with long timeout - and make it run in the background
/opt/mssql-tools/bin/sqlcmd -S favodemel.db -l 60 -U SA -P "Sql2019isfast" -i setup.sql & 
# Start SQL server
/opt/mssql/bin/sqlservr