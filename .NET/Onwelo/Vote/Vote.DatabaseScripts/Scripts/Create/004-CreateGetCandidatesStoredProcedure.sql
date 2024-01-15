CREATE PROCEDURE [dbo].[GetCandidates]
AS
BEGIN
	SELECT p.[Id]
      ,p.[FirstName]
      ,p.[LastName]
	  ,COUNT_BIG(v.[Id]) as [Votes]  
	FROM [dbo].[Person] AS p
	LEFT JOIN [dbo].[Vote] AS v ON v.[IdCandidate] = p.[Id] AND p.[Type] = 1
	GROUP BY p.[Id], p.[FirstName],p.[LastName], p.[Type] HAVING p.[Type] = 1
END
GO