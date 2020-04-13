create procedure sp_login

@Usuario varchar(15), @Pass varchar(15)

as

select id,Usuario,rol
from usuarios where Usuario = @Usuario and Pass=@Pass