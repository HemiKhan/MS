using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MS_Data.Migrations
{
    public partial class SP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var Sp_GetComplaintVerficationDepartmentForSendMail = @"Create or Alter Procedure Sp_GetComplaintVerficationDepartmentForSendMail
            As
            Begin
	            Select Distinct ToDepartment,ToDepartmentName From 
                (   
                  SELECT c.ByDepartment AS FromDepartment, c.ForDepartment AS ToDepartment, dT.DepartmentName AS ToDepartmentName, 
                  CONVERT(VARCHAR(40), DATEDIFF(hour, Max(cs.StatusDateTime), GETDATE())) as AgeHours, c.ComplaintId, c.StatusId FROM Complaint AS c
                  INNER JOIN ComplaintStatus AS cs ON cs.ComplaintId = c.ComplaintId
                  INNER JOIN ComplaintStatusDefinition AS csd ON csd.ComplaintStatusId = c.StatusId
                  INNER JOIN Department AS dT ON dT.DepartmentCode = c.ForDepartment
                  INNER JOIN Department AS dF ON dF.DepartmentCode = c.ByDepartment
                  Where c.StatusId = 15
                  Group by c.ByDepartment, c.ForDepartment, dT.DepartmentName, c.ComplaintId, c.StatusId
                ) a
                Where AgeHours > 8 order by ToDepartment asc
            End";
            migrationBuilder.Sql(Sp_GetComplaintVerficationDepartmentForSendMail);

            var Sp_GetComplaintVerficationForSendMail = @"Create or Alter Procedure Sp_GetComplaintVerficationForSendMail
            As
            Begin
            	Select main.ComplaintId,main.FromDepartment,main.ToDepartment,main.AssetCode,main.ShortName,main.LongName,main.ComplaintDetail,main.Status,main.StatusDate,main.ComplaintBy,main.Remarks From
              ( 
                SELECT c.ComplaintId, dF.DepartmentName AS FromDepartment, dT.DepartmentName AS ToDepartment, cac.AssetCode, ca.ShortName, ca.ItemName AS LongName, c.Detail AS ComplaintDetail, 
                csd.ComplaintStatus AS Status, c.UserId AS ComplaintBy, Format(Max(cs.StatusDateTime), 'dd-MMM-yy HH:mm') AS StatusDate, CONVERT(VARCHAR(40), DATEDIFF(hour, Max(cs.StatusDateTime), GETDATE())) as AgeHours, 
                STUFF((Select DISTINCT ' , ' + cast(rus.Remarks as nvarchar) From dbo.Complaint as ct  INNER JOIN ComplaintRemarks as rus on  ct.ComplaintId = rus.ComplainId WHERE(ct.ComplaintId = c.ComplaintId) 
                FOR XML Path('')), 1, 1, '') AS Remarks FROM Complaint AS c
                INNER JOIN ComplaintStatus AS cs ON cs.ComplaintId = c.ComplaintId
                INNER JOIN ComplaintStatusDefinition AS csd ON csd.ComplaintStatusId = c.StatusId
                INNER JOIN Department AS dT ON dT.DepartmentCode = c.ForDepartment
                INNER JOIN Department AS dF ON dF.DepartmentCode = c.ByDepartment
                INNER JOIN ComplaintCategory AS cc ON cc.CategoryId = c.CategoryId
                LEFT OUTER JOIN ComplaintAssetCodes AS cac ON c.ComplaintId = cac.ComplaintId
                LEFT OUTER JOIN ChartOfAssets ca ON ca.ItemCodeSeparator = cac.AssetCode
                LEFT OUTER JOIN ComplaintPriorityDefinition AS cpd ON c.PriorityId = cpd.ComplaintPriorityId
                LEFT OUTER JOIN ComplaintRemarks AS cr ON c.ComplaintId = cr.ComplainId
                Where csd.ComplaintStatusId = 15 
                Group by cac.AssetCode,ca.ShortName,ca.ItemName,dt.DepartmentName,df.DepartmentName,c.Detail,csd.ComplaintStatus, c.ComplaintId,c.UserId
              ) main
              Where main.AgeHours > 8 order by FromDepartment asc
            End";
            migrationBuilder.Sql(Sp_GetComplaintVerficationForSendMail);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropGetComplaintVerficationDepartmentForSendMail = @"drop PROC Sp_GetComplaintVerficationDepartmentForSendMail";
            migrationBuilder.Sql(dropGetComplaintVerficationDepartmentForSendMail);

            var dropGetComplaintVerficationForSendMail = @"drop PROC Sp_GetComplaintVerficationForSendMail";
            migrationBuilder.Sql(dropGetComplaintVerficationForSendMail);
        }
    }
}
