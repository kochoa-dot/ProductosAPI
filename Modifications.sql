CREATE TABLE TempProductos (
    id INT IDENTITY(1,1) PRIMARY KEY,
    descripcion VARCHAR(50) NULL,
    precio MONEY NULL
);

INSERT INTO TempProductos (descripcion, precio)
SELECT descripcion, precio FROM Productos;

DROP TABLE Productos;

EXEC sp_rename 'TempProductos', 'Productos';
