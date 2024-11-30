create database myfinance;
use myfinance;

create table PLANOCONTA(
	id int not null primary key identity(1,1),
	nome varchar(50) not null,
	tipo char(1) not null,
);

create table TRANSACAO(
	id int not null primary key identity(1,1),
	data datetime not null,
	valor decimal(9,2) not null,
	historico varchar(100),
	tipo char(1) not null,
	planocontaid int not null,
	foreign key (planocontaid) references PLANOCONTA(id)
);