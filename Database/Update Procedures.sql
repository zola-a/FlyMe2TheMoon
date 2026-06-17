-- Drop Update Procedures
IF OBJECT_ID('uspUpdateAttendant','P') IS NOT NULL DROP PROCEDURE uspUpdateAttendant;
IF OBJECT_ID('uspUpdatePilot','P') IS NOT NULL DROP PROCEDURE uspUpdatePilot;
IF OBJECT_ID('uspUpdatePassenger','P') IS NOT NULL DROP PROCEDURE uspUpdatePassenger;
GO


---update passenger
CREATE PROCEDURE uspUpdatePassenger
    @PassengerID INT,
    @FirstName VARCHAR(255),
    @LastName VARCHAR(255),
    @Address VARCHAR(255),
    @City VARCHAR(255),
    @StateID INT,
    @Zip VARCHAR(255),
    @PhoneNumber VARCHAR(255),
    @Email VARCHAR(255),
    @PassengerUsername VARCHAR(255),
    @PassengerPassword VARCHAR(255),
    @PassengerDateOfBirth DATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE TPassengers
    SET strFirstName = @FirstName,
        strLastName = @LastName,
        strAddress = @Address,
        strCity = @City,
        intStateID = @StateID,
        strZip = @Zip,
        strPhoneNumber = @PhoneNumber,
        strEmail = @Email,
        strPassengerUsername = @PassengerUsername,
        strPassengerPassword = @PassengerPassword,
        dtmPassengerDateOfBirth = @PassengerDateOfBirth
    WHERE intPassengerID = @PassengerID;
END;
GO



-- Update Attendant
CREATE PROCEDURE uspUpdateAttendant
    @AttendantID INT,
    @FirstName VARCHAR(255),
    @LastName VARCHAR(255),
    @EmployeeID INT,
    @DateOfHire DATE,
    @DateOfTermination DATE,
    @Username VARCHAR(255),
    @Password VARCHAR(255),
    @Status INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON; SET @Status=-1;
    BEGIN TRY
        BEGIN TRANSACTION;
        IF NOT EXISTS(SELECT 1 FROM TAttendants WHERE intAttendantID=@AttendantID) BEGIN SET @Status=1; ROLLBACK TRANSACTION; RETURN; END
        IF NOT EXISTS(SELECT 1 FROM TEmployees WHERE intEmployeeID=@EmployeeID) BEGIN SET @Status=2; ROLLBACK TRANSACTION; RETURN; END

        UPDATE TAttendants
        SET strFirstName=@FirstName,strLastName=@LastName,strEmployeeID=@EmployeeID,dtmDateOfHire=@DateOfHire,dtmDateOfTermination=@DateOfTermination
        WHERE intAttendantID=@AttendantID;

        UPDATE TEmployees
        SET strEmployeeUsername=@Username,strEmployeePassword=@Password,strEmployeeRole='Attendant'
        WHERE intEmployeeID=@EmployeeID;

        COMMIT TRANSACTION; SET @Status=0;
    END TRY
    BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK TRANSACTION; SET @Status=-1; END CATCH
END;
GO

-- Update Pilot
CREATE PROCEDURE uspUpdatePilot
    @PilotID INT,
    @FirstName VARCHAR(255),
    @LastName VARCHAR(255),
    @EmployeeID VARCHAR(255),
    @DateOfHire DATETIME,
    @DateOfTermination DATETIME,
    @DateOfLicense DATETIME,
    @RoleID INT,
    @Username VARCHAR(255),
    @Password VARCHAR(255),
    @Status INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON; SET @Status=-1;
    BEGIN TRY
        BEGIN TRANSACTION;
        IF NOT EXISTS(SELECT 1 FROM TPilots WHERE intPilotID=@PilotID) BEGIN SET @Status=1; ROLLBACK TRANSACTION; RETURN; END
        IF NOT EXISTS(SELECT 1 FROM TEmployees WHERE intEmployeeID=@EmployeeID) BEGIN SET @Status=2; ROLLBACK TRANSACTION; RETURN; END

        UPDATE TPilots
        SET strFirstName=@FirstName,strLastName=@LastName,strEmployeeID=@EmployeeID,dtmDateOfHire=@DateOfHire,dtmDateOfTermination=@DateOfTermination,
            dtmDateOfLicense=@DateOfLicense,intPilotRoleID=@RoleID
        WHERE intPilotID=@PilotID;

        UPDATE TEmployees
        SET strEmployeeUsername=@Username,strEmployeePassword=@Password,strEmployeeRole='Pilot'
        WHERE intEmployeeID=@EmployeeID;

        COMMIT TRANSACTION; SET @Status=0;
    END TRY
    BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK TRANSACTION; SET @Status=-1; END CATCH
END;
GO
