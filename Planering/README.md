**Planering:**
- Associationsdiagram med tabeller, kolumner, datatyper och relationer
- Vidareutveckling av diagram
- Implementera i SQL, lägg till tabeller och fyll på med data
- Skriv meningsfulla queries, minst 10st, minst 3st joins och minst 1st SQL-funktion
- Implementera detta i C# med meny och val, samt fin utskrift

Kunna hämta ut specifika gäng, och se "medlemmar"
Kunna hämta ut relationer mellan gäng
Kunna hämta ut gäng i ett visst område/stad

Kunna öppna/skapa en ny utredning
Kunna ändra/lägga till info till en utredning, lägga till offer/kriminell till en utredning
Skriva och lägga till "Notes" till utredning

Kunna visa specifika kriminellas info, med brottsregister, domar, pågående utredningar osv

Kunna söka efter specifika brott, och kunna sortera detta efter datum, area eller person(Order by/Group by)

Snygg Utskrift, med radbrytningar/linjer mellan olika "Columner"
Felhantering i C# vid användarinput(Console.ReadLine)
logga felmeddelanden, (spara i fil, istället för att skriva ut i konsoll)

**TODO:**
-[x] Skapa diagram
-[x] Lägg in tabeller och data
-[x] Skriv queries
-[x] Implementera delar i C#

***Potentiella förbättringar/funderingar***
Tog bort Email, Adress och Phone tabellerna, GangConnectionsNote, CriminalToGang, då dessa känns överflödiga och jag kommer inte orka fylla på data i dessa
Hade missat att lägga till Crimedate i Crime-Tabellen, la även till CityId för att veta var brottet har begåtts.

Behöver det finnas en Person, Cop och Criminal tabell, eller räcker det med en Person tabell?

Skulle förmodligen kunna förenkla vissa tabeller så det inte krävs så många joins för alla queries

Hade problem med gangconnections, med dubbla id,

***Tabeller:***
City:
Id:int(FK)
Name:varchar

Area:
Id:int(PK)
Name:varchar
Description:text
CityId:int(FK)

Person:
Id:int(PK)
Name:varchar
DateOfBirth:date
AdressId:int(FK)
Gender:int

Gang:
Id:int(PK)
Name:varchar
Description:text

Criminal:
Id:int(PK)
PersonId:int(FK)
Description:text
GangId:int(FK) NULL
Status:varchar

Victim:
Id:int(PK)
PersonId:int(FK)

CrimeRecord:
Id:int(PK)
CriminalId:int(FK)
ConvictionId:int(FK)

Cop:
Id:int(PK)
PersonId:int(FK)
Role:varchar

Investigation:
Id:int(PK)
Name:varchar
Description:text
CrimeId:int(FK)
Status:varchar

Crime:
Id:int(PK)
Name:Varchar
Description:text

Note:
Id:int(PK)
NoteType:varchar
NoteDate:date
Description:text
CopId:int(FK)
InvestigationId:int(FK)

CopToInvestigation:
CopId:int(FK)
InvestigationId:int(FK)

CriminalToInvestigation:
CriminalId:int(FK)
InvestigationId:int(FK)

Conviction:
Id:int(PK)
Description:text
Sentence:varchar
InvestigationId:int(FK)
ConvictionDate:date
VictimId:int(FK) NULL

GangConnections:
Id:int(PK)
GangId1:int(FK)
GangId2:int(FK)
RelationType:varchar


***Queries:***
--Hämta ut alla brott vid ett specifikt datum för en specifik stad
SELECT Crime.Name, Description, CrimeDate
FROM Crime
JOIN City ON Crime.CityId = City.Id AND City.Name = 'Sandviken'
WHERE CrimeDate BETWEEN '2021-06-06' AND '2021-08-06';

--Hämta ut alla kriminella som är involverade i ett specifikt gäng
SELECT p.Name, p.DateOfBirth, c.Description AS PersonDescription, c.Status, g.Name AS Gang, g.Description AS GangDescription
FROM Person p
JOIN Criminal c ON p.Id = c.PersonId
JOIN Gang g ON c.GangId = g.Id AND g.Name LIKE 'g%'

--Hämta ut alla gäng som är aktiva i en specifik stad
SELECT g.Name AS Gang, City.Name AS ActiveCity, g.Description AS GangDescription
FROM Person p
JOIN Criminal c ON p.Id = c.PersonId
JOIN Gang g ON g.Id = c.GangId
JOIN GangToCity GToC ON g.Id = GToC.GangId
JOIN City ON GToC.CityId = City.Id AND City.Name = 'Sandviken'

--Hämta ut brottsregister för en specifik kriminell
SELECT i.Name, i.Description, co.Sentence, Crime.CrimeDate, co.ConvictionDate
FROM Criminal c
JOIN CrimeRecord cr ON cr.CriminalId = c.Id
JOIN Person p ON p.Id = c.PersonId AND p.Name LIKE '%a%'
JOIN CriminalToInvestigation CtI ON CtI.CriminalId = c.Id
JOIN Investigation i ON i.Id = CtI.InvestigationId
JOIN Crime ON Crime.Id = i.CrimeId
JOIN Conviction co ON co.InvestigationId = i.Id

--Visa aktiva utredningar där en specifik kriminell är involverad
SELECT i.Name, i.Description, cr.CrimeDate, ci.Name
FROM Investigation i
JOIN Crime cr ON cr.Id = i.CrimeId
JOIN City ci ON ci.Id = cr.CityId
JOIN CriminalToInvestigation CtI ON CtI.InvestigationId = i.Id 
JOIN Criminal c ON c.Id = CtI.CriminalId
JOIN Person p ON p.Id = c.PersonId
WHERE i.[Status] = 'Ongoing' AND p.Name LIKE 'm%'

--Visa aktiva utredningar där en specifik polis är involverad
SELECT i.Name, i.Description, cr.CrimeDate, ci.Name
FROM Investigation i
JOIN Crime cr ON cr.Id = i.CrimeId
JOIN City ci ON ci.Id = cr.CityId
JOIN CopToInvestigation CtI ON CtI.InvestigationId = i.Id 
JOIN Cop c ON c.Id = CtI.CopId
JOIN Person p ON p.Id = c.PersonId
WHERE i.[Status] = 'Ongoing' AND p.Name LIKE 'e%'

--Visa ALLA(aktiva och avslutade) utredningar där en specifik kriminell är involverad
SELECT i.Name, i.Description, cr.CrimeDate, ci.Name, i.Status
FROM Investigation i
JOIN Crime cr ON cr.Id = i.CrimeId
JOIN City ci ON ci.Id = cr.CityId
JOIN CriminalToInvestigation CtI ON CtI.InvestigationId = i.Id 
JOIN Criminal c ON c.Id = CtI.CriminalId
JOIN Person p ON p.Id = c.PersonId
WHERE p.Name LIKE 'm%'

--Visa ALLA(aktiva och aslutade) utredningar där en specifik polis är involverad
SELECT i.Name, i.Description, cr.CrimeDate, ci.Name, i.Status
FROM Investigation i
JOIN Crime cr ON cr.Id = i.CrimeId
JOIN City ci ON ci.Id = cr.CityId
JOIN CopToInvestigation CtI ON CtI.InvestigationId = i.Id 
JOIN Cop c ON c.Id = CtI.CopId
JOIN Person p ON p.Id = c.PersonId
WHERE p.Name LIKE 'e%'

--Visa kopplingar mellan olika gäng
SELECT g1.Name AS Gang1, gc.RelationType, g2.Name AS Gang2
FROM GangConnections gc
JOIN Gang g1 ON gc.GangId1 = g1.Id
JOIN Gang g2 ON gc.GangId2 = g2.Id 

--Visa all info om en specifik kriminell
SELECT p.Name, p.Gender, p.DateOfBirth, cr.[Status], cr.[Description], g.Name AS Gang
FROM Person p 
JOIN Criminal cr ON cr.PersonId = p.Id
JOIN Gang g ON g.Id = cr.GangId
WHERE p.Id = 1

--Visa all info om alla gäng
SELECT g.Name, COUNT(c.Name) AS ActiveCitys, COUNT(p.Name) AS Members
FROM Person p 
JOIN Criminal cr ON cr.PersonId = p.Id
JOIN Gang g ON g.Id = cr.GangId
JOIN GangToCity GtC ON GtC.GangId = g.Id
JOIN City c ON c.Id = GtC.CityId
GROUP BY g.Name

--AVG för hur många gäng som är aktiva i varje stad
SELECT c.Name, COUNT(g.Name) AS ActiveGangs
FROM Gang g
JOIN GangToCity GtC ON GtC.GangId = g.Id
JOIN City c ON c.Id = GtC.CityId
GROUP BY c.Name

--SUM för hur många kriminella varje gäng har
SELECT g.Name, COUNT(p.Name) AS Members
FROM Person p 
JOIN Criminal c ON c.PersonId = p.Id
JOIN Gang g ON g.Id = c.GangId
GROUP BY g.Name

--SUM för hur många brott varje kriminell är dömd för(CrimeRecord)
SELECT p.Name, COUNT(cr.Id) AS Convictions          
FROM Criminal c
JOIN CrimeRecord cr ON cr.CriminalId = c.Id
JOIN Person p ON p.Id = c.PersonId
JOIN CriminalToInvestigation CtI ON CtI.CriminalId = c.Id
JOIN Investigation i ON i.Id = CtI.InvestigationId
JOIN Crime ON Crime.Id = i.CrimeId
JOIN Conviction co ON co.InvestigationId = i.Id
GROUP BY p.Name
