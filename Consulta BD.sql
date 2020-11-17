

USE COVID_19

CREATE TABLE PACIENTE(
	id int NOT NULL,
	nome varchar(200),
	cpf char(11),
	cidade varchar (100),
	estado varchar (50),
	sexo char (1),
	estado_civil varchar (50),
	comorbidade int NOT NULL,
	data_registro datetime
	CONSTRAINT PK_Paciente PRIMARY KEY (id)
)

CREATE TABLE LOGINS(
	ID INT NOT NULL IDENTITY (1,1),
	USUARIO VARCHAR(150),
	SENHA VARCHAR(20),
	GRUPO VARCHAR(150),
	CONSTRAINT PK_Login PRIMARY KEY(ID)
)

INSERT INTO LOGINS(USUARIO,SENHA,GRUPO) VALUES('nunes','123','administrador')

SELECT * FROM Paciente