# Villa

Endpoints:
/api/villa GET devuelve una lista de todas las villas

/api/villa/id GET devuelve una villa a partir de un id proporcionado por el cliente

/api/villa/ POST agrega una villa con las siguientes propiedades 
{
  "id": 0,
  "nombre": "string",
  "habitantes": 0,
  "imagenUrl": "string"
}

/api/villa/ DELETE elimina una villa a partir de un Id dado

/api/villa/ PUT Edita las propiedades de la villa a partir de un Id dado

/api/villa/ PATCH Edita una propiedad de la villa a partir de un Id dado


### Se crea una bd con nombre Villa bd en el localhost, en este caso utilizo el servidor SQL de Microsoft 
