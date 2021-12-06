CREATE PROCEDURE getAgendasPr

AS
BEGIN
	
	SELECT * FROM Agenda WHERE Deleted = 'no'

END
