# Descripción de la API de ZenDriver

La API de Conductores y Empresas de Transporte es una REST API construida en C# utilizando el framework .NET 6. Esta API permite a los usuarios consultar información relacionada con conductores y empresas del rubro de transporte.

## Ejemplo de Endpoints Disponibles

[![Azure Deployment](https://github.com/Innova-mind/ZenDriver.API/blob/main/end-points.png)](https://innovamind.azurewebsites.net/swagger/index.html)
[Endpoints Disponibles](https://innovamind.azurewebsites.net/swagger/index.html)


## Respuestas

La API devuelve las respuestas en formato JSON. Los campos devueltos varían según el endpoint consultado. En general, los campos incluyen información básica como el nombre, la dirección y los detalles de contacto del conductor o empresa consultada.

En caso de que ocurra un error durante una consulta, la API devolverá una respuesta con un mensaje de error y un código de estado HTTP correspondiente.

## Autenticación

Para acceder a los endpoints de la API, es necesario autenticarse utilizando un token de acceso. El token se debe incluir en el encabezado `Authorization` de todas las solicitudes. Si no se proporciona un token válido, la API devolverá un código de estado HTTP 401 (No autorizado).

## Conclusión

La API de Conductores y Empresas de Transporte es una herramienta útil para obtener información sobre conductores y empresas del rubro de transporte. Los endpoints disponibles permiten realizar consultas detalladas y filtradas para obtener resultados específicos. La autenticación es necesaria para garantizar la seguridad de los datos consultados.