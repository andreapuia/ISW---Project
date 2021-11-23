use dentalOfficeDB

declare @rez int;
exec dbo.addAdministratorPr @rez,'luci','q1w2e3','Lucian','Brezaiu'
exec dbo.addAdministratorPr @rez,'mihnea','fieni','Mihnea','Ion'
exec dbo.addAdministratorPr @rez,'turea','dusmanu','Adrian','Turea'
exec dbo.addAdministratorPr @rez,'trunchi','pisoiul','Alexandru','Trunchi'

declare @rez int
exec dbo.addDoctorPr @rez,'moni24','infinit','Monica','Chiticar'
exec dbo.addDoctorPr @rez,'danci','minister','Dancila','Viorica'
exec dbo.addDoctorPr @rez,'popa','123456','Popa','Mariana'
exec dbo.addDoctorPr @rez,'bea','bety','Beatrice','Comnoiu'

select * from [User]

declare @rez int
exec dbo.addPatientPr @rez,1,'Corina','Corina',120,'BV'
exec dbo.addPatientPr @rez,1,'Alex','Corina',123,'B'
exec dbo.addPatientPr @rez,2,'Mimi','Corina',187,'DB'
exec dbo.addPatientPr @rez,3,'Mihai','Corina',763,'AG'

declare @rez int
exec dbo.addInterventionPr @rez,'consultatie',50,'2018-05-31'
exec dbo.addInterventionPr @rez,'plomba',80.2,'2018-05-31'
exec dbo.addInterventionPr @rez,'anestezie',30.5,'2018-05-31'
exec dbo.addInterventionPr @rez,'extractie',60.7,'2018-05-31'
exec dbo.addInterventionPr @rez,'obturatie',190,'2018-05-31'

declare @rez int
exec dbo.addAppointmentPr @rez,3,'2018-05-13',9
exec dbo.addAppointmentPr @rez,1,'2018-05-13',8
exec dbo.addAppointmentPr @rez,2,'2018-05-13',10
exec dbo.addAppointmentPr @rez,4,'2018-05-14',8


exec dbo.getAdministratorsPr
exec dbo.getDoctorsPr
exec dbo.getPatientsPr
exec dbo.getAppointmentsPr
exec dbo.getInterventionsPr
exec dbo.getPricesPr


DBCC CHECKIDENT ('User', RESEED, 0);
DBCC CHECKIDENT ('Patient', RESEED, 0);
DBCC CHECKIDENT ('Appointment', RESEED, 0);
DBCC CHECKIDENT ('Intervention', RESEED, 0);
DBCC CHECKIDENT ('Price', RESEED, 0);

delete from Price
delete from Appointment
delete from Intervention
delete from Patient
delete from [User]

