ALTER PROCEDURE AddStudent(
	@StudentID VARCHAR(10) = NULL,
	@FirstName VARCHAR(25) = NULL,
	@LastName VARCHAR(25) = NULL,
	@Email VARCHAR(50) = NULL,
	@ProgramCode VARCHAR(10) = NULL)
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @StudentID IS NULL
		RAISERROR('AddStudent: Required parameter: @StudentID', 16, 1)
	ELSE
		IF @FirstName IS NULL
			RAISERROR('AddStudent: Requied parameter: @FirstName', 16, 1)
		ELSE
			IF @LastName IS NULL
				RAISERROR('AddStudent: Required parameter: @LastName',16, 1)
			ELSE
				IF @ProgramCode IS NULL
					RAISERROR('AddStudent: Required parameter: @ProgramCode', 16, 1)
				ELSE
					BEGIN
						INSERT INTO Student
						(StudentID, FirstName, LastName, EMAIL, ProgramCode)
						VALUES
						(@StudentID, @FirstName, @LastName, @Email, @ProgramCode)

						IF @@ERROR = 0
							SET @ReturnCode = 0
						ELSE
							RAISERROR('AddStudent: Insert error: Student table', 16, 1)
					END
	RETURN @ReturnCode

