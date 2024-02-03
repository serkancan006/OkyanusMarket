***Docker database ****
docker run --name oracle-19c -p 1521:1521 -e ORACLE_SID=orcl -e ORACLE_PWD=123456789 -e ORACLE_CHARACTERSET=AL32UTF8 -v D:/oracle-19c/oradata/:/opt/oracle/oradata doctorkirk/oracle-19c

docker run --name oracle-19c \
-p 1521:1521 \
-e ORACLE_SID=[ORACLE_SID] \
-e ORACLE_PWD=[ORACLE_PASSWORD] \
-e ORACLE_CHARACTERSET=[CHARSET] \
-v /your/custom/path/oracle-19c/oradata/:/opt/oracle/oradata \
doctorkirk/oracle-19c

***Docker Connection String ****
"User Id=SYS;Password=123456789;Data Source=//localhost:1521/orcl;DBA Privilege=SYSDBA"

**************oracle linux? *****************
docker run -d --name oracle-21c \
 -p 1521:1521 \
 -e ORACLE_SID=orcl \
 -e ORACLE_PDB=pdb-name \
 -e ORACLE_PWD=123456789 \
 -e ORACLE_CHARACTERSET=AL32UTF8 \
 -v D:/oracle-21c/oradata/:/opt/oracle/oradata \
container-registry.oracle.com/database/enterprise:21.3.0

docker run -d --name oracle-21c -p 1521:1521 -e ORACLE_SID=orcl -e ORACLE_PDB=pdb-name -e ORACLE_PWD=123456789 -e ORACLE_CHARACTERSET=AL32UTF8 -v D:/oracle-21c/oradata/:/opt/oracle/oradata container-registry.oracle.com/database/enterprise:21.3.0

***********************
docker run --name oracle-21c -p 1521:1521 -e ORACLE_SID=orcl -e ORACLE_PWD=123456789 -e ORACLE_CHARACTERSET=AL32UTF8 -v D:/oracle-21c/oradata/:/opt/oracle/oradata container_name

