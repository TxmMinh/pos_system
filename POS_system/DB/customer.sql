create table customer 
(
	cusID int primary key identity,
	cusName varchar(150) not null,
	cusEmail varchar(150) not null,
	cusPhone varchar(50) not null
)

