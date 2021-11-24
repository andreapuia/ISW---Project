/* procedură ce adaugă o interevenție în baza de date, împreună cu un un nou preț și o dată de start */


CREATE PROCEDURE addInterventionPr
	@output INT OUTPUT,
	@Name VARCHAR(max),
	@Price DECIMAL(5,2),
	@StartDate DATE,
	@EndDate DATE
AS
BEGIN

	DECLARE @id INT = (SELECT ID FROM Intervention WHERE Name = @Name)

	IF @id IS NULL BEGIN

		INSERT INTO  Intervention(Name,Deleted) VALUES (@Name,'no')
		INSERT INTO Price(IDintervention,Value,StartDate,EndDate,Deleted) VALUES (scope_identity(),@Price,@StartDate,@EndDate,'no')
		SET @output=0

	END ELSE BEGIN

		DECLARE @deleted VARCHAR(max) = (SELECT Deleted FROM Intervention WHERE Name = @Name)

		IF @deleted = 'yes' BEGIN

			DECLARE @lastEndDate Date = (SELECT MAX(EndDate) From Price WHERE IDintervention = @id)

			IF @lastEndDate is null BEGIN

				UPDATE Intervention SET Deleted = 'no' WHERE ID = @id
				UPDATE Price SET Deleted = 'no' WHERE IDintervention = @id
				DECLARE @lastPriceID INT = (SELECT ID FROM Price WHERE IDintervention = @id AND EndDate is null)
				UPDATE Price SET Value = @Price, StartDate = @StartDate WHERE ID = @lastPriceID
				SET @output=0

			END ELSE BEGIN IF @StartDate > @lastEndDate BEGIN 

				UPDATE Intervention SET Deleted = 'no' WHERE ID = @id
				UPDATE Price SET Deleted = 'no' WHERE IDintervention = @id
				UPDATE Price SET Value = @Price, StartDate = @StartDate WHERE ID = @lastPriceID
				SET @output=0

			END ELSE BEGIN SET @output = 1	END END

		END ELSE BEGIN SET @output = 2 END
	END
	
END