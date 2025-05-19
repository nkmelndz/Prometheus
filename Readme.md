docker cp ./db/clientes.sql bd_clientes:/tmp/
docker exec -it sqlcmd_client /opt/mssql-tools/bin/sqlcmd -S bd_clientes -U sa -P UPT.2024 -i /tmp/clientes.sql
for($i=1;$i -le 100;$i++) { curl 'http://localhost:5000/api/Clientes'; Start-Sleep -s 1; }