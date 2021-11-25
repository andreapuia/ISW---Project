/* procedură ce returnează toate prețurile din baza de date care nu sunt șterse */

CREATE PROCEDURE getPricesPr
	
AS
BEGIN

	SELECT * FROM Price WHERE Deleted = 'no'

END
GO
