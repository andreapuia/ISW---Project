/* procedură ce returneaza toți doctorii din baza de date, care au câmpul Deleted egal cu 'no'*/

CREATE PROCEDURE getDoctorsPr
	
AS
BEGIN
	
	SELECT * FROM [User] WHERE Role = 'doctor' AND Deleted = 'no'

END
