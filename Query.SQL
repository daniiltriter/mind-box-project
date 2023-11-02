WITH ProductCategoryCounts AS (
    SELECT
        P.ProductID,
        P.ProductName,
        C.CategoryName,
        COUNT(C.CategoryID) OVER (PARTITION BY P.ProductID) AS CategoryCount
    FROM Products P
             LEFT JOIN ProductCategories PC ON P.ProductID = PC.ProductID
             LEFT JOIN Categories C ON PC.CategoryID = C.CategoryID
)
SELECT
    PC.ProductName,
    COALESCE(PC.CategoryName, 'No category') AS CategoryName,
    PC.CategoryCount
FROM ProductCategoryCounts PC