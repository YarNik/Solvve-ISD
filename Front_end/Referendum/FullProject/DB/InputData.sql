USE Referendum

INSERT INTO Users
VALUES
	('ZeroUser'),
	('Nikolay'),
	('Elena'),
	('Boris'),
	('Kostya'),
	('Bob')

INSERT INTO Referendum
VALUES
	('When will the day off?', 1, 1, 1, 0, 1, '2020-06-01', '2020-04-17'),
	('Who were the first pilots?', 2, 1, 1, 2, 1, '2020-06-01', '2020-04-17')

INSERT INTO Answer
VALUES
	(1, 'Saturday', 1),
	(1, 'Sunday', 1),
	(2, 'Brothers Grimm', 2),
	(2, 'Wachowski brothers', 2),
	(2, 'Wright brothers', 2)

INSERT INTO AllAnswers
VALUES
	(2, 1),
	(2, 2),
	(1, 3),
	(3, 1),
	(3, 4),
	(5, 5),
	(4, 2)