create table users
(
	userID int PRIMARY KEY IDENTITY,
	uName varchar(50),
	uUsername varchar(50),
	uPass varchar(50),
	uPhoneNumber varchar(50),
	uImage image
)