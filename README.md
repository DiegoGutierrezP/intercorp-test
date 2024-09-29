# Intercorp Test - Backend

Este es un proyecto de microservicios desarrollado en .NET 8 que utiliza RabbitMQ como sistema de mensajería. La arquitectura está diseñada para ser escalable y eficiente, facilitando la comunicación asíncrona entre los servicios. Este enfoque permite una mayor flexibilidad y robustez en la gestión de eventos y procesos dentro de la aplicación.

## Instrucciones para Ejecutar el Proyecto

1. **Levantar los Servicios**  
   Ejecuta `docker-compose up` para iniciar el proyecto. Esto creará varios servicios, incluyendo la base de datos en PostgreSQL.

2. **Conexión a la Base de Datos**  
   Puedes conectarte a la base de datos utilizando tu IDE preferido, como DBeaver. Configura la conexión con los siguientes parámetros:

   - **Host:** localhost
   - **Port:** 5432
   - **Database:** postgres
   - **Username:** postgres
   - **Password:** pass123

3. **Creación de Tablas**  
   Después de conectarte a la base de datos, ejecuta los siguientes scripts para crear las tablas necesarias:

   ```sql
   CREATE TABLE "Activities" (
       "Id" SERIAL PRIMARY KEY,
       "Type" INT NOT NULL,  -- 1: leer archivo
       "FileName" VARCHAR(255) NOT NULL,
       "FileNumber" INT NOT NULL,
       "Data" TEXT,
       "Log" TEXT,
       "Status" INT NOT NULL,  -- Suponiendo que ActivityStatus es un tipo INT
       "CreatedAt" TIMESTAMP NOT NULL DEFAULT NOW(),
       "UpdatedAt" TIMESTAMP NOT NULL DEFAULT NOW()
   );

   CREATE TABLE "FileInformations" (
       "Id" SERIAL PRIMARY KEY,
       "Random" VARCHAR(255),
       "RandomFloat" DECIMAL,
       "Bool" BOOLEAN NOT NULL,
       "Date" VARCHAR(50),  -- Considera usar un tipo de fecha adecuado si es necesario
       "RegEx" VARCHAR(255),
       "FileName" VARCHAR(255),
       "FileNumber" INTEGER,
       "Enum" VARCHAR(255),
       "Elt" JSONB,
       "Person" JSONB,
       "LastUpdated" VARCHAR(255),
       "LastModified" VARCHAR(255),
       "CreatedAt" TIMESTAMP NOT NULL DEFAULT NOW(),
       "UpdatedAt" TIMESTAMP NOT NULL DEFAULT NOW()
   );

3. **Reconstruir el docker compose**      
   Después de crear las tablas, ejecuta docker-compose build para reconstruir los servicios.