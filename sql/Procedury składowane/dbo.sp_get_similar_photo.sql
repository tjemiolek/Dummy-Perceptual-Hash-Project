CREATE PROCEDURE [dbo].[sp_get_similar_photo] @param1 varchar(8)
AS

BEGIN

;WITH CTETable (ImgPath, Distance, Dph)
AS (
SELECT id.ImagePath, dbo.f_get_distance(@param1, id.Dph) AS result, id.Dph 
FROM ImageData id
)

SELECT ImgPath
FROM CTETable
WHERE Distance <=4
ORDER BY Dph Asc;
END

RETURN