USE Hospital_1

DECLARE @AMountPatients TABLE (TimePeriod NVARCHAR(20), Amount INT)
INSERT INTO @AMountPatients
VALUES
	('7.00 - 10.00', (
		SELECT COUNT(Reception.diagnos)
		FROM Reception
		WHERE (SELECT DATENAME(hour, Reception.time)) BETWEEN 7 AND 9
		)),
	('10.00 - 13.00', (
		SELECT COUNT(Reception.diagnos)
		FROM Reception
		WHERE (SELECT DATENAME(hour, Reception.time)) BETWEEN 10 AND 12
		)),
	('13.00 - 16.00', (
		SELECT COUNT(Reception.diagnos)
		FROM Reception
		WHERE (SELECT DATENAME(hour, Reception.time)) BETWEEN 13 AND 15
		)),
	('16.00 - 19.00', (
		SELECT COUNT(Reception.diagnos)
		FROM Reception
		WHERE (SELECT DATENAME(hour, Reception.time)) BETWEEN 16 AND 18
		))	
	
SELECT TimePeriod AS 'Период времени', Amount AS 'Количество пациентов'
FROM @AMountPatients
