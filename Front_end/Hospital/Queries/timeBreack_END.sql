USE Hospital_1

DECLARE @REceptions TABLE (Doctor INT, BeginReception datetime2(0), EndReception datetime2(0))
INSERT INTO @REceptions
	SELECT Reception.doctor, Reception.time, DATEADD(minute, Reception.duration, Reception.time)
	FROM Reception
	GROUP BY Reception.doctor, Reception.time, Reception.duration

DECLARE @REceptionsBreack TABLE (Doctor INT, BreackMinutes INT, BeginBreack datetime2(0), EndBreack datetime2(0))
DECLARE @RecordID INT
DECLARE @DoctorID INT
SET @DoctorID = 1
	WHILE @DoctorID <= (SELECT COUNT(*) FROM Doctors) 
	BEGIN
		CREATE TABLE #REceptionsTempDoctor (RecordID INT IDENTITY, Doctor INT, BeginReception datetime2(0), EndReception datetime2(0))
		INSERT INTO #REceptionsTempDoctor
		SELECT *
			FROM @REceptions
			WHERE Doctor = @DoctorID
			SET @RecordID = 1
				WHILE @RecordID <= (SELECT COUNT(*) FROM #REceptionsTempDoctor)
				BEGIN
					INSERT INTO @REceptionsBreack
						VALUES (
							(SELECT Doctor FROM #REceptionsTempDoctor WHERE RecordID = @RecordID),							
							 IIF(@RecordID = 1, NULL, DATEDIFF(minute,
								(SELECT EndReception FROM #REceptionsTempDoctor WHERE RecordID = @RecordID - 1),
								(SELECT BeginReception FROM #REceptionsTempDoctor WHERE RecordID = @RecordID)
									)),
							 IIF(@RecordID = 1, NULL, 
								(SELECT EndReception FROM #REceptionsTempDoctor WHERE RecordID = @RecordID - 1)),
							 IIF(@RecordID = 1, NULL, 
								(SELECT BeginReception FROM #REceptionsTempDoctor WHERE RecordID = @RecordID))
						)
					SET @RecordID = @RecordID + 1
				END
		DROP TABLE #REceptionsTempDoctor
		SET @DoctorID = @DoctorID + 1		
		END

SELECT Doctors.[last name] AS 'Доктор', Departaments.title AS 'Отделение', BeginBreack AS 'Начало перерыва', BreackMinutes AS 'Перерыв, мин.', EndBreack AS 'Конец перерыва' 
FROM @REceptionsBreack, Departaments, Doctors
WHERE Doctor = Doctors.id AND Departaments.id = Doctors.depatment AND BreackMinutes > 30
ORDER BY Doctors.[last name], BreackMinutes DESC





