/* procedură ce șterge un doctor din baza de date, primește ca paramentru un id, și șterge și pacienții acelui doctor */

CREATE PROCEDURE deleteDoctorPr
	@id INT
AS
BEGIN
	
	UPDATE [User] SET Deleted = 'yes' WHERE ID = @id

	DECLARE @it INT
	DECLARE [cursor1] CURSOR FOR SELECT ID FROM Patient WHERE IDdoctor = @id
	OPEN [cursor1]
	FETCH NEXT FROM [cursor1] INTO @it
	WHILE @@FETCH_STATUS = 0 BEGIN
			
			DECLARE @cnp VARCHAR(max) = (SELECT CNP FROM Patient WHERE ID = @it)
			exec dbo.deletePatientPr @cnp
			FETCH NEXT FROM [cursor1] INTO @it

	END
	CLOSE [cursor1]
	DEALLOCATE [cursor1]

END
