/* procedură ce actualizează un pacient din baza de date, primește ca parametrii FirstName, LastName, City și CNP-ul pentru identificare */

CREATE PROCEDURE updatePatientPr
	@CNP VARCHAR(max),
	@FirstName VARCHAR(max),
	@LastName VARCHAR(max),
	@City VARCHAR(max) 

AS
BEGIN
	
	UPDATE Patient 
	SET FirstName = @FirstName, LastName = @LastName, City = @City
	WHERE CNP = @CNP

END
GO
