CREATE PROC insertarProductos
@descripcion varchar(50),
@precio money
as 
insert into Productos (descripcion, precio)
values(@descripcion,@precio)
-------------------------------------
CREATE PROC editarProductos
@id int,
@precio money
as
update Productos
set precio = @precio
where id = @id
-------------------------------------
CREATE PROC mostrarProductos
as
SELECT * FROM Productos
-------------------------------------
CREATE PROC eliminarProductos
@id int
as
delete from Productos
where id = @id