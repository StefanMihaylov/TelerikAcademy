USE Company
GO

SELECT e.FirstName + ' ' + e.LastName AS [Full name], p.Name AS [Project], d.Name AS [Department],
	 ep.StartingDate AS [Start Date],  ep.EndDate AS [End Date], 
	 ( SELECT COUNT(r.ReportId)
		FROM Reports r
		WHERE r.Time BETWEEN ep.StartingDate AND ep.EndDate and e.EmployeeId = r.EmployeeId)
FROM Employees e
JOIN Departments d
ON e.DepartmentId = d.DepartmentId
JOIN EmployeesProjects ep
ON e.EmployeeId = ep.EmployeeId
JOIN Projects p
ON p.ProjectId = ep.ProjectId
ORDER BY e.EmployeeId, p.ProjectId





