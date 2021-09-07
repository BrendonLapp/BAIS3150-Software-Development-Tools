CREATE TABLE Program (
	ProgramCode VARCHAR(10) NOT NULL,
	Description VARCHAR(60) NOT NULL
)

ALTER TABLE Program
	ADD CONSTRAINT ProgramCode PRIMARY KEY (ProgramCode);

CREATE TABLE Student (
	StudentID VARCHAR NOT NULL,
	ProgramCode VARCHAR(10) NOT NULL,
	FirstName VARCHAR(25) NOT NULL,
	LastName VARCHAR(25) NOT NULL,
	Email VARCHAR(50) NULL
);

ALTER TABLE Student
	ADD CONSTRAINT PK_StudentID PRIMARY KEY (StudentID)

ALTER TABLE Student
	ADD CONSTRAINT FK_ProgramCode FOREIGN KEY (ProgramCode) REFERENCES Program;

EXECUTE AddStudent 112321,'Brendon', 'Lapp', NULL, 'BAIST'
DROP TABLE Student
DROP TABLE Program


INSERT INTO Program
(ProgramCode, [Description])
VALUES ('BAIST', 'Bachelor of Applied Information Systems Technology')

--Add program
go
CREATE PROCEDURE AddProgram (@ProgramCode VARCHAR(10) = null, @Description VARCHAR(70) = NULL) 
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @ProgramCode IS NULL
		RAISERROR('AddProgram - Required Parameter: @ProgramCode', 16, 1)
		ELSE
			IF @Description IS NULL
				RAISERROR('AddProgram - Required Parameter: @Description', 16 ,1)
				BEGIN
				INSERT INTO Program
				(ProgramCode, Description)
				VALUES
				(@ProgramCode, @Description)

				IF @@ERROR = 0
					SET @ReturnCode = 0
				ELSE
					SET @ReturnCode = 1
				END
RETURN @ReturnCode

--Get all programs
GO
CREATE PROCEDURE GetPrograms
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	SELECT ProgramCode, [Description]
	FROM Program

	IF @@ERROR = 0
		SET @ReturnCode = 0
	ELSE
		RAISERROR('GetPrograms - SELECT Error: Program Table', 16, 1)
RETURN @ReturnCode
EXECUTE GetPrograms
--Get Program
GO
CREATE PROCEDURE GetProgram
	@ProgramCode VARCHAR(10) = NULL
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @ProgramCode IS NULL
		RAISERROR('GetProgram: Program Code cannot be null.', 16, 1)
	ELSE
		BEGIN
			SELECT ProgramCode, [Description]
			FROM Program
			WHERE @ProgramCode = ProgramCode
			IF @@ERROR = 0
				SET @ReturnCode = 0
			ELSE
				BEGIN
					RAISERROR('GetPrograms - Select error: Program Table', 16, 1)
					SET @ReturnCode = 1
				END
		END
	RETURN @ReturnCode

EXECUTE GetProgram @ProgramCode = 'DMIT'

--Add Student
GO
ALTER PROCEDURE AddStudent
	@ProgramCode VARCHAR(10) = NULL,
	@FirstName VARCHAR(15) = NULL,
	@LastName VARCHAR(15) = NULL,
	@Email VARCHAR(30) = NULL
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @FirstName IS NULL
		RAISERROR('AddStudent: First Name cannot be null', 16, 1)
		IF @LastName IS NULL
			RAISERROR('AddStudent: Last Name cannot be null', 16, 1)
	ELSE
		BEGIN
			INSERT INTO Student (ProgramCode, FirstName, LastName, EMAIL)
			VALUES (@ProgramCode, @FirstName, @LastName, @Email)
			IF @@ERROR = 0
				SET @ReturnCode = 0
			ELSE
				BEGIN
					RAISERROR('AddStudent: Failed to insert student', 16, 1)
					SET @ReturnCode = 1
				END
		END
	RETURN @ReturnCode


--Update Student
GO
ALTER PROCEDURE UpdateStudent 
	@StudentID INT = NULL,
	@ProgramCode VARCHAR(10) = NULL,
	@FirstName VARCHAR(15) = NULL,
	@LastName VARCHAR(15) = NULL,
	@Email VARCHAR(30) = NULL
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 0

	IF @StudentID IS NULL
		RAISERROR('UpdateStudent: StudentID cannot be null', 16, 1)
		IF @ProgramCode IS NULL
			RAISERROR('UpdateStudent: Program Code cannot be null', 16, 1)
	ELSE
		BEGIN
			UPDATE Student
			SET 
				FirstName = @FirstName,
				LastName = @LastName,
				ProgramCode = @ProgramCode,
				Email = @Email
			WHERE @StudentID = StudentID
			IF @@ERROR = 0
				SET @ReturnCode = 0
			ELSE
				BEGIN
					RAISERROR('UpdateStudent: Update failed', 16, 1)
					SET @ReturnCode = 1
				END
		END
	RETURN @ReturnCode

--Delete Student
GO
CREATE PROCEDURE DeleteStudent
	@StudentID INT = NULL
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 0

	IF @StudentID IS NULL
		RAISERROR('DeleteSutdent: StudentID cannot be null', 16, 1)
	ELSE
		BEGIN
			DELETE FROM Student
			WHERE StudentID = @StudentID
			IF @@ERROR = 0
				SET @ReturnCode = 0
			ELSE
				BEGIN
					RAISERROR('DeleteStudent: Failed to delete student', 16, 1)
					SET @ReturnCode = 1
				END
		END
	RETURN @ReturnCode

--GetStudent
GO
ALTER PROCEDURE GetStudent
	@StudentID INT = NULL
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 0

	IF @StudentID IS NULL
		RAISERROR('GetStudent: StudentID cannot be null', 16, 1)
	ELSE
		BEGIN
			SELECT StudentID, ProgramCode, FirstName, LastName, Email
			FROM Student
			WHERE @StudentID = StudentID
			IF @@ERROR = 0
				SET @ReturnCode = 0
			ELSE
				BEGIN
					RAISERROR('GetStudent: An error occured while looking up a student', 16, 1)
					SET @ReturnCode = 1
				END
		END
	RETURN @ReturnCode

--GetStudents
CREATE PROCEDURE GetStudents
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 0

	BEGIN
		SELECT StudentID, ProgramCode, FirstName, LastName, Email
		FROM Student
		IF @@ERROR = 0
			SET @ReturnCode = 0
		ELSE
			BEGIN
				RAISERROR('GetStudents: An error occured while looking up students', 16, 1)
				SET @ReturnCode = 1
			END
	END
RETURN @ReturnCode

--GetStudentsByProgram
GO
ALTER PROCEDURE GetStudentsByProgram
	@ProgramCode VARCHAR(10) = NULL
AS
	DECLARE @ReturnCode INT
	SET @ReturnCode = 0

	IF @ProgramCode IS NULL
		RAISERROR('GetStudentsByProgram: Program Code cannot be null', 16, 1)
	ELSE
		BEGIN
			SELECT FirstName, LastName, Description
			FROM Student
			INNER JOIN Program
			ON Student.ProgramCode = Program.ProgramCode
			WHERE @ProgramCode = Student.ProgramCode
		END
	RETURN @ReturnCode

SELECT * FROM Program
SELECT * FROM Student

delete from Program
where ProgramCode = 'tyke'

EXEC GetStudentsByProgram 'Demo'

