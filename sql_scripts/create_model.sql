use master
go
SET QUOTED_IDENTIFIER ON
GO

-- create login
if exists(select * from sys.syslogins where name = 'FeedbackManager')
begin
	drop login FeedbackManager
end
create login FeedbackManager with password = '@fGm1ND1#'
go

-- in case someone uses the DB
--EXEC sp_who2
--kill 51
-- create database
if db_id('feedback_manager') is not null
begin
	drop database feedback_manager
end
create database feedback_manager
go

-- create tables
use feedback_manager
go

if object_id('FM_Role') is not null
begin
	drop table FM_Role
end
create table FM_Role
(
id int not null,
create_date date not null DEFAULT getdate(),
update_date date null,	
name nvarchar(50) not null
)
alter table FM_Role
add constraint PK_fm_role
PRIMARY KEY (id)
go

if object_id('FM_User') is not null
begin
	drop table FM_User
end
create table FM_User
(
	id int identity(1,1) not null,
    create_date date not null DEFAULT getdate(),
	update_date date null,		
	userlogin nvarchar(20) not null,
	userpassword nvarchar(20) not null,
	name nvarchar(200) not null,
	surname nvarchar(200) not null,
	email nvarchar(200) not null,
	fm_role_id int not null
)
alter table FM_User
add constraint PK_fm_user
PRIMARY KEY (id)

ALTER TABLE FM_User
ADD CONSTRAINT FK_fm_user_fm_role
FOREIGN KEY (fm_role_id) REFERENCES FM_Role(id)
go


if OBJECT_ID('FM_Game') is not null
begin
	drop table FM_Game
end
create table FM_Game
(
id int identity(1,1) not null,
create_date date not null DEFAULT getdate(),
update_date date null,	
name nvarchar(200) not null
)
alter table FM_Game
add constraint PK_fm_game
PRIMARY KEY (id)
go

if OBJECT_ID('FM_Game_Session') is not null
begin
	drop table FM_Game_Session
end
create table FM_Game_Session
(
id int identity(1,1) not null,
created_date date not null DEFAULT getdate(),
update_date date null,	
end_date date null,
fm_game_id int not null,
game_session_id uniqueidentifier not null DEFAULT newid()
)
alter table FM_Game_Session
add constraint PK_fm_game_session
PRIMARY KEY (id)

ALTER TABLE FM_Game_Session
ADD CONSTRAINT FK_fm_game_session_fm_game
FOREIGN KEY (fm_game_id) REFERENCES FM_Game(id)

go

if OBJECT_ID('FM_Feedback') is not null
begin
	drop table FM_Feedback
end
create table FM_Feedback
(
id int identity(1,1) not null,
created_date date not null DEFAULT getdate(),
update_date date null,	
rating int not null,
comment nvarchar(500) null,
fm_user_id int not null,
fm_game_session_id int not null
)
alter table FM_Feedback
add constraint PK_fm_feedback
PRIMARY KEY (id)

ALTER TABLE FM_Feedback
ADD CONSTRAINT FK_fm_feedback_fm_user
FOREIGN KEY (fm_user_id) REFERENCES FM_User(id)

ALTER TABLE FM_Feedback
ADD CONSTRAINT FK_fm_feedback_fm_game_session
FOREIGN KEY (fm_game_session_id) REFERENCES FM_Game_Session(id)

ALTER TABLE FM_Feedback
ADD CONSTRAINT UC_fm_user_fm_game_session UNIQUE (fm_user_id,fm_game_session_id)
go

create user FeedbackManager for login FeedbackManager
GRANT SELECT on FM_Role to FeedbackManager
GRANT SELECT on FM_User to FeedbackManager
GRANT SELECT on FM_Game to FeedbackManager
GRANT SELECT on FM_Game_Session to FeedbackManager
GRANT SELECT, INSERT, UPDATE, DELETE on FM_Feedback to FeedbackManager
go