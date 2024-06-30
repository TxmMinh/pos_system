create table tblDetails
(
	detailID int primary key identity,
	dMainID int,
	productID int,
	quantity int,
	price float,
	amount float,
	cost float
)