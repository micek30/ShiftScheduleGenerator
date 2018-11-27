CREATE TABLE LawRequirements(
idRequirements  int identity(1,1) PRIMARY KEY,
reqDesc varchar(50),
fulfilled bit
)

CREATE TABLE Employees(
idEmployee int identity(1,1) PRIMARY KEY,
name varchar(50) NOT NULL,
surname varchar(50) NOT NULL,
jobContract varchar(20),
idTeam int FOREIGN KEY REFERENCES Teams(idTeam),
independent bit,
frenchlvl varchar(5),
idUser int FOREIGN KEY REFERENCES Users(idUser)
)


CREATE TABLE Teams(
idTeam int identity(1,1) PRIMARY KEY,
name varchar(20),
countEmp int
)

CREATE TABLE Users(
idUser int identity(1,1) PRIMARY KEY,
password varchar(20),
permission varchar(10)
)

CREATE TABLE LanguageSupport(
idLanguage int PRIMARY KEY,
isLanguageSupport bit
)

CREATE TABLE EmpRequirements(
idEmpRequirements  int identity(1,1) PRIMARY KEY,
idEmployee int FOREIGN KEY REFERENCES Employees(idEmployee),
reqDesc varchar(50),
dateReq date,
dayNight varchar(1),
fulfilled bit
)

CREATE TABLE EmpRequests(
idEmpRequest  int identity(1,1) PRIMARY KEY,
idEmployee int FOREIGN KEY REFERENCES Employees(idEmployee),
reqDesc varchar(50),
dateReq date,
dayNight varchar(1),
accepted varchar(10),
fulfilled bit
)

CREATE TABLE FTE
           (idFTE int primary key identity(1,1),
           idEmployee int ,
		   dimension float,
           workingHours int,
           workingHoursLast int,
           SPM int,
		   FOREIGN KEY (idEmployee) REFERENCES Employees(idEmployee)
           )
