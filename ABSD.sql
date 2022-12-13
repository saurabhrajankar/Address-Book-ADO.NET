USE Ado_AddressBook
select * from AddressBookTable

--UC3--
create procedure InsertContact
(
@FirstName varchar(255),
@LastName varchar(255),
@Address varchar(255),
@City varchar(255),
@State varchar(255),
@Zip int,
@MobNo int,
@Email varchar(255)
)
As
Begin
Insert Into AddressBookTable values(@FirstName,@LastName,@Address,@City,@State,@Zip,@MobNo,@Email)
End

--UC5--
create procedure DeleteContact
(
@FirstName varchar(255)
)
As
Begin
Delete From AddressBookTable where FirstName=@FirstName
END

--UC6--
create procedure RetrievePersonByCity
(
@City varchar(255)
)
As
Begin
Select * From AddressBookTable where City=@City
End