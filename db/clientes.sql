-- Crear la base de datos si no existe
IF DB_ID('BD_CLIENTES') IS NULL
BEGIN
    CREATE DATABASE BD_CLIENTES;
END
GO

-- Usar la base de datos
USE BD_CLIENTES;
GO

-- Crear la tabla Cliente
IF OBJECT_ID('Cliente', 'U') IS NOT NULL
    DROP TABLE Cliente;
GO

CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(100) NOT NULL
);
GO

-- Insertar datos de ejemplo
INSERT INTO Clientes (Nombre, Correo) VALUES
('Juan Pérez', 'juan@example.com'),
('Ana López', 'ana@example.com'),
('Carlos Ruiz', 'carlos@example.com');
GO
