USE AirportDB;

SELECT Flight.TravelTime FROM Flight WHERE ProuteId = 
	(SELECT ProuteOperator.ProuteId FROM ProuteOperator WHERE OperatorId = 
		(SELECT Operator.Id FROM Operator WHERE Operator.Name = 'SAS'));