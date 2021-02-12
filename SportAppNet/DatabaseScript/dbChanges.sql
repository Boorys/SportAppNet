
create  table OpinionEntity(
Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
GeneralComment varchar(max) null,
Punctuality int null,
Skill int null
)

GO

alter table OpinionEntity add UserId int not null
GO

create  table UserEntity(
Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Email varchar(100) not null,
FirstName varchar(50) not null,
LastName varchar(50) not null,
role varchar(50) not null,
)
GO
alter table [dbo].[UserEntity] add Password varchar(64) not null
GO

alter table OpinionEntity
add constraint OpinionEntity_User_FK FOREIGN KEY ( UserId ) references UserEntity(Id)
GO

create table UserMainTypSport(
UserId int,
MainTypSportId int
)
GO
alter table UserMainTypSport
add constraint UserMainTypSport_User_FK FOREIGN KEY ( UserId ) references UserEntity(Id)
GO

create table MainTypSportEntity(Id int Identity(1,1) PRIMARY KEY,
MainNameOfSport varchar(200)
)
GO

alter table UserMainTypSport
add constraint UserMainTypSport_MainTypSportEntity_FK FOREIGN KEY ( UserId ) references MainTypSportEntity(Id)
GO
create table DisciplineEntity(
Id int primary key identity(1,1),
DisciplineName varchar(100),
AccurateName varchar(100),
MainTypSportId int
)
GO
alter table DisciplineEntity
add constraint DisciplineEntity_MainTypSportEntity_FK FOREIGN KEY ( MainTypSportId ) references MainTypSportEntity(Id)
GO
alter table [dbo].[UserEntity] add IsActive bit null
GO
  insert into [dbo].[MainTypSportEntity](MainNameOfSport)
  values('Tenis')
  GO
  insert into [dbo].[MainTypSportEntity](MainNameOfSport)
  values('Kolarstwo')
  GO
   insert into [dbo].[MainTypSportEntity](MainNameOfSport)
  values('Piesze wycieczki')
  GO
     insert into [dbo].[MainTypSportEntity](MainNameOfSport)
  values('Żeglarstwo')
  GO
     insert into [dbo].[MainTypSportEntity](MainNameOfSport)
  values('Bieganie')
  GO
   alter table  DisciplineEntity drop column AccurateName
GO
    insert into [dbo].[DisciplineEntity](DisciplineName,MainTypSportId)
  values('10 km',5)
  GO
  insert into [dbo].[DisciplineEntity](DisciplineName,MainTypSportId)
  values('5 km',5)
   GO
   insert into [dbo].[DisciplineEntity](DisciplineName,MainTypSportId)
  values('15 km',5)
  GO

   alter table [dbo].[UserEntity] add UserId varchar(50) not null;

   GO
   create  table MainTypSportLocation(
LocationId INT NOT NULL ,
MainTypSportId INT not null,
)
GO
alter table MainTypSportLocation
add constraint MainTypSportLocation_MainTypSport_Entity_FK FOREIGN KEY ( MainTypSportId ) references MainTypSportEntity(Id)
GO

CREATE TABLE [dbo].[LocationEntity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[City] [varchar](max) NOT NULL,
	[Country] [varchar](max) NOT NULL,
	[Department] [varchar](max) NOT NULL,
	[Lang] [decimal](10, 10) NOT NULL,
	[Lat] [decimal](10, 10) NOT NULL,
	[LocationId] [int] NOT NULL,
	[Street] [varchar](max) NOT NULL,
	[StreetNumber] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


alter table MainTypSportLocation
add constraint MainTypSportLocation_Location_Entity_FK FOREIGN KEY ( LocationId ) references LocationEntity(Id)
GO