--CREATE SCHEMA TCS;
--GO;
use Aarohi

CREATE TABLE TCS.RoleMaster
(
	RoleMasterId INT IDENTITY(1,1) PRIMARY KEY,
	RoleId NVARCHAR(10),
	RoleName NVARCHAR(20),
	RoleDesc NVARCHAR(100),
	IsActive BIT DEFAULT(0),
	CreatedOnUTC DATETIME DEFAULT(GETUTCDATE()),
	CreatedBy NVARCHAR(20),
	LastUpdateOnUTC DATETIME,
	LastUpdateBy NVARCHAR(20)
)

GO

CREATE TABLE TCS.UserMaster
(
	UserMasterId INT IDENTITY(1,1) PRIMARY KEY,
	UserId NVARCHAR(20),
	LoginPSWD NVARCHAR(MAX),
	FullName NVARCHAR(50),
	Mobile NVARCHAR(20),
	EmailID NVARCHAR(100),
	DOJ DATE,
	RoleID INT,
	ReportingUserId INT,
	LastLogin	DATETIME,
	Photo VARBINARY,
	CreatedOnUTC DATETIME DEFAULT(GETUTCDATE()),
	CreatedBy NVARCHAR(20),
	LastUpdateOnUTC DATETIME,
	LastUpdateBy NVARCHAR(20)
)

GO
--DROP TABLE TCS.LeadDetail
CREATE TABLE TCS.LeadDetail
(
	LeadDetailId INT IDENTITY(1,1) PRIMARY KEY,
	LeadId NVARCHAR(20),
	SerialNumber NVARCHAR(10),
	CustomerDetailId INT,
	ProviderName NVARCHAR(50),
	AssignedDate DATETIME,
	AssignedTo INT,
	Assignment_Remarks NVARCHAR(100),
	IsActive BIT DEFAULT(1),
	CreatedOnUTC DATETIME DEFAULT(GETUTCDATE()),
	CreatedBy NVARCHAR(20),
	LastUpdateOnUTC DATETIME,
	LastUpdateBy NVARCHAR(20)
)

CREATE TABLE TCS.CustomerDetail
(
	CustomerDetailId INT IDENTITY(1,1) PRIMARY KEY,
	CustomerName NVARCHAR(100),
	CustMobile NVARCHAR(20),
	CustEmail NVARCHAR(100),
	CustAddress NVARCHAR(250),
	CustPincode INT,
	CustCity NVARCHAR(30),
	CreatedOnUTC DATETIME DEFAULT(GETUTCDATE()),
	CreatedBy NVARCHAR(20),
	LastUpdateOnUTC DATETIME,
	LastUpdateBy NVARCHAR(20)
)

GO

CREATE TABLE TCS.LeadAsgnmnt
(
	LeadAsgnmntId  INT IDENTITY(1,1) PRIMARY KEY,
	LeadAssignedDate DATETIME,
	LeadId INT,
	UserId INT,
	CreatedOnUTC DATETIME DEFAULT(GETUTCDATE()),
	CreatedBy NVARCHAR(20),
	LastUpdateOnUTC DATETIME,
	LastUpdateBy NVARCHAR(20)
)

GO

CREATE TABLE TCS.CallStatus
(
	CallStatusId  INT IDENTITY(1,1) PRIMARY KEY,
	CallStatusName NVARCHAR(20),
	CallStatusDesc NVARCHAR(100),
	IsActive BIT,
	CreatedOnUTC DATETIME DEFAULT(GETUTCDATE()),
	CreatedBy NVARCHAR(20),
	LastUpdateOnUTC DATETIME,
	LastUpdateBy NVARCHAR(20)
)

GO
--DROP TABLE TCS.DailyCallDetail
CREATE TABLE TCS.DailyCallDetail
(
	DailyCallDetailId  INT IDENTITY(1,1) PRIMARY KEY,
	CallDate DATE,
	CallTime DATETIME,
	CustomerDetailId INT,
	CallDuration DECIMAL(5,2),
	CallRemark NVARCHAR(500),
	WhatsAppRemark NVARCHAR(500),
	SMSRemark NVARCHAR(500),
	EmailRemark NVARCHAR(500),
	CallStatusID INT,
	CreatedOnUTC DATETIME DEFAULT(GETUTCDATE()),
	CreatedBy NVARCHAR(20),
	LastUpdateOnUTC DATETIME,
	LastUpdateBy NVARCHAR(20)
)
GO

INSERT INTO TCS.RoleMaster(RoleId,RoleName,RoleDesc,CreatedBy,CreatedOnUTC)
VALUES 
('RM','Regional Manager','','system',GETUTCDATE()),
('M','Manager','','system',GETUTCDATE()),
('S','Supervisor','','system',GETUTCDATE()),
('TC','Tele Caller','','system',GETUTCDATE()),
('FO','Field Officer','','system',GETUTCDATE())
GO

INSERT INTO TCS.CallStatus(CallStatusName,CallStatusDesc,IsActive,CreatedBy,CreatedOnUTC)
VALUES 
('Pending','Pending',1,'system',GETUTCDATE()),
('FollowUp','Follow-up',1,'system',GETUTCDATE()),
('Closed','Closed',1,'system',GETUTCDATE()),
('Dead','Dead',1,'system',GETUTCDATE()),
('LeadGenerated','Lead Generated',1,'system',GETUTCDATE())
GO

IF NOT EXISTS(SELECT 0 FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'IsActive' AND TABLE_NAME = 'RoleMaster' AND TABLE_SCHEMA = 'TCS')
BEGIN
	ALTER TABLE TCS.RoleMaster ADD IsActive BIT DEFAULT(1);
END
GO

IF NOT EXISTS(SELECT 0 FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'IsActive' AND TABLE_NAME = 'UserMaster' AND TABLE_SCHEMA = 'TCS')
BEGIN
	ALTER TABLE TCS.UserMaster ADD IsActive BIT DEFAULT(1);
END
GO

IF NOT EXISTS(SELECT 0 FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'IsActive' AND TABLE_NAME = 'LeadDetail' AND TABLE_SCHEMA = 'TCS')
BEGIN
	ALTER TABLE TCS.LeadDetail ADD IsActive BIT DEFAULT(1);
END
GO

IF NOT EXISTS(SELECT 0 FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'IsActive' AND TABLE_NAME = 'CustomerDetail' AND TABLE_SCHEMA = 'TCS')
BEGIN
	ALTER TABLE TCS.CustomerDetail ADD IsActive BIT DEFAULT(1);
END
GO

IF NOT EXISTS(SELECT 0 FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'IsActive' AND TABLE_NAME = 'LeadAsgnmnt' AND TABLE_SCHEMA = 'TCS')
BEGIN
	ALTER TABLE TCS.LeadAsgnmnt ADD IsActive BIT DEFAULT(1);
END
GO

IF NOT EXISTS(SELECT 0 FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'IsActive' AND TABLE_NAME = 'DailyCallDetail' AND TABLE_SCHEMA = 'TCS')
BEGIN
	ALTER TABLE TCS.DailyCallDetail ADD IsActive BIT DEFAULT(1);
END
GO