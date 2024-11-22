CREATE TABLE Carrinho 
( 
Id INT PRIMARY KEY AUTO_INCREMENT,
UsuarioId INT, 
ProdutoId INT,
Quantidade INT NOT NULL,
FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
FOREIGN KEY (ProdutoId) REFERENCES Produtos(Id)
);

