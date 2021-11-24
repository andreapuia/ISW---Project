CREATE PROCEDURE addAgendaPr
	@idAppointment INT,
	@idIntervention INT

AS
BEGIN
	
	INSERT INTO Agenda(IDappointment,IDintervention,Deleted) VALUES (@idAppointment,@idIntervention,'no')

END
GO
