create database MaquinaExpendedoraDB;

CREATE TABLE Productos_ (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductoNombre NVARCHAR(100) NOT NULL,
    Codigo NVARCHAR(20) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Cantidad INT NOT NULL
);


INSERT INTO Productos_ (ProductoNombre, Codigo, Precio, Cantidad) VALUES
('Doritos Nacho', 'A1', 30.00, 10),
('Takis Fuego', 'A2', 35.00, 10),
('Cheetos', 'A3', 28.00, 10),
('Doritos BBQ', 'A4', 32.00, 10),

('KitKat', 'B1', 25.00, 15),
('Snickers', 'B2', 27.00, 15),
('Twix', 'B3', 26.00, 15),
('Mars', 'B4', 29.00, 15),

('Gatorade Rojo', 'C1', 20.00, 20),
('Gatorade Naranja', 'C2', 20.00, 20),
('Gatorade Azul', 'C3', 20.00, 20),
('Gatorade Morado', 'C4', 20.00, 20);

USE MaquinaExpendedoraDB;
GO

SELECT * FROM Productos_;
