create database reto2;
use reto2;

												/*USUARIO*/
create table Usuario(
	Idu int primary key IDENTITY,
	documento varchar(50) not null unique,
	nombres varchar(70) not null,
	apellidos varchar(70) not null,
	contraseña varchar(32) not null,
	telefono varchar(45),
	puntos int,
	rol bit default 0)
GO
												/*CRUDUSUARIO*/
create procedure createuser(
	@documento varchar(50),
	@nombres varchar(70),
	@apellidos varchar(70),
	@contraseña varchar(32),
	@telefono varchar(45))
	as begin insert into Usuario(documento,nombres,apellidos,contraseña,telefono)
	values(@documento,@nombres,@apellidos,@contraseña,@telefono);

END
GO
create procedure updateuser(
	@documento varchar(50),
	@contraseña varchar(32),
	@telefono varchar(45))
	as begin update Usuario set telefono=@telefono, contraseña=@contraseña 
	where documento=@documento;
END
GO
create procedure deleteuser(@documento varchar(50)) as begin delete from Usuario where documento=@documento;
END
GO
create procedure readuser
as begin
select documento,nombres,apellidos,contraseña,telefono,puntos from Usuario;
END
GO
create procedure loginuser(@documento varchar(50),@contraseña varchar(32))
as begin
select *from Usuario where documento=@documento and contraseña=@contraseña;
END
GO
create procedure searchxDoc(@documento varchar(50))
as begin
select *from Usuario where documento = @documento;
END
GO

												/*CATALOGO*/
create table Catalogo(
	Idcat int IDENTITY primary key,
	nombre  varchar(50) Unique not null,
	fecha_creacion date default getdate(),
	estado bit default 1)											
GO
												/*CRUD CATALOGO*/
create procedure createcatalogo(
	@nombre varchar(50),
	@estado bit)
	as begin
	insert into Catalogo (nombre,estado) values(@nombre,@estado);
END
GO
create procedure updatecatalogo(
	@Idcat int,
	@nombre varchar(50),
	@estado bit)
	as begin
	update Catalogo set nombre=@nombre, estado=@estado where Idcat=@Idcat;
END
GO
create procedure deletecatalogo(@idcat int)
as begin delete from Catalogo where Idcat=@idcat;
END
GO
create procedure readcatalogo(@idcat int)
as begin select Idcat, nombre,fecha_creacion,estado from Catalogo where Idcat = @idcat;
END
GO
create procedure searchcatalog(@fecha date, @nombre varchar(50))
as begin
select Idcat, nombre,fecha_creacion,estado from Catalogo where fecha_creacion = @fecha or nombre  = @nombre
END
GO
create procedure comboCatalog
as begin
select*from Catalogo where estado = 1;
END
GO

												/*PRODUCTO*/
create table Producto(
	Idprod int IDENTITY primary key,
	nombre varchar(70) UNIQUE not null,
	imagen varchar(70) not null,
	cantidad int,
	precio float)
GO
												/*CRUD PRODUCTO*/
create procedure createproducto(
	@nombre varchar(70),
	@imagen varchar(70),
	@cantidad int)
	as begin insert into Producto(nombre,imagen,cantidad) values (@nombre,@imagen,@cantidad)
END
GO
create procedure updateproducto(
	@nombre varchar(70),
	@imagen varchar(70),
	@cantidad int)as begin update Producto set nombre=@nombre,imagen=@imagen,cantidad=@cantidad; 
END
GO
create procedure readproducto
as begin
select * from Producto;
END
GO
create procedure deleteproducto(@Id int)
as begin delete from Producto where Idprod=@Id;
END
GO
create procedure searchProducto(@nombre varchar(50))
as begin
select * from Producto where nombre = @nombre;
END
GO


												/*(TABLA INTERMEDIA) PROD_CATALOG*/
create table Prod_Catalog(
	IdprodCat int primary key IDENTITY,
	Idcat int,
	Idpro int,
	foreign key (Idcat) references Catalogo(Idcat),
	foreign key (Idpro) references Producto(Idprod))
/*ASOCIAR*/
GO
create procedure createrel(@Catal int, @Prod int)
as begin
insert into Prod_Catalog (Idcat,Idpro) values(@Catal, @Prod);
END
/*DES-ASOCIAR*/
GO
create procedure deleterel(@Idcatprod int)
as begin
delete from Prod_Catalog where Idcatprod=@Idcatprod;
END
GO


Select *from Producto;
Select *from Catalogo;
delete from Producto;
delete from Catalogo;
/*SEMILLAS*/
/*admin*/


