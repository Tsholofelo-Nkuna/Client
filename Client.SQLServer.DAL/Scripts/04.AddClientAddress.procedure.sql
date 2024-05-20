create or alter procedure AddClientAddress @clientId bigint, @addressDescription nvarchar(128)
as begin
	if(exists(select UniqueId from Client where UniqueId = @clientId ))
	begin
	insert into Address(Description, ClientUniqueId, CreatedON)
	values (@addressDescription, @clientId, CURRENT_TIMESTAMP)
	end
end

