USE [TIENDADB]
GO
/****** Object:  StoredProcedure [dbo].[editarProductos]    Script Date: 16/08/2023 08:25:54 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[editarProductos]
@id int,
@precio money
as
update Productos
set precio = @precio
where id = @id
GO
/****** Object:  StoredProcedure [dbo].[eliminarProductos]    Script Date: 16/08/2023 08:25:54 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[eliminarProductos]
@id int
as
delete from Productos
where id = @id
GO
/****** Object:  StoredProcedure [dbo].[insertarProductos]    Script Date: 16/08/2023 08:25:54 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertarProductos]
@descripcion varchar(50),
@precio money
as 
insert into Productos (descripcion, precio)
values(@descripcion,@precio)
GO
/****** Object:  StoredProcedure [dbo].[mostrarProductos]    Script Date: 16/08/2023 08:25:54 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[mostrarProductos]
as
SELECT * FROM Productos
GO
