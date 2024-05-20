use ClientDb;

create table Client(
UniqueId bigint Identity(1,1) Primary Key, 
LastName nvarchar(128),
FirstName nvarchar(128),
Gender int,
ContactNumber nvarchar(128),
CreatedOn DateTime not null);

create table Address(
UniqueId bigint Identity(1,1) Primary Key,
Description nvarchar(128),
ClientUniqueId bigint Foreign Key References Client(UniqueId),
CreatedON DateTime not null
)
