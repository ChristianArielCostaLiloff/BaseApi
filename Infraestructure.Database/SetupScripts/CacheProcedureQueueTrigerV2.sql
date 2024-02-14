
---- Crear el procedimiento almacenado para vaciar la cola de mensajes
--CREATE PROCEDURE [Security].[usp_EmptyQueue]
--AS
--BEGIN
--    -- Declarar variables
--    DECLARE @conversationHandle UNIQUEIDENTIFIER;

--    -- Iniciar un bucle para recibir y eliminar mensajes de la cola hasta que no haya más mensajes
--    WHILE (1 = 1)
--    BEGIN
--        -- Intentar recibir un mensaje de la cola
--        RECEIVE TOP(1) @conversationHandle = conversation_handle
--        FROM [Security].[RolePermissionsChangeQueueV1];

--        -- Salir del bucle si no hay más mensajes
--        IF (@@ROWCOUNT = 0)
--            BREAK;

--        -- Eliminar el mensaje de la cola
--        END CONVERSATION @conversationHandle;
--    END;
--END;
--GO
