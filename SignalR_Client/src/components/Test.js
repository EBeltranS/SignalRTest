import React, { useEffect, useState } from 'react';

export default function MyComponent() {

  const [message, setMessage] = useState('');

  useEffect(() => {
    // Realizar la solicitud GET a la API
    fetch("https://localhost:7130/api/information/sendMessage") // La URL debe ser relativa al dominio de tu aplicación
      .then(response => {
        if (!response.ok) {
          throw new Error('La solicitud no se completó correctamente.');
        }
        return response.text(); // Leer la respuesta como texto
      })
      .then(data => {
        setMessage(data); // Actualizar el estado con la respuesta de la API
      })
      .catch(error => {
        console.error('Error al llamar a la API:', error);
      });
  }, []);
/*
  useEffect(() => {
    // Realizar la solicitud GET a la API
    fetch("https://localhost:7130/api/information/sendInformation") // La URL debe ser relativa al dominio de tu aplicación
      .then(response => {
        if (!response.ok) {
          throw new Error('La solicitud no se completó correctamente.');
        }
        return response.text(); // Leer la respuesta como texto
      })
      .then(data => {
        setMessage(data); // Actualizar el estado con la respuesta de la API
      })
      .catch(error => {
        console.error('Error al llamar a la API:', error);
      });
  }, []);
*/

  return (
    <div>
      <div>Probando SignalR - Info en tiempo real:</div>
      <div>mensaje: {message}</div>
    </div>
  );
}