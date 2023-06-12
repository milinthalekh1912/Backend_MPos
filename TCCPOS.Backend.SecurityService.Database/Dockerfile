FROM mysql:8.0

#ENV MYSQL_RANDOM_ROOT_PASSWORD 1
#ENV MYSQL_DATABASE securitydb
#ENV MYSQL_USER devadmin
#ENV MYSQL_PASSWORD devadmin1234

ADD "TCCPOS.Backend.SecurityService.Database/initscript.sql" /docker-entrypoint-initdb.d

EXPOSE 3306