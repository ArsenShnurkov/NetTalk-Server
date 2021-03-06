/****** Object:  ForeignKey [FK_TbFriend_TbUsers]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbFriend_TbUsers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbFriend]'))
ALTER TABLE [dbo].[TbFriend] DROP CONSTRAINT [FK_TbFriend_TbUsers]
GO
/****** Object:  ForeignKey [FK_TbFriend_TbUsers1]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbFriend_TbUsers1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbFriend]'))
ALTER TABLE [dbo].[TbFriend] DROP CONSTRAINT [FK_TbFriend_TbUsers1]
GO
/****** Object:  ForeignKey [FK_TbMessage_TbUsers]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbMessage_TbUsers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbMessage]'))
ALTER TABLE [dbo].[TbMessage] DROP CONSTRAINT [FK_TbMessage_TbUsers]
GO
/****** Object:  ForeignKey [FK_TbMessage_TbUsers1]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbMessage_TbUsers1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbMessage]'))
ALTER TABLE [dbo].[TbMessage] DROP CONSTRAINT [FK_TbMessage_TbUsers1]
GO
/****** Object:  ForeignKey [FK_TbUserStatus_TbUsers]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbUserStatus_TbUsers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbUserStatus]'))
ALTER TABLE [dbo].[TbUserStatus] DROP CONSTRAINT [FK_TbUserStatus_TbUsers]
GO
/****** Object:  ForeignKey [FK_TbVcard_TbUsers]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbVcard_TbUsers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbVcard]'))
ALTER TABLE [dbo].[TbVcard] DROP CONSTRAINT [FK_TbVcard_TbUsers]
GO
/****** Object:  View [dbo].[VwMessage]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VwMessage]'))
DROP VIEW [dbo].[VwMessage]
GO
/****** Object:  View [dbo].[VwMessageOffline]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VwMessageOffline]'))
DROP VIEW [dbo].[VwMessageOffline]
GO
/****** Object:  View [dbo].[VwUsers]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VwUsers]'))
DROP VIEW [dbo].[VwUsers]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DeleteUser]
GO
/****** Object:  View [dbo].[VwFriend]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VwFriend]'))
DROP VIEW [dbo].[VwFriend]
GO
/****** Object:  View [dbo].[VwLog]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VwLog]'))
DROP VIEW [dbo].[VwLog]
GO
/****** Object:  Table [dbo].[TbFriend]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbFriend]') AND type in (N'U'))
DROP TABLE [dbo].[TbFriend]
GO
/****** Object:  Table [dbo].[TbMessage]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbMessage]') AND type in (N'U'))
DROP TABLE [dbo].[TbMessage]
GO
/****** Object:  Table [dbo].[TbUserStatus]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbUserStatus]') AND type in (N'U'))
DROP TABLE [dbo].[TbUserStatus]
GO
/****** Object:  Table [dbo].[TbVcard]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbVcard]') AND type in (N'U'))
DROP TABLE [dbo].[TbVcard]
GO
/****** Object:  Table [dbo].[TbUsers]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbUsers]') AND type in (N'U'))
DROP TABLE [dbo].[TbUsers]
GO
/****** Object:  Table [dbo].[TbLogs]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbLogs]') AND type in (N'U'))
DROP TABLE [dbo].[TbLogs]
GO
/****** Object:  Table [dbo].[TbAlerts]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbAlerts]') AND type in (N'U'))
DROP TABLE [dbo].[TbAlerts]
GO
/****** Object:  Default [DF_TbFriend_GroupName]    Script Date: 04/21/2011 23:07:18 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_TbFriend_GroupName]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbFriend]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TbFriend_GroupName]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TbFriend] DROP CONSTRAINT [DF_TbFriend_GroupName]
END


End
GO
/****** Object:  Table [dbo].[TbAlerts]    Script Date: 04/21/2011 23:07:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbAlerts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TbAlerts](
	[AlertId] [uniqueidentifier] NOT NULL,
	[AlertText] [nvarchar](500) COLLATE Arabic_CI_AS NOT NULL,
	[AlertTime] [time](7) NOT NULL,
	[AlertHTML] [nvarchar](500) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_TbAlerts] PRIMARY KEY CLUSTERED 
(
	[AlertId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[TbLogs]    Script Date: 04/21/2011 23:07:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbLogs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TbLogs](
	[LogId] [uniqueidentifier] NOT NULL,
	[LogText] [nvarchar](max) COLLATE Arabic_CI_AS NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogSessionId] [varchar](10) COLLATE Arabic_CI_AS NULL,
	[LogUserId] [uniqueidentifier] NULL,
	[LogIP] [varchar](15) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_TbLogs] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'd59d565b-f899-11df-af9a-002643af3ca4', N'<error><info>Global.asax</info><main>Exception of type &#39;System.Web.HttpUnhandledException&#39; was thrown.</main><sub>You must specify a valid predicate for filtering the results.
Parameter name: predicate</sub></error>', CAST(0x00009E39011B9019 AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'f8e22c8f-f899-11df-af9a-002643af3ca4', N'<error><info>Global.asax</info><main>Exception of type &#39;System.Web.HttpUnhandledException&#39; was thrown.</main><sub>You must specify a valid predicate for filtering the results.
Parameter name: predicate</sub></error>', CAST(0x00009E39011BD55E AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'cef0fe42-f89a-11df-af9a-002643af3ca4', N'<error><info>Global.asax</info><main>Exception of type &#39;System.Web.HttpUnhandledException&#39; was thrown.</main><sub>&#39;a_0&#39; could not be resolved in the current scope or context. Make sure that all referenced variables are in scope, that required schemas are loaded, and that namespaces are referenced correctly. Near simple identifier, line 6, column 19.</sub></error>', CAST(0x00009E39011D7A39 AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6c470c5c-f89a-11df-af9a-002643af3ca4', N'<error><info>Global.asax</info><main>Exception of type &#39;System.Web.HttpUnhandledException&#39; was thrown.</main><sub>The specified parameter name &#39;@a_0&#39; is not valid. Parameter names must begin with a letter and can only contain letters, numbers, and underscores.
Parameter name: name</sub></error>', CAST(0x00009E39011CB83E AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'3299f3ba-f89a-11df-af9a-002643af3ca4', N'<error><info>Global.asax</info><main>Exception of type &#39;System.Web.HttpUnhandledException&#39; was thrown.</main><sub>The specified parameter name &#39;@0&#39; is not valid. Parameter names must begin with a letter and can only contain letters, numbers, and underscores.
Parameter name: name</sub></error>', CAST(0x00009E39011C46D8 AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'a20ca2fb-f89a-11df-af9a-002643af3ca4', N'<error><info>Global.asax</info><main>Exception of type &#39;System.Web.HttpUnhandledException&#39; was thrown.</main><sub>&#39;UserIsOnline&#39; is not a member of type &#39;NetTalkModel.TbUsers&#39; in the currently loaded schemas. Near simple identifier, line 6, column 4.</sub></error>', CAST(0x00009E39011D21F7 AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'bed9c66b-f89b-11df-af9a-002643af3ca4', N'<error><info>Global.asax</info><main>Exception of type &#39;System.Web.HttpUnhandledException&#39; was thrown.</main><sub>Exception has been thrown by the target of an invocation.</sub></error>', CAST(0x00009E39011F51EA AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5787e5e1-f89b-11df-af9a-002643af3ca4', N'<error><info>Global.asax</info><main>Exception of type &#39;System.Web.HttpUnhandledException&#39; was thrown.</main><sub>The type &#39;NetTalk.BLL.Users&#39; is ambiguous: it could come from assembly &#39;I:\Projects\Chat\IMServerSite\NetTalk.Web\bin\IMServerBLL.DLL&#39; or from assembly &#39;I:\Projects\Chat\IMServerSite\NetTalk.Web\bin\NetTalk.BLL.DLL&#39;. Please specify the assembly explicitly in the type name.</sub></error>', CAST(0x00009E39011E86C5 AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'51190678-f89d-11df-af9a-002643af3ca4', N'<error><info>Global.asax</info><main>Exception of type &#39;System.Web.HttpUnhandledException&#39; was thrown.</main><sub>Exception has been thrown by the target of an invocation.</sub></error>', CAST(0x00009E39012268C1 AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'072ac598-f89d-11df-af9a-002643af3ca4', N'<error><info>Global.asax</info><main>Exception of type &#39;System.Web.HttpUnhandledException&#39; was thrown.</main><sub>Exception has been thrown by the target of an invocation.</sub></error>', CAST(0x00009E390121D767 AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc90906-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6ef6" from="mahdi@127.0.0.1" type="result"><query xmlns="jabber:iq:roster" /></iq>', CAST(0x00009E0300F352B4 AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc90907-ce16-11df-a641-6cf04978803c', N'<stream:stream from=''127.0.0.1'' xmlns=''jabber:client'' xmlns:stream=''http://etherx.jabber.org/streams'' id=''8711d412''><stream:features><auth xmlns=''http://jabber.org/features/iq-auth''/></stream:features>', CAST(0x00009E0300F358FC AS DateTime), N'8711d412', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc90908-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec8bd7b75" type="get"><query xmlns="jabber:iq:auth"><username>mahdi2</username></query></iq>', CAST(0x00009E0300F358FC AS DateTime), N'8711d412', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc90909-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec8bd7b75" type="result"><query xmlns="jabber:iq:auth"><username>mahdi2</username><digest /><resource /></query></iq>', CAST(0x00009E0300F35901 AS DateTime), N'8711d412', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc9090a-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec8bd7b76" type="get"><query xmlns="jabber:iq:auth"><username>mahdi2</username></query></iq>', CAST(0x00009E0300F35901 AS DateTime), N'8711d412', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc9090b-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec8bd7b76" type="result"><query xmlns="jabber:iq:auth"><username>mahdi2</username><digest /><resource /></query></iq>', CAST(0x00009E0300F35906 AS DateTime), N'8711d412', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'8378050c-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec8bd7b7d" type="get"><ping xmlns="urn:xmpp:ping" /></iq>', CAST(0x00009E0300F38145 AS DateTime), N'8711d412', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc9090c-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec8bd7b77" type="set"><query xmlns="jabber:iq:auth"><username>mahdi2</username><resource>Home</resource><digest>b722bcf30ad132deb3a0088f53b19db48858d598</digest></query></iq>', CAST(0x00009E0300F35906 AS DateTime), N'8711d412', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc9090d-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec8bd7b77" type="result" />', CAST(0x00009E0300F3590F AS DateTime), N'8711d412', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc9090e-ce16-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client" to="mahdi2@127.0.0.1"><status /></presence>', CAST(0x00009E0300F3591D AS DateTime), N'8711d412', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc9090f-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec8bd7b78" type="set"><query xmlns="jabber:iq:auth"><username>mahdi2</username><resource>Home</resource><digest>b722bcf30ad132deb3a0088f53b19db48858d598</digest></query></iq>', CAST(0x00009E0300F3592B AS DateTime), N'8711d412', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc90910-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" to="127.0.0.1" id="purplec8bd7b79" type="get"><query xmlns="http://jabber.org/protocol/disco#items" /></iq>', CAST(0x00009E0300F35930 AS DateTime), N'8711d412', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc90911-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" to="127.0.0.1" id="purplec8bd7b7a" type="get"><query xmlns="http://jabber.org/protocol/disco#info" /></iq>', CAST(0x00009E0300F35934 AS DateTime), N'8711d412', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc90912-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec8bd7b7a" from="127.0.0.1" to="mahdi2@127.0.0.1" type="result"><query xmlns="http://jabber.org/protocol/disco#info"><identity type="pc" category="client" /><feature var="http://jabber.org/protocol/pubsub#access-roster" /><feature var="msgoffline" /><feature var="http://jabber.org/protocol/pubsub#auto-subscribe" /><feature var="http://jabber.org/protocol/pubsub#presence-notifications" /><feature var="jabber:iq:last" /><feature var="jabber:iq:version" /><feature var="urn:xmpp:ping" /><feature var="http://jabber.org/protocol/ibb" /><feature var="jabber:iq:ibb" /><feature var="urn:xmpp:receipts" /></query></iq>', CAST(0x00009E0300F35939 AS DateTime), N'8711d412', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc90913-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec8bd7b7b" type="get"><vCard xmlns="vcard-temp" /></iq>', CAST(0x00009E0300F3593E AS DateTime), N'8711d412', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc90914-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec8bd7b7b" to="mahdi2@127.0.0.1" type="result"><vCard xmlns="vcard-temp"><EMAIL><PREF /><USERID>mahdi@tini.ir</USERID></EMAIL><FN>Mahdi 2 Yousefi</FN><N><FAMILY>Yousefi</FAMILY><GIVEN>Mahdi 2</GIVEN><MIDDLE /></N><NICKNAME>mahdi2</NICKNAME><JABBERID>mahdi2@127.0.0.1</JABBERID></vCard></iq>', CAST(0x00009E0300F35942 AS DateTime), N'8711d412', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc90915-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec8bd7b7c" type="get"><query xmlns="jabber:iq:roster" /></iq>', CAST(0x00009E0300F35947 AS DateTime), N'8711d412', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc90916-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec8bd7b7c" from="mahdi2@127.0.0.1" type="result"><query xmlns="jabber:iq:roster" /></iq>', CAST(0x00009E0300F35951 AS DateTime), N'8711d412', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6bc90917-ce16-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client"><priority>1</priority><c xmlns="http://jabber.org/protocol/caps" node="http://pidgin.im/" ver="ZJcqUfuUIFo9PX0wTgU7J3kB5hA=" hash="sha-1" /><x xmlns="vcard-temp:x:update"><photo /></x></presence>', CAST(0x00009E0300F3595F AS DateTime), N'8711d412', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'9008494e-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec8bd7b7d" to="mahdi2@127.0.0.1" from="127.0.0.1" type="result" />', CAST(0x00009E0300F399F8 AS DateTime), N'8711d412', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed7a-ce16-11df-a641-6cf04978803c', N'<stream:stream from=''127.0.0.1'' xmlns=''jabber:client'' xmlns:stream=''http://etherx.jabber.org/streams'' id=''015eb531''><stream:features><auth xmlns=''http://jabber.org/features/iq-auth''/></stream:features>', CAST(0x00009E0300F33D10 AS DateTime), N'015eb531', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed7b-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6eee" type="get"><query xmlns="jabber:iq:auth"><username>mahdi</username></query></iq>', CAST(0x00009E0300F33F2B AS DateTime), N'015eb531', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed7c-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6eee" type="result"><query xmlns="jabber:iq:auth"><username>mahdi</username><digest /><resource /></query></iq>', CAST(0x00009E0300F33F2F AS DateTime), N'015eb531', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed7d-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6eef" type="get"><query xmlns="jabber:iq:auth"><username>mahdi</username></query></iq>', CAST(0x00009E0300F33F34 AS DateTime), N'015eb531', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed7e-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6eef" type="result"><query xmlns="jabber:iq:auth"><username>mahdi</username><digest /><resource /></query></iq>', CAST(0x00009E0300F33F34 AS DateTime), N'015eb531', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed7f-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6ef0" type="set"><query xmlns="jabber:iq:auth"><username>mahdi</username><resource>Home</resource><digest>68b38e64b73116ede9ad80b0ae10f3c6c69e9ed5</digest></query></iq>', CAST(0x00009E0300F33F39 AS DateTime), N'015eb531', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed80-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6ef0" type="result" />', CAST(0x00009E0300F3400C AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed81-ce16-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client" to="mahdi@127.0.0.1"><status /></presence>', CAST(0x00009E0300F34044 AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed82-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6ef1" type="set"><query xmlns="jabber:iq:auth"><username>mahdi</username><resource>Home</resource><digest>68b38e64b73116ede9ad80b0ae10f3c6c69e9ed5</digest></query></iq>', CAST(0x00009E0300F34065 AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed83-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" to="127.0.0.1" id="purple347d6ef2" type="get"><query xmlns="http://jabber.org/protocol/disco#items" /></iq>', CAST(0x00009E0300F3406A AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed84-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" to="127.0.0.1" id="purple347d6ef3" type="get"><query xmlns="http://jabber.org/protocol/disco#info" /></iq>', CAST(0x00009E0300F3406E AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed85-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6ef3" from="127.0.0.1" to="mahdi@127.0.0.1" type="result"><query xmlns="http://jabber.org/protocol/disco#info"><identity type="pc" category="client" /><feature var="http://jabber.org/protocol/pubsub#access-roster" /><feature var="msgoffline" /><feature var="http://jabber.org/protocol/pubsub#auto-subscribe" /><feature var="http://jabber.org/protocol/pubsub#presence-notifications" /><feature var="jabber:iq:last" /><feature var="jabber:iq:version" /><feature var="urn:xmpp:ping" /><feature var="http://jabber.org/protocol/ibb" /><feature var="jabber:iq:ibb" /><feature var="urn:xmpp:receipts" /></query></iq>', CAST(0x00009E0300F34073 AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed86-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6ef4" type="get"><vCard xmlns="vcard-temp" /></iq>', CAST(0x00009E0300F34078 AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed87-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6ef4" to="mahdi@127.0.0.1" type="result"><vCard xmlns="vcard-temp"><EMAIL><PREF /><USERID>mahdi@tini.ir</USERID></EMAIL><FN>Mahdi Yousefi</FN><N><FAMILY>Yousefi</FAMILY><GIVEN>Mahdi</GIVEN><MIDDLE /></N><NICKNAME>mahdi</NICKNAME><JABBERID>mahdi@127.0.0.1</JABBERID></vCard></iq>', CAST(0x00009E0300F34081 AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed88-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6ef5" type="get"><query xmlns="jabber:iq:roster" /></iq>', CAST(0x00009E0300F34086 AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed89-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6ef5" from="mahdi@127.0.0.1" type="result"><query xmlns="jabber:iq:roster"><item name="Mahdi 2 Yousefi" subscription="from" jid="mahdi2@127.0.0.1" /></query></iq>', CAST(0x00009E0300F34094 AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed8a-ce16-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client"><priority>1</priority><c xmlns="http://jabber.org/protocol/caps" node="http://pidgin.im/" ver="ZJcqUfuUIFo9PX0wTgU7J3kB5hA=" hash="sha-1" /><x xmlns="vcard-temp:x:update"><photo /></x></presence>', CAST(0x00009E0300F340CC AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'60c6ed8b-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6ef6" type="set"><query xmlns="jabber:iq:roster"><item jid="mahdi2@127.0.0.1" subscription="remove" /></query></iq>', CAST(0x00009E0300F343BF AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'b4f332e6-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6ef7" from="mahdi@127.0.0.1" type="result"><query xmlns="jabber:iq:roster" /></iq>', CAST(0x00009E0300F3E28D AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'b4f332e7-ce16-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client" type="subscribe" to="mahdi2@127.0.0.1" />', CAST(0x00009E0300F3E292 AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'b4f332e8-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec8bd7b7e" type="get"><ping xmlns="urn:xmpp:ping" /></iq>', CAST(0x00009E0300F3E29B AS DateTime), N'8711d412', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'b4f332e9-ce16-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client" type="subscribe" to="mahdi2@127.0.0.1" />', CAST(0x00009E0300F3E2C6 AS DateTime), N'8711d412', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'b4f332ea-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec8bd7b7e" to="mahdi2@127.0.0.1" from="127.0.0.1" type="result" />', CAST(0x00009E0300F3E2C6 AS DateTime), N'8711d412', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'b4f332eb-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6ef8" type="get"><ping xmlns="urn:xmpp:ping" /></iq>', CAST(0x00009E0300F3E2CA AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'b4f332ec-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6ef8" to="mahdi@127.0.0.1" from="127.0.0.1" type="result" />', CAST(0x00009E0300F3E2D4 AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'76cd86ec-ce16-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple347d6ef7" type="set"><query xmlns="jabber:iq:roster"><item name="" jid="mahdi2@127.0.0.1"><group>Buddies</group></item></query></iq>', CAST(0x00009E0300F3685E AS DateTime), N'015eb531', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'53303c00-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da70737" type="result"><query xmlns="jabber:iq:auth"><username>mahdi</username><digest /><resource /></query></iq>', CAST(0x00009E03010EAB4D AS DateTime), N'f9c65544', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'53303c01-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da70738" type="get"><query xmlns="jabber:iq:auth"><username>mahdi</username></query></iq>', CAST(0x00009E03010EAB4D AS DateTime), N'f9c65544', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'53303c02-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da70738" type="result"><query xmlns="jabber:iq:auth"><username>mahdi</username><digest /><resource /></query></iq>', CAST(0x00009E03010EAB52 AS DateTime), N'f9c65544', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'53303c03-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da70739" type="set"><query xmlns="jabber:iq:auth"><username>mahdi</username><resource>Home</resource><digest>84ccec39c2866db2fa826fc248635c923626002c</digest></query></iq>', CAST(0x00009E03010EAB52 AS DateTime), N'f9c65544', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'53303c04-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da70739" type="result" />', CAST(0x00009E03010EAC25 AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'53303c05-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client" to="mahdi@127.0.0.1"><status /></presence>', CAST(0x00009E03010EAC62 AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'53303c06-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da7073a" type="set"><query xmlns="jabber:iq:auth"><username>mahdi</username><resource>Home</resource><digest>84ccec39c2866db2fa826fc248635c923626002c</digest></query></iq>', CAST(0x00009E03010EAC83 AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'53303c07-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" to="127.0.0.1" id="purple5da7073b" type="get"><query xmlns="http://jabber.org/protocol/disco#items" /></iq>', CAST(0x00009E03010EAC88 AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'53303c08-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" to="127.0.0.1" id="purple5da7073c" type="get"><query xmlns="http://jabber.org/protocol/disco#info" /></iq>', CAST(0x00009E03010EAC8C AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'53303c09-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da7073c" from="127.0.0.1" to="mahdi@127.0.0.1" type="result"><query xmlns="http://jabber.org/protocol/disco#info"><identity type="pc" category="client" /><feature var="http://jabber.org/protocol/pubsub#access-roster" /><feature var="msgoffline" /><feature var="http://jabber.org/protocol/pubsub#auto-subscribe" /><feature var="http://jabber.org/protocol/pubsub#presence-notifications" /><feature var="jabber:iq:last" /><feature var="jabber:iq:version" /><feature var="urn:xmpp:ping" /><feature var="http://jabber.org/protocol/ibb" /><feature var="jabber:iq:ibb" /><feature var="urn:xmpp:receipts" /></query></iq>', CAST(0x00009E03010EAC91 AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'53303c0a-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da7073d" type="get"><vCard xmlns="vcard-temp" /></iq>', CAST(0x00009E03010EAC96 AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'53303c0b-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da7073d" to="mahdi@127.0.0.1" type="result"><vCard xmlns="vcard-temp"><EMAIL><PREF /><USERID>mahdi@tini.ir</USERID></EMAIL><FN>Mahdi Yousefi</FN><N><FAMILY>Yousefi</FAMILY><GIVEN>Mahdi</GIVEN><MIDDLE /></N><NICKNAME>mahdi</NICKNAME><JABBERID>mahdi@127.0.0.1</JABBERID></vCard></iq>', CAST(0x00009E03010EACA4 AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'53303c0c-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da7073e" type="get"><query xmlns="jabber:iq:roster" /></iq>', CAST(0x00009E03010EACA8 AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'53303c0d-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da7073e" from="mahdi@127.0.0.1" type="result"><query xmlns="jabber:iq:roster"><item name="Mahdi 2 Yousefi" subscription="from" jid="mahdi2@127.0.0.1" /></query></iq>', CAST(0x00009E03010EACB2 AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'53303c0e-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client"><priority>1</priority><c xmlns="http://jabber.org/protocol/caps" node="http://pidgin.im/" ver="ZJcqUfuUIFo9PX0wTgU7J3kB5hA=" hash="sha-1" /><x xmlns="vcard-temp:x:update"><photo /></x></presence>', CAST(0x00009E03010EACE5 AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'd21beb16-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple6a8b0b09" type="get"><ping xmlns="urn:xmpp:ping" /></iq>', CAST(0x00009E03010FA250 AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'd21beb17-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple6a8b0b09" to="mahdi@127.0.0.1" from="127.0.0.1" type="result" />', CAST(0x00009E03010FA250 AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'd21beb18-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd147" type="get"><ping xmlns="urn:xmpp:ping" /></iq>', CAST(0x00009E03010FAD06 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'd21beb19-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd147" to="mahdi2@127.0.0.1" from="127.0.0.1" type="result" />', CAST(0x00009E03010FAD0B AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'76e06f2e-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd144" type="set"><query xmlns="jabber:iq:roster"><item name="" jid="mahdi@127.0.0.1"><group>Buddies</group></item></query></iq>', CAST(0x00009E03010EEEF1 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'ae96a23a-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da70741" type="get"><ping xmlns="urn:xmpp:ping" /></iq>', CAST(0x00009E03010F5C7A AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'ae96a23b-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da70741" to="mahdi@127.0.0.1" from="127.0.0.1" type="result" />', CAST(0x00009E03010F5C7E AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'ae96a23c-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd146" type="get"><ping xmlns="urn:xmpp:ping" /></iq>', CAST(0x00009E03010F66B6 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'ae96a23d-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd146" to="mahdi2@127.0.0.1" from="127.0.0.1" type="result" />', CAST(0x00009E03010F66BB AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6f769f56-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd143" type="get"><ping xmlns="urn:xmpp:ping" /></iq>', CAST(0x00009E03010EE05E AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6f769f57-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd143" to="mahdi2@127.0.0.1" from="127.0.0.1" type="result" />', CAST(0x00009E03010EE063 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'902e4460-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd144" from="mahdi2@127.0.0.1" type="result"><query xmlns="jabber:iq:roster"><item name="Mahdi Yousefi" subscription="both" jid="mahdi@127.0.0.1"><group>Buddies</group></item></query></iq>', CAST(0x00009E03010F20B1 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'902e4461-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client" from="mahdi2@127.0.0.1" to="mahdi2@127.0.0.1" /><presence xmlns="jabber:client" from="mahdi@127.0.0.1" to="mahdi2@127.0.0.1" />', CAST(0x00009E03010F20B6 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'902e4462-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da70740" type="get"><ping xmlns="urn:xmpp:ping" /></iq>', CAST(0x00009E03010F20C4 AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'902e4463-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da70740" to="mahdi@127.0.0.1" from="127.0.0.1" type="result" />', CAST(0x00009E03010F20CD AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'08352790-ce24-11df-a641-6cf04978803c', N'<stream:stream from=''127.0.0.1'' xmlns=''jabber:client'' xmlns:stream=''http://etherx.jabber.org/streams'' id=''66401f90''><stream:features><auth xmlns=''http://jabber.org/features/iq-auth''/></stream:features>', CAST(0x00009E03010E155C AS DateTime), N'66401f90', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'08352791-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purpledbc66ed9" type="set"><query xmlns="jabber:iq:auth"><username>mahdi</username><resource>Home</resource><digest>e0c7de93b7b7a9bdceb5a18dc1d57a7931fb9b70</digest></query></iq>', CAST(0x00009E03010E155C AS DateTime), N'7cf85fb1', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'08352792-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple3e20fd7f" type="get"><query xmlns="jabber:iq:auth"><username>mahdi2</username></query></iq>', CAST(0x00009E03010E156E AS DateTime), N'66401f90', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'08352793-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple3e20fd7f" type="result"><query xmlns="jabber:iq:auth"><username>mahdi2</username><digest /><resource /></query></iq>', CAST(0x00009E03010E1573 AS DateTime), N'66401f90', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'08352798-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple3e20fd81" type="set"><query xmlns="jabber:iq:auth"><username>mahdi2</username><resource>Home</resource><digest>b3d95362a94c11aa6bc45b218bcfb74693624866</digest></query></iq>', CAST(0x00009E03010E15BE AS DateTime), N'66401f90', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'08352799-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purpledbc66edb" from="127.0.0.1" to="mahdi@127.0.0.1" type="result"><query xmlns="http://jabber.org/protocol/disco#info"><identity type="pc" category="client" /><feature var="http://jabber.org/protocol/pubsub#access-roster" /><feature var="msgoffline" /><feature var="http://jabber.org/protocol/pubsub#auto-subscribe" /><feature var="http://jabber.org/protocol/pubsub#presence-notifications" /><feature var="jabber:iq:last" /><feature var="jabber:iq:version" /><feature var="urn:xmpp:ping" /><feature var="http://jabber.org/protocol/ibb" /><feature var="jabber:iq:ibb" /><feature var="urn:xmpp:receipts" /></query></iq>', CAST(0x00009E03010E15E3 AS DateTime), N'7cf85fb1', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'0835279a-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purpledbc66edc" type="get"><vCard xmlns="vcard-temp" /></iq>', CAST(0x00009E03010E1604 AS DateTime), N'7cf85fb1', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'0835279c-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple3e20fd82" type="set"><query xmlns="jabber:iq:auth"><username>mahdi2</username><resource>Home</resource><digest>b3d95362a94c11aa6bc45b218bcfb74693624866</digest></query></iq>', CAST(0x00009E03010E1620 AS DateTime), N'66401f90', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'9be592a4-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd145" type="get"><ping xmlns="urn:xmpp:ping" /></iq>', CAST(0x00009E03010F37BA AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'9be592a5-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd145" to="mahdi2@127.0.0.1" from="127.0.0.1" type="result" />', CAST(0x00009E03010F37BF AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836b4-ce24-11df-a641-6cf04978803c', N'<stream:stream from=''127.0.0.1'' xmlns=''jabber:client'' xmlns:stream=''http://etherx.jabber.org/streams'' id=''15342f78''><stream:features><auth xmlns=''http://jabber.org/features/iq-auth''/></stream:features>', CAST(0x00009E03010F7EC5 AS DateTime), N'15342f78', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836b5-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple6a8b0b01" type="get"><query xmlns="jabber:iq:auth"><username>mahdi</username></query></iq>', CAST(0x00009E03010F7ECA AS DateTime), N'15342f78', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836b6-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple6a8b0b01" type="result"><query xmlns="jabber:iq:auth"><username>mahdi</username><digest /><resource /></query></iq>', CAST(0x00009E03010F7ECA AS DateTime), N'15342f78', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836b7-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple6a8b0b02" type="get"><query xmlns="jabber:iq:auth"><username>mahdi</username></query></iq>', CAST(0x00009E03010F7ECA AS DateTime), N'15342f78', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836b8-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple6a8b0b02" type="result"><query xmlns="jabber:iq:auth"><username>mahdi</username><digest /><resource /></query></iq>', CAST(0x00009E03010F7ECF AS DateTime), N'15342f78', NULL, N'127.0.0.1')
GO
print 'Processed 100 total records'
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836b9-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple6a8b0b03" type="set"><query xmlns="jabber:iq:auth"><username>mahdi</username><resource>Home</resource><digest>675c463e2de1305d66f7293b0e87afd5df1db9f0</digest></query></iq>', CAST(0x00009E03010F7ECF AS DateTime), N'15342f78', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836ba-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple6a8b0b03" type="result" />', CAST(0x00009E03010F7ED8 AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836bb-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client" to="mahdi@127.0.0.1"><status /></presence>', CAST(0x00009E03010F7EE6 AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'e3fb2bbc-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple6a8b0b0a" type="get"><ping xmlns="urn:xmpp:ping" /></iq>', CAST(0x00009E03010FC573 AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836bc-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client" from="mahdi@127.0.0.1" to="mahdi2@127.0.0.1"><status /></presence>', CAST(0x00009E03010F7EF4 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'e3fb2bbd-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple6a8b0b0a" to="mahdi@127.0.0.1" from="127.0.0.1" type="result" />', CAST(0x00009E03010FC578 AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836bd-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client" from="mahdi@127.0.0.1" to="mahdi@127.0.0.1"><status /></presence>', CAST(0x00009E03010F7EF9 AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'e3fb2bbe-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd148" type="get"><ping xmlns="urn:xmpp:ping" /></iq>', CAST(0x00009E03010FD02E AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836be-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple6a8b0b04" type="set"><query xmlns="jabber:iq:auth"><username>mahdi</username><resource>Home</resource><digest>675c463e2de1305d66f7293b0e87afd5df1db9f0</digest></query></iq>', CAST(0x00009E03010F7EFE AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'e3fb2bbf-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd148" to="mahdi2@127.0.0.1" from="127.0.0.1" type="result" />', CAST(0x00009E03010FD033 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836bf-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" to="127.0.0.1" id="purple6a8b0b05" type="get"><query xmlns="http://jabber.org/protocol/disco#items" /></iq>', CAST(0x00009E03010F7F02 AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836c0-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" to="127.0.0.1" id="purple6a8b0b06" type="get"><query xmlns="http://jabber.org/protocol/disco#info" /></iq>', CAST(0x00009E03010F7F07 AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836c1-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple6a8b0b06" from="127.0.0.1" to="mahdi@127.0.0.1" type="result"><query xmlns="http://jabber.org/protocol/disco#info"><identity type="pc" category="client" /><feature var="http://jabber.org/protocol/pubsub#access-roster" /><feature var="msgoffline" /><feature var="http://jabber.org/protocol/pubsub#auto-subscribe" /><feature var="http://jabber.org/protocol/pubsub#presence-notifications" /><feature var="jabber:iq:last" /><feature var="jabber:iq:version" /><feature var="urn:xmpp:ping" /><feature var="http://jabber.org/protocol/ibb" /><feature var="jabber:iq:ibb" /><feature var="urn:xmpp:receipts" /></query></iq>', CAST(0x00009E03010F7F0C AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836c2-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple6a8b0b07" type="get"><vCard xmlns="vcard-temp" /></iq>', CAST(0x00009E03010F7F10 AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836c3-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple6a8b0b07" to="mahdi@127.0.0.1" type="result"><vCard xmlns="vcard-temp"><EMAIL><PREF /><USERID>mahdi@tini.ir</USERID></EMAIL><FN>Mahdi Yousefi</FN><N><FAMILY>Yousefi</FAMILY><GIVEN>Mahdi</GIVEN><MIDDLE /></N><NICKNAME>mahdi</NICKNAME><JABBERID>mahdi@127.0.0.1</JABBERID></vCard></iq>', CAST(0x00009E03010F7F1A AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836c4-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple6a8b0b08" type="get"><query xmlns="jabber:iq:roster" /></iq>', CAST(0x00009E03010F7F1A AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836c5-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple6a8b0b08" from="mahdi@127.0.0.1" type="result"><query xmlns="jabber:iq:roster"><item name="Mahdi 2 Yousefi" subscription="both" jid="mahdi2@127.0.0.1" /></query></iq>', CAST(0x00009E03010F7F23 AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836c6-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client" from="mahdi2@127.0.0.1" to="mahdi@127.0.0.1" /><presence xmlns="jabber:client" from="mahdi@127.0.0.1" to="mahdi@127.0.0.1" />', CAST(0x00009E03010F7F2D AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadc6-ce24-11df-a641-6cf04978803c', N'<stream:stream from=''127.0.0.1'' xmlns=''jabber:client'' xmlns:stream=''http://etherx.jabber.org/streams'' id=''fa3e50f8''><stream:features><auth xmlns=''http://jabber.org/features/iq-auth''/></stream:features>', CAST(0x00009E03010EB69E AS DateTime), N'fa3e50f8', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836c7-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client"><priority>1</priority><c xmlns="http://jabber.org/protocol/caps" node="http://pidgin.im/" ver="ZJcqUfuUIFo9PX0wTgU7J3kB5hA=" hash="sha-1" /><x xmlns="vcard-temp:x:update"><photo /></x></presence>', CAST(0x00009E03010F7F36 AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadc7-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd13b" type="get"><query xmlns="jabber:iq:auth"><username>mahdi2</username></query></iq>', CAST(0x00009E03010EB6A3 AS DateTime), N'fa3e50f8', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836c8-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client" from="mahdi@127.0.0.1" to="mahdi2@127.0.0.1"><status /></presence>', CAST(0x00009E03010F7F4D AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadc8-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd13b" type="result"><query xmlns="jabber:iq:auth"><username>mahdi2</username><digest /><resource /></query></iq>', CAST(0x00009E03010EB6A3 AS DateTime), N'fa3e50f8', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'b8bfc7c8-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client" type="unavailable" from="mahdi@127.0.0.1" to="mahdi2@127.0.0.1"><status /></presence>', CAST(0x00009E03010F7074 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'c00836c9-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client" from="mahdi@127.0.0.1" to="mahdi@127.0.0.1"><status /></presence>', CAST(0x00009E03010F7F52 AS DateTime), N'15342f78', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadc9-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd13c" type="get"><query xmlns="jabber:iq:auth"><username>mahdi2</username></query></iq>', CAST(0x00009E03010EB6A3 AS DateTime), N'fa3e50f8', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadca-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd13c" type="result"><query xmlns="jabber:iq:auth"><username>mahdi2</username><digest /><resource /></query></iq>', CAST(0x00009E03010EB6A8 AS DateTime), N'fa3e50f8', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadcb-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd13d" type="set"><query xmlns="jabber:iq:auth"><username>mahdi2</username><resource>Home</resource><digest>787ff36465478ebe5e05d16c7a964e6d494e57e1</digest></query></iq>', CAST(0x00009E03010EB6A8 AS DateTime), N'fa3e50f8', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadcc-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd13d" type="result" />', CAST(0x00009E03010EB6B1 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadcd-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client" to="mahdi2@127.0.0.1"><status /></presence>', CAST(0x00009E03010EB6BF AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadce-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd13e" type="set"><query xmlns="jabber:iq:auth"><username>mahdi2</username><resource>Home</resource><digest>787ff36465478ebe5e05d16c7a964e6d494e57e1</digest></query></iq>', CAST(0x00009E03010EB6CD AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadcf-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" to="127.0.0.1" id="purplec49bd13f" type="get"><query xmlns="http://jabber.org/protocol/disco#items" /></iq>', CAST(0x00009E03010EB6D2 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadd0-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" to="127.0.0.1" id="purplec49bd140" type="get"><query xmlns="http://jabber.org/protocol/disco#info" /></iq>', CAST(0x00009E03010EB6D7 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadd1-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd140" from="127.0.0.1" to="mahdi2@127.0.0.1" type="result"><query xmlns="http://jabber.org/protocol/disco#info"><identity type="pc" category="client" /><feature var="http://jabber.org/protocol/pubsub#access-roster" /><feature var="msgoffline" /><feature var="http://jabber.org/protocol/pubsub#auto-subscribe" /><feature var="http://jabber.org/protocol/pubsub#presence-notifications" /><feature var="jabber:iq:last" /><feature var="jabber:iq:version" /><feature var="urn:xmpp:ping" /><feature var="http://jabber.org/protocol/ibb" /><feature var="jabber:iq:ibb" /><feature var="urn:xmpp:receipts" /></query></iq>', CAST(0x00009E03010EB6D7 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadd2-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd141" type="get"><vCard xmlns="vcard-temp" /></iq>', CAST(0x00009E03010EB6DB AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6968e6d2-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da7073f" type="get"><ping xmlns="urn:xmpp:ping" /></iq>', CAST(0x00009E03010ED477 AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadd3-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd141" to="mahdi2@127.0.0.1" type="result"><vCard xmlns="vcard-temp"><EMAIL><PREF /><USERID>mahdi@tini.ir</USERID></EMAIL><FN>Mahdi 2 Yousefi</FN><N><FAMILY>Yousefi</FAMILY><GIVEN>Mahdi 2</GIVEN><MIDDLE /></N><NICKNAME>mahdi2</NICKNAME><JABBERID>mahdi2@127.0.0.1</JABBERID></vCard></iq>', CAST(0x00009E03010EB6E5 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6968e6d3-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client" type="subscribed" to="mahdi@127.0.0.1" />', CAST(0x00009E03010ED47C AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadd4-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd142" type="get"><query xmlns="jabber:iq:roster" /></iq>', CAST(0x00009E03010EB6E9 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6968e6d4-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da7073f" to="mahdi@127.0.0.1" from="127.0.0.1" type="result" />', CAST(0x00009E03010ED561 AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadd5-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purplec49bd142" from="mahdi2@127.0.0.1" type="result"><query xmlns="jabber:iq:roster" /></iq>', CAST(0x00009E03010EB6F3 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6968e6d5-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client"><status /></presence>', CAST(0x00009E03010ED56B AS DateTime), N'f9c65544', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadd6-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client" type="subscribe" from="mahdi@127.0.0.1" to="mahdi2@127.0.0.1" />', CAST(0x00009E03010EB6FC AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'6968e6d6-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client"><status /></presence>', CAST(0x00009E03010EDB63 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadd7-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client"><priority>1</priority><c xmlns="http://jabber.org/protocol/caps" node="http://pidgin.im/" ver="ZJcqUfuUIFo9PX0wTgU7J3kB5hA=" hash="sha-1" /><x xmlns="vcard-temp:x:update"><photo /></x></presence>', CAST(0x00009E03010EB701 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'5a3aadd8-ce24-11df-a641-6cf04978803c', N'<presence xmlns="jabber:client" type="subscribed" to="mahdi@127.0.0.1" />', CAST(0x00009E03010EBE46 AS DateTime), N'fa3e50f8', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'53303bfe-ce24-11df-a641-6cf04978803c', N'<stream:stream from=''127.0.0.1'' xmlns=''jabber:client'' xmlns:stream=''http://etherx.jabber.org/streams'' id=''f9c65544''><stream:features><auth xmlns=''http://jabber.org/features/iq-auth''/></stream:features>', CAST(0x00009E03010EA8CB AS DateTime), N'f9c65544', NULL, N'127.0.0.1')
INSERT [dbo].[TbLogs] ([LogId], [LogText], [LogDate], [LogSessionId], [LogUserId], [LogIP]) VALUES (N'53303bff-ce24-11df-a641-6cf04978803c', N'<iq xmlns="jabber:client" id="purple5da70737" type="get"><query xmlns="jabber:iq:auth"><username>mahdi</username></query></iq>', CAST(0x00009E03010EAB49 AS DateTime), N'f9c65544', NULL, N'127.0.0.1')
/****** Object:  Table [dbo].[TbUsers]    Script Date: 04/21/2011 23:07:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbUsers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TbUsers](
	[UserId] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
	[UserPassCrypt] [varchar](100) COLLATE Arabic_CI_AS NOT NULL,
	[UserPassSalt] [varchar](40) COLLATE Arabic_CI_AS NOT NULL,
	[UserLastLoginDate] [datetime] NULL,
	[UserPrevLoginDate] [datetime] NULL,
	[UserLastChangePass] [datetime] NULL,
	[UserWebAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_TbUsers] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON),
 CONSTRAINT [IX_TbUsers] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[TbUsers] ([UserId], [Username], [UserPassCrypt], [UserPassSalt], [UserLastLoginDate], [UserPrevLoginDate], [UserLastChangePass], [UserWebAdmin]) VALUES (N'd36df92c-cdf8-11df-a641-6cf04978803c', N'mahdi3', N'np43qSfkDewXEWDnwF6b9g==', N'73E63328460B79BA6D47759045E6B78171E97382', NULL, NULL, NULL, 0)
INSERT [dbo].[TbUsers] ([UserId], [Username], [UserPassCrypt], [UserPassSalt], [UserLastLoginDate], [UserPrevLoginDate], [UserLastChangePass], [UserWebAdmin]) VALUES (N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'mahdi', N'aK4LbhNGKWxCKGwBcgTt+w==', N'626DB19A6D0B6B8CEA1E99750D8ED0EBB74B68D6', CAST(0x00009E03010F7ED3 AS DateTime), CAST(0x00009E03010EAC1C AS DateTime), NULL, 0)
INSERT [dbo].[TbUsers] ([UserId], [Username], [UserPassCrypt], [UserPassSalt], [UserLastLoginDate], [UserPrevLoginDate], [UserLastChangePass], [UserWebAdmin]) VALUES (N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'mahdi2', N'UBZo6+DE/31EhbjDU1ioCA==', N'DC66AA05DA4D5D90EF7444685FCA42764FED3DFF', CAST(0x00009E03010EB6AC AS DateTime), CAST(0x00009E0300F3590A AS DateTime), NULL, 0)
/****** Object:  Table [dbo].[TbVcard]    Script Date: 04/21/2011 23:07:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbVcard]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TbVcard](
	[UserId] [uniqueidentifier] NOT NULL,
	[VcardURL] [nvarchar](300) COLLATE Arabic_CI_AS NULL,
	[VcardTitle] [nvarchar](100) COLLATE Arabic_CI_AS NULL,
	[VcardFirstName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
	[VcardLastName] [nvarchar](50) COLLATE Arabic_CI_AS NOT NULL,
	[VcardPhoto] [varchar](100) COLLATE Arabic_CI_AS NULL,
	[VcardOrgName] [nvarchar](100) COLLATE Arabic_CI_AS NULL,
	[VcardOrgUnit] [nvarchar](100) COLLATE Arabic_CI_AS NULL,
	[VcardNickname] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[VcardDescription] [nvarchar](300) COLLATE Arabic_CI_AS NULL,
	[VcardBirthday] [datetime] NULL,
	[VcardEmail] [nvarchar](200) COLLATE Arabic_CI_AS NULL,
	[VcardTelCell] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[VcardTelFax] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[VcardTelVoice] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[VcardTelVoice2] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
 CONSTRAINT [PK_TbVcard] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[TbVcard] ([UserId], [VcardURL], [VcardTitle], [VcardFirstName], [VcardLastName], [VcardPhoto], [VcardOrgName], [VcardOrgUnit], [VcardNickname], [VcardDescription], [VcardBirthday], [VcardEmail], [VcardTelCell], [VcardTelFax], [VcardTelVoice], [VcardTelVoice2]) VALUES (N'd36df92c-cdf8-11df-a641-6cf04978803c', N'http://www.usefi3.net', NULL, N'Mahdi 3', N'Yousefi', NULL, N'Unit 3', NULL, NULL, NULL, CAST(0x000079C200000000 AS DateTime), N'mahdi@tini.ir', NULL, NULL, NULL, NULL)
INSERT [dbo].[TbVcard] ([UserId], [VcardURL], [VcardTitle], [VcardFirstName], [VcardLastName], [VcardPhoto], [VcardOrgName], [VcardOrgUnit], [VcardNickname], [VcardDescription], [VcardBirthday], [VcardEmail], [VcardTelCell], [VcardTelFax], [VcardTelVoice], [VcardTelVoice2]) VALUES (N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'http://www.usefi.net', NULL, N'Mahdi', N'Yousefi', NULL, N'Unit', NULL, NULL, NULL, CAST(0x000079C200000000 AS DateTime), N'mahdi@tini.ir', NULL, NULL, NULL, NULL)
INSERT [dbo].[TbVcard] ([UserId], [VcardURL], [VcardTitle], [VcardFirstName], [VcardLastName], [VcardPhoto], [VcardOrgName], [VcardOrgUnit], [VcardNickname], [VcardDescription], [VcardBirthday], [VcardEmail], [VcardTelCell], [VcardTelFax], [VcardTelVoice], [VcardTelVoice2]) VALUES (N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'http://www.usefi2.net', NULL, N'Mahdi 2', N'Yousefi', NULL, N'Unit 2', NULL, NULL, NULL, CAST(0x000079C200000000 AS DateTime), N'mahdi@tini.ir', NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[TbUserStatus]    Script Date: 04/21/2011 23:07:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbUserStatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TbUserStatus](
	[UserId] [uniqueidentifier] NOT NULL,
	[UserStatus] [smallint] NOT NULL,
	[UserStatusText] [nvarchar](1000) COLLATE Arabic_CI_AS NULL,
	[UserIsOnline] [bit] NOT NULL,
	[UserStatusDate] [datetime] NOT NULL,
 CONSTRAINT [PK_TbUserStatus] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[TbUserStatus] ([UserId], [UserStatus], [UserStatusText], [UserIsOnline], [UserStatusDate]) VALUES (N'd36df92c-cdf8-11df-a641-6cf04978803c', 0, NULL, 0, CAST(0x00009E0300B922FC AS DateTime))
INSERT [dbo].[TbUserStatus] ([UserId], [UserStatus], [UserStatusText], [UserIsOnline], [UserStatusDate]) VALUES (N'cbf5db42-cdf8-11df-a641-6cf04978803c', -1, N'', 0, CAST(0x00009E03010FD605 AS DateTime))
INSERT [dbo].[TbUserStatus] ([UserId], [UserStatus], [UserStatusText], [UserIsOnline], [UserStatusDate]) VALUES (N'cbf5db43-cdf8-11df-a641-6cf04978803c', -1, N'', 0, CAST(0x00009E03010FD601 AS DateTime))
/****** Object:  Table [dbo].[TbMessage]    Script Date: 04/21/2011 23:07:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbMessage]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TbMessage](
	[MessageId] [uniqueidentifier] NOT NULL,
	[MessageDate] [datetime] NOT NULL,
	[MessageViewDate] [datetime] NULL,
	[MessageFromUserId] [uniqueidentifier] NOT NULL,
	[MessageToUserId] [uniqueidentifier] NOT NULL,
	[MessageText] [nvarchar](max) COLLATE Arabic_CI_AS NOT NULL,
	[MessageHTML] [nvarchar](max) COLLATE Arabic_CI_AS NULL,
	[MessageSenderIP] [varchar](15) COLLATE Arabic_CI_AS NOT NULL,
 CONSTRAINT [PK_TbMessage] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[TbMessage] ([MessageId], [MessageDate], [MessageViewDate], [MessageFromUserId], [MessageToUserId], [MessageText], [MessageHTML], [MessageSenderIP]) VALUES (N'51096e8c-ce0c-11df-a641-6cf04978803c', CAST(0x00009E0300DF7603 AS DateTime), CAST(0x00009E0300DF9FC3 AS DateTime), N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'salam', NULL, N'127.0.0.1')
INSERT [dbo].[TbMessage] ([MessageId], [MessageDate], [MessageViewDate], [MessageFromUserId], [MessageToUserId], [MessageText], [MessageHTML], [MessageSenderIP]) VALUES (N'7ff4f5b8-ce0c-11df-a641-6cf04978803c', CAST(0x00009E0300DFD13C AS DateTime), CAST(0x00009E0300DFD13C AS DateTime), N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'salam', NULL, N'127.0.0.1')
INSERT [dbo].[TbMessage] ([MessageId], [MessageDate], [MessageViewDate], [MessageFromUserId], [MessageToUserId], [MessageText], [MessageHTML], [MessageSenderIP]) VALUES (N'320451a7-ce12-11df-a641-6cf04978803c', CAST(0x00009E0300EB0B92 AS DateTime), CAST(0x00009E0300EB0B9B AS DateTime), N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'mahdi salam', NULL, N'127.0.0.1')
/****** Object:  Table [dbo].[TbFriend]    Script Date: 04/21/2011 23:07:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TbFriend]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TbFriend](
	[UserId] [uniqueidentifier] NOT NULL,
	[FriendId] [uniqueidentifier] NOT NULL,
	[GroupName] [nvarchar](50) COLLATE Arabic_CI_AS NULL,
	[FriendStatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_TbFriend] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[FriendId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[TbFriend] ([UserId], [FriendId], [GroupName], [FriendStatus]) VALUES (N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'', 2)
INSERT [dbo].[TbFriend] ([UserId], [FriendId], [GroupName], [FriendStatus]) VALUES (N'cbf5db43-cdf8-11df-a641-6cf04978803c', N'cbf5db42-cdf8-11df-a641-6cf04978803c', N'Buddies', 2)
/****** Object:  View [dbo].[VwLog]    Script Date: 04/21/2011 23:07:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VwLog]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VwLog]
AS
SELECT     dbo.TbLogs.LogId, dbo.TbLogs.LogText, dbo.TbLogs.LogDate, dbo.TbLogs.LogSessionId, dbo.TbLogs.LogUserId, dbo.TbUsers.Username, 
                      dbo.TbVcard.VcardFirstName, dbo.TbVcard.VcardLastName, dbo.TbVcard.VcardPhoto
FROM         dbo.TbVcard RIGHT OUTER JOIN
                      dbo.TbUsers ON dbo.TbVcard.UserId = dbo.TbUsers.UserId RIGHT OUTER JOIN
                      dbo.TbLogs ON dbo.TbUsers.UserId = dbo.TbLogs.LogUserId
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'VwLog', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TbLogs"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 143
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TbUsers"
            Begin Extent = 
               Top = 0
               Left = 371
               Bottom = 167
               Right = 561
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TbVcard"
            Begin Extent = 
               Top = 0
               Left = 750
               Bottom = 271
               Right = 919
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwLog'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'VwLog', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwLog'
GO
/****** Object:  View [dbo].[VwFriend]    Script Date: 04/21/2011 23:07:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VwFriend]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VwFriend]
AS
SELECT     dbo.TbFriend.UserId, dbo.TbFriend.FriendId, dbo.TbFriend.GroupName, dbo.TbUsers.Username AS FriendUserName, dbo.TbUserStatus.UserStatus, 
                      dbo.TbUserStatus.UserStatusText, dbo.TbVcard.VcardFirstName, dbo.TbVcard.VcardLastName, dbo.TbVcard.VcardPhoto, dbo.TbVcard.VcardOrgName, 
                      dbo.TbVcard.VcardOrgUnit, dbo.TbFriend.FriendStatus, TbUsers_1.Username, dbo.TbUserStatus.UserIsOnline
FROM         dbo.TbFriend INNER JOIN
                      dbo.TbUsers ON dbo.TbFriend.FriendId = dbo.TbUsers.UserId INNER JOIN
                      dbo.TbUsers AS TbUsers_1 ON dbo.TbFriend.UserId = TbUsers_1.UserId LEFT OUTER JOIN
                      dbo.TbVcard ON dbo.TbUsers.UserId = dbo.TbVcard.UserId LEFT OUTER JOIN
                      dbo.TbUserStatus ON dbo.TbUsers.UserId = dbo.TbUserStatus.UserId
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'VwFriend', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TbFriend"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 190
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TbUsers"
            Begin Extent = 
               Top = 6
               Left = 228
               Bottom = 121
               Right = 410
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TbUsers_1"
            Begin Extent = 
               Top = 6
               Left = 448
               Bottom = 121
               Right = 630
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TbVcard"
            Begin Extent = 
               Top = 6
               Left = 668
               Bottom = 121
               Right = 829
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TbUserStatus"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 241
               Right = 195
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or =' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwFriend'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane2' , N'SCHEMA',N'dbo', N'VIEW',N'VwFriend', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwFriend'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'VwFriend', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwFriend'
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 04/21/2011 23:07:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[DeleteUser] 
	@UserId uniqueidentifier
AS
BEGIN
	delete from TbMessage where MessageFromUserId = @UserId or MessageToUserId = @UserId;
	delete from TbFriend where UserId = @UserId or FriendId = @UserId;
	delete from TbUserStatus where UserId =@UserId;
	delete from TbVcard where UserId = @UserId;
	delete from TbUsers where UserId = @UserId;
END
' 
END
GO
/****** Object:  View [dbo].[VwUsers]    Script Date: 04/21/2011 23:07:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VwUsers]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VwUsers]
AS
SELECT     dbo.TbUsers.UserId, dbo.TbUsers.Username, dbo.TbUsers.UserLastLoginDate, dbo.TbUsers.UserPrevLoginDate, dbo.TbUsers.UserLastChangePass, 
                      dbo.TbVcard.VcardFirstName, dbo.TbVcard.VcardLastName, dbo.TbVcard.VcardPhoto, dbo.TbVcard.VcardOrgName, dbo.TbVcard.VcardOrgUnit, 
                      dbo.TbUserStatus.UserStatus, dbo.TbUserStatus.UserStatusText, dbo.TbUserStatus.UserIsOnline
FROM         dbo.TbUsers LEFT OUTER JOIN
                      dbo.TbUserStatus ON dbo.TbUsers.UserId = dbo.TbUserStatus.UserId LEFT OUTER JOIN
                      dbo.TbVcard ON dbo.TbUsers.UserId = dbo.TbVcard.UserId
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'VwUsers', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TbUsers"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 188
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TbUserStatus"
            Begin Extent = 
               Top = 96
               Left = 310
               Bottom = 214
               Right = 474
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TbVcard"
            Begin Extent = 
               Top = 0
               Left = 508
               Bottom = 271
               Right = 677
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwUsers'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'VwUsers', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwUsers'
GO
/****** Object:  View [dbo].[VwMessageOffline]    Script Date: 04/21/2011 23:07:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VwMessageOffline]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VwMessageOffline]
AS
SELECT     dbo.TbMessage.MessageId, dbo.TbMessage.MessageDate, dbo.TbMessage.MessageViewDate, dbo.TbMessage.MessageFromUserId, 
                      dbo.TbMessage.MessageToUserId, dbo.TbMessage.MessageText, dbo.TbMessage.MessageHTML, dbo.TbMessage.MessageSenderIP, 
                      dbo.TbUsers.Username
FROM         dbo.TbMessage INNER JOIN
                      dbo.TbUsers ON dbo.TbMessage.MessageFromUserId = dbo.TbUsers.UserId
WHERE     (dbo.TbMessage.MessageViewDate IS NULL)
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'VwMessageOffline', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TbMessage"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 190
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TbUsers"
            Begin Extent = 
               Top = 0
               Left = 408
               Bottom = 252
               Right = 598
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwMessageOffline'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'VwMessageOffline', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwMessageOffline'
GO
/****** Object:  View [dbo].[VwMessage]    Script Date: 04/21/2011 23:07:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VwMessage]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VwMessage]
AS
SELECT     dbo.TbMessage.MessageId, dbo.TbMessage.MessageDate, dbo.TbMessage.MessageViewDate, dbo.TbMessage.MessageFromUserId, 
                      dbo.TbMessage.MessageToUserId, dbo.TbMessage.MessageText, dbo.TbMessage.MessageHTML, dbo.TbMessage.MessageSenderIP, 
                      dbo.VwUsers.VcardFirstName AS MessageFromFirstName, dbo.VwUsers.VcardLastName AS MessageFromLastName, 
                      dbo.VwUsers.VcardPhoto AS MessageFromPhoto, VwUsers_1.VcardFirstName AS MessageToFirstName, VwUsers_1.VcardLastName AS MessageToLastName, 
                      VwUsers_1.VcardPhoto AS MessageToPhoto
FROM         dbo.TbMessage INNER JOIN
                      dbo.VwUsers ON dbo.TbMessage.MessageFromUserId = dbo.VwUsers.UserId INNER JOIN
                      dbo.VwUsers AS VwUsers_1 ON dbo.TbMessage.MessageToUserId = VwUsers_1.UserId
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'VwMessage', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[44] 4[23] 2[14] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TbMessage"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 198
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VwUsers"
            Begin Extent = 
               Top = 0
               Left = 412
               Bottom = 216
               Right = 602
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VwUsers_1"
            Begin Extent = 
               Top = 0
               Left = 658
               Bottom = 215
               Right = 848
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2490
         Alias = 2010
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwMessage'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'VwMessage', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VwMessage'
GO
/****** Object:  Default [DF_TbFriend_GroupName]    Script Date: 04/21/2011 23:07:18 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_TbFriend_GroupName]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbFriend]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TbFriend_GroupName]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TbFriend] ADD  CONSTRAINT [DF_TbFriend_GroupName]  DEFAULT (N'دوستان') FOR [GroupName]
END


End
GO
/****** Object:  ForeignKey [FK_TbFriend_TbUsers]    Script Date: 04/21/2011 23:07:18 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbFriend_TbUsers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbFriend]'))
ALTER TABLE [dbo].[TbFriend]  WITH CHECK ADD  CONSTRAINT [FK_TbFriend_TbUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[TbUsers] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbFriend_TbUsers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbFriend]'))
ALTER TABLE [dbo].[TbFriend] CHECK CONSTRAINT [FK_TbFriend_TbUsers]
GO
/****** Object:  ForeignKey [FK_TbFriend_TbUsers1]    Script Date: 04/21/2011 23:07:18 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbFriend_TbUsers1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbFriend]'))
ALTER TABLE [dbo].[TbFriend]  WITH CHECK ADD  CONSTRAINT [FK_TbFriend_TbUsers1] FOREIGN KEY([FriendId])
REFERENCES [dbo].[TbUsers] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbFriend_TbUsers1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbFriend]'))
ALTER TABLE [dbo].[TbFriend] CHECK CONSTRAINT [FK_TbFriend_TbUsers1]
GO
/****** Object:  ForeignKey [FK_TbMessage_TbUsers]    Script Date: 04/21/2011 23:07:18 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbMessage_TbUsers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbMessage]'))
ALTER TABLE [dbo].[TbMessage]  WITH CHECK ADD  CONSTRAINT [FK_TbMessage_TbUsers] FOREIGN KEY([MessageFromUserId])
REFERENCES [dbo].[TbUsers] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbMessage_TbUsers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbMessage]'))
ALTER TABLE [dbo].[TbMessage] CHECK CONSTRAINT [FK_TbMessage_TbUsers]
GO
/****** Object:  ForeignKey [FK_TbMessage_TbUsers1]    Script Date: 04/21/2011 23:07:18 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbMessage_TbUsers1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbMessage]'))
ALTER TABLE [dbo].[TbMessage]  WITH CHECK ADD  CONSTRAINT [FK_TbMessage_TbUsers1] FOREIGN KEY([MessageToUserId])
REFERENCES [dbo].[TbUsers] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbMessage_TbUsers1]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbMessage]'))
ALTER TABLE [dbo].[TbMessage] CHECK CONSTRAINT [FK_TbMessage_TbUsers1]
GO
/****** Object:  ForeignKey [FK_TbUserStatus_TbUsers]    Script Date: 04/21/2011 23:07:18 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbUserStatus_TbUsers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbUserStatus]'))
ALTER TABLE [dbo].[TbUserStatus]  WITH CHECK ADD  CONSTRAINT [FK_TbUserStatus_TbUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[TbUsers] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbUserStatus_TbUsers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbUserStatus]'))
ALTER TABLE [dbo].[TbUserStatus] CHECK CONSTRAINT [FK_TbUserStatus_TbUsers]
GO
/****** Object:  ForeignKey [FK_TbVcard_TbUsers]    Script Date: 04/21/2011 23:07:18 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbVcard_TbUsers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbVcard]'))
ALTER TABLE [dbo].[TbVcard]  WITH CHECK ADD  CONSTRAINT [FK_TbVcard_TbUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[TbUsers] ([UserId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TbVcard_TbUsers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TbVcard]'))
ALTER TABLE [dbo].[TbVcard] CHECK CONSTRAINT [FK_TbVcard_TbUsers]
GO
