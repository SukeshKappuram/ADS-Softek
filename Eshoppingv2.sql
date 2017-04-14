use [aspnet-EshoppingV2.0]

create Proc insrtCategory
			@Name nvarchar(20),
           @Description nvarchar(20)
As
INSERT INTO [dbo].[Categories]
           ([Name]
           ,[Description])
     VALUES
           (@Name,
           @Description
		   )
select @@IDENTITY

create Proc updtCategory
			@Name nvarchar(20),
           @Description nvarchar(20),
		   @Id int
As
UPDATE [dbo].[Categories]
   SET [Name] = @Name
      ,[Description] = @Description
 WHERE Id=@Id
select @@ROWCOUNT


create Proc dltCategory
		   @Id int
As
DELETE FROM [dbo].[Categories]
      WHERE id=@Id

select @@ROWCOUNT


create Proc CategorySelect
As
SELECT [Id]
      ,[Name]
      ,[Description]
  FROM [dbo].[Categories]


