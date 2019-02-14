declare @id nvarchar(128)
select @id=id
from AspNetUsers
where UserName='Jose'

insert into AspNetUserRoles
([UserId],[RoleId]) values (@id, 2)