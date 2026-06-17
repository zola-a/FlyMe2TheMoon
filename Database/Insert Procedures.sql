-- Drop Insert Procedures
IF OBJECT_ID('usp_InsertAttendant','P') IS NOT NULL DROP PROCEDURE usp_InsertAttendant;
IF OBJECT_ID('usp_InsertPilot','P') IS NOT NULL DROP PROCEDURE usp_InsertPilot;
IF OBJECT_ID('usp_InsertFlight', 'P') IS NOT NULL DROP PROCEDURE usp_InsertFlight;
GO

-- Insert Attendant
CREATE PROCEDURE usp_InsertAttendant
    @AttendantID INT,
    @FirstName VARCHAR(255),
    @LastName VARCHAR(255),
    @EmployeeID VARCHAR(255), -- keep as EmployeeID reference
    @DateOfHire DATETIME,
    @DateOfTermination DATETIME,
    @Username VARCHAR(255),
    @Password VARCHAR(255),
    @Status INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Insert into TAttendants
        INSERT INTO TAttendants
            (intAttendantID, strFirstName, strLastName, strEmployeeID, dtmDateOfHire, dtmDateOfTermination)
        VALUES
            (@AttendantID, @FirstName, @LastName, @EmployeeID, @DateOfHire, @DateOfTermination);

        -- Generate next EmployeeID
        DECLARE @NextEmployeeID INT;
        SELECT @NextEmployeeID = ISNULL(MAX(intEmployeeID),0) + 1 FROM TEmployees;

        -- Insert into TEmployees
        INSERT INTO TEmployees
            (intEmployeeID, strEmployeeUsername, strEmployeePassword, strEmployeeRole, intRoleLinkID)
        VALUES
            (@NextEmployeeID, @Username, @Password, 'Attendant', @AttendantID);

        COMMIT TRANSACTION;
        SET @Status = 0;

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        SET @Status = -1;
    END CATCH
END
GO


-- Insert Pilot
CREATE PROCEDURE usp_InsertPilot
    @PilotID INT,
    @FirstName VARCHAR(255),
    @LastName VARCHAR(255),
    @EmployeeID VARCHAR(255),
    @DateOfHire DATETIME,
    @DateOfTermination DATETIME,
    @DateOfLicense DATETIME,
    @PilotRoleID INT,
    @Username VARCHAR(255),
    @Password VARCHAR(255),
    @Status INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Insert into TPilots
        INSERT INTO TPilots
            (intPilotID, strFirstName, strLastName, strEmployeeID,
             dtmDateOfHire, dtmDateOfTermination, dtmDateOfLicense, intPilotRoleID)
        VALUES
            (@PilotID, @FirstName, @LastName, @EmployeeID,
             @DateOfHire, @DateOfTermination, @DateOfLicense, @PilotRoleID);

        -- Generate next EmployeeID
        DECLARE @NextEmployeeID INT;
        SELECT @NextEmployeeID = ISNULL(MAX(intEmployeeID), 0) + 1 FROM TEmployees;

        -- Insert into TEmployees
        INSERT INTO TEmployees
            (intEmployeeID, strEmployeeUsername, strEmployeePassword, strEmployeeRole, intRoleLinkID)
        VALUES
            (@NextEmployeeID, @Username, @Password, 'Pilot', @PilotID);

        COMMIT TRANSACTION;
        SET @Status = 0;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        SET @Status = -1;
    END CATCH
END
GO




-- ==========================================
-- Insert Flight
-- ==========================================
CREATE PROCEDURE usp_InsertFlight
    @FlightID INT,
    @FlightNumber VARCHAR(50),
    @FromAirportID INT,
    @ToAirportID INT,
    @FlightDate DATETIME,
    @DepartureTime DATETIME,
    @LandingTime DATETIME,
    @MilesFlown INT,
    @PlaneID INT,
    @Status INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Status = -1; -- default = error

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Validate future date
        IF @FlightDate <= GETDATE()
        BEGIN
            SET @Status = 2; -- Flight date not in the future
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Validate PlaneID exists
        IF NOT EXISTS (SELECT 1 FROM TPlanes WHERE intPlaneID = @PlaneID)
        BEGIN
            SET @Status = 3; -- Plane not found
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Insert new flight
        INSERT INTO TFlights
            (intFlightID, strFlightNumber, intFromAirportID, intToAirportID, dtmFlightDate, dtmTimeofDeparture, dtmTimeOfLanding, intMilesFlown, intPlaneID)
        VALUES
            (@FlightID, @FlightNumber, @FromAirportID, @ToAirportID, @FlightDate, @DepartureTime, @LandingTime, @MilesFlown, @PlaneID);

        COMMIT TRANSACTION;
        SET @Status = 0; -- Success
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SET @Status = -1; -- General Error
    END CATCH
END;
GO


