create or alter procedure CreateOrEditClient
@clientId bigint, @firstName nvarchar(128),
@lastName nvarchar(128), @gender int,
@contact nvarchar(128)
as
begin 
	if(exists(select UniqueId from Client where UniqueId = @clientId))
	begin
	 update c
	 set c.ContactNumber = @contact, c.LastName = @lastName,
	 c.Gender = @gender, c.FirstName = @firstName
	 from Client c where c.UniqueId = @clientId
	end
	else
	begin
	insert into Client(ContactNumber, FirstName, LastName, Gender, CreatedOn) values (@contact, @firstName, @lastName, @gender, CURRENT_TIMESTAMP);
	end
end