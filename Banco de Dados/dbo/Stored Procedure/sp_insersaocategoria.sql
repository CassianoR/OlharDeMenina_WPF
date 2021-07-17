CREATE PROCEDURE sp_insersaocategoria
    @NomeCategoria VARCHAR(40)
AS
BEGIN
    INSERT INTO Categoria VALUES (@NomeCategoria)
END