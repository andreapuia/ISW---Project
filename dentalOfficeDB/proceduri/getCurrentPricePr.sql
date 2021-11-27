CREATE PROCEDURE getCurrentPricePr
	@output INT OUTPUT,
	@id INT
AS
BEGIN
	
	DECLARE @startDate DATE = (SELECT StartDate FROM Price WHERE IDintervention = @id AND EndDate is null)
	
	IF CAST(GETDATE() as DATE) >= @startDate BEGIN

		SELECT * FROM Price WHERE IDintervention = @id AND EndDate is null
		SET @output = 0

	END ELSE BEGIN

		DECLARE @idPrice INT = (SELECT ID FROM Price WHERE IDintervention = @id AND StartDate <= CAST(GETDATE() as DATE) AND CAST(GETDATE() as DATE) <= EndDate)

		IF @idPrice is not null BEGIN

			SELECT * FROM Price WHERE ID = @idPrice
			SET @output = 0

		END ELSE BEGIN

			SET @output = 1

		END
	END

END
GO
