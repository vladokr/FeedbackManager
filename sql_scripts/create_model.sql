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
create_date datetime not null DEFAULT getdate(),
update_date datetime null,	
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
    create_date datetime not null DEFAULT getdate(),
	update_date datetime null,		
	user_login nvarchar(20) not null,
	user_password nvarchar(20) not null,
	name nvarchar(200) not null,
	surname nvarchar(200) not null,
	email nvarchar(200) not null,
	role_id int not null
)
alter table FM_User
add constraint PK_fm_user
PRIMARY KEY (id)

ALTER TABLE FM_User
ADD CONSTRAINT FK_fm_user_fm_role
FOREIGN KEY (role_id) REFERENCES FM_Role(id)
go


if OBJECT_ID('FM_Game') is not null
begin
	drop table FM_Game
end
create table FM_Game
(
id int not null,
create_date datetime not null DEFAULT getdate(),
update_date datetime null,	
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
create_date datetime not null DEFAULT getdate(),
update_date datetime null,	
[start_date] datetime null,
end_date datetime null,
game_id int not null,
session_identifier uniqueidentifier not null DEFAULT newid()
)
alter table FM_Game_Session
add constraint PK_fm_game_session
PRIMARY KEY (id)

ALTER TABLE FM_Game_Session
ADD CONSTRAINT FK_fm_game_session_fm_game
FOREIGN KEY (game_id) REFERENCES FM_Game(id)

go

if OBJECT_ID('FM_Feedback') is not null
begin
	drop table FM_Feedback
end
create table FM_Feedback
(
id int identity(1,1) not null,
create_date datetime not null DEFAULT getdate(),
update_date datetime null,	
rating int not null,
comment nvarchar(500) null,
[user_id] int not null,
game_session_id int not null
)
alter table FM_Feedback
add constraint PK_fm_feedback
PRIMARY KEY (id)

ALTER TABLE FM_Feedback
ADD CONSTRAINT FK_fm_feedback_fm_user
FOREIGN KEY ([user_id]) REFERENCES FM_User(id)

ALTER TABLE FM_Feedback
ADD CONSTRAINT FK_fm_feedback_fm_game_session
FOREIGN KEY (game_session_id) REFERENCES FM_Game_Session(id)

ALTER TABLE FM_Feedback
ADD CONSTRAINT UC_fm_user_fm_game_session UNIQUE ([user_id],game_session_id)
go

if OBJECT_ID('sp_insert_feedback') is not null
begin
	drop procedure sp_insert_feedback
end
go
CREATE PROCEDURE sp_insert_feedback 
@rating int,
@user_login nvarchar(20),
@session_identifier uniqueidentifier,
@comment nvarchar(500) = null
AS
declare @user_id int
declare @game_session_id int
BEGIN
	select @user_id = id from FM_User where user_login = @user_login
	select @game_session_id = id from FM_Game_Session where session_identifier = @session_identifier

	insert into FM_Feedback(rating, comment, [user_id], game_session_id)
	values(@rating, @comment, @user_id, @game_session_id)

END
GO

create user FeedbackManager for login FeedbackManager
GRANT SELECT on FM_Role to FeedbackManager
GRANT SELECT on FM_User to FeedbackManager
GRANT SELECT on FM_Game to FeedbackManager
GRANT SELECT on FM_Game_Session to FeedbackManager
GRANT SELECT, INSERT, UPDATE, DELETE on FM_Feedback to FeedbackManager
GRANT EXECUTE on sp_insert_feedback to FeedbackManager
go