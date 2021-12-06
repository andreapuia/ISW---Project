/* procedură ce returnează toți pacienți neșterși din baza de date pentru un anumit doctor, primește ca parametru id-ul doctorului*/

CREATE PROCEDURE getPatientsFromADoctorPr
	@id INT
AS
BEGIN
	
	SELECT * FROM Patient WHERE DELETED = 'no' AND IDdoctor = @id

END
