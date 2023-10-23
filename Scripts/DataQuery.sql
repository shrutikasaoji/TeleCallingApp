use Aarohi
DECLARE @Columns NVARCHAR(500)=''
SELECT @Columns=@Columns+COALESCE(''+Column_Name+' = @'+Column_Name+', ','') FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'LeadDetail'
--SELECT @Columns=@Columns+COALESCE('@'+Column_Name+', ','') FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'LeadDetail'
SELECT @Columns

 
SELECT  Column_Name FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'DailyCallDetail'
SELECT um.UserMasterId, um.UserId, um.LoginPSWD, um.FullName, um.Mobile, um.EmailID, um.DOJ, um.RoleID,rm.RoleName,um.ReportingUserId,rep.FullName AS 'ReportingUser',
um.LastLogin, um.Photo, um.CreatedOnUTC, um.CreatedBy, um.LastUpdateOnUTC, um.LastUpdateBy
FROM TCS.Usermaster um INNER JOIN tcs.RoleMaster rm ON rm.RoleMasterId = um.RoleID
LEFT join TCS.UserMaster rep ON rep.UserMasterId = um.ReportingUserId

SELECT * FROM TCS.CustomerDetail
SELECT calls.DailyCallDetailId, calls.CallDate, calls.CallTime, calls.CustomerDetailId, cust.CustomerName, calls.CallDuration, calls.CallRemark, calls.WhatsAppRemark, calls.SMSRemark, calls.EmailRemark, calls.CallStatusID,sts.CallStatusName, calls.CreatedOnUTC, calls.CreatedBy, calls.LastUpdateOnUTC, calls.LastUpdateBy
FROM TCS.DailyCallDetail calls INNER JOIN TCS.CustomerDetail cust ON cust.CustomerDetailId = calls.CustomerDetailId
INNER JOIN TCS.CallStatus sts ON sts.CallStatusId = calls.CallStatusID

SELECT * FROM TCS.RoleMaster
SELECT * FROM TCS.UserMaster
SELECT * FROM TCS.CustomerDetail
SELECT * FROM TCS.DailyCallDetail
SELECT * FROM TCS.LeadDetail
update TCS.DailyCallDetail SET CustomerDetailId = 1 

SELECT * FROM TCS.RoleMaster WHERE RoleMasterId = 1
, LastUpdateOnUTC = GETUTCDATE(), LastUpdateBy = 'system'
UPDATE TCS.RoleMaster
SET RoleId = @RoleId, RoleName = @RoleName, RoleDesc = @RoleDesc, LastUpdateOnUTC = GETUTCDATE(), LastUpdateBy = 'system'
WHERE RoleMasterId = @RoleMasterId

UPDATE TCS.RoleMaster SET RoleName = @RoleName, RoleDesc = @RoleDesc, LastUpdateOnUTC = GETUTCDATE(), LastUpdateBy = 'system' WHERE RoleMasterId = @RoleMasterId

SELECT um.UserMasterId, um.UserId, um.LoginPSWD, um.FullName, um.Mobile, um.EmailID, um.DOJ, um.RoleID,rm.RoleName,um.ReportingUserId,rep.FullName AS 'ReportingUser',um.LastLogin, um.Photo, um.CreatedOnUTC, um.CreatedBy, um.LastUpdateOnUTC, um.LastUpdateBy
FROM TCS.Usermaster um INNER JOIN tcs.RoleMaster rm ON rm.RoleMasterId = um.RoleID
LEFT join TCS.UserMaster rep ON rep.UserMasterId = um.ReportingUserId

SELECT um.UserMasterId, um.UserId, um.LoginPSWD, um.FullName, um.Mobile, um.EmailID, um.DOJ, um.RoleID,rm.RoleName,um.ReportingUserId,rep.FullName AS 'ReportingUser',um.LastLogin, um.Photo, um.CreatedOnUTC, um.CreatedBy, um.LastUpdateOnUTC, um.LastUpdateBy
FROM TCS.Usermaster um INNER JOIN tcs.RoleMaster rm ON rm.RoleMasterId = um.RoleID 
LEFT join TCS.UserMaster rep ON rep.UserMasterId = um.ReportingUserId

INSERT INTO TCS.DailyCallDetail(@CallDate, @CallTime, @CustomerDetailId, @CallDuration, @CallRemark, @WhatsAppRemark, @SMSRemark, @EmailRemark, @CallStatusID, @CreatedOnUTC, @CreatedBy, @IsActive)
VALUES (CallDate, CallTime, CustomerDetailId, CallDuration, CallRemark, WhatsAppRemark, SMSRemark, EmailRemark, CallStatusID, GETUTCDATE(), 'system',  1 )

SELECT calls.DailyCallDetailId, calls.CallDate, calls.CallTime, calls.CustomerDetailId, cust.CustomerName, calls.CallDuration, calls.CallRemark, calls.WhatsAppRemark, calls.SMSRemark, calls.EmailRemark, calls.CallStatusID, sts.CallStatusName, calls.CreatedOnUTC, calls.CreatedBy, calls.LastUpdateOnUTC, calls.LastUpdateBy 
FROM TCS.DailyCallDetail calls 
INNER JOIN TCS.CustomerDetail cust ON cust.CustomerDetailId = calls.CustomerDetailId 
INNER JOIN TCS.CallStatus sts ON sts.CallStatusId = calls.CallStatusID

SELECT leads.LeadDetailId, leads.LeadId, leads.SerialNumber, leads.CustomerDetailId, leads.ProviderName,leads.AssignedTo,um.FullName AS 'AssignedToUser', leads.AssignedDate,leads.Assignment_Remarks,
leads.CreatedOnUTC, leads.CreatedBy, leads.LastUpdateOnUTC, leads.LastUpdateBy, leads.IsActive, cust.CustomerName, cust.CustMobile, cust.CustEmail,
cust.CustAddress, cust.CustPincode, cust.CustCity FROM TCS.LeadDetail leads 
INNER JOIN TCS.CustomerDetail cust ON cust.CustomerDetailId = leads.CustomerDetailId 
LEFT JOIN TCS.UserMaster um ON um.UserMasterId = leads.AssignedTo

INSERT INTO TCS.LeadDetail( LeadId, SerialNumber, CustomerDetailId, ProviderName,AssignedTo,AssignedDate,Assignment_Remarks, CreatedOnUTC, CreatedBy, IsActive ) 
VALUES(@LeadId, @SerialNumber, @CustomerDetailId, @ProviderName,@AssignedTo,@AssignedDate,@Assignment_Remarks, GETUTCDATE(), 'system', 1)