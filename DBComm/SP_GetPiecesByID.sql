CREATE PROCEDURE [dbo].[GetPiecesByID]
	@TableName VARCHAR(10),
	@PieceID int
AS
	SELECT * 
	FROM @TableName
    WHERE ID = @PieceID;