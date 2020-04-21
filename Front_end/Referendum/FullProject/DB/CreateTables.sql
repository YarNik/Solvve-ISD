USE Referendum

CREATE TABLE Users
(
    Id INT PRIMARY KEY IDENTITY,    
    UserName NVARCHAR(20)
)

CREATE TABLE Referendum
(
    Id INT PRIMARY KEY IDENTITY,    
    Proposition NVARCHAR(256),
	Autor INT REFERENCES Users (Id),
	Active INT,
	Published INT,
	MaxOwnAnswers INT,
	MaxAmountAnswers INT,
	DeadLine DATETIME2(0),
	PublishDate DATETIME2(0)
)

CREATE TABLE Answer
(
    Id INT PRIMARY KEY IDENTITY,
	Referendum INT REFERENCES Referendum (Id),
    Appellation NVARCHAR(128),
	AnswerAutor INT REFERENCES Users (Id)
)

CREATE TABLE AllAnswers
(
    IdAnswer INT REFERENCES Answer (Id),    
    IdUser INT REFERENCES Users (Id)
)