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




