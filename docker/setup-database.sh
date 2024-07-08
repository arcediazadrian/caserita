#!/bin/sh
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "caseritaDB!23" -e -i /caserita/drop-database.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "caseritaDB!23" -e -i /caserita/create-database.sql