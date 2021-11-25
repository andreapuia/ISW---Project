CREATE PROCEDURE getAppointmentsFromAPatientPr
	@id INT
AS
BEGIN
	
	SELECT * FROM Appointment WHERE IDpatient = @id AND Deleted = 'no'

END
GO
