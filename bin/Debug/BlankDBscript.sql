USE [master] 
GO
USE [RPOS_DB]
GO
--Added by Jaemsoft tech 12/02/2020 2:04AM
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblstock](
	[No#] [int] IDENTITY(1,1) NOT NULL, 
	[Item] [nvarchar](100) NULL,
	[Tarehe] date NULL,
	[Stock] [decimal](15, 2) NULL,
	[PLUS_MINUS] [nvarchar](100) NULL,
	[Total] [decimal](15, 2) NULL,
	[Sold] [decimal](15, 2) NULL,
	[Balance] [decimal](15, 2) NULL,
	[Narration] [nvarchar](100) NULL
 CONSTRAINT [PK_STOCK] PRIMARY KEY CLUSTERED 
(
	[No#] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO  
/****** Object:  Table [dbo].[Activation]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HardwareID] [nchar](100) NOT NULL,
	[ActivationID] [nchar](150) NOT NULL,
 CONSTRAINT [PK_Activation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryName] [nvarchar](250) NOT NULL,
	[VAT] [decimal](18, 2) NULL,
	[ST] [decimal](18, 2) NULL,
	[SC] [decimal](18, 2) NULL,
	[BackColor] [int] NULL,
	[Cat_ID] [int] IDENTITY(1,1) NOT NULL,
	[Kitchen] [nchar](200) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CreditCustomer]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCustomer](
	[CC_ID] [int] NOT NULL,
	[CreditCustomerID] [nchar](30) NOT NULL,
	[Name] [nchar](200) NULL,
	[ContactNo] [nchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[OpeningBalance] [decimal](18, 2) NULL,
	[OpeningBalanceType] [nchar](10) NULL,
	[RegistrationDate] [datetime] NULL,
	[Active] [nchar](10) NULL,
 CONSTRAINT [PK_CreditCustomer] PRIMARY KEY CLUSTERED 
(
	[CC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CreditCustomerLedger]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCustomerLedger](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[LedgerNo] [nchar](50) NULL,
	[Label] [nchar](200) NULL,
	[Debit] [decimal](18, 2) NULL,
	[Credit] [decimal](18, 2) NULL,
	[CreditCustomer_ID] [int] NULL,
 CONSTRAINT [PK_CreditCustomerLedger] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CreditCustomerPayment]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCustomerPayment](
	[T_ID] [int] NOT NULL,
	[TransactionID] [nchar](20) NULL,
	[Date] [datetime] NOT NULL,
	[PaymentMode] [nchar](30) NULL,
	[CreditCustomer_ID] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](250) NULL,
	[PaymentModeDetails] [nvarchar](250) NULL,
 CONSTRAINT [PK_CreditCustomerPayment] PRIMARY KEY CLUSTERED 
(
	[T_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Currency]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[CurrencyCode] [nchar](10) NOT NULL,
	[Currencyname] [nchar](200) NOT NULL,
	[Rate] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_CurrencyRate] PRIMARY KEY CLUSTERED 
(
	[CurrencyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dish]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dish](
	[DishName] [nvarchar](250) NOT NULL,
	[Category] [nvarchar](250) NULL,
	[DIRate] [decimal](18, 2) NULL,
	[TARate] [decimal](18, 2) NULL,
	[HDRate] [decimal](18, 2) NULL,
	[BackColor] [int] NULL,
	[Barcode] [nchar](30) NULL,
	[MI_Status] [nchar](20) NULL,
	[DishID] [int] NULL,
	[Photo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Dish] PRIMARY KEY CLUSTERED 
(
	[DishName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmailSetting]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailSetting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServerName] [nchar](150) NOT NULL,
	[SMTPAddress] [nvarchar](250) NOT NULL,
	[Username] [nchar](200) NOT NULL,
	[Password] [nchar](100) NOT NULL,
	[Port] [int] NOT NULL,
	[TLS_SSL_Required] [nchar](10) NOT NULL,
	[IsDefault] [nchar](10) NOT NULL,
	[IsActive] [nchar](10) NOT NULL,
 CONSTRAINT [PK_EmailSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeRegistration]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeRegistration](
	[EmpId] [int] NOT NULL,
	[EmployeeID] [nchar](15) NOT NULL,
	[EmployeeName] [nchar](150) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[City] [nchar](150) NOT NULL,
	[ContactNo] [nchar](30) NOT NULL,
	[Email] [nchar](150) NOT NULL,
	[DateOfJoining] [datetime] NOT NULL,
	[Photo] [image] NOT NULL,
	[Active] [nchar](20) NULL,
 CONSTRAINT [PK_EmployeeRegistration] PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Expense]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expense](
	[ExpenseName] [nvarchar](250) NOT NULL,
	[ExpenseType] [nchar](200) NOT NULL,
 CONSTRAINT [PK_Expense_1] PRIMARY KEY CLUSTERED 
(
	[ExpenseName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExpenseType]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenseType](
	[Type] [nchar](200) NOT NULL,
 CONSTRAINT [PK_ExpenseType] PRIMARY KEY CLUSTERED 
(
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GridGrouping]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GridGrouping](
	[Id] [int] NOT NULL,
	[Col1] [nvarchar](250) NOT NULL,
	[Col2] [int] NOT NULL,
 CONSTRAINT [PK_GridGrouping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HDCustomer]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HDCustomer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nchar](150) NULL,
	[Address] [nvarchar](max) NULL,
	[ContactNo] [nchar](50) NULL,
 CONSTRAINT [PK_HDCustomer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HotelName] [nchar](150) NULL,
	[AddressLine1] [nvarchar](250) NULL,
	[AddressLine2] [nvarchar](250) NULL,
	[AddressLine3] [nvarchar](250) NULL,
	[ContactNo] [nchar](100) NULL,
	[EmailID] [nchar](150) NULL,
	[TIN] [nchar](30) NULL,
	[STNo] [nchar](30) NULL,
	[CIN] [nchar](30) NULL,
	[Logo] [image] NULL,
	[BaseCurrency] [nchar](200) NULL,
	[CurrencyCode] [nchar](10) NULL,
	[TicketFooterMessage] [nvarchar](250) NULL,
	[ShowLogo] [nchar](20) NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Journal]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journal](
	[ID] [int] NOT NULL,
	[DebitAccount] [nchar](200) NULL,
	[CreditAccount] [nchar](200) NULL,
	[Date] [datetime] NULL,
	[Amount] [decimal](18, 2) NULL,
	[Remarks] [nvarchar](max) NULL,
 CONSTRAINT [PK_Journal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kitchen]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kitchen](
	[Kitchenname] [nchar](200) NOT NULL,
	[Printer] [nvarchar](250) NOT NULL,
	[IsEnabled] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Kitchen] PRIMARY KEY CLUSTERED 
(
	[Kitchenname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LedgerBook]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LedgerBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[Name] [nchar](200) NULL,
	[LedgerNo] [nchar](200) NULL,
	[Label] [nchar](200) NULL,
	[AccLedger] [nchar](200) NULL,
	[Debit] [decimal](18, 2) NULL,
	[Credit] [decimal](18, 2) NULL,
	[PartyID] [nchar](50) NULL,
 CONSTRAINT [PK_LedgerBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nchar](100) NOT NULL,
	[Operation] [nvarchar](250) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoyaltyMember]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoyaltyMember](
	[MemberID] [int] NOT NULL,
	[Name] [nchar](200) NULL,
	[ContactNo] [nchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[RegistrationDate] [datetime] NULL,
	[Active] [nchar](10) NULL,
 CONSTRAINT [PK_LoyaltyMember] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoyaltyMemberLedgerBook]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoyaltyMemberLedgerBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[LedgerNo] [nchar](50) NOT NULL,
	[Label] [nchar](200) NOT NULL,
	[PointsEarned] [decimal](18, 2) NOT NULL,
	[PointsRedeem] [decimal](18, 2) NOT NULL,
	[MemberID] [int] NULL,
 CONSTRAINT [PK_LoyaltyMemberBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoyaltySetting]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoyaltySetting](
	[LoyaltyName] [nchar](150) NOT NULL,
	[Amount] [decimal](18, 2) NULL,
	[Points] [int] NULL,
 CONSTRAINT [PK_LoyaltySetting] PRIMARY KEY CLUSTERED 
(
	[LoyaltyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Member]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[MemberID] [int] NOT NULL,
	[Name] [nchar](200) NULL,
	[ContactNo] [nchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[RegistrationDate] [datetime] NULL,
	[Active] [nchar](10) NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MemberLedger]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberLedger](
	[Id] [int] NOT NULL,
	[Date] [datetime] NULL,
	[LedgerNo] [nchar](50) NULL,
	[Label] [nchar](200) NULL,
	[Debit] [decimal](18, 2) NULL,
	[Credit] [decimal](18, 2) NULL,
	[MemberID] [int] NULL,
 CONSTRAINT [PK_MemberLedger] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Modifiers]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modifiers](
	[MIM_ID] [int] NOT NULL,
	[ModifierName] [nvarchar](250) NULL,
	[Item] [nvarchar](250) NULL,
	[Rate] [decimal](18, 2) NULL,
	[BackColor] [int] NULL,
 CONSTRAINT [PK_Modifiers] PRIMARY KEY CLUSTERED 
(
	[MIM_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NotesMaster]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotesMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Notes] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_NotesMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OtherSetting]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtherSetting](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParcelCharges] [decimal](18, 2) NULL,
	[HomeDeliveryCharges] [decimal](18, 2) NULL,
	[VAT] [decimal](18, 2) NULL,
	[ServiceTax] [decimal](18, 2) NULL,
	[ServiceCharges] [decimal](18, 2) NULL,
	[TA] [nchar](10) NULL,
	[HD] [nchar](10) NULL,
	[EB] [nchar](10) NULL,
	[KG] [nchar](10) NULL,
	[TaxType] [nchar](20) NULL,
 CONSTRAINT [PK_OtherCharges] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[T_ID] [int] NOT NULL,
	[TransactionID] [nchar](20) NULL,
	[Date] [datetime] NOT NULL,
	[PaymentMode] [nchar](30) NULL,
	[SupplierID] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](250) NULL,
	[PaymentModeDetails] [nvarchar](250) NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[T_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PizzaMaster]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PizzaMaster](
	[Pizza_ID] [int] NOT NULL,
	[PizzaName] [nchar](200) NULL,
	[PizzaSize] [nchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[Discount] [decimal](18, 2) NULL,
	[Rate] [decimal](18, 2) NULL,
	[BackColor] [int] NULL,
 CONSTRAINT [PK_PizzaMaster] PRIMARY KEY CLUSTERED 
(
	[Pizza_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PizzaSize]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PizzaSize](
	[Size] [nchar](100) NOT NULL,
 CONSTRAINT [PK_PizzaSize] PRIMARY KEY CLUSTERED 
(
	[Size] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PizzaTopping]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PizzaTopping](
	[T_ID] [int] NOT NULL,
	[ToppingName] [nchar](200) NULL,
	[PizzaSize] [nchar](100) NULL,
	[Rate] [decimal](18, 2) NULL,
	[BackColor] [int] NULL,
 CONSTRAINT [PK_PizzaTopping] PRIMARY KEY CLUSTERED 
(
	[T_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PosGrouping]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PosGrouping](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Col1] [nvarchar](250) NULL,
	[Col2] [decimal](18, 2) NULL,
	[Col3] [int] NULL,
	[Col4] [decimal](18, 2) NULL,
	[Col5] [decimal](18, 2) NULL,
	[Col6] [decimal](18, 2) NULL,
	[Col7] [decimal](18, 2) NULL,
	[Col8] [decimal](18, 2) NULL,
	[Col9] [decimal](18, 2) NULL,
	[Col10] [decimal](18, 2) NULL,
	[Col11] [decimal](18, 2) NULL,
	[Col12] [decimal](18, 2) NULL,
	[Col13] [decimal](18, 2) NULL,
	[Col14] [nvarchar](max) NULL,
	[Col15] [int] NULL,
	[Col16] [nchar](200) NULL,
 CONSTRAINT [PK_PosGroupingTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PosGrouping1]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PosGrouping1](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Col1] [nvarchar](250) NULL,
	[Col2] [decimal](18, 2) NULL,
	[Col3] [int] NULL,
	[Col4] [decimal](18, 2) NULL,
	[Col5] [decimal](18, 2) NULL,
	[Col6] [decimal](18, 2) NULL,
	[Col7] [decimal](18, 2) NULL,
	[Col8] [decimal](18, 2) NULL,
	[Col9] [decimal](18, 2) NULL,
	[Col10] [decimal](18, 2) NULL,
	[Col11] [decimal](18, 2) NULL,
	[Col12] [decimal](18, 2) NULL,
	[Col13] [decimal](18, 2) NULL,
	[Col14] [nvarchar](max) NULL,
	[Col15] [int] NULL,
	[Col16] [nchar](200) NULL,
 CONSTRAINT [PK_PosGrouping1Table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PosPrinterSetting]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PosPrinterSetting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TillID] [nchar](200) NULL,
	[PrinterName] [nvarchar](250) NULL,
	[IsEnabled] [nchar](20) NULL,
	[CashDrawer] [nchar](20) NULL,
	[CustomerDisplay] [nchar](20) NULL,
	[CDPort] [nchar](20) NULL,
	[CallerID] [nchar](20) NULL,
	[CallerIDPort] [nchar](20) NULL,
	[SMII] [nchar](20) NULL,
 CONSTRAINT [PK_PosPrinterSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[PID] [int] NOT NULL,
	[ProductCode] [nchar](30) NOT NULL,
	[ProductName] [nchar](200) NOT NULL,
	[Category] [nchar](150) NULL,
	[Description] [nvarchar](max) NULL,
	[Unit] [nchar](50) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ReorderPoint] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[PID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product_OpeningStock]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_OpeningStock](
	[PS_ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Warehouse] [nchar](250) NOT NULL,
	[Qty] [decimal](18, 2) NOT NULL,
	[HasExpiryDate] [nchar](10) NULL,
	[ExpiryDate] [nchar](50) NULL,
 CONSTRAINT [PK_Product_OpeningStock] PRIMARY KEY CLUSTERED 
(
	[PS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[ST_ID] [int] NOT NULL,
	[InvoiceNo] [nchar](30) NOT NULL,
	[Date] [datetime] NOT NULL,
	[PurchaseType] [nchar](20) NOT NULL,
	[Supplier_ID] [int] NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[DiscountPer] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[PreviousDue] [decimal](18, 2) NOT NULL,
	[FreightCharges] [decimal](18, 2) NOT NULL,
	[OtherCharges] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[RoundOff] [decimal](18, 2) NOT NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
	[TotalPayment] [decimal](18, 2) NOT NULL,
	[PaymentDue] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
	[HST] [decimal](18, 2) NULL,
	[HSTPer] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[ST_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Purchase_Join]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase_Join](
	[SP_ID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Qty] [decimal](18, 2) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[Warehouse] [nchar](250) NOT NULL,
	[HasExpirydate] [nchar](10) NULL,
	[ExpiryDate] [nchar](50) NULL,
 CONSTRAINT [PK_Purchase_Join] PRIMARY KEY CLUSTERED 
(
	[SP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[PO_ID] [int] NOT NULL,
	[PONumber] [nchar](50) NOT NULL,
	[Date] [datetime] NULL,
	[Supplier_ID] [int] NULL,
	[Terms] [nvarchar](max) NULL,
	[SubTotal] [decimal](18, 2) NULL,
	[VATPer] [decimal](18, 2) NULL,
	[VATAmount] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[TaxType] [nchar](20) NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[PO_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseOrder_Join]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrder_Join](
	[POJ_ID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseOrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Qty] [decimal](18, 2) NOT NULL,
	[PricePerUnit] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_PurchaseOrder_Join] PRIMARY KEY CLUSTERED 
(
	[POJ_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[R_Table]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[R_Table](
	[TableNo] [nchar](30) NOT NULL,
	[Status] [nchar](30) NOT NULL,
	[BkColor] [int] NOT NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[TableNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Recipe]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipe](
	[R_ID] [int] NOT NULL,
	[RecipeName] [nchar](200) NOT NULL,
	[Dish] [nvarchar](250) NOT NULL,
	[FixedCost] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Recipe] PRIMARY KEY CLUSTERED 
(
	[R_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Recipe_Join]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipe_Join](
	[RJ_ID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [decimal](18, 2) NULL,
	[CostPerUnit] [decimal](18, 2) NULL,
	[TotalItemCost] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Recipe_Join] PRIMARY KEY CLUSTERED 
(
	[RJ_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Registration]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[UserID] [nchar](100) NOT NULL,
	[UserType] [nchar](30) NOT NULL,
	[Password] [nchar](50) NOT NULL,
	[Name] [nchar](150) NOT NULL,
	[ContactNo] [nchar](50) NULL,
	[EmailID] [nchar](150) NULL,
	[JoiningDate] [datetime] NOT NULL,
	[Active] [nchar](10) NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RestaurantPOS_BillingInfoEB]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantPOS_BillingInfoEB](
	[Id] [int] NOT NULL,
	[BillNo] [nchar](15) NOT NULL,
	[ODN] [nchar](30) NULL,
	[BillDate] [datetime] NULL,
	[EBDiscountPer] [decimal](18, 4) NULL,
	[EBDiscountAmt] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[Cash] [decimal](18, 2) NULL,
	[Change] [decimal](18, 2) NULL,
	[Operator] [nchar](100) NULL,
	[PaymentMode] [nchar](50) NULL,
	[BillNote] [nvarchar](max) NULL,
	[ExchangeRate] [decimal](18, 2) NOT NULL,
	[CurrencyCode] [nchar](10) NULL,
	[EB_Status] [nchar](20) NULL,
	[Member_ID] [nchar](10) NULL,
	[EB_PhoneNo] [nchar](50) NULL,
 CONSTRAINT [PK_RestaurantPOS_BillingInfoEB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RestaurantPOS_BillingInfoHD]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantPOS_BillingInfoHD](
	[Id] [int] NOT NULL,
	[BillNo] [nchar](15) NOT NULL,
	[ODN] [nchar](30) NULL,
	[BillDate] [datetime] NULL,
	[Operator] [nchar](100) NULL,
	[SubTotal] [decimal](18, 2) NULL,
	[HDDiscountPer] [decimal](18, 4) NULL,
	[HDDiscountAmt] [decimal](18, 2) NULL,
	[HomeDeliveryCharges] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[CustomerName] [nchar](200) NULL,
	[Address] [nvarchar](250) NULL,
	[ContactNo] [nchar](50) NULL,
	[Employee_ID] [int] NOT NULL,
	[PaymentMode] [nchar](50) NOT NULL,
	[BillNote] [nvarchar](max) NULL,
	[Member_ID] [nchar](10) NULL,
	[HD_Status] [nchar](30) NULL,
 CONSTRAINT [PK_RestaurantPOS_BillingInfoHD] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RestaurantPOS_BillingInfoKOT]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantPOS_BillingInfoKOT](
	[Id] [int] NOT NULL,
	[BillNo] [nchar](15) NULL,
	[BillDate] [datetime] NULL,
	[ODN] [nchar](30) NULL,
	[KOTDiscountPer] [decimal](18, 4) NULL,
	[KOTDiscountAmt] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[Cash] [decimal](18, 2) NULL,
	[Change] [decimal](18, 2) NULL,
	[Operator] [nchar](100) NULL,
	[PaymentMode] [nchar](100) NULL,
	[ExchangeRate] [decimal](18, 2) NULL,
	[CurrencyCode] [nchar](10) NULL,
	[Member_ID] [nchar](10) NULL,
	[Waiter] [nchar](200) NULL,
 CONSTRAINT [PK_RestaurantPOS_BillingInfoKOT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RestaurantPOS_BillingInfoTA]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantPOS_BillingInfoTA](
	[Id] [int] NOT NULL,
	[BillNo] [nchar](15) NOT NULL,
	[ODN] [nchar](30) NULL,
	[BillDate] [datetime] NOT NULL,
	[SubTotal] [decimal](18, 2) NULL,
	[TADiscountPer] [decimal](18, 4) NULL,
	[TADiscountAmt] [decimal](18, 2) NULL,
	[ParcelCharges] [decimal](18, 2) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[Cash] [decimal](18, 2) NULL,
	[Change] [decimal](18, 2) NULL,
	[Operator] [nchar](100) NULL,
	[PaymentMode] [nchar](50) NULL,
	[BillNote] [nvarchar](max) NULL,
	[ExchangeRate] [decimal](18, 2) NULL,
	[CurrencyCode] [nchar](10) NULL,
	[Member_ID] [nchar](10) NULL,
	[PhoneNo] [nchar](100) NULL,
	[TA_Status] [nchar](30) NULL,
 CONSTRAINT [PK_RestaurantPOS_BillingInfoTA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RestaurantPOS_OrderedProductBillEB]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantPOS_OrderedProductBillEB](
	[OP_ID] [int] IDENTITY(1,1) NOT NULL,
	[BillID] [int] NULL,
	[Dish] [nvarchar](250) NULL,
	[Rate] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[VATPer] [decimal](18, 2) NULL,
	[VATAmount] [decimal](18, 2) NULL,
	[STPer] [decimal](18, 2) NULL,
	[STAmount] [decimal](18, 2) NULL,
	[SCPer] [decimal](18, 2) NULL,
	[SCAmount] [decimal](18, 2) NULL,
	[DiscountPer] [decimal](18, 4) NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[Notes] [nvarchar](max) NULL,
	[Category] [nchar](200) NULL,
 CONSTRAINT [PK_RestaurantPOS_OrderedProductBillEB] PRIMARY KEY CLUSTERED 
(
	[OP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RestaurantPOS_OrderedProductBillHD]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantPOS_OrderedProductBillHD](
	[OP_ID] [int] IDENTITY(1,1) NOT NULL,
	[BillID] [int] NULL,
	[Dish] [nvarchar](250) NULL,
	[Rate] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[VATPer] [decimal](18, 2) NULL,
	[VATAmount] [decimal](18, 2) NULL,
	[STPer] [decimal](18, 2) NULL,
	[STAmount] [decimal](18, 2) NULL,
	[SCPer] [decimal](18, 2) NULL,
	[SCAmount] [decimal](18, 2) NULL,
	[DiscountPer] [decimal](18, 4) NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[Notes] [nvarchar](max) NULL,
	[Category] [nchar](200) NULL,
 CONSTRAINT [PK_RestaurantPOS_OrderedProductBillHD] PRIMARY KEY CLUSTERED 
(
	[OP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RestaurantPOS_OrderedProductBillKOT]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantPOS_OrderedProductBillKOT](
	[OP_ID] [int] IDENTITY(1,1) NOT NULL,
	[BillID] [int] NULL,
	[Dish] [nvarchar](250) NULL,
	[Rate] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[VATPer] [decimal](18, 2) NULL,
	[VATAmount] [decimal](18, 2) NULL,
	[STPer] [decimal](18, 2) NULL,
	[STAmount] [decimal](18, 2) NULL,
	[SCPer] [decimal](18, 2) NULL,
	[SCAmount] [decimal](18, 2) NULL,
	[DiscountPer] [decimal](18, 4) NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[TableNo] [nchar](30) NULL,
	[Category] [nchar](200) NULL,
 CONSTRAINT [PK_RestaurantPOS_OrderedProductBillKOT] PRIMARY KEY CLUSTERED 
(
	[OP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RestaurantPOS_OrderedProductBillTA]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantPOS_OrderedProductBillTA](
	[OP_ID] [int] IDENTITY(1,1) NOT NULL,
	[BillID] [int] NULL,
	[Dish] [nvarchar](250) NULL,
	[Rate] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[VATPer] [decimal](18, 2) NULL,
	[VATAmount] [decimal](18, 2) NULL,
	[STPer] [decimal](18, 2) NULL,
	[STAmount] [decimal](18, 2) NULL,
	[SCPer] [decimal](18, 2) NULL,
	[SCAmount] [decimal](18, 2) NULL,
	[DiscountPer] [decimal](18, 4) NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[Notes] [nvarchar](max) NULL,
	[Category] [nchar](200) NULL,
 CONSTRAINT [PK_RestaurantPOS_OrderedProductBillTA] PRIMARY KEY CLUSTERED 
(
	[OP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RestaurantPOS_OrderedProductKOT]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantPOS_OrderedProductKOT](
	[OP_ID] [int] IDENTITY(1,1) NOT NULL,
	[TicketID] [int] NULL,
	[Dish] [nvarchar](250) NULL,
	[Rate] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[VATPer] [decimal](18, 2) NULL,
	[VATAmount] [decimal](18, 2) NULL,
	[STPer] [decimal](18, 2) NULL,
	[STAmount] [decimal](18, 2) NULL,
	[SCPer] [decimal](18, 2) NULL,
	[SCAmount] [decimal](18, 2) NULL,
	[DiscountPer] [decimal](18, 2) NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[Notes] [nvarchar](max) NULL,
	[Category] [nchar](200) NULL,
	[T_Number] [nchar](30) NULL,
 CONSTRAINT [PK_RestaurantPOS_OrderedProductKOT] PRIMARY KEY CLUSTERED 
(
	[OP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RestaurantPOS_OrderInfoKOT]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantPOS_OrderInfoKOT](
	[ID] [int] NOT NULL,
	[TicketNo] [nchar](15) NOT NULL,
	[BillDate] [datetime] NOT NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[TableNo] [nchar](30) NULL,
	[Operator] [nchar](100) NULL,
	[GroupName] [nchar](200) NULL,
	[TicketNote] [nvarchar](max) NULL,
	[KOT_Status] [nchar](30) NULL,
 CONSTRAINT [PK_RestaurantPOS_OrderInfoKOT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RM_Used]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RM_Used](
	[RM_ID] [int] NOT NULL,
	[BillNo] [nchar](30) NULL,
	[BillDate] [datetime] NULL,
 CONSTRAINT [PK_RM_Used] PRIMARY KEY CLUSTERED 
(
	[RM_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RM_Used_Join]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RM_Used_Join](
	[RMJ_ID] [int] IDENTITY(1,1) NOT NULL,
	[RawMaterialID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [decimal](18, 2) NULL,
 CONSTRAINT [PK_RM_Used_Join] PRIMARY KEY CLUSTERED 
(
	[RMJ_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RMCategory]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RMCategory](
	[CategoryName] [nchar](150) NOT NULL,
 CONSTRAINT [PK_RMCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SMSSetting]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMSSetting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[APIURL] [nvarchar](max) NOT NULL,
	[IsDefault] [nchar](10) NOT NULL,
	[IsEnabled] [nchar](10) NOT NULL,
 CONSTRAINT [PK_SMSSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stock_Store]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock_Store](
	[St_ID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Remarks] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Stock_Store] PRIMARY KEY CLUSTERED 
(
	[St_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stock_Store_Join]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock_Store_Join](
	[SSJ_ID] [int] IDENTITY(1,1) NOT NULL,
	[StockID] [int] NOT NULL,
	[Dish] [nvarchar](250) NOT NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [PK_Stock_Store_Join] PRIMARY KEY CLUSTERED 
(
	[SSJ_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockAdjustment_Store]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockAdjustment_Store](
	[SA_ID] [int] NOT NULL,
	[Date] [datetime] NULL,
	[ProductID] [int] NULL,
	[AdjustmentType] [nchar](20) NULL,
	[Qty] [decimal](18, 2) NULL,
	[Reason] [nchar](200) NULL,
 CONSTRAINT [PK_StockAdjustment_Kitchen] PRIMARY KEY CLUSTERED 
(
	[SA_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockAdjustment_Warehouse]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockAdjustment_Warehouse](
	[SA_ID] [int] NOT NULL,
	[Date] [datetime] NULL,
	[Warehouse] [nchar](250) NULL,
	[ProductID] [int] NULL,
	[AdjustmentType] [nchar](20) NULL,
	[Qty] [decimal](18, 2) NULL,
	[Reason] [nchar](200) NULL,
 CONSTRAINT [PK_StockAdjustment_Warehouse] PRIMARY KEY CLUSTERED 
(
	[SA_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockTransfer]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockTransfer](
	[ST_ID] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Kitchen] [nchar](200) NOT NULL,
 CONSTRAINT [PK_StockTransfer_1] PRIMARY KEY CLUSTERED 
(
	[ST_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StockTransfer_Join]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockTransfer_Join](
	[STJ_ID] [int] IDENTITY(1,1) NOT NULL,
	[StockTransferID] [int] NOT NULL,
	[Warehouse] [nchar](250) NOT NULL,
	[ProductID] [int] NOT NULL,
	[ExpiryDate] [nchar](50) NULL,
	[Qty] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_StockTransfer] PRIMARY KEY CLUSTERED 
(
	[STJ_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[ID] [int] NOT NULL,
	[SupplierID] [nchar](30) NOT NULL,
	[Name] [nchar](200) NULL,
	[Address] [nvarchar](250) NULL,
	[City] [nchar](200) NULL,
	[State] [nchar](150) NULL,
	[ZipCode] [nchar](15) NULL,
	[ContactNo] [nchar](150) NULL,
	[EmailID] [nchar](200) NULL,
	[Remarks] [nvarchar](max) NULL,
	[TIN] [nchar](100) NULL,
	[STNo] [nchar](100) NULL,
	[CST] [nchar](100) NULL,
	[PAN] [nchar](100) NULL,
	[AccountName] [nchar](150) NULL,
	[AccountNumber] [nchar](100) NULL,
	[Bank] [nchar](150) NULL,
	[Branch] [nchar](150) NULL,
	[IFSCCode] [nchar](50) NULL,
	[OpeningBalance] [decimal](18, 2) NULL,
	[OpeningBalanceType] [nchar](30) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SupplierLedgerBook]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierLedgerBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Name] [nchar](200) NOT NULL,
	[LedgerNo] [nchar](50) NOT NULL,
	[Label] [nchar](200) NOT NULL,
	[Debit] [decimal](18, 2) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[PartyID] [nchar](20) NULL,
 CONSTRAINT [PK_SupplierLedgerBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblOrder]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrder](
	[OD_ID] [int] IDENTITY(1,1) NOT NULL,
	[ODNo] [int] NOT NULL,
	[BillNo] [nchar](30) NULL,
 CONSTRAINT [PK_tblOrder] PRIMARY KEY CLUSTERED 
(
	[OD_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Temp_Stock]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temp_Stock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Warehouse] [nchar](250) NOT NULL,
	[Qty] [decimal](18, 2) NOT NULL,
	[HasExpiryDate] [nchar](10) NULL,
	[ExpiryDate] [nchar](50) NULL,
 CONSTRAINT [PK_Temp_Stock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Temp_Stock_RM]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temp_Stock_RM](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Qty] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Temp_Stock_RM] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Temp_Stock_Store]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temp_Stock_Store](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Dish] [nvarchar](250) NOT NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [PK_Temp_Stock_Store] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UnitMaster]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnitMaster](
	[Unit] [nchar](50) NOT NULL,
 CONSTRAINT [PK_UnitMaster] PRIMARY KEY CLUSTERED 
(
	[Unit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher](
	[ID] [int] NOT NULL,
	[VoucherNo] [nchar](30) NOT NULL,
	[Name] [nchar](150) NULL,
	[Date] [datetime] NOT NULL,
	[Details] [nvarchar](max) NULL,
	[PaymentMode] [nchar](150) NOT NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Voucher_OtherDetails]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher_OtherDetails](
	[VD_ID] [int] IDENTITY(1,1) NOT NULL,
	[VoucherID] [int] NOT NULL,
	[Particulars] [nvarchar](250) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Voucher_OtherDetails] PRIMARY KEY CLUSTERED 
(
	[VD_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wallet]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wallet](
	[WalletType] [nchar](200) NOT NULL,
 CONSTRAINT [PK_Wallet] PRIMARY KEY CLUSTERED 
(
	[WalletType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouse](
	[WarehouseName] [nchar](250) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[WarehouseType] [nchar](200) NOT NULL,
	[City] [nchar](200) NOT NULL,
 CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED 
(
	[WarehouseName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WarehouseType]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WarehouseType](
	[Type] [nchar](200) NOT NULL,
 CONSTRAINT [PK_WarehouseType] PRIMARY KEY CLUSTERED 
(
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkPeriodEnd]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkPeriodEnd](
	[Id] [int] NOT NULL,
	[WPEnd] [datetime] NOT NULL,
 CONSTRAINT [PK_WorkPeriodEnd] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkPeriodStart]    Script Date: 9/20/2018 11:43:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkPeriodStart](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WPStart] [datetime] NOT NULL,
	[Status] [nchar](20) NOT NULL,
 CONSTRAINT [PK_WorkPeriodStart] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Registration] ([UserID], [UserType], [Password], [Name], [ContactNo], [EmailID], [JoiningDate], [Active]) VALUES (N'Cashier                                                                                             ', N'Cashier                       ', N'NjEyNA==                                          ', N'Cashier                                                                                                                                               ', N'123456789                                        ', N'cashier@gmail.com                                                                                                                                     ', CAST(0x0000A8C8006B12A7 AS DateTime), N'Yes       ')
INSERT [dbo].[Registration] ([UserID], [UserType], [Password], [Name], [ContactNo], [EmailID], [JoiningDate], [Active]) VALUES (N'KDS User                                                                                            ', N'Kitchen User                  ', N'MTExMQ==                                          ', N'KDS User                                                                                                                                              ', N'123456789                                        ', N'BlankDB@gmail.com                                                                                                                                       ', CAST(0x0000A87B00419562 AS DateTime), N'Yes       ')
INSERT [dbo].[Registration] ([UserID], [UserType], [Password], [Name], [ContactNo], [EmailID], [JoiningDate], [Active]) VALUES (N'VP                                                                                               ', N'Waiter                        ', N'ODg4OA==                                          ', N'VP                                                                                                                                           ', N'123456789                                        ', N'Admin@gmail.com                                                                                                                                       ', CAST(0x0000A63D006E20A5 AS DateTime), N'Yes       ')
INSERT [dbo].[Registration] ([UserID], [UserType], [Password], [Name], [ContactNo], [EmailID], [JoiningDate], [Active]) VALUES (N'sa                                                                                                  ', N'Super Admin                   ', N'MTIzNA==                                          ', N'Admin                                                                                                                                            ', N'123456789                                        ', N'BlankDB@gmail.com                                                                                                                                    ', CAST(0x0000A5E401260979 AS DateTime), N'Yes       ')
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_VAT]  DEFAULT ((0.00)) FOR [VAT]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_ST]  DEFAULT ((0.00)) FOR [ST]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_SC]  DEFAULT ((0.00)) FOR [SC]
GO
ALTER TABLE [dbo].[CreditCustomer] ADD  CONSTRAINT [DF_CreditCustomer_OpeningBalance]  DEFAULT ((0.00)) FOR [OpeningBalance]
GO
ALTER TABLE [dbo].[Dish] ADD  CONSTRAINT [DF_Dish_Rate]  DEFAULT ((0.00)) FOR [DIRate]
GO
ALTER TABLE [dbo].[Dish] ADD  CONSTRAINT [DF_Dish_TakeawayRate]  DEFAULT ((0.00)) FOR [TARate]
GO
ALTER TABLE [dbo].[Dish] ADD  CONSTRAINT [DF_Dish_HDRate]  DEFAULT ((0.00)) FOR [HDRate]
GO
ALTER TABLE [dbo].[Modifiers] ADD  CONSTRAINT [DF_Modifiers_Rate]  DEFAULT ((0.00)) FOR [Rate]
GO
ALTER TABLE [dbo].[OtherSetting] ADD  CONSTRAINT [DF_OtherSetting_ParcelCharges]  DEFAULT ((0.00)) FOR [ParcelCharges]
GO
ALTER TABLE [dbo].[OtherSetting] ADD  CONSTRAINT [DF_OtherSetting_HomeDeliveryCharges]  DEFAULT ((0.00)) FOR [HomeDeliveryCharges]
GO
ALTER TABLE [dbo].[OtherSetting] ADD  CONSTRAINT [DF_OtherSetting_VAT]  DEFAULT ((0.00)) FOR [VAT]
GO
ALTER TABLE [dbo].[OtherSetting] ADD  CONSTRAINT [DF_OtherSetting_ServiceTax]  DEFAULT ((0.00)) FOR [ServiceTax]
GO
ALTER TABLE [dbo].[OtherSetting] ADD  CONSTRAINT [DF_OtherSetting_ServiceCharge]  DEFAULT ((0.00)) FOR [ServiceCharges]
GO
ALTER TABLE [dbo].[PizzaMaster] ADD  CONSTRAINT [DF_PizzaMaster_Discount]  DEFAULT ((0.00)) FOR [Discount]
GO
ALTER TABLE [dbo].[PizzaMaster] ADD  CONSTRAINT [DF_PizzaMaster_Rate]  DEFAULT ((0.00)) FOR [Rate]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Price]  DEFAULT ((0.00)) FOR [Price]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_ReorderPoint]  DEFAULT ((0)) FOR [ReorderPoint]
GO
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF_PurchaseOrder_SubTotal]  DEFAULT ((0.00)) FOR [SubTotal]
GO
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF_PurchaseOrder_VATPer]  DEFAULT ((0.00)) FOR [VATPer]
GO
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF_PurchaseOrder_VATAmount]  DEFAULT ((0.00)) FOR [VATAmount]
GO
ALTER TABLE [dbo].[PurchaseOrder] ADD  CONSTRAINT [DF_PurchaseOrder_GrandTotal]  DEFAULT ((0.00)) FOR [GrandTotal]
GO
ALTER TABLE [dbo].[PurchaseOrder_Join] ADD  CONSTRAINT [DF_PurchaseOrder_Join_PricePerUnit]  DEFAULT ((0.00)) FOR [PricePerUnit]
GO
ALTER TABLE [dbo].[PurchaseOrder_Join] ADD  CONSTRAINT [DF_PurchaseOrder_Join_Amount]  DEFAULT ((0.00)) FOR [Amount]
GO
ALTER TABLE [dbo].[Recipe_Join] ADD  CONSTRAINT [DF_Recipe_Join_Quantity]  DEFAULT ((0.00)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Recipe_Join] ADD  CONSTRAINT [DF_Recipe_Join_Cost]  DEFAULT ((0.00)) FOR [CostPerUnit]
GO
ALTER TABLE [dbo].[Recipe_Join] ADD  CONSTRAINT [DF_Recipe_Join_TotalItemCost]  DEFAULT ((0.00)) FOR [TotalItemCost]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoEB] ADD  CONSTRAINT [DF_RestaurantPOS_BillingInfoEB_EBDiscountPer]  DEFAULT ((0.00)) FOR [EBDiscountPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoEB] ADD  CONSTRAINT [DF_RestaurantPOS_BillingInfoEB_GrandTotal]  DEFAULT ((0.00)) FOR [GrandTotal]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoEB] ADD  CONSTRAINT [DF_RestaurantPOS_BillingInfoEB_Cash]  DEFAULT ((0.00)) FOR [Cash]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoEB] ADD  CONSTRAINT [DF_RestaurantPOS_BillingInfoEB_Change]  DEFAULT ((0.00)) FOR [Change]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoEB] ADD  CONSTRAINT [DF_RestaurantPOS_BillingInfoEB_ExchangeRate]  DEFAULT ((0.0000)) FOR [ExchangeRate]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoHD] ADD  CONSTRAINT [DF_RestaurantPOS_BillingInfoHD_HDDiscountPer]  DEFAULT ((0.00)) FOR [HDDiscountPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoKOT] ADD  CONSTRAINT [DF_RestaurantPOS_BillingInfoKOT_KOTDiscountPer]  DEFAULT ((0.00)) FOR [KOTDiscountPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoKOT] ADD  CONSTRAINT [DF_RestaurantPOS_BillingInfoKOT_KOTDiscountAmt]  DEFAULT ((0.00)) FOR [KOTDiscountAmt]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoKOT] ADD  CONSTRAINT [DF_RestaurantPOS_BillingInfoKOT_GrandTotal]  DEFAULT ((0.00)) FOR [GrandTotal]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoKOT] ADD  CONSTRAINT [DF_RestaurantPOS_BillingInfoKOT_Cash]  DEFAULT ((0.00)) FOR [Cash]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoKOT] ADD  CONSTRAINT [DF_RestaurantPOS_BillingInfoKOT_Change]  DEFAULT ((0.00)) FOR [Change]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoKOT] ADD  CONSTRAINT [DF_RestaurantPOS_BillingInfoKOT_ExchangeRate]  DEFAULT ((0.0000)) FOR [ExchangeRate]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoTA] ADD  CONSTRAINT [DF_RestaurantPOS_BillingInfoTA_TADiscountPer]  DEFAULT ((0.00)) FOR [TADiscountPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoTA] ADD  CONSTRAINT [DF_RestaurantPOS_BillingInfoTA_ParcelCharges]  DEFAULT ((0.00)) FOR [ParcelCharges]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoTA] ADD  CONSTRAINT [DF_RestaurantPOS_BillingInfoTA_ExchangeRate]  DEFAULT ((0.0000)) FOR [ExchangeRate]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillEB] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillEB_Rate]  DEFAULT ((0.00)) FOR [Rate]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillEB] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillEB_Amount]  DEFAULT ((0.00)) FOR [Amount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillEB] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillEB_VATPer]  DEFAULT ((0.00)) FOR [VATPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillEB] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillEB_VATAmount]  DEFAULT ((0.00)) FOR [VATAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillEB] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillEB_STPer]  DEFAULT ((0.00)) FOR [STPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillEB] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillEB_STAmount]  DEFAULT ((0.00)) FOR [STAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillEB] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillEB_SCPer]  DEFAULT ((0.00)) FOR [SCPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillEB] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillEB_SCAmount]  DEFAULT ((0.00)) FOR [SCAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillEB] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillEB_DiscountPer]  DEFAULT ((0.00)) FOR [DiscountPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillEB] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillEB_DiscountAmount]  DEFAULT ((0.00)) FOR [DiscountAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillEB] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillEB_TotalAmount]  DEFAULT ((0.00)) FOR [TotalAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillHD] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillHD_Rate]  DEFAULT ((0.00)) FOR [Rate]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillHD] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillHD_Amount]  DEFAULT ((0.00)) FOR [Amount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillHD] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillHD_VATPer]  DEFAULT ((0.00)) FOR [VATPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillHD] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillHD_VATAmount]  DEFAULT ((0.00)) FOR [VATAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillHD] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillHD_STPer]  DEFAULT ((0.00)) FOR [STPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillHD] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillHD_STAmount]  DEFAULT ((0.00)) FOR [STAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillHD] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillHD_SCPer]  DEFAULT ((0.00)) FOR [SCPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillHD] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillHD_SCAmount]  DEFAULT ((0.00)) FOR [SCAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillHD] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillHD_DiscountPer]  DEFAULT ((0.00)) FOR [DiscountPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillHD] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillHD_DiscountAmount]  DEFAULT ((0.00)) FOR [DiscountAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillHD] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillHD_TotalAmount]  DEFAULT ((0.00)) FOR [TotalAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillKOT_Rate]  DEFAULT ((0.00)) FOR [Rate]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillKOT_Amount]  DEFAULT ((0.00)) FOR [Amount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillKOT_VATPer]  DEFAULT ((0.00)) FOR [VATPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillKOT_VATAmount]  DEFAULT ((0.00)) FOR [VATAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillKOT_STPer]  DEFAULT ((0.00)) FOR [STPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillKOT_STAmount]  DEFAULT ((0.00)) FOR [STAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillKOT_SCPer]  DEFAULT ((0.00)) FOR [SCPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillKOT_SCAmount]  DEFAULT ((0.00)) FOR [SCAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillKOT_DiscountPer]  DEFAULT ((0.00)) FOR [DiscountPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillKOT_DiscountAmount]  DEFAULT ((0.00)) FOR [DiscountAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillKOT_TotalAmount]  DEFAULT ((0.00)) FOR [TotalAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillTA] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillTA_Rate]  DEFAULT ((0.00)) FOR [Rate]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillTA] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillTA_Amount]  DEFAULT ((0.00)) FOR [Amount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillTA] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillTA_VATPer]  DEFAULT ((0.00)) FOR [VATPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillTA] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillTA_VATAmount]  DEFAULT ((0.00)) FOR [VATAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillTA] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillTA_STPer]  DEFAULT ((0.00)) FOR [STPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillTA] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillTA_STAmount]  DEFAULT ((0.00)) FOR [STAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillTA] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillTA_SCPer]  DEFAULT ((0.00)) FOR [SCPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillTA] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillTA_SCAmount]  DEFAULT ((0.00)) FOR [SCAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillTA] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillTA_DiscountPer]  DEFAULT ((0.00)) FOR [DiscountPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillTA] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillTA_DiscountAmount]  DEFAULT ((0.00)) FOR [DiscountAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillTA] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductBillTA_TotalAmount]  DEFAULT ((0.00)) FOR [TotalAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductKOT_Rate]  DEFAULT ((0.00)) FOR [Rate]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductKOT_Amount]  DEFAULT ((0.00)) FOR [Amount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductKOT_VATPer]  DEFAULT ((0.00)) FOR [VATPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductKOT_VATAmount]  DEFAULT ((0.00)) FOR [VATAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductKOT_STPer]  DEFAULT ((0.00)) FOR [STPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductKOT_STAmount]  DEFAULT ((0.00)) FOR [STAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductKOT_SCPer]  DEFAULT ((0.00)) FOR [SCPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductKOT_SCAmount]  DEFAULT ((0.00)) FOR [SCAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductKOT_DiscountPer]  DEFAULT ((0.00)) FOR [DiscountPer]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductKOT_DiscountAmount]  DEFAULT ((0.00)) FOR [DiscountAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderedProductKOT_TotalAmount]  DEFAULT ((0.00)) FOR [TotalAmount]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderInfoKOT] ADD  CONSTRAINT [DF_RestaurantPOS_OrderInfoKOT_GrandTotal]  DEFAULT ((0.00)) FOR [GrandTotal]
GO
ALTER TABLE [dbo].[Temp_Stock_RM] ADD  CONSTRAINT [DF_Temp_Stock_RM_Qty]  DEFAULT ((0)) FOR [Qty]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Kitchen] FOREIGN KEY([Kitchen])
REFERENCES [dbo].[Kitchen] ([Kitchenname])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Kitchen]
GO
ALTER TABLE [dbo].[CreditCustomerLedger]  WITH CHECK ADD  CONSTRAINT [FK_CreditCustomerLedger_CreditCustomer] FOREIGN KEY([CreditCustomer_ID])
REFERENCES [dbo].[CreditCustomer] ([CC_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CreditCustomerLedger] CHECK CONSTRAINT [FK_CreditCustomerLedger_CreditCustomer]
GO
ALTER TABLE [dbo].[CreditCustomerPayment]  WITH CHECK ADD  CONSTRAINT [FK_CreditCustomerPayment_CreditCustomer] FOREIGN KEY([CreditCustomer_ID])
REFERENCES [dbo].[CreditCustomer] ([CC_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[CreditCustomerPayment] CHECK CONSTRAINT [FK_CreditCustomerPayment_CreditCustomer]
GO
ALTER TABLE [dbo].[Dish]  WITH CHECK ADD  CONSTRAINT [FK_Dish_Category] FOREIGN KEY([Category])
REFERENCES [dbo].[Category] ([CategoryName])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Dish] CHECK CONSTRAINT [FK_Dish_Category]
GO
ALTER TABLE [dbo].[Expense]  WITH CHECK ADD  CONSTRAINT [FK_Expense_ExpenseType] FOREIGN KEY([ExpenseType])
REFERENCES [dbo].[ExpenseType] ([Type])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Expense] CHECK CONSTRAINT [FK_Expense_ExpenseType]
GO
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_Registration] FOREIGN KEY([UserID])
REFERENCES [dbo].[Registration] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_Registration]
GO
ALTER TABLE [dbo].[LoyaltyMemberLedgerBook]  WITH CHECK ADD  CONSTRAINT [FK_LoyaltyMemberLedgerBook_LoyaltyMember] FOREIGN KEY([MemberID])
REFERENCES [dbo].[LoyaltyMember] ([MemberID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[LoyaltyMemberLedgerBook] CHECK CONSTRAINT [FK_LoyaltyMemberLedgerBook_LoyaltyMember]
GO
ALTER TABLE [dbo].[MemberLedger]  WITH CHECK ADD  CONSTRAINT [FK_MemberLedger_Member] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Member] ([MemberID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MemberLedger] CHECK CONSTRAINT [FK_MemberLedger_Member]
GO
ALTER TABLE [dbo].[Modifiers]  WITH CHECK ADD  CONSTRAINT [FK_Modifiers_Dish] FOREIGN KEY([Item])
REFERENCES [dbo].[Dish] ([DishName])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Modifiers] CHECK CONSTRAINT [FK_Modifiers_Dish]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Supplier]
GO
ALTER TABLE [dbo].[PizzaMaster]  WITH CHECK ADD  CONSTRAINT [FK_PizzaMaster_PizzaSize] FOREIGN KEY([PizzaSize])
REFERENCES [dbo].[PizzaSize] ([Size])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PizzaMaster] CHECK CONSTRAINT [FK_PizzaMaster_PizzaSize]
GO
ALTER TABLE [dbo].[PizzaTopping]  WITH CHECK ADD  CONSTRAINT [FK_PizzaTopping_PizzaSize] FOREIGN KEY([PizzaSize])
REFERENCES [dbo].[PizzaSize] ([Size])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PizzaTopping] CHECK CONSTRAINT [FK_PizzaTopping_PizzaSize]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Product] FOREIGN KEY([Unit])
REFERENCES [dbo].[UnitMaster] ([Unit])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_RMCategory] FOREIGN KEY([Category])
REFERENCES [dbo].[RMCategory] ([CategoryName])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_RMCategory]
GO
ALTER TABLE [dbo].[Product_OpeningStock]  WITH CHECK ADD  CONSTRAINT [FK_Product_OpeningStock_Product1] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_OpeningStock] CHECK CONSTRAINT [FK_Product_OpeningStock_Product1]
GO
ALTER TABLE [dbo].[Product_OpeningStock]  WITH CHECK ADD  CONSTRAINT [FK_Product_OpeningStock_Warehouse] FOREIGN KEY([Warehouse])
REFERENCES [dbo].[Warehouse] ([WarehouseName])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Product_OpeningStock] CHECK CONSTRAINT [FK_Product_OpeningStock_Warehouse]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Supplier] FOREIGN KEY([Supplier_ID])
REFERENCES [dbo].[Supplier] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Supplier]
GO
ALTER TABLE [dbo].[Purchase_Join]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Join_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Purchase_Join] CHECK CONSTRAINT [FK_Purchase_Join_Product]
GO
ALTER TABLE [dbo].[Purchase_Join]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Join_Purchase] FOREIGN KEY([PurchaseID])
REFERENCES [dbo].[Purchase] ([ST_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Purchase_Join] CHECK CONSTRAINT [FK_Purchase_Join_Purchase]
GO
ALTER TABLE [dbo].[Purchase_Join]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Join_Warehouse] FOREIGN KEY([Warehouse])
REFERENCES [dbo].[Warehouse] ([WarehouseName])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Purchase_Join] CHECK CONSTRAINT [FK_Purchase_Join_Warehouse]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Supplier] FOREIGN KEY([Supplier_ID])
REFERENCES [dbo].[Supplier] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Supplier]
GO
ALTER TABLE [dbo].[PurchaseOrder_Join]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Join_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PurchaseOrder_Join] CHECK CONSTRAINT [FK_PurchaseOrder_Join_Product]
GO
ALTER TABLE [dbo].[PurchaseOrder_Join]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Join_PurchaseOrder] FOREIGN KEY([PurchaseOrderID])
REFERENCES [dbo].[PurchaseOrder] ([PO_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseOrder_Join] CHECK CONSTRAINT [FK_PurchaseOrder_Join_PurchaseOrder]
GO
ALTER TABLE [dbo].[Recipe]  WITH CHECK ADD  CONSTRAINT [FK_Recipe_Dish] FOREIGN KEY([Dish])
REFERENCES [dbo].[Dish] ([DishName])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Recipe] CHECK CONSTRAINT [FK_Recipe_Dish]
GO
ALTER TABLE [dbo].[Recipe_Join]  WITH CHECK ADD  CONSTRAINT [FK_Recipe_Join_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Recipe_Join] CHECK CONSTRAINT [FK_Recipe_Join_Product]
GO
ALTER TABLE [dbo].[Recipe_Join]  WITH CHECK ADD  CONSTRAINT [FK_Recipe_Join_Recipe] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipe] ([R_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Recipe_Join] CHECK CONSTRAINT [FK_Recipe_Join_Recipe]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoEB]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantPOS_BillingInfoEB_Registration] FOREIGN KEY([Operator])
REFERENCES [dbo].[Registration] ([UserID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoEB] CHECK CONSTRAINT [FK_RestaurantPOS_BillingInfoEB_Registration]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoHD]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantPOS_BillingInfoHD_EmployeeRegistration] FOREIGN KEY([Employee_ID])
REFERENCES [dbo].[EmployeeRegistration] ([EmpId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoHD] CHECK CONSTRAINT [FK_RestaurantPOS_BillingInfoHD_EmployeeRegistration]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoHD]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantPOS_BillingInfoHD_Registration] FOREIGN KEY([Operator])
REFERENCES [dbo].[Registration] ([UserID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoHD] CHECK CONSTRAINT [FK_RestaurantPOS_BillingInfoHD_Registration]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoKOT]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantPOS_BillingInfoKOT_Registration] FOREIGN KEY([Operator])
REFERENCES [dbo].[Registration] ([UserID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoKOT] CHECK CONSTRAINT [FK_RestaurantPOS_BillingInfoKOT_Registration]
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoTA]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantPOS_BillingInfoTA_Registration] FOREIGN KEY([Operator])
REFERENCES [dbo].[Registration] ([UserID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RestaurantPOS_BillingInfoTA] CHECK CONSTRAINT [FK_RestaurantPOS_BillingInfoTA_Registration]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillEB]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantPOS_OrderedProductBillEB_RestaurantPOS_BillingInfoEB] FOREIGN KEY([BillID])
REFERENCES [dbo].[RestaurantPOS_BillingInfoEB] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillEB] CHECK CONSTRAINT [FK_RestaurantPOS_OrderedProductBillEB_RestaurantPOS_BillingInfoEB]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillHD]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantPOS_OrderedProductBillHD_RestaurantPOS_BillingInfoHD] FOREIGN KEY([BillID])
REFERENCES [dbo].[RestaurantPOS_BillingInfoHD] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillHD] CHECK CONSTRAINT [FK_RestaurantPOS_OrderedProductBillHD_RestaurantPOS_BillingInfoHD]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillKOT]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantPOS_OrderedProductBillKOT_R_Table] FOREIGN KEY([TableNo])
REFERENCES [dbo].[R_Table] ([TableNo])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillKOT] CHECK CONSTRAINT [FK_RestaurantPOS_OrderedProductBillKOT_R_Table]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillKOT]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantPOS_OrderedProductBillKOT_TempRestaurantPOS_OrderInfoKOT] FOREIGN KEY([BillID])
REFERENCES [dbo].[RestaurantPOS_BillingInfoKOT] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillKOT] CHECK CONSTRAINT [FK_RestaurantPOS_OrderedProductBillKOT_TempRestaurantPOS_OrderInfoKOT]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillTA]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantPOS_OrderedProductBillTA_RestaurantPOS_BillingInfoTA] FOREIGN KEY([BillID])
REFERENCES [dbo].[RestaurantPOS_BillingInfoTA] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductBillTA] CHECK CONSTRAINT [FK_RestaurantPOS_OrderedProductBillTA_RestaurantPOS_BillingInfoTA]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductKOT]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantPOS_OrderedProductKOT_RestaurantPOS_OrderInfoKOT] FOREIGN KEY([TicketID])
REFERENCES [dbo].[RestaurantPOS_OrderInfoKOT] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderedProductKOT] CHECK CONSTRAINT [FK_RestaurantPOS_OrderedProductKOT_RestaurantPOS_OrderInfoKOT]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderInfoKOT]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantPOS_OrderInfoKOT_R_Table] FOREIGN KEY([TableNo])
REFERENCES [dbo].[R_Table] ([TableNo])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderInfoKOT] CHECK CONSTRAINT [FK_RestaurantPOS_OrderInfoKOT_R_Table]
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderInfoKOT]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantPOS_OrderInfoKOT_Registration] FOREIGN KEY([Operator])
REFERENCES [dbo].[Registration] ([UserID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[RestaurantPOS_OrderInfoKOT] CHECK CONSTRAINT [FK_RestaurantPOS_OrderInfoKOT_Registration]
GO
ALTER TABLE [dbo].[RM_Used_Join]  WITH CHECK ADD  CONSTRAINT [FK_RM_Used_Join_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RM_Used_Join] CHECK CONSTRAINT [FK_RM_Used_Join_Product]
GO
ALTER TABLE [dbo].[RM_Used_Join]  WITH CHECK ADD  CONSTRAINT [FK_RM_Used_Join_RM_Used] FOREIGN KEY([RawMaterialID])
REFERENCES [dbo].[RM_Used] ([RM_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RM_Used_Join] CHECK CONSTRAINT [FK_RM_Used_Join_RM_Used]
GO
ALTER TABLE [dbo].[Stock_Store_Join]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Store_Join_Dish] FOREIGN KEY([Dish])
REFERENCES [dbo].[Dish] ([DishName])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Stock_Store_Join] CHECK CONSTRAINT [FK_Stock_Store_Join_Dish]
GO
ALTER TABLE [dbo].[Stock_Store_Join]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Store_Join_Stock_Store] FOREIGN KEY([StockID])
REFERENCES [dbo].[Stock_Store] ([St_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stock_Store_Join] CHECK CONSTRAINT [FK_Stock_Store_Join_Stock_Store]
GO
ALTER TABLE [dbo].[StockAdjustment_Store]  WITH CHECK ADD  CONSTRAINT [FK_StockAdjustment_Kitchen_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[StockAdjustment_Store] CHECK CONSTRAINT [FK_StockAdjustment_Kitchen_Product]
GO
ALTER TABLE [dbo].[StockAdjustment_Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_StockAdjustment_Warehouse_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[StockAdjustment_Warehouse] CHECK CONSTRAINT [FK_StockAdjustment_Warehouse_Product]
GO
ALTER TABLE [dbo].[StockAdjustment_Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_StockAdjustment_Warehouse_Warehouse] FOREIGN KEY([Warehouse])
REFERENCES [dbo].[Warehouse] ([WarehouseName])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[StockAdjustment_Warehouse] CHECK CONSTRAINT [FK_StockAdjustment_Warehouse_Warehouse]
GO
ALTER TABLE [dbo].[StockTransfer]  WITH CHECK ADD  CONSTRAINT [FK_StockTransfer_Kitchen] FOREIGN KEY([Kitchen])
REFERENCES [dbo].[Kitchen] ([Kitchenname])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[StockTransfer] CHECK CONSTRAINT [FK_StockTransfer_Kitchen]
GO
ALTER TABLE [dbo].[StockTransfer_Join]  WITH CHECK ADD  CONSTRAINT [FK_StockTransfer_Join_StockTransfer] FOREIGN KEY([StockTransferID])
REFERENCES [dbo].[StockTransfer] ([ST_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StockTransfer_Join] CHECK CONSTRAINT [FK_StockTransfer_Join_StockTransfer]
GO
ALTER TABLE [dbo].[StockTransfer_Join]  WITH CHECK ADD  CONSTRAINT [FK_StockTransfer_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[StockTransfer_Join] CHECK CONSTRAINT [FK_StockTransfer_Product]
GO
ALTER TABLE [dbo].[StockTransfer_Join]  WITH CHECK ADD  CONSTRAINT [FK_StockTransfer_Warehouse] FOREIGN KEY([Warehouse])
REFERENCES [dbo].[Warehouse] ([WarehouseName])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[StockTransfer_Join] CHECK CONSTRAINT [FK_StockTransfer_Warehouse]
GO
ALTER TABLE [dbo].[Temp_Stock]  WITH CHECK ADD  CONSTRAINT [FK_Temp_Stock_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Temp_Stock] CHECK CONSTRAINT [FK_Temp_Stock_Product]
GO
ALTER TABLE [dbo].[Temp_Stock]  WITH CHECK ADD  CONSTRAINT [FK_Temp_Stock_Warehouse] FOREIGN KEY([Warehouse])
REFERENCES [dbo].[Warehouse] ([WarehouseName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Temp_Stock] CHECK CONSTRAINT [FK_Temp_Stock_Warehouse]
GO
ALTER TABLE [dbo].[Temp_Stock_RM]  WITH CHECK ADD  CONSTRAINT [FK_Temp_Stock_RM_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Temp_Stock_RM] CHECK CONSTRAINT [FK_Temp_Stock_RM_Product]
GO
ALTER TABLE [dbo].[Temp_Stock_Store]  WITH CHECK ADD  CONSTRAINT [FK_TempStock_Store_Dish] FOREIGN KEY([Dish])
REFERENCES [dbo].[Dish] ([DishName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Temp_Stock_Store] CHECK CONSTRAINT [FK_TempStock_Store_Dish]
GO
ALTER TABLE [dbo].[Voucher_OtherDetails]  WITH CHECK ADD  CONSTRAINT [FK_Voucher_OtherDetails_Expense] FOREIGN KEY([Particulars])
REFERENCES [dbo].[Expense] ([ExpenseName])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Voucher_OtherDetails] CHECK CONSTRAINT [FK_Voucher_OtherDetails_Expense]
GO
ALTER TABLE [dbo].[Voucher_OtherDetails]  WITH CHECK ADD  CONSTRAINT [FK_Voucher_OtherDetails_Voucher] FOREIGN KEY([VoucherID])
REFERENCES [dbo].[Voucher] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Voucher_OtherDetails] CHECK CONSTRAINT [FK_Voucher_OtherDetails_Voucher]
GO
ALTER TABLE [dbo].[Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_Warehouse_WarehouseType] FOREIGN KEY([WarehouseType])
REFERENCES [dbo].[WarehouseType] ([Type])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Warehouse] CHECK CONSTRAINT [FK_Warehouse_WarehouseType]
GO
ALTER TABLE [dbo].[WorkPeriodEnd]  WITH CHECK ADD  CONSTRAINT [FK_WorkPeriodEnd_WorkPeriodStart] FOREIGN KEY([Id])
REFERENCES [dbo].[WorkPeriodStart] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkPeriodEnd] CHECK CONSTRAINT [FK_WorkPeriodEnd_WorkPeriodStart]
GO
USE [master]
GO
ALTER DATABASE [RPOS_DB] SET  READ_WRITE 
GO
