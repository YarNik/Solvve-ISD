USE Hospital_1
	SELECT Diagnoses.diagnosis AS Диагноз, COUNT(Reception.diagnos) AS Пациентов
	FROM Diagnoses, Reception
	WHERE Diagnoses.id = Reception.diagnos AND Reception.time >= '2020-02-01 00:00:00' AND Reception.time < '2020-03-01 00:00:00'
	GROUP BY Diagnoses.diagnosis
	ORDER BY COUNT(Reception.diagnos) DESC
	