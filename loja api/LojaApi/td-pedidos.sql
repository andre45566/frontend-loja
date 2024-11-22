CREATE TABLE Pedidos 
( 
Id INT PRIMARY KEY AUTO_INCREMENT,
UsuarioId INT, 
DataPedido DATE NOT NULL, 
StatusPedido VARCHAR(50) DEFAULT 'Em andamento', 
ValorTotal DECIMAL(10, 2) NOT NULL,
FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
 );

