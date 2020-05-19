USE [RatingEmpresas] ;
GO

BULK INSERT regions
FROM 'C:\Users\stefa\source\repos\rating-empresas-api-.NET\docs\19_cod_ccaa.csv'
WITH
(
    FORMAT='CSV',
    CODEPAGE = '65001',
    FIRSTROW = 2,
    FIELDQUOTE = '"',
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '0x0A',
    ROWS_PER_BATCH = 1000,
    TABLOCK
)
GO

BULK INSERT provinces
FROM 'C:\Users\stefa\source\repos\rating-empresas-api-.NET\docs\19_cod_prov.csv'
WITH
(
    FORMAT='CSV',
    CODEPAGE = '65001',
    FIRSTROW = 2,
    FIELDQUOTE = '"',
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '0x0A',
    ROWS_PER_BATCH = 1000,
    TABLOCK
)
GO

BULK INSERT cities
FROM 'C:\Users\stefa\source\repos\rating-empresas-api-.NET\docs\19_codmun.csv'
WITH
(
    FORMAT='CSV',
    CODEPAGE = '65001',
    FIRSTROW = 2,
    FIELDQUOTE = '"',
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '0x0A',
    ROWS_PER_BATCH = 1000,
    TABLOCK
)
GO
