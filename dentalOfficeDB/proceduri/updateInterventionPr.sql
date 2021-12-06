/* procedură ce actualizează prețul unei proceduri existente, primește ca parametru id-ul procedurii,noul preț și data de start */

CREATE PROCEDURE updateInterventionPr
	@output INT OUTPUT,
	@limit Date OUTPUT,
	@ID INT,
	@Price DECIMAL(5,2),
	@StartDate DATE

AS
BEGIN
	
	DECLARE @lastPriceID INT = (SELECT ID FROM Price WHERE IDintervention = @ID AND EndDate is null)
	DECLARE @startDatePrice Date =  (SELECT StartDate FROM Price WHERE ID = @lastPriceID)

	DECLARE @endDatePrice DATE = DATEADD(day,-1,@StartDate)

	IF @startDatePrice > @endDatePrice BEGIN

		SET @output = 1
		
	END ELSE BEGIN

		UPDATE Price SET EndDate = @endDatePrice WHERE ID = @lastPriceID
		INSERT INTO Price(IDintervention,Value,StartDate,EndDate,Deleted) VALUES (@ID,@Price,@StartDate,null,'no')
		SET @output = 0

	END

	SET @limit = @startDatePrice

END
