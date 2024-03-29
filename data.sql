USE [University]
GO
SET IDENTITY_INSERT [dbo].[Faculties] ON 

INSERT [dbo].[Faculties] ([FacultyId], [FacultyName]) VALUES (1, N'IT')
INSERT [dbo].[Faculties] ([FacultyId], [FacultyName]) VALUES (2, N'Engineering')
INSERT [dbo].[Faculties] ([FacultyId], [FacultyName]) VALUES (3, N'Medicine')
INSERT [dbo].[Faculties] ([FacultyId], [FacultyName]) VALUES (4, NULL)
INSERT [dbo].[Faculties] ([FacultyId], [FacultyName]) VALUES (5, N'Fashion design')
SET IDENTITY_INSERT [dbo].[Faculties] OFF
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([DepartmentId], [DepartmentName], [FacultyId]) VALUES (1, N'IDS', 1)
INSERT [dbo].[Departments] ([DepartmentId], [DepartmentName], [FacultyId]) VALUES (2, N'CM', 1)
INSERT [dbo].[Departments] ([DepartmentId], [DepartmentName], [FacultyId]) VALUES (3, N'AI', 1)
INSERT [dbo].[Departments] ([DepartmentId], [DepartmentName], [FacultyId]) VALUES (4, N'Electrical', 2)
INSERT [dbo].[Departments] ([DepartmentId], [DepartmentName], [FacultyId]) VALUES (5, N'IDS', 2)
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [Name]) VALUES (1, N'Student')
INSERT [dbo].[Roles] ([RoleId], [Name]) VALUES (2, N'Lecturer')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [RoleId], [DepartmentId], [FacultyId]) VALUES (2, N'saman perera', 2, 3, 1)
INSERT [dbo].[Users] ([UserId], [UserName], [RoleId], [DepartmentId], [FacultyId]) VALUES (3, N'Amal', 1, 1, 2)
INSERT [dbo].[Users] ([UserId], [UserName], [RoleId], [DepartmentId], [FacultyId]) VALUES (4, N'srimaal', 1, 2, 1)
INSERT [dbo].[Users] ([UserId], [UserName], [RoleId], [DepartmentId], [FacultyId]) VALUES (5, N'sumana', 2, 4, 2)
INSERT [dbo].[Users] ([UserId], [UserName], [RoleId], [DepartmentId], [FacultyId]) VALUES (6, N'Raman', 2, 3, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
