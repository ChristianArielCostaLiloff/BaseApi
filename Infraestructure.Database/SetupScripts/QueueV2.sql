-- Crear la cola de mensajes y asociar el procedimiento almacenado
CREATE QUEUE Security.RolePermissionsChangeQueue
WITH STATUS = ON, -- Indica que la cola está habilitada y lista para recibir mensajes
     ACTIVATION (
         STATUS = ON, -- Habilita la activación de la cola
         PROCEDURE_NAME = Security.usp_SendRolePermissionsChangeMessage, -- Especifica el procedimiento almacenado que se ejecutará cuando lleguen mensajes
         MAX_QUEUE_READERS = 1, -- Limita el número máximo de lectores de la cola a 1
         EXECUTE AS SELF -- Especifica que el procedimiento se ejecutará con los permisos del usuario actual
     )
