USE AirportDB;
--Fill Airport table
INSERT INTO Airport 
VALUES ('CPH', 'Kastrup Luftfhavn')
INSERT INTO Airport 
VALUES ('LAX', 'Los Angeles Airport')
--Fill PRoute Table
INSERT INTO PRoute
VALUES ('CPH', 'LAX')
--Fill Operator Table
INSERT INTO Operator
VALUES ('SAS')
--Fill Flight Table
INSERT INTO Flight
VALUES (5, 1)
--Fill FlightOperator Table
INSERT INTO FlightOperator
VALUES (1, 1, 24, 29)
--Fill ProuteOperator Table
INSERT INTO ProuteOperator
VALUES (1, 1)
