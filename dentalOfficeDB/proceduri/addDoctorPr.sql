/* procedură ce adaugă un doctor în baza de date, dacă doctorul deja există, îi actualizează user name-ul și câmpul Deleted */

CREATE PROCEDURE addDoctorPr
	@output INT OUTPUT,
	@Username VARCHAR(max),
	@Password VARCHAR(max),
	@FirstName VARCHAR(max),
	@LastName VARCHAR(max)

AS
BEGIN
	
	DECLARE @id INT = (SELECT ID FROM [User] WHERE FirstName = @FirstName AND LastName = @LastName AND Role = 'doctor')

	IF @id IS NULL BEGIN

		SET @output = 0
		INSERT INTO [User](Username,Password,FirstName,LastName,Role,Deleted) VALUES (@Username,@Password,@FirstName,@LastName,'doctor','no')

	END ELSE BEGIN
		
		DECLARE @deleted VARCHAR(max) = (SELECT Deleted FROM [User] WHERE ID = @id)
		IF @deleted = 'yes' BEGIN
			
			UPDATE [User] SET Username = @Username, Password=@Password, Deleted = 'no' WHERE ID = @id
			SET @output = 0

		END ELSE BEGIN

			SET @output = 1

		END

	END


END
