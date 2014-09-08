USE [Company]

GO

SELECT Employees.FirstName + ' ' + Employees.LastName AS [Full Name],
		Projects.Name AS [Project Name], 
		Departments.Name As [Department Name],
		EmployeesProjects.StartDate AS [Start Date],
		EmployeesProjects.EndDate AS [End Date],
		   (SELECT COUNT(*)
			FROM Employees
			INNER JOIN Reports
			ON Employees.Id = Reports.EmployeeId
			WHERE Employees.Id = EmployeesProjects.EmployeeId
				AND Reports.Time > EmployeesProjects.StartDate
				AND Reports.Time < EmployeesProjects.EndDate
			GROUP BY Employees.Id
			) AS [Reports]
		
FROM EmployeesProjects
INNER JOIN Employees
	ON EmployeesProjects.EmployeeId = Employees.Id
INNER JOIN Projects
	ON EmployeesProjects.ProjectId = Projects.Id
INNER JOIN Departments
	ON Employees.DepartmentId = Departments.Id
ORDER BY Employees.Id, Projects.Id

