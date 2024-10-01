# Intercorp Test - Backend

Este es un proyecto de microservicios desarrollado en .NET 8 que utiliza RabbitMQ como sistema de mensajer�a. La arquitectura est� dise�ada para ser escalable y eficiente, facilitando la comunicaci�n as�ncrona entre los servicios. Este enfoque permite una mayor flexibilidad y robustez en la gesti�n de eventos y procesos dentro de la aplicaci�n.

## Instrucciones para Ejecutar el Proyecto

1. **Levantar los Servicios**  
   Ejecuta `docker-compose up` para iniciar el proyecto. Esto crear� varios servicios, incluyendo la base de datos en PostgreSQL.

2. **Conexi�n a la Base de Datos**  
   Puedes conectarte a la base de datos utilizando tu IDE preferido, como DBeaver. Configura la conexi�n con los siguientes par�metros:

   - **Host:** localhost
   - **Port:** 5432
   - **Database:** postgres
   - **Username:** postgres
   - **Password:** pass123

### Estructura del proyecto

![Descripci�n de la imagen](./proyect_structure.PNG)