USE Company

SELECT e.FirstName + ' ' + e.LastName AS [Full name], d.Name AS [Department], p.Name AS [Project], ep.StartDate AS [Start date], ep.EndDate AS [End date],
(SELECT COUNT(*)
 FROM Reports
 WHERE EmployeeId = e.Id AND TimeOfReporting >= ep.StartDate AND TimeOfReporting <= ep.EndDate) AS [Number of reports]
FROM Employees e
	JOIN EmployeesProjects ep
	ON ep.EmployeeId = e.Id
		JOIN Projects p
		ON p.Id = ep.ProjectId
			JOIN Departments d
			ON d.Id = e.DepartmentId
ORDER BY e.Id, p.Id