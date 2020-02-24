USE Hospital_1

CREATE TABLE Departaments
(
    id INT PRIMARY KEY IDENTITY,    
    title NVARCHAR(50)    
)
CREATE TABLE Diagnoses
(
    id INT PRIMARY KEY IDENTITY,    
    diagnosis NVARCHAR(20)    
)
CREATE TABLE Doctors
(
    id INT PRIMARY KEY IDENTITY,    
    name NVARCHAR(20),
	[last name] NVARCHAR(20),
	depatment INT REFERENCES Departaments (id)
)
CREATE TABLE Patients
(
    id INT PRIMARY KEY IDENTITY,    
    name NVARCHAR(20),	
	[last name] NVARCHAR(20),
)
CREATE TABLE ReceptionDuration
(
    time INT PRIMARY KEY
)
CREATE TABLE Reception
(
    id INT PRIMARY KEY IDENTITY,    
    patient INT REFERENCES Patients (id),
	doctor INT REFERENCES Doctors (id),
	time datetime2(0),
	duration INT REFERENCES ReceptionDuration (time),
	diagnos INT REFERENCES Diagnoses (id)
)
