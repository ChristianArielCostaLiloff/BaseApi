-- Crear la cola de mensajes y asociar el procedimiento almacenado
CREATE QUEUE Security.RolePermissionsChangeQueue
WITH STATUS = ON, -- Indica que la cola est� habilitada y lista para recibir mensajes
     ACTIVATION (
         STATUS = ON, -- Habilita la activaci�n de la cola
         PROCEDURE_NAME = Security.usp_SendRolePermissionsChangeMessage, -- Especifica el procedimiento almacenado que se ejecutar� cuando lleguen mensajes
         MAX_QUEUE_READERS = 1, -- Limita el n�mero m�ximo de lectores de la cola a 1
         EXECUTE AS SELF -- Especifica que el procedimiento se ejecutar� con los permisos del usuario actual
     )
