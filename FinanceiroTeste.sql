create database FINANCEIRO;
GO

USE FINANCEIRO;
GO

--CRIANDO TABELAS



CREATE TABLE CATEGORIA (
   ID_CATEGORIA INT PRIMARY KEY NOT NULL IDENTITY,
   NOME VARCHAR(50) NOT NULL,
   LIMITE MONEY NOT NULL,
   
);
GO

ALTER TABLE CATEGORIA ADD VALOR_ATUAL MONEY NULL;
GO

 select * from movimento;
go


 select * from categoria;
go

delete from categoria where id_categoria in (40)
go

CREATE TABLE MOVIMENTO (
  ID_MOVIMENTO INT PRIMARY KEY NOT NULL IDENTITY,
  DESCRICAO VARCHAR(50) NOT NULL,
  VALOR MONEY NOT NULL,
  DATA_CADASTRO DATE NOT NULL,
  PARCELA INT,
  VALOR_TOTAL AS (VALOR * PARCELA),
  ID_CATEGORIA INT FOREIGN KEY REFERENCES CATEGORIA(ID_CATEGORIA)
  );
GO

select * from MOVIMENTO

delete from MOVIMENTO where id_categoria in (38)
go

CREATE TABLE MOVIMENTO_RECORRENTE(
  ID_RECORRENTE INT PRIMARY KEY NOT NULL identity,
  NOME VARCHAR(30),
  VALOR MONEY,
  RECORRENCIA VARCHAR(20),
  ID_CATEGORIA INT FOREIGN KEY REFERENCES CATEGORIA(ID_CATEGORIA)
);
GO

CREATE TABLE SALDO (
TOTAL MONEY NULL,
)
GO

INSERT INTO SALDO VALUES(  
0.0);
GO

UPDATE SALDO SET TOTAL=TOTAL+0.0
GO

SELECT * FROM SALDO
GO

delete from saldo where total = 1200.00

/*
--Inserindo alguns registros para teste
INSERT into CATEGORIA values ('Casa', 200.00);
insert into CATEGORIA VALUES ('Carro', 230.00);
INSERT INTO CATEGORIA VALUES ('Limpeza', 100.00);
insert into CATEGORIA VAlUES ('Cachorros',50.00);
insert into CATEGORIA values ('Agua', 60.00);
GO

--Inserindo alguns registros para teste
INSERT INTO MOVIMENTO VALUES ('Cera ',10.00,'2012-02-10', 1,2);
insert into MOVIMENTO VAlUES ('Racao',49.99, '2011-10-12', 3,4);
INSERT INTO MOVIMENTO VALUES ('Coca Cola', 3.00, '2011-12-02',3,3);
insert into MOVIMENTO values ('Detergente', 2.00,'2011-11-10', 1, 2);

INSERT INTO MOVIMENTO_RECORRENTE VALUES ('Fatura', -80.00, 'Mensal', 1);
INSERT INTO MOVIMENTO_RECORRENTE VALUES ('Compras', -90.00, 'Semanal',1);
INSERT INTO MOVIMENTO_RECORRENTE VALUES ('Conta de agua', -50.00, 'Mensal', 4); 
GO

SELECT M.ID_MOVIMENTO,
       M.DESCRICAO,
       M.VALOR,
       M.DATA_CADASTRO,
       M.PARCELA,
       C.NOME as [CATEGORIA]      
FROM MOVIMENTO M INNER JOIN CATEGORIA C
 on
     M.ID_CATEGORIA = C.ID_CATEGORIA
 WHERE M.DESCRICAO LIKE 'C%'
 go
 
 SELECT M.ID_MOVIMENTO,
       M.DESCRICAO,
       M.VALOR,
       M.DATA_CADASTRO,
       M.PARCELA,
       C.NOME as [CATEGORIA]      
 FROM MOVIMENTO M INNER JOIN CATEGORIA C
 on
     M.ID_CATEGORIA = C.ID_CATEGORIA
 WHERE M.DATA_CADASTRO BETWEEN '2012-10-02' 
 AND '2012-12-02'
 go
 
 SELECT M.ID_MOVIMENTO,
       M.DESCRICAO,
       M.VALOR,
       M.DATA_CADASTRO,
       M.PARCELA,
       C.NOME as [CATEGORIA]      
 FROM MOVIMENTO M INNER JOIN CATEGORIA C
 on
     M.ID_CATEGORIA = C.ID_CATEGORIA
 WHERE C.NOME like 'C%';
 GO
 
select * from CATEGORIA where limite = (select MAX(limite) from CATEGORIA);
 GO
 
select * from MOVIMENTO where VALOR = (select MAX(valor) from MOVIMENTO);
GO

select * from CATEGORIA where limite = (select Min(limite) from CATEGORIA);
GO
 
select * from MOVIMENTO where VALOR = (select Min(valor) from MOVIMENTO);

select * from MOVIMENTO where day(DATA_CADASTRO) = 2;

select * from MOVIMENTO where year(DATA_CADASTRO) = 2011;

select AVG(valor) from MOVIMENTO;

select AVG(valor) from MOVIMENTO_RECORRENTE;

select CATEGORIA.NOME,
	   --CATEGORIA.LIMITE,
	   SUM(CATEGORIA.LIMITE - MOVIMENTO.VALOR)
 from CATEGORIA inner join MOVIMENTO
 on CATEGORIA.ID_CATEGORIA = MOVIMENTO.ID_CATEGORIA
 group by CATEGORIA.nome;
GO

*/

select * from CATEGORIA;
go

INSERT INTO CATEGORIA VALUES 
('Sem Categoria', 0);