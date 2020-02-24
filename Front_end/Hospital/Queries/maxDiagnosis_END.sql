USE Hospital_1

DECLARE @REceptions TABLE (Departament NVARCHAR(50), DoctorID INT, LastName NVARCHAR(20), Diagnosis NVARCHAR(20), Amount INT)
INSERT INTO @REceptions
	SELECT Departaments.title, Reception.doctor, Doctors.[last name], Diagnoses.diagnosis, COUNT(Reception.duration) AS Amount
	FROM Departaments, Doctors, Reception, Diagnoses
	WHERE Reception.doctor = Doctors.id AND Doctors.depatment = Departaments.id AND Reception.diagnos = Diagnoses.id AND Reception.time BETWEEN '2019-12-01 00:00:00' AND '2020-03-01 00:00:00'
	GROUP BY Departaments.title, Doctors.[last name], Diagnoses.diagnosis, Reception.doctor

DECLARE @DOctorMaxDiagnos TABLE (Departament NVARCHAR(50), DoctorID INT, LastName NVARCHAR(20), Diagnos NVARCHAR(20), Amount INT)
DECLARE @DoctorID INT
SET @DoctorID = (SELECT COUNT(*) FROM Doctors)
WHILE @DoctorID > 0
	BEGIN
		DECLARE @TEmpDoctor TABLE (Departament NVARCHAR(50), DoctorID INT, LastName NVARCHAR(20), Diagnos NVARCHAR(20), Amount INT)
		INSERT INTO @TEmpDoctor
			SELECT *
			FROM @REceptions 
			WHERE DoctorID = @DoctorID
			INSERT INTO @DOctorMaxDiagnos
				SELECT * 
				FROM @TEmpDoctor 
				WHERE Amount = (SELECT MAX(Amount) FROM @TEmpDoctor)
		SET @DoctorID = @DoctorID - 1
		DELETE @TEmpDoctor				
	END

SELECT Departament AS Отделение, LastName AS Доктор, Diagnos AS Диагноз, Amount AS Диагнозов_поставлено
FROM @DOctorMaxDiagnos
ORDER BY Departament