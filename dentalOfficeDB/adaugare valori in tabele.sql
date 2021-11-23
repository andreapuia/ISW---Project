use dentalOfficeDB

declare @rez int;
exec dbo.addAdministratorPr @rez,'cris','q1w2e3','Cristina','Calin'
exec dbo.addAdministratorPr @rez,'andrea','q1w2e3','Andrea','Puia'

declare @rez int
exec dbo.addDoctorPr @rez,'baditaaex','q1w2e3','Alexandru','Badita'
exec dbo.addDoctorPr @rez,'ghiuzanrxa','q1w2e3','Roxana','Ghiuzan'

