CREATE PROCEDURE [dbo].[GetVoters]

AS
BEGIN
	SELECT 
		p.[Id]
		,p.[FirstName]
		,p.[LastName]
		,CASE
			WHEN COUNT(v.[Id]) > 0 THEN CAST(1 AS BIT)
			ELSE CAST(0 AS BIT)
	  END AS [HasVote]
	FROM [dbo].[Person] AS p
	LEFT JOIN [dbo].[Vote] AS v ON v.[IdVoter] = p.[Id] AND p.[Type] = 0
	GROUP BY p.[Id], p.[FirstName],p.[LastName], p.[Type] HAVING p.[Type] = 0
END
GO