/* procedură ce adaugă o nouă programare, se știe că noua programare nu se va suprapune peste altă programare, returnează indexul noii programări */

CREATE PROCEDURE addAppointmentPr
	@output INT OUTPUT,
	@IDpatient INT,
	@Date DATE,
	@Hour INT
AS
BEGIN
	
	INSERT INTO Appointment(IDpatient,Date,Hour,Deleted) VALUES (@IDpatient,@Date,@Hour,'no')
	SET @output = SCOPE_IDENTITY()
END
GO
