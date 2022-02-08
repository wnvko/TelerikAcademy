USE Company
GO

CREATE PROC dbo.usp_CreateCacheTable
AS
  CREATE TABLE CacheOfAllEmployeesWithProjects(
	FullName nvarchar(41),
	Department nvarchar(50),
	Project nvarchar(50),
	StartDate datetime,
	EndDate datetime,
	NumberOfReports int)
GO

EXEC dbo.usp_CreateCacheTable