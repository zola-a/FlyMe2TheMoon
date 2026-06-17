-- Drop Delete Procedures
IF OBJECT_ID('uspDeleteAttendant','P') IS NOT NULL DROP PROCEDURE uspDeleteAttendant;
IF OBJECT_ID('uspDeletePilot','P') IS NOT NULL DROP PROCEDURE uspDeletePilot;
GO

-- Delete Attendant
CREATE PROCEDURE uspDeleteAttendant
    @AttendantID INT,
    @Status INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS(SELECT 1 FROM TAttendants WHERE intAttendantID=@AttendantID)
    BEGIN SET @Status=1; RETURN; END

    BEGIN TRANSACTION
        DELETE FROM TEmployees WHERE intRoleLinkID=@AttendantID AND strEmployeeRole='Attendant';
        DELETE FROM TAttendants WHERE intAttendantID=@AttendantID;
    COMMIT TRANSACTION
    SET @Status=0
END;
GO

-- Delete Pilot
CREATE PROCEDURE uspDeletePilot
    @intPilotID INT,
    @Status INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS(SELECT 1 FROM TPilots WHERE intPilotID=@intPilotID)
    BEGIN SET @Status=1; RETURN; END

    IF EXISTS(SELECT 1 FROM TFlights F
               INNER JOIN TPilotFlights PF ON PF.intFlightID=F.intFlightID
               WHERE PF.intPilotID=@intPilotID
                 AND DATEADD(DAY,DATEDIFF(DAY,0,F.dtmFlightDate),CAST(F.dtmTimeofDeparture AS DATETIME))>GETDATE())
    BEGIN SET @Status=2; RETURN; END

    BEGIN TRANSACTION
        DELETE FROM TEmployees WHERE intRoleLinkID=@intPilotID AND strEmployeeRole='Pilot';
        DELETE FROM TPilotFlights WHERE intPilotID=@intPilotID;
        DELETE FROM TPilots WHERE intPilotID=@intPilotID;
    COMMIT TRANSACTION
    SET @Status=0
END;
GO
