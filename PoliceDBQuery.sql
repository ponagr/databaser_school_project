--CREATE DATABASE yhstudent76_GangInvestigationDB

--Tabeller
------------------------------------------------------------
-- Tabell: City
CREATE TABLE City (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL
);

-- Tabell: Area
CREATE TABLE Area (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    CityId INT NOT NULL,
    FOREIGN KEY (CityId) REFERENCES City(Id)
);

-- Tabell: Adress
CREATE TABLE Adress (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Street VARCHAR(255) NOT NULL,
    Zip VARCHAR(10) NOT NULL,
    AreaId INT NOT NULL,
    FOREIGN KEY (AreaId) REFERENCES Area(Id)
);

-- Tabell: Person
CREATE TABLE Person (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    DateOfBirth DATE NOT NULL,
    AdressId INT NOT NULL,
    Gender INT NOT NULL,
    FOREIGN KEY (AdressId) REFERENCES Adress(Id)
);

-- Tabell: Gang
CREATE TABLE Gang (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    Description TEXT
);

-- Tabell: Criminal
CREATE TABLE Criminal (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PersonId INT NOT NULL,
    Description TEXT,
    GangId INT NULL,
    Status VARCHAR(50),
    FOREIGN KEY (PersonId) REFERENCES Person(Id),
    FOREIGN KEY (GangId) REFERENCES Gang(Id)
);

-- Tabell: Victim
CREATE TABLE Victim (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PersonId INT NOT NULL,
    FOREIGN KEY (PersonId) REFERENCES Person(Id)
);

-- Tabell: Phone
CREATE TABLE Phone (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Type VARCHAR(50),
    Number VARCHAR(20) NOT NULL,
    PersonId INT NOT NULL,
    FOREIGN KEY (PersonId) REFERENCES Person(Id)
);

-- Tabell: Email
CREATE TABLE Email (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Type VARCHAR(50),
    Adress VARCHAR(255) NOT NULL,
    PersonId INT NOT NULL,
    FOREIGN KEY (PersonId) REFERENCES Person(Id)
);

-- Tabell: Crime
CREATE TABLE Crime (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    Description TEXT
);

-- Tabell: Investigation
CREATE TABLE Investigation (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    CrimeId INT NOT NULL,
    Status VARCHAR(50),
    FOREIGN KEY (CrimeId) REFERENCES Crime(Id)
);

-- Tabell: Cop
CREATE TABLE Cop (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PersonId INT NOT NULL,
    Role VARCHAR(50),
    FOREIGN KEY (PersonId) REFERENCES Person(Id)
);

-- Tabell: Note
CREATE TABLE Note (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NoteType VARCHAR(50),
    NoteDate DATE,
    Description TEXT,
    CopId INT NOT NULL,
    InvestigationId INT NOT NULL,
    FOREIGN KEY (CopId) REFERENCES Cop(Id),
    FOREIGN KEY (InvestigationId) REFERENCES Investigation(Id)
);

-- Tabell: Conviction
CREATE TABLE Conviction (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Description TEXT,
    Sentence VARCHAR(255),
    InvestigationId INT NOT NULL,
    ConvictionDate DATE,
    VictimId INT NULL,
    FOREIGN KEY (InvestigationId) REFERENCES Investigation(Id),
    FOREIGN KEY (VictimId) REFERENCES Victim(Id)
);

-- Tabell: CrimeRecord
CREATE TABLE CrimeRecord (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CriminalId INT NOT NULL,
    ConvictionId INT NOT NULL,
    FOREIGN KEY (CriminalId) REFERENCES Criminal(Id),
    FOREIGN KEY (ConvictionId) REFERENCES Conviction(Id)
);



-- Kopplingstabell: CopToInvestigation
CREATE TABLE CopToInvestigation (
    CopId INT NOT NULL,
    InvestigationId INT NOT NULL,
    PRIMARY KEY (CopId, InvestigationId),
    FOREIGN KEY (CopId) REFERENCES Cop(Id),
    FOREIGN KEY (InvestigationId) REFERENCES Investigation(Id)
);

-- Kopplingstabell: CriminalToInvestigation
CREATE TABLE CriminalToInvestigation (
    CriminalId INT NOT NULL,
    InvestigationId INT NOT NULL,
    PRIMARY KEY (CriminalId, InvestigationId),
    FOREIGN KEY (CriminalId) REFERENCES Criminal(Id),
    FOREIGN KEY (InvestigationId) REFERENCES Investigation(Id)
);

-- Tabell: GangConnections
CREATE TABLE GangConnections (
    Id INT PRIMARY KEY IDENTITY(1,1),
    GangId1 INT NOT NULL,
    GangId2 INT NOT NULL,
    RelationType VARCHAR(50),
    FOREIGN KEY (GangId1) REFERENCES Gang(Id),
    FOREIGN KEY (GangId2) REFERENCES Gang(Id)
);

-- Tabell: GangConnectionsNote
CREATE TABLE GangConnectionsNote (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NoteType VARCHAR(50),
    NoteDate DATE,
    Description TEXT,
    GangConnectionId INT NOT NULL,
    FOREIGN KEY (GangConnectionId) REFERENCES GangConnections(Id)
);

-- Tabell: CriminalToGang
CREATE TABLE CriminalToGang (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CriminalId INT NOT NULL,
    JoinDate DATE,
    Status VARCHAR(50),
    CriminalLevel VARCHAR(50),
    GangId INT NOT NULL,
    FOREIGN KEY (CriminalId) REFERENCES Criminal(Id),
    FOREIGN KEY (GangId) REFERENCES Gang(Id)
);
---------------------------------------------------------------------------


--Data
---------------------------------------------------------------------------
INSERT INTO City (Name) VALUES 
('Sandviken'),
('Stockholm'),
('Göteborg'),
('Malmö');

INSERT INTO Area (Name, Description, CityId) VALUES 
('Central', 'City center', 1),
('Suburb', 'Outer residential area', 1),
('Old Town', 'Historic part of the city', 2),
('Industrial', 'Industrial zone', 3),
('Harbor', 'Coastal area', 4);

INSERT INTO Adress (Street, Zip, AreaId) VALUES 
('Storgatan 1', '81130', 1),
('Bergvägen 12', '81120', 2),
('Gamla Torget 5', '10010', 3),
('Industrivägen 3', '42140', 4),
('Hamngatan 9', '21120', 5);

INSERT INTO Person (Name, DateOfBirth, AdressId, Gender) VALUES 
('Erik Svensson', '1985-03-15', 1, 1),
('Anna Karlsson', '1990-07-22', 2, 2),
('Johan Larsson', '1978-11-02', 3, 1),
('Lisa Andersson', '1995-01-18', 4, 2),
('Oskar Nilsson', '1982-05-30', 5, 1);

INSERT INTO Gang (Name, Description) VALUES 
('Nordic Crew', 'Active in northern Sweden'),
('Eastside Legends', 'Based in Stockholm'),
('West Coast Kings', 'Ruling Göteborg'),
('Harbor Rebels', 'Operating in Malmö');

INSERT INTO Criminal (PersonId, Description, GangId, Status) VALUES 
(1, 'Leader of Nordic Crew', 1, 'Active'),
(3, 'Member of Eastside Legends', 2, 'In Prison'),
(5, 'Operates in Malmö harbor', 4, 'Active');

INSERT INTO Victim (PersonId) VALUES 
(2),
(4);

INSERT INTO Crime (Name, Description) VALUES 
('Robbery', 'Armed robbery of a bank'),
('Smuggling', 'Illegal goods smuggling'),
('Assault', 'Physical attack on a victim');

INSERT INTO Investigation (Name, Description, CrimeId, Status) VALUES 
('Bank Heist Investigation', 'Investigating recent bank robbery', 1, 'Open'),
('Smuggling Ring', 'Tracking smugglers in the harbor', 2, 'Closed'),
('Assault in Old Town', 'Victim assaulted in Stockholm', 3, 'Ongoing');

INSERT INTO Conviction (Description, Sentence, InvestigationId, ConvictionDate, VictimId) VALUES 
('Caught during the act', '5 years in prison', 1, '2024-10-05', NULL),
('Evidence of smuggling', '10 years in prison', 2, '2023-12-15', NULL),
('Perpetrator confessed', '2 years probation', 3, '2024-06-01', 1);

INSERT INTO Cop (PersonId, Role) VALUES 
(1, 'Detective'),
(3, 'Forensic Expert'),
(5, 'Patrol Officer');

INSERT INTO Note (NoteType, NoteDate, Description, CopId, InvestigationId) VALUES 
('Observation', '2024-11-01', 'Suspect seen near the scene', 1, 1),
('Evidence', '2024-11-15', 'Fingerprint analysis completed', 3, 2);

INSERT INTO GangConnections (GangId1, GangId2, RelationType) VALUES 
(1, 2, 'Rivalry'),
(2, 4, 'Allies');

INSERT INTO CriminalToGang (CriminalId, JoinDate, Status, CriminalLevel, GangId) VALUES 
(1, '2010-03-20', 'Active', 'Leader', 1),
(3, '2015-07-15', 'Inactive', 'Member', 2),
(5, '2018-11-22', 'Active', 'Member', 4);

---------------------------------------------------------------------------


--Queries
---------------------------------------------------------------------------
SELECT * FROM Adress
SELECT * FROM Area 
SELECT * FROM City 
SELECT * FROM Conviction 
SELECT * FROM Cop 
SELECT * FROM CopToInvestigation
SELECT * FROM Crime 
SELECT * FROM CrimeRecord 
SELECT * FROM Criminal 
SELECT * FROM CriminalToGang 
SELECT * FROM CriminalToInvestigation 
SELECT * FROM Email 
SELECT * FROM Phone 
SELECT * FROM Gang 
SELECT * FROM Investigation 
SELECT * FROM Victim 
SELECT * FROM Person 
SELECT * FROM Note 
SELECT * FROM GangConnections
SELECT * FROM GangConnectionsNote
----------------------------------------------



---------------------------------------------------------------------------