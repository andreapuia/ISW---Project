/* procedură ce returnează toate intervențiile din baza de date care nu sunt șterse */

CREATE PROCEDURE getInterventionsPr

AS
BEGIN
	
	SELECT * FROM Intervention WHERE Deleted = 'no'

END
