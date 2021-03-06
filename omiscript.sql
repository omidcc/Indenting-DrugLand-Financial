USE [master]
GO
/****** Object:  Database [DrugLandDB]    Script Date: 11/18/2015 12:34:27 PM ******/
CREATE DATABASE [DrugLandDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DrugLandDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DrugLandDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DrugLandDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DrugLandDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DrugLandDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DrugLandDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DrugLandDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DrugLandDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DrugLandDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DrugLandDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DrugLandDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DrugLandDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DrugLandDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DrugLandDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DrugLandDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DrugLandDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DrugLandDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DrugLandDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DrugLandDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DrugLandDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DrugLandDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DrugLandDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DrugLandDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DrugLandDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DrugLandDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DrugLandDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DrugLandDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DrugLandDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DrugLandDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DrugLandDB] SET RECOVERY FULL 
GO
ALTER DATABASE [DrugLandDB] SET  MULTI_USER 
GO
ALTER DATABASE [DrugLandDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DrugLandDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DrugLandDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DrugLandDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DrugLandDB', N'ON'
GO
USE [DrugLandDB]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 11/18/2015 12:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [bigint] NOT NULL,
	[SourceType] [nvarchar](50) NOT NULL,
	[SourceId] [bigint] NOT NULL,
	[AddressType] [nvarchar](50) NOT NULL,
	[AddressLine1] [nvarchar](500) NULL,
	[AddressLine2] [nvarchar](500) NULL,
	[City] [nvarchar](50) NULL,
	[ZipCode] [nvarchar](50) NULL,
	[CountryId] [int] NULL,
	[Phone] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Web] [nvarchar](50) NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppFunctionality]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppFunctionality](
	[Id] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ModuleId] [int] NOT NULL,
	[Functionality] [nvarchar](250) NULL,
	[Url] [nvarchar](250) NULL,
	[ParentId] [int] NULL,
	[IsCompanySpecific] [bit] NULL,
	[IsActive] [bit] NULL,
	[Sequence] [int] NULL,
	[LastUpdated] [timestamp] NOT NULL,
	[Icon] [nvarchar](100) NULL,
 CONSTRAINT [PK_AppFunctionality] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppModule]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppModule](
	[Id] [int] NOT NULL,
	[Module] [nvarchar](50) NOT NULL,
	[CompanyId] [int] NULL,
	[AdminId] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppPermission]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppPermission](
	[Id] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[UserId] [int] NULL,
	[CompanyId] [int] NULL,
	[FunctionalityId] [int] NULL,
	[IsView] [bit] NULL,
	[IsInsert] [bit] NULL,
	[IsUpdate] [bit] NULL,
	[IsDelete] [bit] NULL,
	[IsApprove] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bank]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank](
	[BankId] [int] NOT NULL,
	[BankCode] [nvarchar](50) NOT NULL,
	[BankName] [nvarchar](500) NOT NULL,
	[ContactPerson] [nvarchar](250) NULL,
	[ContactDesignation] [nvarchar](150) NULL,
	[ContactNo] [nvarchar](500) NULL,
	[ContactEmail] [nvarchar](150) NULL,
	[CompanyId] [int] NULL,
	[IsActive] [bit] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[BankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BankAccounts]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankAccounts](
	[BankAccountId] [bigint] NOT NULL,
	[BankId] [bigint] NOT NULL,
	[BranchName] [nvarchar](150) NULL,
	[AccountNo] [nvarchar](50) NULL,
	[AccountTitle] [nvarchar](250) NULL,
	[AccountType] [nvarchar](150) NULL,
	[OpeningDate] [date] NULL,
	[CompanyId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_BankAccounts] PRIMARY KEY CLUSTERED 
(
	[BankAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChartOfAccount]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChartOfAccount](
	[CoaId] [int] NOT NULL,
	[CoaType] [nvarchar](50) NOT NULL,
	[CoaGroupId] [int] NOT NULL,
	[CoaCode] [nvarchar](50) NOT NULL,
	[CoaTitle] [nvarchar](350) NOT NULL,
	[ParentId] [int] NULL,
	[IsActive] [bit] NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_ChartOfAccount] PRIMARY KEY CLUSTERED 
(
	[CoaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChartOfAccountGroup]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChartOfAccountGroup](
	[CoaGroupId] [int] NOT NULL,
	[CoaGroupName] [nvarchar](150) NOT NULL,
	[ParentId] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[CompanyId] [int] NULL,
 CONSTRAINT [PK_CoaGroup] PRIMARY KEY CLUSTERED 
(
	[CoaGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Company]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](250) NOT NULL,
	[Address] [nvarchar](500) NULL,
	[Phone] [nvarchar](150) NULL,
	[Email] [nvarchar](50) NULL,
	[Web] [nvarchar](50) NULL,
	[LogoPath] [nvarchar](250) NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ContactId] [bigint] NOT NULL,
	[SourceType] [nvarchar](50) NOT NULL,
	[SourceId] [bigint] NOT NULL,
	[ContactName] [nvarchar](500) NULL,
	[ContactDesignation] [nvarchar](150) NULL,
	[IsMainContact] [bit] NULL,
	[Phone] [nvarchar](250) NULL,
	[Mobile] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CostCenter]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostCenter](
	[CostCenterId] [int] NOT NULL,
	[CostCenterType] [nvarchar](50) NOT NULL,
	[CostCenterName] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_CostCenter] PRIMARY KEY CLUSTERED 
(
	[CostCenterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [bigint] NOT NULL,
	[CustomerName] [nvarchar](500) NOT NULL,
	[CustomerCategoryId] [int] NULL,
	[SalesPersonId] [bigint] NULL,
	[IsActive] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[CreditLimit] [numeric](18, 0) NULL,
	[UpdateBy] [bigint] NULL,
	[UpdateDate] [datetime] NULL,
	[TotalDebit] [numeric](18, 4) NULL,
	[TotalCredit] [numeric](18, 4) NULL,
	[Balance]  AS ([TotalDebit]-[TotalCredit]),
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] NOT NULL,
	[DepartmentName] [nvarchar](150) NOT NULL,
	[ParentDepartmentId] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[CompanyId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Designation]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[DesignationId] [int] NOT NULL,
	[Designation] [nvarchar](150) NOT NULL,
	[DepartmentId] [int] NULL,
	[CompanyId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] NOT NULL,
	[EmployeeCode] [nvarchar](20) NULL,
	[EmployeeName] [nvarchar](520) NULL,
	[Address] [nvarchar](500) NULL,
	[DOB] [date] NULL,
	[JoinDate] [date] NULL,
	[DepartmentId] [int] NULL,
	[DesignationId] [int] NULL,
	[CompanyId] [int] NULL,
	[IsActive] [bit] NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[JournalDetails]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[JournalDetails](
	[JournalDetailsId] [bigint] NOT NULL,
	[MasterId] [bigint] NOT NULL,
	[AccountNo] [bigint] NOT NULL,
	[Debit] [decimal](18, 4) NOT NULL,
	[Credit] [decimal](18, 4) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[CompanyId] [int] NOT NULL,
	[VoucherNo] [varchar](50) NULL,
 CONSTRAINT [PK_JournalDetails] PRIMARY KEY CLUSTERED 
(
	[JournalDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[JournalMaster]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JournalMaster](
	[JournalId] [bigint] NOT NULL,
	[JournalDate] [date] NOT NULL,
	[JournalType] [nvarchar](50) NULL,
	[JournalDescription] [nvarchar](500) NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[ApprovedBy] [int] NULL,
	[ApprovedDate] [datetime] NULL,
	[CompanyId] [int] NOT NULL,
	[PostDate] [datetime] NULL,
	[CostCenterId] [int] NULL,
 CONSTRAINT [PK_JournalMaster] PRIMARY KEY CLUSTERED 
(
	[JournalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ListTable]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListTable](
	[Id] [int] NOT NULL,
	[ListType] [nvarchar](50) NOT NULL,
	[ListId] [int] NOT NULL,
	[ListValue] [nvarchar](150) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierId] [bigint] NOT NULL,
	[SupplierName] [nvarchar](500) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[UpdateBy] [bigint] NULL,
	[UpdateDate] [datetime] NULL,
	[TotalDebit] [numeric](18, 4) NULL,
	[TotalCredit] [numeric](18, 4) NULL,
	[Balance]  AS ([TotalDebit]-[TotalCredit]),
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[RoleId] [int] NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRoleMapping]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoleMapping](
	[MappingId] [bigint] NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoleMapping] PRIMARY KEY CLUSTERED 
(
	[MappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[EmployeeId] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[vewAppFunctionalityMenu]    Script Date: 11/18/2015 12:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vewAppFunctionalityMenu]
AS
SELECT        TOP (100) PERCENT dbo.AppPermission.Id, dbo.AppPermission.RoleId, dbo.AppPermission.UserId, dbo.AppPermission.CompanyId, dbo.AppFunctionality.Functionality, dbo.AppFunctionality.Url, 
                         dbo.AppFunctionality.IsActive, dbo.AppFunctionality.Sequence, dbo.AppPermission.FunctionalityId, dbo.AppFunctionality.ModuleId, dbo.AppModule.Module, dbo.AppFunctionality.ParentId, 
                         dbo.AppFunctionality.IsCompanySpecific, dbo.AppPermission.IsView, dbo.AppPermission.IsInsert, dbo.AppPermission.IsUpdate, dbo.AppPermission.IsDelete, dbo.AppPermission.IsApprove
FROM            dbo.AppModule INNER JOIN
                         dbo.AppFunctionality ON dbo.AppModule.Id = dbo.AppFunctionality.ModuleId INNER JOIN
                         dbo.AppPermission ON dbo.AppFunctionality.Id = dbo.AppPermission.FunctionalityId
ORDER BY dbo.AppFunctionality.ModuleId, dbo.AppFunctionality.Sequence







GO
INSERT [dbo].[Addresses] ([AddressId], [SourceType], [SourceId], [AddressType], [AddressLine1], [AddressLine2], [City], [ZipCode], [CountryId], [Phone], [Mobile], [Email], [Web], [CompanyId]) VALUES (0, N'Company', 1, N'Billing Address', N'Dhaka', N'Dhaka', N'Dhaka', N'1208', 9, N'1234156456', N'123456', N'asd@gmail.com', N'www.google.com', 1)
INSERT [dbo].[Addresses] ([AddressId], [SourceType], [SourceId], [AddressType], [AddressLine1], [AddressLine2], [City], [ZipCode], [CountryId], [Phone], [Mobile], [Email], [Web], [CompanyId]) VALUES (1, N'Company', 1, N'Company', N'Gazipur Industrial Area', N'Savar EPZ', N'Dhaka', N'1250', 11, N'5142780', N'5142780', N'incepta@mail.com', N'www.incepta.pharm.bd', 1)
INSERT [dbo].[AppFunctionality] ([Id], [CompanyId], [ModuleId], [Functionality], [Url], [ParentId], [IsCompanySpecific], [IsActive], [Sequence], [Icon]) VALUES (10, 1, 1, N'Accounts', N'#', 0, 1, 1, 0, N'fa fa-edit')
INSERT [dbo].[AppFunctionality] ([Id], [CompanyId], [ModuleId], [Functionality], [Url], [ParentId], [IsCompanySpecific], [IsActive], [Sequence], [Icon]) VALUES (11, 1, 1, N'Journal', N'JournalInformationDetail.aspx', 10, 1, 1, 1, N'fa fa-circle-o')
INSERT [dbo].[AppFunctionality] ([Id], [CompanyId], [ModuleId], [Functionality], [Url], [ParentId], [IsCompanySpecific], [IsActive], [Sequence], [Icon]) VALUES (12, 1, 3, N'Journal Lists', N'JournalMasterList.aspx', 10, 1, 1, 2, N'fa fa-circle-o')
INSERT [dbo].[AppFunctionality] ([Id], [CompanyId], [ModuleId], [Functionality], [Url], [ParentId], [IsCompanySpecific], [IsActive], [Sequence], [Icon]) VALUES (20, 1, 4, N'Setup', N'#', 0, 1, 1, 0, N'fa fa-edit')
INSERT [dbo].[AppFunctionality] ([Id], [CompanyId], [ModuleId], [Functionality], [Url], [ParentId], [IsCompanySpecific], [IsActive], [Sequence], [Icon]) VALUES (21, 1, 4, N'Company Info', N'CompanyInfo.aspx', 20, 1, 1, 1, N'fa fa-circle-o')
INSERT [dbo].[AppFunctionality] ([Id], [CompanyId], [ModuleId], [Functionality], [Url], [ParentId], [IsCompanySpecific], [IsActive], [Sequence], [Icon]) VALUES (22, 1, 4, N'Chart Of Account Group', N'ChartOfAccountGroupInfo.aspx', 20, 1, 1, 2, N'fa fa-circle-o')
INSERT [dbo].[AppFunctionality] ([Id], [CompanyId], [ModuleId], [Functionality], [Url], [ParentId], [IsCompanySpecific], [IsActive], [Sequence], [Icon]) VALUES (23, 1, 4, N'Bank Account Info', N'BankAccountsInfo.aspx', 20, 1, 1, 3, N'fa fa-circle-o')
INSERT [dbo].[AppFunctionality] ([Id], [CompanyId], [ModuleId], [Functionality], [Url], [ParentId], [IsCompanySpecific], [IsActive], [Sequence], [Icon]) VALUES (24, 1, 4, N'Chart of Account', N'ChartOfAccounting.aspx', 20, 1, 1, 4, N'fa fa-circle-o')
INSERT [dbo].[AppFunctionality] ([Id], [CompanyId], [ModuleId], [Functionality], [Url], [ParentId], [IsCompanySpecific], [IsActive], [Sequence], [Icon]) VALUES (25, 1, 4, N'Contact and Address', N'ContactAndAddress.aspx', 20, 1, 1, 5, N'fa fa-circle-o')
INSERT [dbo].[AppFunctionality] ([Id], [CompanyId], [ModuleId], [Functionality], [Url], [ParentId], [IsCompanySpecific], [IsActive], [Sequence], [Icon]) VALUES (26, 1, 4, N' Cost Center Info', N'CostCenterInfo.aspx', 20, 1, 1, 6, N'fa fa-circle-o')
INSERT [dbo].[AppFunctionality] ([Id], [CompanyId], [ModuleId], [Functionality], [Url], [ParentId], [IsCompanySpecific], [IsActive], [Sequence], [Icon]) VALUES (27, 1, 4, N'Customer Info', N'CustomerInfo.aspx', 20, 1, 1, 7, N'fa fa-circle-o')
INSERT [dbo].[AppFunctionality] ([Id], [CompanyId], [ModuleId], [Functionality], [Url], [ParentId], [IsCompanySpecific], [IsActive], [Sequence], [Icon]) VALUES (28, 1, 4, N'Department Info', N'DepartmentInfo.aspx', 20, 1, 1, 8, N'fa fa-circle-o')
INSERT [dbo].[AppFunctionality] ([Id], [CompanyId], [ModuleId], [Functionality], [Url], [ParentId], [IsCompanySpecific], [IsActive], [Sequence], [Icon]) VALUES (30, 1, 4, N'Employee Info', N'EmployeeInfo.aspx', 20, 1, 1, 10, N'fa fa-circle-o')
INSERT [dbo].[AppFunctionality] ([Id], [CompanyId], [ModuleId], [Functionality], [Url], [ParentId], [IsCompanySpecific], [IsActive], [Sequence], [Icon]) VALUES (31, 1, 4, N'ListTable Info', N'ListTableInfo.aspx', 20, 1, 1, 11, N'fa fa-circle-o')
INSERT [dbo].[AppFunctionality] ([Id], [CompanyId], [ModuleId], [Functionality], [Url], [ParentId], [IsCompanySpecific], [IsActive], [Sequence], [Icon]) VALUES (32, 1, 4, N'Supplier Info ', N'SupplierInfo.aspx', 20, 1, 1, 12, N'fa fa-circle-o')
INSERT [dbo].[AppFunctionality] ([Id], [CompanyId], [ModuleId], [Functionality], [Url], [ParentId], [IsCompanySpecific], [IsActive], [Sequence], [Icon]) VALUES (33, 1, 4, N'User Info', N'UserInfo.aspx', 20, 1, 1, 13, N'fa fa-circle-o')
INSERT [dbo].[AppFunctionality] ([Id], [CompanyId], [ModuleId], [Functionality], [Url], [ParentId], [IsCompanySpecific], [IsActive], [Sequence], [Icon]) VALUES (34, 1, 4, N'Bank Info Details', N'BankInfoDetails.aspx', 20, 1, 1, 14, N'fa fa-circle-o')
INSERT [dbo].[AppModule] ([Id], [Module], [CompanyId], [AdminId]) VALUES (1, N'Accounts', 1, 1)
INSERT [dbo].[AppModule] ([Id], [Module], [CompanyId], [AdminId]) VALUES (2, N'Customer', 1, 1)
INSERT [dbo].[AppModule] ([Id], [Module], [CompanyId], [AdminId]) VALUES (3, N'Supplier', 1, 1)
INSERT [dbo].[AppModule] ([Id], [Module], [CompanyId], [AdminId]) VALUES (4, N'Setup', 1, 1)
INSERT [dbo].[AppModule] ([Id], [Module], [CompanyId], [AdminId]) VALUES (5, N'Banks', 1, 1)
INSERT [dbo].[AppModule] ([Id], [Module], [CompanyId], [AdminId]) VALUES (6, N'User Management', 1, 1)
INSERT [dbo].[AppModule] ([Id], [Module], [CompanyId], [AdminId]) VALUES (7, N'Report', 1, 1)
INSERT [dbo].[AppModule] ([Id], [Module], [CompanyId], [AdminId]) VALUES (8, N'Bank Info', 0, 0)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (1, 1, 0, 0, 10, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (2, 1, 0, 0, 11, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (3, 1, 0, 0, 12, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (4, 1, 0, 0, 20, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (5, 1, 0, 0, 21, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (6, 1, 0, 0, 6, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (7, 1, 0, 0, 22, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (8, 1, 0, 0, 23, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (9, 1, 0, 0, 24, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (10, 1, 0, 0, 25, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (11, 1, 0, 0, 26, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (12, 1, 0, 0, 27, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (13, 1, 0, 0, 28, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (14, 1, 0, 0, 29, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (15, 1, 0, 0, 30, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (16, 1, 0, 0, 31, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (17, 1, 0, 0, 32, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (18, 1, 0, 0, 33, 1, 1, 1, 1, 1)
INSERT [dbo].[AppPermission] ([Id], [RoleId], [UserId], [CompanyId], [FunctionalityId], [IsView], [IsInsert], [IsUpdate], [IsDelete], [IsApprove]) VALUES (19, 1, 0, 0, 34, 1, 1, 1, 1, 1)
INSERT [dbo].[Bank] ([BankId], [BankCode], [BankName], [ContactPerson], [ContactDesignation], [ContactNo], [ContactEmail], [CompanyId], [IsActive], [UpdatedBy], [UpdatedDate]) VALUES (0, N'1208', N'Dhaka Bank', N'Karim', N'Manager', N'01670175236', N'incepta@mail.com', 1, 1, 1, CAST(0x0000A54500000000 AS DateTime))
INSERT [dbo].[Bank] ([BankId], [BankCode], [BankName], [ContactPerson], [ContactDesignation], [ContactNo], [ContactEmail], [CompanyId], [IsActive], [UpdatedBy], [UpdatedDate]) VALUES (1, N'BBL', N'Bangladesh Bank', N'Anwar', N'HR', N'01010101', N'an@gmail.com', 1, 1, 1, CAST(0x0000A55200000000 AS DateTime))
INSERT [dbo].[BankAccounts] ([BankAccountId], [BankId], [BranchName], [AccountNo], [AccountTitle], [AccountType], [OpeningDate], [CompanyId], [IsActive]) VALUES (0, 0, N'Panthapath', N'bddl/01/2015', N'Drug Land account', N'Current', CAST(0x9E3A0B00 AS Date), 1, 1)
INSERT [dbo].[BankAccounts] ([BankAccountId], [BankId], [BranchName], [AccountNo], [AccountTitle], [AccountType], [OpeningDate], [CompanyId], [IsActive]) VALUES (1, 0, N'gulshan', N'0124517', N'title', N'Savings', CAST(0x993A0B00 AS Date), 1, 1)
INSERT [dbo].[BankAccounts] ([BankAccountId], [BankId], [BranchName], [AccountNo], [AccountTitle], [AccountType], [OpeningDate], [CompanyId], [IsActive]) VALUES (2, 0, N'gulshan', N'0124517', N'title', N'Current', CAST(0xB53A0B00 AS Date), 1, 1)
INSERT [dbo].[ChartOfAccountGroup] ([CoaGroupId], [CoaGroupName], [ParentId], [IsActive], [UpdateBy], [UpdateDate], [CompanyId]) VALUES (0, N'Incepta', 0, 0, 1, CAST(0x0000A54500D5DCD4 AS DateTime), 0)
INSERT [dbo].[ChartOfAccountGroup] ([CoaGroupId], [CoaGroupName], [ParentId], [IsActive], [UpdateBy], [UpdateDate], [CompanyId]) VALUES (1, N'Petty Cash', 1, 1, 1, CAST(0x0000A54D00B263F8 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([CompanyId], [CompanyName], [Address], [Phone], [Email], [Web], [LogoPath], [UpdateBy], [UpdateDate], [IsActive]) VALUES (1, N'Acme', N'Dhaka ', N'456456456', N'acme@gmail.com', N'www.acme.com', N'www.acme.com/logo.gif', 1, CAST(0x0000A53100000000 AS DateTime), 1)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [Address], [Phone], [Email], [Web], [LogoPath], [UpdateBy], [UpdateDate], [IsActive]) VALUES (5, N'square', N'dhaka', N'1245136', N'd@mail.com', N'www.sq.com', N'www.sq.com.logo', 1, CAST(0x0000A53100000000 AS DateTime), 1)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [Address], [Phone], [Email], [Web], [LogoPath], [UpdateBy], [UpdateDate], [IsActive]) VALUES (1005, N'Beximco', N'Beximco Pharma', N'+8801472426535', N'beximco@beximcopharma.com', N'www.beximcopharma.com', N'www.beximcopharma.com/logo.gif', 1, CAST(0x0000A53201241958 AS DateTime), 1)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [Address], [Phone], [Email], [Web], [LogoPath], [UpdateBy], [UpdateDate], [IsActive]) VALUES (1006, N'Orion', N'dhaka', N'4875120', N'orion@mail.com', N'www.orion.com.bd', N'www.orion.com.bd/logo.html', 1, CAST(0x0000A54300DE0AF8 AS DateTime), 1)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [Address], [Phone], [Email], [Web], [LogoPath], [UpdateBy], [UpdateDate], [IsActive]) VALUES (1007, N'adc', N'test', N'4875120', N'beximco@beximcopharma.com', N'www.beximcopharma.com', N'www.square.com/logo.html', 1, CAST(0x0000A54D00B0BA94 AS DateTime), 1)
INSERT [dbo].[Company] ([CompanyId], [CompanyName], [Address], [Phone], [Email], [Web], [LogoPath], [UpdateBy], [UpdateDate], [IsActive]) VALUES (1008, N'adc', N'test', N'4875120', N'square@mail.com', N'www.beximcopharma.com', N'www.orion.com.bd/logo.html', 1, CAST(0x0000A54D00B196E4 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Company] OFF
INSERT [dbo].[Contacts] ([ContactId], [SourceType], [SourceId], [ContactName], [ContactDesignation], [IsMainContact], [Phone], [Mobile], [Email], [CompanyId]) VALUES (0, N'Name', 1, N'Mr Hawlader', N'1', 0, N'123123', N'123123', N'mdasdas@asdmasd.com', 0)
INSERT [dbo].[CostCenter] ([CostCenterId], [CostCenterType], [CostCenterName], [IsActive], [CompanyId], [UpdateBy], [UpdateDate]) VALUES (0, N'Centre-1', N'NameCentre -1', 1, 1, 1, CAST(0x0000A53C00000000 AS DateTime))
INSERT [dbo].[Customer] ([CustomerId], [CustomerName], [CustomerCategoryId], [SalesPersonId], [IsActive], [CompanyId], [CreditLimit], [UpdateBy], [UpdateDate], [TotalDebit], [TotalCredit]) VALUES (0, N'omi', 1, 0, 1, 1, CAST(1000 AS Numeric(18, 0)), 1, CAST(0x0000A54500D3FFE0 AS DateTime), CAST(0.0000 AS Numeric(18, 4)), CAST(0.0000 AS Numeric(18, 4)))
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [ParentDepartmentId], [IsActive], [UpdateBy], [UpdateDate], [CompanyId]) VALUES (1, N'Human Resource', 1, 1, 1, CAST(0x0000A534011E6C38 AS DateTime), 1005)
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [ParentDepartmentId], [IsActive], [UpdateBy], [UpdateDate], [CompanyId]) VALUES (2, N'Marketing', 1, 1, 1, CAST(0x0000A534012061C8 AS DateTime), 1)
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [ParentDepartmentId], [IsActive], [UpdateBy], [UpdateDate], [CompanyId]) VALUES (3, N'Finance', 1, 1, 1, CAST(0x0000A5340120735C AS DateTime), 1005)
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [ParentDepartmentId], [IsActive], [UpdateBy], [UpdateDate], [CompanyId]) VALUES (0, N'Management', 1, 1, 1, CAST(0x0000A544013A2770 AS DateTime), 5)
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [ParentDepartmentId], [IsActive], [UpdateBy], [UpdateDate], [CompanyId]) VALUES (1, N'Management', 1, 1, 1, CAST(0x0000A544013C0B6C AS DateTime), 5)
INSERT [dbo].[Designation] ([DesignationId], [Designation], [DepartmentId], [CompanyId], [IsActive], [UpdateBy], [UpdateDate]) VALUES (1, N'Manager', 1, 1, 1, 1, CAST(0x0000A52400000000 AS DateTime))
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeCode], [EmployeeName], [Address], [DOB], [JoinDate], [DepartmentId], [DesignationId], [CompanyId], [IsActive], [UpdateBy], [UpdateDate]) VALUES (0, N'1208', N'Zahid', N'Home', CAST(0xA53A0B00 AS Date), CAST(0xA13A0B00 AS Date), 0, 0, 0, 1, 1, CAST(0x0000A544012E2A4C AS DateTime))
INSERT [dbo].[JournalDetails] ([JournalDetailsId], [MasterId], [AccountNo], [Debit], [Credit], [Description], [CompanyId], [VoucherNo]) VALUES (1, 1, 0, CAST(1000.0000 AS Decimal(18, 4)), CAST(0.0000 AS Decimal(18, 4)), N'test', 0, N'JV-1-2015')
INSERT [dbo].[JournalDetails] ([JournalDetailsId], [MasterId], [AccountNo], [Debit], [Credit], [Description], [CompanyId], [VoucherNo]) VALUES (2, 1, 0, CAST(0.0000 AS Decimal(18, 4)), CAST(1000.0000 AS Decimal(18, 4)), N'test', 0, N'JV-2-2015')
INSERT [dbo].[JournalMaster] ([JournalId], [JournalDate], [JournalType], [JournalDescription], [UpdateBy], [UpdateDate], [ApprovedBy], [ApprovedDate], [CompanyId], [PostDate], [CostCenterId]) VALUES (1, CAST(0xA03A0B00 AS Date), N'Document', N'test', 1, CAST(0x0000A54D00AFAF64 AS DateTime), NULL, NULL, 1, NULL, 0)
INSERT [dbo].[ListTable] ([Id], [ListType], [ListId], [ListValue], [CompanyId], [IsActive], [UpdateBy], [UpdateDate]) VALUES (0, N'Journal', 1, N'Invoice', 1, 1, 1, CAST(0x0000A53C00000000 AS DateTime))
INSERT [dbo].[ListTable] ([Id], [ListType], [ListId], [ListValue], [CompanyId], [IsActive], [UpdateBy], [UpdateDate]) VALUES (1, N'Document', 1, N'12', 0, 1, 1, CAST(0x0000A5440133C4AC AS DateTime))
INSERT [dbo].[ListTable] ([Id], [ListType], [ListId], [ListValue], [CompanyId], [IsActive], [UpdateBy], [UpdateDate]) VALUES (0, N'Journal New', 2, N'22', 0, 1, 1, CAST(0x0000A5440134E3C8 AS DateTime))
INSERT [dbo].[Supplier] ([SupplierId], [SupplierName], [IsActive], [CompanyId], [UpdateBy], [UpdateDate], [TotalDebit], [TotalCredit]) VALUES (1, N'Incepta', 1, 1, 1, CAST(0x0000A54500D524D8 AS DateTime), CAST(1000.0000 AS Numeric(18, 4)), CAST(1208.0000 AS Numeric(18, 4)))
INSERT [dbo].[UserRole] ([RoleId], [RoleName], [IsActive], [UpdateBy], [UpdateDate], [CompanyId]) VALUES (1, N'Super', 1, 1, CAST(0x0000A41300000000 AS DateTime), 0)
INSERT [dbo].[UserRoleMapping] ([MappingId], [UserId], [RoleId]) VALUES (1, 1, 1)
INSERT [dbo].[Users] ([UserId], [UserName], [UserPassword], [IsActive], [UpdateBy], [UpdateDate], [CompanyId], [EmployeeId]) VALUES (1, N'Super', N'pass12', 1, 1, CAST(0x0000A41300000000 AS DateTime), 0, 0)
USE [master]
GO
ALTER DATABASE [DrugLandDB] SET  READ_WRITE 
GO
