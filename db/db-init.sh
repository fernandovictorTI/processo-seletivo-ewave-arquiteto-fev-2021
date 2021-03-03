sleep 60s
echo "running set up script"
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Sql2019isfast -d master -i setup.sql