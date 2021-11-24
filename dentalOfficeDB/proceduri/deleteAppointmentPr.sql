CREATE PROCEDURE deleteAppointmentPr
	@id INT
AS
BEGIN
	
	UPDATE Appointment SET Deleted = 'yes' WHERE ID = @id

	DECLARE @it INT
	DECLARE [cursor3] CURSOR FOR SELECT ID FROM Agenda WHERE IDappointment = @id
	OPEN [cursor3]
	FETCH NEXT FROM [cursor3] INTO @it
	WHILE @@FETCH_STATUS = 0 BEGIN
			
			UPDATE Agenda SET Deleted = 'yes' WHERE ID = @it
			FETCH NEXT FROM [cursor3] INTO @it

	END
	CLOSE [cursor3]
	DEALLOCATE [cursor3]


END
GO
