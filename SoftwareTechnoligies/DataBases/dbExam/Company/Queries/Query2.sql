USE [Company]

GO

SELECT COUNT(*) AS [Count], Departments.Name
FROM Departments
INNER JOIN Employees
ON Departments.Id = Employees.DepartmentId
GROUP BY Departments.Name