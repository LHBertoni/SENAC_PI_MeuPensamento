CREATE DATABASE MeuPensamento

GO

USE MeuPensamento

GO

CREATE TABLE USUARIO 
(
ID INT IDENTITY PRIMARY KEY,
EMAIL VARCHAR(300) NOT NULL,
SENHA VARCHAR(50)
)

CREATE TABLE PENSAMENTO (
ID BIGINT IDENTITY PRIMARY KEY,
IDUSUARIO INT NOT NULL FOREIGN KEY REFERENCES USUARIO(ID),
PENSAMENTO	VARCHAR(500) NOT NULL,
SITUACAO	VARCHAR(500) NOT NULL,
RAIVA		INT NOT NULL,
ANGUSTIA	INT NOT NULL,
TRISTEZA	INT NOT NULL,
ANSIEDADE	INT NOT NULL,
SENTIMENTO	VARCHAR(500),
DATAHORA	DATETIME NOT NULL DEFAULT GETDATE(),
ATIVO		CHAR(1) DEFAULT 'S'
)

CREATE TABLE REACOES (
ID BIGINT IDENTITY PRIMARY KEY,
IDPENSAMENTO BIGINT NOT NULL FOREIGN KEY REFERENCES PENSAMENTO(ID),
REACAO	VARCHAR(50) NOT NULL,
)

CREATE TABLE CARTAOENFRENTAMENTO (
ID	BIGINT IDENTITY PRIMARY KEY,
IDUSUARIO	INT NOT NULL FOREIGN KEY REFERENCES USUARIO(ID),
MENSAGEM	VARCHAR(500) NOT NULL,
)

GO

INSERT INTO USUARIO (EMAIL, SENHA)
SELECT 'email@email.com', 'E10ADC3949BA59ABBE56E057F20F883E'

DECLARE @IDUSUARIO INT

SELECT @IDUSUARIO = @@IDENTITY

INSERT INTO CARTAOENFRENTAMENTO (IDUSUARIO, MENSAGEM)
VALUES
(@IDUSUARIO, 'Não devo me incomodar com a opinião das outras pessoas...'),
(@IDUSUARIO, 'Sou importante!')

GO

