/* procedură ce returnează un user, și primește ca parametru username și password */

CREATE PROCEDURE getUserPr
	@output INT OUTPUT,
	@Username VARCHAR(max),
	@Password VARCHAR(max)

AS
BEGIN
	
	DECLARE @id INT = (SELECT ID FROM [User] WHERE Username=@Username AND Password=@Password AND Deleted = 'no')

	IF @id IS NULL BEGIN
		SET @output = 1
	END ELSE BEGIN
		SELECT * FROM [User] WHERE ID = @id
		SET @output = 0
	END
	

END