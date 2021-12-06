CREATE PROCEDURE getAppointmentsPr
AS
BEGIN
	
	SELECT * FROM Appointment WHERE Deleted = 'no'

END
GO

