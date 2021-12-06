/* procedură ce returnează orele dintr-o zi la care sunt făcute programări */

CREATE PROCEDURE getUnavailableHoursPr
	@Date DATE
AS
BEGIN
	
	SELECT [Hour] FROM Appointment WHERE [Date] = @Date AND Deleted = 'no'

END
