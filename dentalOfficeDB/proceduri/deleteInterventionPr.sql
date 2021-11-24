CREATE PROCEDURE deleteInterventionPr
	@id INT

AS
BEGIN
	
	UPDATE Intervention SET Deleted = 'yes' WHERE ID = @id

	UPDATE Price SET Deleted = 'yes' WHERE IDintervention = @id

END
