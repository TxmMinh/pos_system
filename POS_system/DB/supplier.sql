create table supplier 
(
	supID int primary key identity,
	supName varchar(150) not null,
	supEmail varchar(150) not null,
	supPhone varchar(50) not null
)