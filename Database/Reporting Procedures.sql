-- Drop Reporting Procedures
IF OBJECT_ID('usp_GetTotalCustomers','P')         IS NOT NULL DROP PROCEDURE usp_GetTotalCustomers;
IF OBJECT_ID('usp_GetTotalFlights','P')           IS NOT NULL DROP PROCEDURE usp_GetTotalFlights;
IF OBJECT_ID('usp_GetAverageMiles','P')          IS NOT NULL DROP PROCEDURE usp_GetAverageMiles;
IF OBJECT_ID('usp_GetPilotTotalMiles','P')       IS NOT NULL DROP PROCEDURE usp_GetPilotTotalMiles;
IF OBJECT_ID('usp_GetAttendantTotalMiles','P')   IS NOT NULL DROP PROCEDURE usp_GetAttendantTotalMiles;
IF OBJECT_ID('usp_GetAllCustomers','P')          IS NOT NULL DROP PROCEDURE usp_GetAllCustomers;
IF OBJECT_ID('usp_GetCustomerTotalMiles','P')    IS NOT NULL DROP PROCEDURE usp_GetCustomerTotalMiles;
IF OBJECT_ID('usp_GetCustomerPastFlights','P')   IS NOT NULL DROP PROCEDURE usp_GetCustomerPastFlights;
IF OBJECT_ID('usp_GetCustomerFutureFlights','P') IS NOT NULL DROP PROCEDURE usp_GetCustomerFutureFlights;
IF OBJECT_ID('usp_GetAllPilots','P')             IS NOT NULL DROP PROCEDURE usp_GetAllPilots;
IF OBJECT_ID('uspGetNextAttendantID','P')        IS NOT NULL DROP PROCEDURE uspGetNextAttendantID;
IF OBJECT_ID('uspGetStates','P')                 IS NOT NULL DROP PROCEDURE uspGetStates;
IF OBJECT_ID('usp_BookFlightWithCost', 'P')		 IS NOT NULL DROP PROCEDURE usp_BookFlightWithCost;
GO

-- Create Reporting Procedures
CREATE PROCEDURE usp_GetTotalCustomers AS
BEGIN
    SELECT COUNT(*) AS TotalCustomers FROM TPassengers;
END;
GO

CREATE PROCEDURE usp_GetTotalFlights AS
BEGIN
    SELECT COUNT(*) AS TotalFlights FROM TFlights;
END;
GO

CREATE PROCEDURE usp_GetAverageMiles AS
BEGIN
    SELECT AVG(f.intMilesFlown) AS AverageMiles
    FROM TFlightPassengers fp
    JOIN TFlights f ON fp.intFlightID = f.intFlightID;
END;
GO

CREATE PROCEDURE usp_GetPilotTotalMiles AS
BEGIN
    SELECT p.strFirstName + ' ' + p.strLastName AS PilotName,
           ISNULL(SUM(f.intMilesFlown),0) AS TotalMiles
    FROM TPilots p
    LEFT JOIN TPilotFlights pf ON p.intPilotID = pf.intPilotID
    LEFT JOIN TFlights f ON pf.intFlightID = f.intFlightID
    GROUP BY p.strFirstName, p.strLastName;
END;
GO

CREATE PROCEDURE usp_GetAttendantTotalMiles AS
BEGIN
    SELECT a.strFirstName + ' ' + a.strLastName AS AttendantName,
           ISNULL(SUM(f.intMilesFlown),0) AS TotalMiles
    FROM TAttendants a
    LEFT JOIN TAttendantFlights af ON a.intAttendantID = af.intAttendantID
    LEFT JOIN TFlights f ON af.intFlightID = f.intFlightID
    GROUP BY a.strFirstName, a.strLastName;
END;
GO

CREATE PROCEDURE usp_GetAllCustomers AS
BEGIN
    SELECT intPassengerID AS CustomerID,
           strFirstName AS FirstName,
           strLastName AS LastName,
           strFirstName + ' ' + strLastName AS FullName
    FROM TPassengers
    ORDER BY strLastName, strFirstName;
END;
GO

CREATE PROCEDURE usp_GetCustomerTotalMiles @CustomerID INT AS
BEGIN
    SELECT ISNULL(SUM(F.intMilesFlown), 0) AS TotalMiles
    FROM TFlights F
    INNER JOIN TFlightPassengers FP ON F.intFlightID = FP.intFlightID
    WHERE FP.intPassengerID = @CustomerID AND F.dtmFlightDate < GETDATE();
END;
GO

CREATE PROCEDURE usp_GetCustomerPastFlights @CustomerID INT AS
BEGIN
    SELECT F.strFlightNumber, F.dtmFlightDate, F.dtmTimeofDeparture, F.dtmTimeOfLanding, F.intMilesFlown,
           AF.strAirportCity AS FromCity, AT.strAirportCity AS ToCity
    FROM TFlights F
    INNER JOIN TFlightPassengers FP ON F.intFlightID = FP.intFlightID
    INNER JOIN TAirports AF ON F.intFromAirportID = AF.intAirportID
    INNER JOIN TAirports AT ON F.intToAirportID = AT.intAirportID
    WHERE FP.intPassengerID = @CustomerID AND F.dtmFlightDate < GETDATE()
    ORDER BY F.dtmFlightDate DESC;
END;
GO

CREATE PROCEDURE usp_GetCustomerFutureFlights @CustomerID INT AS
BEGIN
    SELECT F.strFlightNumber, F.dtmFlightDate, F.dtmTimeofDeparture, F.dtmTimeOfLanding, F.intMilesFlown,
           AF.strAirportCity AS FromCity, AT.strAirportCity AS ToCity
    FROM TFlights F
    INNER JOIN TFlightPassengers FP ON F.intFlightID = FP.intFlightID
    INNER JOIN TAirports AF ON F.intFromAirportID = AF.intAirportID
    INNER JOIN TAirports AT ON F.intToAirportID = AT.intAirportID
    WHERE FP.intPassengerID = @CustomerID AND F.dtmFlightDate >= GETDATE()
    ORDER BY F.dtmFlightDate;
END;
GO

CREATE PROCEDURE usp_GetAllPilots AS
BEGIN
    SELECT P.intPilotID AS PilotID, P.strFirstName AS FirstName, P.strLastName AS LastName,
           P.strLastName + ', ' + P.strFirstName AS FullName, P.strEmployeeID AS EmployeeID,
           P.dtmDateOfHire AS DateOfHire, P.dtmDateOfTermination AS DateOfTermination,
           P.dtmDateOfLicense AS DateOfLicense, R.strPilotRole AS PilotRole
    FROM TPilots P
    INNER JOIN TPilotRoles R ON P.intPilotRoleID = R.intPilotRoleID
    ORDER BY P.strLastName, P.strFirstName;
END;
GO

CREATE PROCEDURE uspGetNextAttendantID AS
BEGIN
    SELECT ISNULL(MAX(intAttendantID), 0) + 1 AS NextID FROM TAttendants;
END;
GO

CREATE PROCEDURE uspGetStates AS
BEGIN
    SELECT intStateID, strState FROM TStates ORDER BY strState;
END;
GO



CREATE PROCEDURE usp_BookFlightWithCost
    @PassengerID INT,
    @FlightID INT,
    @SeatType NVARCHAR(50),
    @FlightCost DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NextID INT
    SELECT @NextID = ISNULL(MAX(intFlightPassengerID),0) + 1 FROM TFlightPassengers

    INSERT INTO TFlightPassengers (intFlightPassengerID, intFlightID, intPassengerID, strSeat, decFlightCost)
    VALUES (@NextID, @FlightID, @PassengerID, @SeatType, @FlightCost)
END
GO










