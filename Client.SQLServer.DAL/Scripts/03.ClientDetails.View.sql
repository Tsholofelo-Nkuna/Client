create or alter view ClientDetailsView
as select c.Gender, c.FirstName, c.LastName, c.ContactNumber, c.UniqueId as ClientUniqueId, a.UniqueId as AddressUniqueId, a.Description as AddressDescription from Client c
left join Address a on c.UniqueId = a.ClientUniqueId

