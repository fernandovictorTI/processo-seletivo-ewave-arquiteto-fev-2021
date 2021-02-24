FROM mcr.microsoft.com/mssql/server:2019-CU9-ubuntu-16.04
COPY . /

RUN sudo chmod +x /db-init.sh
CMD /bin/bash ./entrypoint.sh