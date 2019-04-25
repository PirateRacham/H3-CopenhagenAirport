USE AirportDB;

DROP TABLE IF EXISTS dbo.ProuteOperator;
DROP TABLE IF EXISTS dbo.FlightOperator;
DROP TABLE IF EXISTS dbo.Flight;
DROP TABLE IF EXISTS dbo.Operator;
DROP TABLE IF EXISTS dbo.PRoute;
DROP TABLE IF EXISTS dbo.Airport;

CREATE TABLE Airport
(
	AIATA varchar(50) NOT NULL,
	Name varchar(60) NOT NULL
);

CREATE TABLE PRoute
(
	Id int NOT NULL IDENTITY(1,1),
	Origin varchar(50) NOT NULL,
	Destination varchar(50) NOT NULL
);

CREATE TABLE ProuteOperator
(
	ProuteId int NOT NULL,
	OperatorId int NOT NULL
);

CREATE TABLE Operator
(
	Id int NOT NULL IDENTITY(1,1),
	Name varchar(50) NOT NULL
);

CREATE TABLE FlightOperator
(
	OperatorId int NOT NULL,
	FlightId int NOT NULL,
	Liftoff int NOT NULL,
	Touchdown int NOT NULL
);

CREATE TABLE Flight 
(
	Id int NOT NULL IDENTITY(1,1),
	TravelTime int NOT NULL,
	ProuteId int NOT NULL
);

/*Primarykeys*/
ALTER TABLE Airport ADD PRIMARY KEY (AIATA);
ALTER TABLE PRoute ADD PRIMARY KEY (Id);
ALTER TABLE Operator ADD PRIMARY KEY (Id);
ALTER TABLE Flight ADD PRIMARY KEY (Id);
ALTER TABLE ProuteOperator ADD CONSTRAINT PK_ProuteOperator PRIMARY KEY (ProuteId, OperatorId);
ALTER TABLE FlightOperator ADD CONSTRAINT PK_FlightOperator PRIMARY KEY (FlightId, OperatorId, Liftoff);

/*Foreign keys*/
ALTER TABLE PRoute ADD FOREIGN KEY (Origin) REFERENCES Airport(AIATA);
ALTER TABLE PRoute ADD FOREIGN KEY (Destination) REFERENCES Airport(AIATA);
ALTER TABLE ProuteOperator ADD FOREIGN KEY (ProuteId) REFERENCES PRoute(Id);
ALTER TABLE ProuteOperator ADD FOREIGN KEY (OperatorId) REFERENCES Operator(Id);
ALTER TABLE FlightOperator ADD FOREIGN KEY (OperatorId) REFERENCES Operator(Id);
ALTER TABLE FlightOperator ADD FOREIGN KEY (FlightId) REFERENCES Flight(Id);
