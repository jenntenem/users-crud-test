USE prueba

--DROP TABLE dbo.usuarios
--DROP TABLE dbo.departamentos
--DROP TABLE dbo.cargos
GO

CREATE TABLE [dbo].[cargos] (
	[id] [int] NOT NULL IDENTITY (1,1) PRIMARY KEY,
	[codigo] [nchar](10) NOT NULL,
	[nombre] [nchar](25) NOT NULL,
	[activo] [bit] NOT NULL DEFAULT 1,
	[idUsuarioCreacion] [int] NOT NULL,
);

CREATE TABLE [dbo].[departamentos](
	[id] [int] NOT NULL IDENTITY (1,1) PRIMARY KEY,
	[codigo] [nchar](10) NOT NULL,
	[nombre] [nchar](25) NOT NULL,
	[activo] [bit] NOT NULL DEFAULT 1,
	[idUsuarioCreacion] [int] NOT NULL);

CREATE TABLE [dbo].[usuarios](
	[id] [int] NOT NULL IDENTITY (1,1) PRIMARY KEY,
	[usuario] [nchar](10) NULL,
	[primerNombre] [nchar](10) NULL,
	[segundoNombre] [nchar](10) NULL,
	[primerApellido] [nchar](10) NULL,
	[segundoApellido] [nchar](10) NULL,
	[email] [nchar](50) NULL,
	[idDepartamento] [int] NULL,
	[idCargo] [int] NULL,
	[activo] [bit] NOT NULL DEFAULT 1, 
	FOREIGN KEY ([idDepartamento]) REFERENCES dbo.departamentos (id),
	FOREIGN KEY ([idCargo]) REFERENCES dbo.cargos (id),
	CONSTRAINT AK_username UNIQUE(usuario)  

);

GO

-- Insertar registros en la tabla cargos
INSERT INTO dbo.cargos (codigo, nombre, activo, idUsuarioCreacion)
VALUES 
    ('CG001', 'Gerente de Ventas', 1, 1),
    ('CG002', 'Analista de RRHH', 1, 1),
    ('CG003', 'Ingeniero de Software', 1, 1),
    ('CG004', 'Contador', 1, 1),
    ('CG005', 'Especialista en Marketing', 1, 1);

-- Insertar registros en la tabla departamentos
INSERT INTO dbo.departamentos (codigo, nombre, activo, idUsuarioCreacion)
VALUES 
    ('DEP001', 'Ventas', 1, 1),
    ('DEP002', 'Recursos Humanos', 1, 1),
    ('DEP003', 'Tecnología', 1, 1),
    ('DEP004', 'Finanzas', 1, 1),
    ('DEP005', 'Marketing', 1, 1);

-- Insertar registros en la tabla usuarios
INSERT INTO usuarios (usuario, primerNombre, segundoNombre, primerApellido, segundoApellido, email, idDepartamento, idCargo)
VALUES 
    ('usuario1', 'Juan', 'Carlos', 'Pérez', 'Gómez', 'juan.carlos@example.com', 1, 1),
    ('usuario2', 'María', NULL, 'González', 'López', 'maria.gonzalez@example.com', 2, 2),
    ('usuario3', 'Pedro', 'Antonio', 'Martínez', 'Díaz', 'pedro.antonio@example.com', 3, 3),
    ('usuario4', 'Ana', NULL, 'Sánchez', 'Rodríguez', 'ana.sanchez@example.com', 4, 4),
    ('usuario5', 'Luis', 'Miguel', 'García', 'Fernández', 'luis.miguel@example.com', 5, 5);


SELECT * FROM dbo.cargos;
SELECT * FROM dbo.departamentos;
SELECT * FROM dbo.usuarios;