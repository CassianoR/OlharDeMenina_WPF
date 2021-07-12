CREATE VIEW Produtos_add_Quantidade AS
SELECT p.NomeProduto, p.Descricao, p.Marca, p.Categoria, p.Valor, e.QuantidadeEstoque
FROM Produtos p, Estoque e
WHERE e.FK_CodigoProduto = p.Codigo