-- Create the same table in MySQL and partition it by date (1990, 2000, 2010). 
-- Fill 1 000 000 log entries. Compare the searching speed in all partitions (random dates) 
-- to certain partition (e.g. year 1995)

CREATE DATABASE LogsDB;

USE LogsDB;

Create TABLE Logs(
  LogId int NOT NULL AUTO_INCREMENT,
  LogDate date,
  LogText nvarchar(50),
  CONSTRAINT PK_Logs_LogId PRIMARY KEY (LogId, LogDate)
) PARTITION BY RANGE(YEAR(LogDate))(
	PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p1 VALUES LESS THAN (2000),
	PARTITION p2 VALUES LESS THAN (2010),
	PARTITION p3 VALUES LESS THAN MAXVALUE
);

DELIMITER $$
DROP PROCEDURE IF EXISTS insert_million_rows $$

CREATE PROCEDURE InsertMilionRowsInDB () 
BEGIN
DECLARE counter INT DEFAULT 0;
	START TRANSACTION;
	WHILE counter < 1000000 DO
		INSERT INTO Logs(LogDate, LogText)
		VALUES(TIMESTAMPADD(DAY, FLOOR(1 + RAND() * 10000), '1990-01-01'),
		CONCAT('text ', counter));
SET counter = counter + 1;
END WHILE;
END $$

CALL InsertMilionRowsInDB (); -- database created for 38s

SELECT COUNT(*) FROM Logs PARTITION (p2); -- search for 0.3s

SELECT COUNT(*) FROM Logs WHERE YEAR(LogDate) = 1995; -- search for 1.3s