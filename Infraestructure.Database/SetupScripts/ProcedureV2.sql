CREATE PROCEDURE [Security].[usp_SendRolePermissionsChangeMessage]
AS
BEGIN
    -- Declarar variables
    DECLARE @xmlData XML; -- Variable para almacenar los datos en formato XML
    DECLARE @ConversationHandle UNIQUEIDENTIFIER; -- Variable para almacenar el identificador de la conversación

    -- Seleccionar los datos de la tabla RolePermissions y convertirlos en XML
    SET @xmlData = (
        SELECT Id, IdRole, IdPermission 
        FROM [Security].[RolePermissions]
        FOR XML AUTO, ROOT('RolePermissions')
    );

    -- Iniciar una conversación y obtener el identificador de la conversación
    BEGIN DIALOG CONVERSATION @ConversationHandle
    FROM SERVICE RolePermissionsChangeQueue -- Servicio de la cola de mensajes
    TO SERVICE 'RolePermissionsChangeQueue' -- Nombre de la cola de mensajes
    WITH ENCRYPTION = OFF; -- Deshabilitar la encriptación

    -- Enviar el mensaje a la cola de mensajes
    SEND ON CONVERSATION @ConversationHandle
    (@xmlData);

END;
GO

