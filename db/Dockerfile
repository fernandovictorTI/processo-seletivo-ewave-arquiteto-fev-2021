FROM mcr.microsoft.com/mssql/server:2019-latest

ENV ACCEPT_EULA y
ENV SA_PASSWORD Sql2019isfast

COPY ./setup.sql .
COPY ./entrypoint.sh .
COPY ./db-init.sh .

EXPOSE 1433
USER root

RUN chmod +x /db-init.sh

CMD /bin/bash ./entrypoint.sh