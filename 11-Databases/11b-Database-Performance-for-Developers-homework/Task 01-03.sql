-- Task 1
-- Create a table in SQL Server with 10 000 000 log entries (date + text). 
-- Search in the table by date range. Check the speed (without caching).
-----------------------------------------------------

USE master
GO

CREATE DATABASE LogsDB
GO

USE LogsDB
GO

Create TABLE Logs(
  LogId int NOT NULL IDENTITY,
  LogDate date,
  LogText nvarchar(50),
  CONSTRAINT PK_Logs_LogId PRIMARY KEY (LogId)
)

DECLARE @startTime datetime = GETDATE()

DECLARE @dateFrom date = '2014-01-01'
DECLARE @dateTo date = '2014-09-01'
DECLARE @datediff int = (datediff(day, @dateFrom, @dateTo)+1)
DECLARE @randomDay date
DECLARE @counter int = 0

WHILE @counter < 1000000 -- 1 000 000 records
BEGIN
  SET @randomDay = dateadd(day, rand(checksum(newid()))*@datediff, @dateFrom)
  INSERT INTO Logs(LogDate, LogText) VALUES(@randomDay, 'Text' + CONVERT(varchar,@counter))
  SET @counter = @counter + 1
END

DECLARE @stopTime datetime = GETDATE()
print cast(@stopTime-@startTime as time)

 -- database filled for 00:04:43 on my PC

SELECT COUNT(*) FROM Logs

SELECT TOP 5 * FROM Logs


--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS; 

--Test search by date before adding index
DECLARE @startTime1 datetime = GETDATE()

SELECT COUNT(*) FROM Logs 
WHERE LogDate BETWEEN CONVERT(datetime, '2014-04-01') AND CONVERT(datetime, '2014-05-01');

DECLARE @stopTime1 datetime = GETDATE()
print cast(@stopTime1 - @startTime1 as time)

SELECT TOP 5 * FROM Logs
WHERE LogDate BETWEEN CONVERT(datetime, '2014-04-01') AND CONVERT(datetime, '2014-05-01');

-- return more the 120 000 records for 00:00:00.9330000

-----------------------------------------------------
-- Task 2
-- Add an index to speed-up the search by date. Test the search speed (after cleaning the cache).
-----------------------------------------------------

CREATE INDEX IDX_Logs_LogId
ON Logs(LogId)

--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS; 

--Test search by date after adding index
DECLARE @startTime2 datetime = GETDATE()

SELECT COUNT(*) FROM Logs 
WHERE LogDate BETWEEN CONVERT(datetime, '2014-04-01') AND CONVERT(datetime, '2014-05-01');

DECLARE @stopTime2 datetime = GETDATE()
print cast(@stopTime2 - @startTime2 as time)

-- return more the 120 000 records for 00:00:00.1170000

-----------------------------------------------------
-- Task 3
-- Add a full text index for the text column. Try to search with and without the full-text index and compare the speed
-----------------------------------------------------

--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;

DECLARE @startTime3 datetime = GETDATE()

--Search from full text
SELECT COUNT(*) FROM Logs
WHERE LogText LIKE '%1234%'

DECLARE @stopTime3 datetime = GETDATE()
print cast(@stopTime3 - @startTime3 as time)

-- return 300 records for 00:00:01.4830000

-- Add full text catalog
CREATE FULLTEXT CATALOG MessagesFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Logs(LogText)
KEY INDEX PK_Logs_LogId
ON MessagesFullTextCatalog
WITH CHANGE_TRACKING AUTO

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

DECLARE @startTime4 datetime = GETDATE()

--Search from full text
SELECT COUNT(*) FROM Logs
WHERE LogText LIKE '%1234%'

DECLARE @stopTime4 datetime = GETDATE()
print cast(@stopTime4 - @startTime4 as time)

-- return 300 records for 00:00:00.9930000

