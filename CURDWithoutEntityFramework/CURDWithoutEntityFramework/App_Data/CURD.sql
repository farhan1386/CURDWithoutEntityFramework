CREATE TABLE [dbo].[Employee](  
    [Id] [int] IDENTITY(1,1) NOT NULL,  
    [FirstName] [nvarchar](50) NULL,  
    [LastName] [nvarchar](50) NULL,  
    [Gender] [char](10) NULL,  
    [Age] [int] NULL,  
    [Position] [nvarchar](50) NULL,  
    [Office] [nvarchar](50) NULL,  
    [Salary] [int] NULL,  
 CONSTRAINT [PK__Employee__3214EC07BA0DD227] PRIMARY KEY CLUSTERED   
(  
    [Id] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  
  
GO  
  
Create procedure [dbo].[spGetEmployees]  
as   
begin  
SELECT* FROM Employee  
end  
  
create procedure spInserNewEmployee
(  
@FirstName nvarchar(50),  
@LastName nvarchar(50),  
@Gender char(10),  
@Age int,  
@Position nvarchar(50),  
@Office nvarchar(50),  
@Salary int  
)  
as   
begin  
    insert into [dbo].[Employee](FirstName,LastName,Gender,Age,Position,Office,Salary)  
    values(@FirstName,@LastName,@Gender,@Age,@Position,@Office,@Salary)  
end 
  
  
  
Create procedure [dbo].[spUpdateRecord]  
(  
@Id int,  
@FirstName nvarchar(50),  
@LastName nvarchar(50),  
@Gender char(10),  
@Age int,  
@Position nvarchar(50),  
@Office nvarchar(50),  
@Salary int  
)  
as  
begin  
update Employee  
set FirstName=@FirstName,LastName=@LastName,Gender=@Gender,Age=@Age,  
Position=@Position,Office=@Position,  
Salary=@Salary where Id=@Id  
end  
  
Create procedure [dbo].[spDeleteRecord]  
(  
@Id int  
)  
as  
begin  
    delete from Employee where Id=@Id  
end  