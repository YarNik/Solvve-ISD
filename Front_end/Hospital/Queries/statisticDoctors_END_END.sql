USE Hospital_1

DECLARE @REceptions TABLE (DoctorID INT, Diagnosis NVARCHAR(20), Amount INT)
INSERT INTO @REceptions
	SELECT Reception.doctor, Diagnoses.diagnosis, COUNT(Reception.diagnos)
	FROM Reception, Diagnoses
	WHERE Reception.diagnos = Diagnoses.id
	GROUP BY Reception.doctor, Diagnoses.diagnosis

DECLARE @DOctorReceptionDate TABLE (DoctorID INT, YearMonth NVARCHAR(20))
INSERT INTO @DOctorReceptionDate
	SELECT Reception.doctor, CONCAT(LEFT(Reception.time, 4), ' ', DATENAME(month, Reception.time))
	FROM Reception
	
DECLARE @DOctorAmountMonts TABLE (DoctorID INT, AmountMonts INT)
INSERT INTO @DOctorAmountMonts
	SELECT DoctorID, COUNT(DISTINCT YearMonth) FROM @DOctorReceptionDate
	GROUP BY DoctorID
	
	
DECLARE @STatisticDoctors TABLE (DoctorID INT, LastName NVARCHAR(20), AmountPatients INT, AmountAverage DECIMAL(3, 2), Diagnosis NVARCHAR(20))
DECLARE @DoctorID INT
SET @DoctorID = (SELECT COUNT(*) FROM Doctors)
WHILE @DoctorID > 0
	BEGIN
		DECLARE @TEmpDoctor TABLE (DoctorID INT, Diagnosis NVARCHAR(20), Amount INT)
		INSERT INTO @TEmpDoctor
			SELECT *
			FROM @REceptions 
			WHERE DoctorID = @DoctorID
		INSERT INTO @STatisticDoctors
			VALUES (@DoctorID,
				(
				SELECT Doctors.[last name]
				FROM Doctors
				WHERE Doctors.id = @DoctorID),
				(
				SELECT COUNT(Reception.diagnos)
				FROM Reception
				WHERE Reception.doctor = @DoctorID
				),
				(
				SELECT COUNT(Reception.diagnos)
				FROM Reception
				WHERE Reception.doctor = @DoctorID
				) / CONVERT(DECIMAL(3, 2), 
					(SELECT AmountMonts FROM @DOctorAmountMonts WHERE DoctorID = @DoctorID)
				),
				(
				SELECT  TOP 1 Diagnosis 
				FROM @TEmpDoctor 
				WHERE Amount = (SELECT MAX(Amount) FROM @TEmpDoctor)
				)
			)
		SET @DoctorID = @DoctorID - 1
		DELETE @TEmpDoctor
	END

SELECT LastName AS Доктор, AmountPatients AS 'Пациентов', AmountAverage AS 'Пациентов в месяц', Diagnosis AS 'Частый диагноз'
FROM @STatisticDoctors
ORDER BY AmountAverage
