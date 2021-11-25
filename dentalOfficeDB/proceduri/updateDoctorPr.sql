/* procedură ce actualizează informațiile despre un doctor, procedura verifică ca username-ul primit ca parametru nu mai există */

CREATE PROCEDURE updateDoctorPr
	@output INT OUTPUT,
	@ID INT,
	@Username VARCHAR(max),
	@Password VARCHAR(max),
	@FirstName VARCHAR(max),
	@LastName VARCHAR(max)
AS
BEGIN
	
	DECLARE @name VARCHAR(max) = (SELECT Username FROM [User] WHERE ID = @ID)

	IF @name = @Username BEGIN

			UPDATE [User]
			SET Password = @Password, FirstName = @FirstName, LastName = @LastName
			WHERE ID = @ID
			SET @output = 0

	END ELSE BEGIN

		DECLARE @index INT = (SELECT ID FROM [User] WHERE Username = @Username)

		IF @index is null BEGIN

			UPDATE [User]
			SET UserName=@Username, Password = @Password, FirstName = @FirstName, LastName = @LastName
			WHERE ID = @ID
			SET @output = 0

		END ELSE BEGIN

			SET @output = 1

		END
	END


	
END
