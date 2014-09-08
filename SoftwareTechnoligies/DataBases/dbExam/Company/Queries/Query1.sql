USE [Company]

GO

SELECT Employees.FirstName + ' ' + Employees.LastName AS [Full Name], YearSalary AS [Year Salary]
FROM Employees
WHERE Employees.YearSalary >= 100000 AND Employees.YearSalary <= 150000
ORDER BY Employees.YearSalary


