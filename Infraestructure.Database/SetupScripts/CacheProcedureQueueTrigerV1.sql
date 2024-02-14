-- Crear el procedimiento almacenado
CREATE PROCEDURE [Security].[usp_SendRolePermissionsChangeMessageV1]
AS
BEGIN
    DECLARE @updateCache BIT;
    SET @updateCache = 1; -- Indicar que se requiere una actualización del caché
    -- Envía el mensaje a la cola de mensajes
    DECLARE @ConversationHandle UNIQUEIDENTIFIER;
    BEGIN DIALOG CONVERSATION @ConversationHandle FROM SERVICE RolePermissionsChangeQueueV1 TO SERVICE 'RolePermissionsChangeQueueV1';
    SEND ON CONVERSATION @ConversationHandle MESSAGE TYPE [http://schemas.microsoft.com/SQL/Notifications/PostEventNotification] (@updateCache);
END;
GO

-- Crear la cola de mensajes y asociar el procedimiento almacenado
CREATE QUEUE [Security].[RolePermissionsChangeQueueV1]
    WITH STATUS = ON,
    ACTIVATION (
        STATUS = ON,
        PROCEDURE_NAME = [Security].[usp_SendRolePermissionsChangeMessageV1],
        MAX_QUEUE_READERS = 1,
        EXECUTE AS SELF
    );
GO

-- Crear un trigger en la tabla RolePermissions para detectar cambios
CREATE TRIGGER Security.tr_RolePermissionsChangeV1
ON [Security].[RolePermissions]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    -- Llamar al procedimiento almacenado para enviar un mensaje a la cola de mensajes
    EXEC Security.usp_SendRolePermissionsChangeMessageV1;
END;
GO

