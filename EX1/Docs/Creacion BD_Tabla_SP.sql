--=============================================================CREACION DB====================================================================
CREATE DATABASE [EX1DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EX1DB', FILENAME = N'C:\Users\Public\Documents\EX1DB.mdf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EX1DB_log', FILENAME = N'C:\Users\Public\Documents\EX1DB_log.ldf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
GO

--============================================================CREACION TABLA==================================================================
USE EX1DB
GO
CREATE TABLE [User] (
    id int IDENTITY(1,1) PRIMARY KEY,
    nombre varchar(20) NOT NULL,
	apellido varchar(20) NOT NULL,
	email varchar(70) NOT NULL,
    password varchar(50) NOT NULL,
);

--======================================================CREACION DE STORED PROCEDURE===========================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Marcos Fernandez>
-- Create date: <23/05/2020>
-- Description:	<Insert Tabla User>
-- =============================================
CREATE PROCEDURE USER_INS
	-- Add the parameters for the stored procedure here
	@NOMBRE varchar(20), @APELLIDO varchar(20), @EMAIL varchar(70), @PASSWORD varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>

	INSERT INTO [User] (nombre,apellido,email,password) 
	VALUES (@NOMBRE,@APELLIDO,@EMAIL,@PASSWORD)
END
GO

-- =============================================
-- Author:		<Marcos Fernandez>
-- Create date: <23/05/2020>
-- Description:	<Update Tabla User>
-- =============================================
CREATE PROCEDURE USER_UPD
	-- Add the parameters for the stored procedure here
	@ID int, @NOMBRE varchar(20), @APELLIDO varchar(20), @EMAIL varchar(70), @PASSWORD varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>

	UPDATE [User] 
	SET nombre=@NOMBRE,apellido=@APELLIDO,email=@EMAIL,password=@PASSWORD
	WHERE id = @ID
END
GO

-- =============================================
-- Author:		<Marcos Fernandez>
-- Create date: <23/05/2020>
-- Description:	<Delete Tabla User>
-- =============================================
CREATE PROCEDURE USER_DEL
	-- Add the parameters for the stored procedure here
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>

	DELETE FROM [User] 
	WHERE id = @ID
END
GO