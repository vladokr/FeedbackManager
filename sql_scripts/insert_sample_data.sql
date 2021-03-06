USE [feedback_manager]
GO
INSERT [dbo].[FM_Role] ([id], [create_date], [update_date], [name]) VALUES (1, CAST(0x0000A867012C5E77 AS DateTime), NULL, N'PLAYER')
GO
INSERT [dbo].[FM_Role] ([id], [create_date], [update_date], [name]) VALUES (2, CAST(0x0000A867012C66E9 AS DateTime), NULL, N'OPERATOR')
GO
SET IDENTITY_INSERT [dbo].[FM_User] ON 

GO
INSERT [dbo].[FM_User] ([id], [create_date], [update_date], [user_login], [user_password], [name], [surname], [email], [role_id]) VALUES (1, CAST(0x0000A867012C9D6E AS DateTime), NULL, N'vladokr', N'123456', N'Vlado', N'Kragujevski', N'vlado@gmail.com', 1)
GO
INSERT [dbo].[FM_User] ([id], [create_date], [update_date], [user_login], [user_password], [name], [surname], [email], [role_id]) VALUES (2, CAST(0x0000A867012D25E1 AS DateTime), NULL, N'Ubi-UserId', N'5678hygrd', N'Some', N'UbiUser', N'some@hotmail.com', 1)
GO
INSERT [dbo].[FM_User] ([id], [create_date], [update_date], [user_login], [user_password], [name], [surname], [email], [role_id]) VALUES (3, CAST(0x0000A867012D5B8D AS DateTime), NULL, N'Ubi-Oper', N'12oper89', N'Some', N'UbiOper', N'oper@yahoo.com', 2)
GO
SET IDENTITY_INSERT [dbo].[FM_User] OFF
GO
INSERT [dbo].[FM_Game] ([id], [create_date], [update_date], [name]) VALUES (1, CAST(0x0000A867012DDBC1 AS DateTime), NULL, N'Assassin''s Creed Origins')
GO
INSERT [dbo].[FM_Game] ([id], [create_date], [update_date], [name]) VALUES (2, CAST(0x0000A867012E2891 AS DateTime), NULL, N'Atomega')
GO
INSERT [dbo].[FM_Game] ([id], [create_date], [update_date], [name]) VALUES (3, CAST(0x0000A867012E35B2 AS DateTime), NULL, N'For Honor')
GO
INSERT [dbo].[FM_Game] ([id], [create_date], [update_date], [name]) VALUES (4, CAST(0x0000A867012E463C AS DateTime), NULL, N'Mario + Rabbids Kingdom Battle')
GO
INSERT [dbo].[FM_Game] ([id], [create_date], [update_date], [name]) VALUES (5, CAST(0x0000A867012F05C7 AS DateTime), NULL, N'Star Trek: Bridge Crew')
GO
INSERT [dbo].[FM_Game] ([id], [create_date], [update_date], [name]) VALUES (6, CAST(0x0000A867012F145A AS DateTime), NULL, N'Eagle Flight')
GO
INSERT [dbo].[FM_Game] ([id], [create_date], [update_date], [name]) VALUES (7, CAST(0x0000A867012F20D7 AS DateTime), NULL, N'Far Cry Primal')
GO
INSERT [dbo].[FM_Game] ([id], [create_date], [update_date], [name]) VALUES (8, CAST(0x0000A867012F2B9D AS DateTime), NULL, N'Just Dance 2017')
GO
INSERT [dbo].[FM_Game] ([id], [create_date], [update_date], [name]) VALUES (9, CAST(0x0000A867012F3589 AS DateTime), NULL, N'Steep')
GO
INSERT [dbo].[FM_Game] ([id], [create_date], [update_date], [name]) VALUES (10, CAST(0x0000A867012F5233 AS DateTime), NULL, N'Anno 2205')
GO
SET IDENTITY_INSERT [dbo].[FM_Game_Session] ON 

GO
INSERT [dbo].[FM_Game_Session] ([id], [create_date], [update_date], [start_date], [end_date], [game_id], [session_identifier]) VALUES (1, CAST(0x0000A86701307C4E AS DateTime), NULL, CAST(0x0000A86700FF0C0E AS DateTime), CAST(0x0000A867010F86CE AS DateTime), 1, N'8a537c50-8a70-46f1-bf94-500ccc30c6d9')
GO
INSERT [dbo].[FM_Game_Session] ([id], [create_date], [update_date], [start_date], [end_date], [game_id], [session_identifier]) VALUES (2, CAST(0x0000A8670130B775 AS DateTime), NULL, CAST(0x0000A867010F86CE AS DateTime), CAST(0x0000A8670120018E AS DateTime), 4, N'ba83d4db-a855-4ccb-9673-6e56c6e26bba')
GO
INSERT [dbo].[FM_Game_Session] ([id], [create_date], [update_date], [start_date], [end_date], [game_id], [session_identifier]) VALUES (3, CAST(0x0000A867013124F6 AS DateTime), NULL, CAST(0x0000A8670120AA36 AS DateTime), CAST(0x0000A86701225016 AS DateTime), 10, N'a2f4394c-86d5-4554-87ac-7bcbbb68e7d8')
GO
SET IDENTITY_INSERT [dbo].[FM_Game_Session] OFF
GO
