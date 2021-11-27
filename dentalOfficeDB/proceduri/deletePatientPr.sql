/* procedură de șterge un pacient din baza de date, primește CNP-ul pentru identificare, și șterge și programările pacientului */

CREATE PROCEDURE deletePatientPr
	@CNP VARCHAR(max)
AS
BEGIN
	
	UPDATE Patient SET Deleted = 'yes' WHERE CNP = @CNP

	/* TODO: trebuie sterse toate programarile acestui pacient folosind procedura deleteAppointment */
	DECLARE @idPatient INT = (SELECT ID FROM Patient WHERE CNP = @CNP)
	
	DECLARE @it INT
	DECLARE [cursor2] CURSOR FOR SELECT ID FROM Appointment WHERE IDpatient = @idPatient
	OPEN [cursor2]
	FETCH NEXT FROM [cursor2] INTO @it
	WHILE @@FETCH_STATUS = 0 BEGIN
			
			exec dbo.deleteAppointmentPr @it
			FETCH NEXT FROM [cursor2] INTO @it

	END
	CLOSE [cursor2]
	DEALLOCATE [cursor2]




END
GO
