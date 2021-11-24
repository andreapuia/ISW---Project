/* procedură ce adaugă un pacient în baza de date, și verifică ca pacientul să nu existe deja, dacă deja există se verifică dacă este șters sau nu */

CREATE PROCEDURE addPatientPr
	@output INT OUTPUT,
	@IDdoctor INT,
	@FirstName VARCHAR(max),
	@LastName VARCHAR(max),
	@CNP VARCHAR(max),
	@City VARCHAR(max)

AS
BEGIN

	DECLARE @id INT = (SELECT ID FROM Patient WHERE CNP = @CNP)

	IF @id is null BEGIN
		
		INSERT INTO Patient(IDdoctor,FirstName,LastName,CNP,City,Deleted) VALUES (@IDdoctor,@FirstName,@LastName,@CNP,@City,'no')
		SET @output = 0

	END ELSE BEGIN
	
		DECLARE @deleted VARCHAR(max) = (SELECT Deleted FROM Patient WHERE CNP = @CNP)
		IF @deleted = 'yes' BEGIN

			DECLARE @doctor INT = (SELECT IDdoctor FROM Patient WHERE CNP = @CNP)
			IF @doctor = @IDdoctor BEGIN /* pacientul și-a păstrat doctorul */
			
				SET @output = 0

			END ELSE BEGIN /* pacientul s-a transferat la alt doctor*/
				
				SET @output = 2
			END


			UPDATE Patient SET IDdoctor = @IDdoctor,FirstName=@FirstName, LastName=@LastName, City=@City, Deleted = 'no' WHERE CNP = @CNP

			DECLARE @idPatient INT = (SELECT ID FROM Patient WHERE CNP = @CNP)
			UPDATE Appointment SET Deleted = 'no' WHERE IDpatient = @idPatient
			/* TODO: pentru toate programarile acestui pacient, trebuie sa marchez ca fiind nesterse valorile din tabela intermediara*/

			

		END ELSE BEGIN
	
			SET @output = 1

		END
	END
END
