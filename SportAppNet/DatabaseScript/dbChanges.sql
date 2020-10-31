
create table OpinionEntity(
Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
GeneralComment varchar(max) null,
Punctuality int null,
Skill int null
)

alter table OpinionEntity add UserId int not null

create table UserEntity(
Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Email varchar(100) not null,
FirstName varchar(50) not null,
LastName varchar(50) not null,
role varchar(50) not null,
)
alter table [dbo].[UserEntity] add Password varchar(64) not null


alter table OpinionEntity
add constraint OpinionEntity_User_FK FOREIGN KEY ( UserId ) references UserEntity(Id)


create table UserMainTypSport(
UserId int,
MainTypSportId int
)

alter table UserMainTypSport
add constraint UserMainTypSport_User_FK FOREIGN KEY ( UserId ) references UserEntity(Id)


create table MainTypSportEntity(Id int  PRIMARY KEY,
MainNameOfSport varchar(200)
)


alter table UserMainTypSport
add constraint UserMainTypSport_MainTypSportEntity_FK FOREIGN KEY ( UserId ) references MainTypSportEntity(Id)

create table DisciplineEntity(
Id int primary key,
DisciplineName varchar(100),
AccurateName varchar(100),
MainTypSportId int
)

alter table DisciplineEntity
add constraint DisciplineEntity_MainTypSportEntity_FK FOREIGN KEY ( MainTypSportId ) references MainTypSportEntity(Id)

alter table [dbo].[UserEntity] add IsActive bit null