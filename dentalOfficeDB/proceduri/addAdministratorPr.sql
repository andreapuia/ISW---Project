/* procedură ce adaugă un administrator în baza de date, și primește ca parametru username, password, first name și last name. */

CREATE PROCEDURE addAdministratorPr
	@output INT OUTPUT,
	@Username VARCHAR(max),
	@Password VARCHAR(max),
	@FirstName VARCHAR(max),
	@LastName VARCHAR(max)

AS
BEGIN
	
	DECLARE @id INT = (SELECT ID FROM [User] WHERE Username = @Username AND Role = 'administrator')

	IF @id IS NULL BEGIN

		INSERT INTO  [User](Username,Password,FirstName,LastName,Role,Deleted) VALUES (@Username,@Password,@FirstName,@LastName,'administrator','no')
		SET @output=0
	END
	ELSE BEGIN
		SET @output=1
	END
	

END