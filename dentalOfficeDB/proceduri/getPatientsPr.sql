/* procedură ce returnează toți pacienți neșterși din baza de date */


CREATE PROCEDURE getPatientsPr

AS
BEGIN
	
	SELECT * FROM Patient WHERE DELETED = 'no'

END