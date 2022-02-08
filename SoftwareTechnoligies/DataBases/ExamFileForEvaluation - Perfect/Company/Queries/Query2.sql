USE Company

SELECT d.Name AS [Department], COUNT(e.Id) AS [Number of employees]
FROM Departments d
	JOIN Employees e
	ON e.DepartmentId = d.Id
GROUP BY d.Name
ORDER BY [Number of employees] DESC