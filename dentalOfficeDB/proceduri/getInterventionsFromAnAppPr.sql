CREATE PROCEDURE getInterventionsFromAnAppPr
	@idAppointment INT
AS
BEGIN
	
	select i.ID,i.Name,i.Deleted
	from Agenda a
	inner join Intervention i ON i.ID = a.IDintervention
	where a.IDappointment = @idAppointment

END
