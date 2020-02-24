USE Hospital_1

DECLARE @REceptions TABLE (DepartamentID INT, Departament NVARCHAR(50),  LastName NVARCHAR(20), Amount INT)
INSERT INTO @REceptions
	SELECT Departaments.id, Departaments.title, Doctors.[last name], SUM(Reception.duration) AS Amount
	FROM Departaments, Doctors, Reception
	WHERE Reception.doctor = Doctors.id AND Doctors.depatment = Departaments.id AND Reception.time BETWEEN '2019-12-01 00:00:00' AND '2020-03-01 00:00:00'
	GROUP BY Departaments.id, Departaments.title, Doctors.[last name]

DECLARE @DOctorMax TABLE (DepartamentID INT, Departament NVARCHAR(50),  LastName NVARCHAR(20), Amount INT)
DECLARE @AmountDepatments INT
SET @AmountDepatments = (SELECT COUNT(*) FROM Departaments)
WHILE @AmountDepatments > 0
	BEGIN
		DECLARE @TEmpDepatment TABLE (DepartamentID INT, Departament NVARCHAR(50), LastName NVARCHAR(20), Amount INT)
		INSERT INTO @TEmpDepatment
			SELECT *
			FROM @REceptions 
			WHERE DepartamentID = @AmountDepatments
			INSERT INTO @DOctorMax
				SELECT * 
				FROM @TEmpDepatment 
				WHERE Amount = (SELECT MAX(Amount) FROM @TEmpDepatment)
		SET @AmountDepatments = @AmountDepatments - 1
		DELETE @TEmpDepatment				
	END

SELECT Departament AS Отделение, LastName AS Доктор, Amount AS Минут_отработано
FROM @DOctorMax



