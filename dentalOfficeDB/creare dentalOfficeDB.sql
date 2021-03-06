/* crearea bazei de date*/

CREATE DATABASE dentalOfficeDB
USE dentalOfficeDB



/* crearea tabelelor și a relațiilor */

CREATE TABLE [User]
(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Username VARCHAR(max),
	[Password] VARCHAR(max),
	FirstName VARCHAR(max),
	LastName VARCHAR(max),
	Role VARCHAR(max),
	Deleted VARCHAR(max),
)

CREATE TABLE Patient
(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IDdoctor INT NOT NULL foreign key references [User](ID),
	FirstName VARCHAR(max),
	LastName VARCHAR(max),
	CNP VARCHAR(max),
	City VARCHAR(max),
	Deleted VARCHAR(max),
)

CREATE TABLE Intervention
(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(max),
	Deleted VARCHAR(max),
)

CREATE TABLE Appointment
(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IDpatient INT NOT NULL foreign key references Patient(ID),
	[Date] DATE,
	[Hour] INT,
	Deleted VARCHAR(max),
)

CREATE TABLE Agenda
(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IDappointment  INT NOT NULL foreign key references Appointment(ID),
	IDintervention INT NOT NULL foreign key references Intervention(ID),
	Deleted VARCHAR(max)
)

CREATE TABLE Price
(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IDintervention INT NOT NULL foreign key references Intervention(ID),
	[Value] DECIMAL(5,2),
	StartDate DATE,
	EndDate DATE,
	Deleted VARCHAR(max)
)


/* adăugarea de constrângeri asupra câampurilor */

ALTER TABLE [User]
ADD CONSTRAINT UserRoleConstraint
CHECK (Role='doctor' OR Role='administrator')

ALTER TABLE [User]
ADD CONSTRAINT UserDeletedConstraint
CHECK (Deleted='yes' OR Deleted='no')

ALTER TABLE Patient
ADD CONSTRAINT PatientDeletedConstraint
CHECK (Deleted='yes' OR Deleted='no')

ALTER TABLE Appointment
ADD CONSTRAINT AppointmentDeletedConstraint
CHECK (Deleted='yes' OR Deleted='no')

ALTER TABLE Intervention
ADD CONSTRAINT InterventionDeletedConstraint
CHECK (Deleted='yes' OR Deleted='no')

ALTER TABLE Price
ADD CONSTRAINT PriceDeletedConstraint
CHECK (Deleted='yes' OR Deleted='no')


ALTER TABLE Appointment
ADD CONSTRAINT AppointmenHourConstraint
CHECK ([Hour] in (8,9,10,11,12,13,14,15))

