USE Company
GO

SELECT d.Name, COUNT(e.EmployeeId) as [Number of Employees]
FROM Employees e
INNER JOIN Departments d
ON e.DepartmentId = d.DepartmentId
GROUP BY d.Name
ORDER BY [Number of Employees] DESC
