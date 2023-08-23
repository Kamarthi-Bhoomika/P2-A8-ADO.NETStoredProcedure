create database OrderDb
use OrderDb

create table Customers
(CustomerId int primary key,
FirstName nvarchar(50),
LastName nvarchar(50))

insert into Customers values(202395,'Bhoomika','Kamarthi')
insert into Customers values(202396,'Sam','C')
insert into Customers values(202397,'Arsh','Sharma')


create table Orders
(OrderId int primary key identity,
CustomerId int foreign key References Customers,
OrderDate datetime default current_timestamp,
TotalAmount decimal)

create proc PlaceOrder
@customerid int,
@totalamount decimal
as
insert into Orders (CustomerId,TotalAmount) values
(@customerid,@totalamount)
update Orders set TotalAmount=o.sumtotal from(select Sum(TotalAmount) as sumtotal from Orders where CustomerId=@customerid) o where CustomerId=@customerid

drop proc PlaceOrder

exec PlaceOrder 202395,50000
exec PlaceOrder 202395,2300


select * from Customers
select * from Orders
drop table orders
