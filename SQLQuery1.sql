USE TestDem1
create table Roles(
RoleId int primary key identity(1,1),
RoleName varchar(50));

create table Users(
UserId int primary key identity(1,1),
RoleId int foreign key references Roles(RoleId),
FirstName varchar(50),
SecondName varchar(50),
LastName varchar(50),
Login varchar(50),
Password varchar (50));

create table PVZ(
PVZId int primary key identity(1,1),
PVZName varchar(100));

create table ProductName(
ProductNameId int primary key identity(1,1),
ProductType varchar(50));

create table Unit(
UnitId int primary key identity(1,1),
UnitName varchar(50));

create table Importer(
ImporterId int primary key identity(1,1),
ImporterName varchar(50));

create table Creater(
CreaterId int primary key identity(1,1),
CreaterName varchar(50));

create table Category(
CategoryId int primary key identity(1,1),
CategoryName varchar(50));

create table Products(
ProductsId varchar(50) primary key,
ProductNameId int foreign key references ProductName(ProductNameId),
UnitId int foreign key references Unit(UnitId),
Price decimal(10,2),
ImporterId int foreign key references Importer(ImporterId),
CreaterId int foreign key references Creater(CreaterId),
CategoryId int foreign key references Category(CategoryId),
Sale int,
Quantity int,
Info varchar(100),
Image varchar(50));

create table StatusName(
StatusNameId int primary key identity(1,1),
StatusType varchar(50));

create table Orders (
OrdersId int primary key identity(1,1),
DateOrder Date,
DateDevilery Date,
PVZId int foreign key references PVZ(PVZId),
UserId int foreign key references Users(UserId),
Code int,
StatusNameId int foreign key references StatusName(StatusNameId));

create table DetailOrders(
DetailOrdersId int primary key identity(1,1),
OrdersId int foreign key references Orders(OrdersId),
ProductsId varchar(50) foreign key references Products(ProductsId),
Quantity int);
