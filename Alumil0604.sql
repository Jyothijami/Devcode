USE [Alumil]
GO
/****** Object:  StoredProcedure [dbo].[spUserNameExists]    Script Date: 06-04-2019 23:14:24 ******/
DROP PROCEDURE [dbo].[spUserNameExists]
GO
/****** Object:  StoredProcedure [dbo].[spEmpUserNameExists]    Script Date: 06-04-2019 23:14:24 ******/
DROP PROCEDURE [dbo].[spEmpUserNameExists]
GO
/****** Object:  StoredProcedure [dbo].[SP_UTY_USER_MASTER]    Script Date: 06-04-2019 23:14:24 ******/
DROP PROCEDURE [dbo].[SP_UTY_USER_MASTER]
GO
/****** Object:  StoredProcedure [dbo].[SP_PERMISSIONS]    Script Date: 06-04-2019 23:14:24 ******/
DROP PROCEDURE [dbo].[SP_PERMISSIONS]
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_UOM_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:24 ******/
DROP PROCEDURE [dbo].[SP_MASTER_UOM_SEARCH_SELECT]
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_SUBCATEGORY_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:24 ******/
DROP PROCEDURE [dbo].[SP_MASTER_SUBCATEGORY_SEARCH_SELECT]
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_REGION_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:24 ******/
DROP PROCEDURE [dbo].[SP_MASTER_REGION_SEARCH_SELECT]
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_PLANT_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:24 ******/
DROP PROCEDURE [dbo].[SP_MASTER_PLANT_SEARCH_SELECT]
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_ENQUIRYMODE_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:24 ******/
DROP PROCEDURE [dbo].[SP_MASTER_ENQUIRYMODE_SEARCH_SELECT]
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_DESPMODE_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:24 ******/
DROP PROCEDURE [dbo].[SP_MASTER_DESPMODE_SEARCH_SELECT]
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_DESG_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:24 ******/
DROP PROCEDURE [dbo].[SP_MASTER_DESG_SEARCH_SELECT]
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_DEPT_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:24 ******/
DROP PROCEDURE [dbo].[SP_MASTER_DEPT_SEARCH_SELECT]
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_CURRENCYTYPE_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:24 ******/
DROP PROCEDURE [dbo].[SP_MASTER_CURRENCYTYPE_SEARCH_SELECT]
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_COUNTRY_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:24 ******/
DROP PROCEDURE [dbo].[SP_MASTER_COUNTRY_SEARCH_SELECT]
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_CATEGORY_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:24 ******/
DROP PROCEDURE [dbo].[SP_MASTER_CATEGORY_SEARCH_SELECT]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomers]    Script Date: 06-04-2019 23:14:24 ******/
DROP PROCEDURE [dbo].[GetCustomers]
GO
ALTER TABLE [dbo].[State_Master] DROP CONSTRAINT [FK_State_Master_State_Master]
GO
/****** Object:  Index [CI_PaymentTermsId]    Script Date: 06-04-2019 23:14:24 ******/
DROP INDEX [CI_PaymentTermsId] ON [dbo].[PaymentTerms_Master]
GO
/****** Object:  Table [dbo].[Users_Menu]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Users_Menu]
GO
/****** Object:  Table [dbo].[User_Permissions]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[User_Permissions]
GO
/****** Object:  Index [CI_UserId]    Script Date: 06-04-2019 23:14:24 ******/
DROP INDEX [CI_UserId] ON [dbo].[User_Master] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[User_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[User_Master]
GO
/****** Object:  Table [dbo].[Uom_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Uom_Master]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Test]
GO
/****** Object:  Table [dbo].[Table1]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Table1]
GO
/****** Object:  Table [dbo].[SupplierRequest_Quotation_Suppliers]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[SupplierRequest_Quotation_Suppliers]
GO
/****** Object:  Table [dbo].[SupplierRequest_Quotation_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[SupplierRequest_Quotation_Master]
GO
/****** Object:  Table [dbo].[SupplierRequest_Quotation_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[SupplierRequest_Quotation_Details]
GO
/****** Object:  Table [dbo].[Supplier_Type]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Supplier_Type]
GO
/****** Object:  Table [dbo].[Supplier_Quotation_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Supplier_Quotation_Master]
GO
/****** Object:  Table [dbo].[Supplier_Quotation_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Supplier_Quotation_Details]
GO
/****** Object:  Table [dbo].[Supplier_PurchaseReceipt_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Supplier_PurchaseReceipt_Details]
GO
/****** Object:  Table [dbo].[Supplier_PurchaseReceipt]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Supplier_PurchaseReceipt]
GO
/****** Object:  Table [dbo].[Supplier_PurchaseOrderDetails]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Supplier_PurchaseOrderDetails]
GO
/****** Object:  Table [dbo].[Supplier_Po_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Supplier_Po_Master]
GO
/****** Object:  Table [dbo].[Supplier_Po_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Supplier_Po_Details]
GO
/****** Object:  Table [dbo].[Supplier_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Supplier_Master]
GO
/****** Object:  Table [dbo].[Suplier_PurchaseOrder]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Suplier_PurchaseOrder]
GO
/****** Object:  Table [dbo].[SubCategory_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[SubCategory_Master]
GO
/****** Object:  Table [dbo].[StorageLocation_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[StorageLocation_Master]
GO
/****** Object:  Table [dbo].[Stock_Type]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Stock_Type]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Stock]
GO
/****** Object:  Table [dbo].[State_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[State_Master]
GO
/****** Object:  Table [dbo].[SoMat_FileName]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[SoMat_FileName]
GO
/****** Object:  Table [dbo].[Salutation_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Salutation_Master]
GO
/****** Object:  Table [dbo].[SalesOrder_MaterialAnalysis]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[SalesOrder_MaterialAnalysis]
GO
/****** Object:  Table [dbo].[SalesOrder_GlassAnalysis]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[SalesOrder_GlassAnalysis]
GO
/****** Object:  Table [dbo].[SalesOrder_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[SalesOrder_Details]
GO
/****** Object:  Table [dbo].[SalesEnquiry_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[SalesEnquiry_Master]
GO
/****** Object:  Table [dbo].[SalesEnquiry_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[SalesEnquiry_Details]
GO
/****** Object:  Index [CI_SalesTermsId]    Script Date: 06-04-2019 23:14:24 ******/
DROP INDEX [CI_SalesTermsId] ON [dbo].[Sales_TermsConditions] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[Sales_TermsConditions]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Sales_TermsConditions]
GO
/****** Object:  Index [CI_StorageTempId]    Script Date: 06-04-2019 23:14:24 ******/
DROP INDEX [CI_StorageTempId] ON [dbo].[Sales_Storage_Template] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[Sales_Storage_Template]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Sales_Storage_Template]
GO
/****** Object:  Index [CI_QuatationDetId]    Script Date: 06-04-2019 23:14:24 ******/
DROP INDEX [CI_QuatationDetId] ON [dbo].[Sales_QuotationDetails] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[Sales_QuotationDetails]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Sales_QuotationDetails]
GO
/****** Object:  Table [dbo].[Sales_Quatation_CalcChange]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Sales_Quatation_CalcChange]
GO
/****** Object:  Table [dbo].[Sales_Order]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Sales_Order]
GO
/****** Object:  Table [dbo].[Sales_Invoice_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Sales_Invoice_Details]
GO
/****** Object:  Table [dbo].[Sales_Invoice]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Sales_Invoice]
GO
/****** Object:  Index [CI_SalesDamageTempId]    Script Date: 06-04-2019 23:14:24 ******/
DROP INDEX [CI_SalesDamageTempId] ON [dbo].[Sales_Damage_Template] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[Sales_Damage_Template]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Sales_Damage_Template]
GO
/****** Object:  Table [dbo].[SalaryStructure_Earning]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[SalaryStructure_Earning]
GO
/****** Object:  Table [dbo].[SalaryStructure_Deduction]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[SalaryStructure_Deduction]
GO
/****** Object:  Table [dbo].[Salary_Structure]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Salary_Structure]
GO
/****** Object:  Table [dbo].[Salary_Component]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Salary_Component]
GO
/****** Object:  Table [dbo].[Regional_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Regional_Master]
GO
/****** Object:  Table [dbo].[QuotationMaster_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[QuotationMaster_Details]
GO
/****** Object:  Index [CI_QuatationId]    Script Date: 06-04-2019 23:14:24 ******/
DROP INDEX [CI_QuatationId] ON [dbo].[Quotation_Master] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[Quotation_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Quotation_Master]
GO
/****** Object:  Table [dbo].[Quatation_Documents]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Quatation_Documents]
GO
/****** Object:  Index [CI_QCId]    Script Date: 06-04-2019 23:14:24 ******/
DROP INDEX [CI_QCId] ON [dbo].[Quatation_Changeables] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[Quatation_Changeables]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Quatation_Changeables]
GO
/****** Object:  Table [dbo].[Purchase_Receipt]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Purchase_Receipt]
GO
/****** Object:  Table [dbo].[ProductionOrder_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[ProductionOrder_Details]
GO
/****** Object:  Table [dbo].[ProductionOrder]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[ProductionOrder]
GO
/****** Object:  Table [dbo].[Plant_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Plant_Master]
GO
/****** Object:  Table [dbo].[PaymentTerms_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[PaymentTerms_Master]
GO
/****** Object:  Table [dbo].[Payments_Received]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Payments_Received]
GO
/****** Object:  Table [dbo].[Packing_Material]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Packing_Material]
GO
/****** Object:  Table [dbo].[Operation_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Operation_Master]
GO
/****** Object:  Table [dbo].[OfferTerms]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[OfferTerms]
GO
/****** Object:  Table [dbo].[OfferLetter_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[OfferLetter_Details]
GO
/****** Object:  Table [dbo].[OfferLetter]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[OfferLetter]
GO
/****** Object:  Table [dbo].[Mode_Payment]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Mode_Payment]
GO
/****** Object:  Table [dbo].[MaterialRequest_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[MaterialRequest_Details]
GO
/****** Object:  Table [dbo].[MaterialRequest]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[MaterialRequest]
GO
/****** Object:  Table [dbo].[MaterialGroup_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[MaterialGroup_Master]
GO
/****** Object:  Table [dbo].[Material_Type]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Material_Type]
GO
/****** Object:  Table [dbo].[Material_Status]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Material_Status]
GO
/****** Object:  Table [dbo].[Material_Receipt_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Material_Receipt_Details]
GO
/****** Object:  Table [dbo].[Material_Receipt]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Material_Receipt]
GO
/****** Object:  Table [dbo].[Material_PurchaseData]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Material_PurchaseData]
GO
/****** Object:  Table [dbo].[Material_MRPData]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Material_MRPData]
GO
/****** Object:  Table [dbo].[Material_Master2]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Material_Master2]
GO
/****** Object:  Table [dbo].[Material_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Material_Master]
GO
/****** Object:  Table [dbo].[Material_Manufacture_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Material_Manufacture_Details]
GO
/****** Object:  Table [dbo].[Material_Manufacture]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Material_Manufacture]
GO
/****** Object:  Table [dbo].[Material_Color_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Material_Color_Details]
GO
/****** Object:  Index [CI_LoddetailsId]    Script Date: 06-04-2019 23:14:24 ******/
DROP INDEX [CI_LoddetailsId] ON [dbo].[Login_Log_Details] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[Login_Log_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Login_Log_Details]
GO
/****** Object:  Table [dbo].[LeaveType]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[LeaveType]
GO
/****** Object:  Table [dbo].[Leave_Application]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Leave_Application]
GO
/****** Object:  Table [dbo].[LeadSource]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[LeadSource]
GO
/****** Object:  Table [dbo].[Lead]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Lead]
GO
/****** Object:  Table [dbo].[JobTitle]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[JobTitle]
GO
/****** Object:  Table [dbo].[JobOpenings]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[JobOpenings]
GO
/****** Object:  Table [dbo].[JobApplicant]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[JobApplicant]
GO
/****** Object:  Table [dbo].[ItemSeries]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[ItemSeries]
GO
/****** Object:  Index [CI_InstallationTempId]    Script Date: 06-04-2019 23:14:24 ******/
DROP INDEX [CI_InstallationTempId] ON [dbo].[Installation_Assistance_Template] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[Installation_Assistance_Template]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Installation_Assistance_Template]
GO
/****** Object:  Table [dbo].[IndustryType_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[IndustryType_Master]
GO
/****** Object:  Table [dbo].[Indent_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Indent_Master]
GO
/****** Object:  Table [dbo].[Indent_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Indent_Details]
GO
/****** Object:  Table [dbo].[Incoterms_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Incoterms_Master]
GO
/****** Object:  Table [dbo].[Grade_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Grade_Master]
GO
/****** Object:  Table [dbo].[GlassRequest_Quatation_Supplier]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[GlassRequest_Quatation_Supplier]
GO
/****** Object:  Table [dbo].[GlassRequest_Quatation_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[GlassRequest_Quatation_Master]
GO
/****** Object:  Table [dbo].[GlassRequest_Quatation_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[GlassRequest_Quatation_Details]
GO
/****** Object:  Table [dbo].[GlassQuatation_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[GlassQuatation_Details]
GO
/****** Object:  Table [dbo].[Glass_Quatation_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Glass_Quatation_Master]
GO
/****** Object:  Table [dbo].[Glass_PO_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Glass_PO_Master]
GO
/****** Object:  Table [dbo].[Glass_PO_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Glass_PO_Details]
GO
/****** Object:  Table [dbo].[Enquiry_Mode]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Enquiry_Mode]
GO
/****** Object:  Table [dbo].[Enquiry_GlassDetails]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Enquiry_GlassDetails]
GO
/****** Object:  Table [dbo].[Enquiry_FloorPlanDetails]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Enquiry_FloorPlanDetails]
GO
/****** Object:  Table [dbo].[Enquiry_FinishDetails]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Enquiry_FinishDetails]
GO
/****** Object:  Table [dbo].[Enquiry_ElevationDetails]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Enquiry_ElevationDetails]
GO
/****** Object:  Table [dbo].[Employee_Type]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Employee_Type]
GO
/****** Object:  Table [dbo].[Employee_SalaryStructure]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Employee_SalaryStructure]
GO
/****** Object:  Table [dbo].[Employee_SalaryDetails]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Employee_SalaryDetails]
GO
/****** Object:  Table [dbo].[Employee_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Employee_Master]
GO
/****** Object:  Table [dbo].[Employee_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Employee_Details]
GO
/****** Object:  Table [dbo].[Employee_Attendance]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Employee_Attendance]
GO
/****** Object:  Table [dbo].[DispatchMode_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[DispatchMode_Master]
GO
/****** Object:  Table [dbo].[Designation_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Designation_Master]
GO
/****** Object:  Table [dbo].[Department_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Department_Master]
GO
/****** Object:  Table [dbo].[Delivery_Challan_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Delivery_Challan_Master]
GO
/****** Object:  Table [dbo].[Delivery_Challan_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Delivery_Challan_Details]
GO
/****** Object:  Table [dbo].[Customer_Units]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Customer_Units]
GO
/****** Object:  Table [dbo].[Customer_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Customer_Master]
GO
/****** Object:  Table [dbo].[Currency_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Currency_Master]
GO
/****** Object:  Table [dbo].[Country_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Country_Master]
GO
/****** Object:  Table [dbo].[Company_Profile]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Company_Profile]
GO
/****** Object:  Table [dbo].[Company_LogoStamps]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Company_LogoStamps]
GO
/****** Object:  Table [dbo].[Color_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Color_Master]
GO
/****** Object:  Table [dbo].[Code_Prefix]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Code_Prefix]
GO
/****** Object:  Table [dbo].[City_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[City_Master]
GO
/****** Object:  Table [dbo].[Category_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Category_Master]
GO
/****** Object:  Table [dbo].[Brand_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Brand_Master]
GO
/****** Object:  Table [dbo].[Bom_Operations]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Bom_Operations]
GO
/****** Object:  Table [dbo].[Bom_Details]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Bom_Details]
GO
/****** Object:  Table [dbo].[Bom]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Bom]
GO
/****** Object:  Table [dbo].[Architect_Master]    Script Date: 06-04-2019 23:14:24 ******/
DROP TABLE [dbo].[Architect_Master]
GO
USE [master]
GO
/****** Object:  Database [Alumil]    Script Date: 06-04-2019 23:14:24 ******/
DROP DATABASE [Alumil]
GO
/****** Object:  Database [Alumil]    Script Date: 06-04-2019 23:14:24 ******/
CREATE DATABASE [Alumil]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ALUSOFT', FILENAME = N'C:\Program Files (x86)\Plesk\Databases\MSSQL\MSSQL11.MSSQLSERVER2012\MSSQL\DATA\Alumil.mdf' , SIZE = 7168KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ALUSOFT_log', FILENAME = N'C:\Program Files (x86)\Plesk\Databases\MSSQL\MSSQL11.MSSQLSERVER2012\MSSQL\DATA\Alumil_log.ldf' , SIZE = 15040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Alumil] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Alumil].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Alumil] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Alumil] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Alumil] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Alumil] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Alumil] SET ARITHABORT OFF 
GO
ALTER DATABASE [Alumil] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Alumil] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Alumil] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Alumil] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Alumil] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Alumil] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Alumil] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Alumil] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Alumil] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Alumil] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Alumil] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Alumil] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Alumil] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Alumil] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Alumil] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Alumil] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Alumil] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Alumil] SET RECOVERY FULL 
GO
ALTER DATABASE [Alumil] SET  MULTI_USER 
GO
ALTER DATABASE [Alumil] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Alumil] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Alumil] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Alumil] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Alumil]
GO
/****** Object:  Table [dbo].[Architect_Master]    Script Date: 06-04-2019 23:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Architect_Master](
	[Architect_Id] [bigint] NULL,
	[Architect_Name] [nvarchar](50) NULL,
	[Architect_Mobile] [nvarchar](50) NULL,
	[Architect_Email] [nvarchar](50) NULL,
	[Architect_Address] [nvarchar](150) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bom]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bom](
	[Bom_Id] [bigint] NULL,
	[So_Id] [bigint] NULL,
	[So_Det_Id] [bigint] NULL,
	[Quantity] [bigint] NULL,
	[Bom_No] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bom_Details]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bom_Details](
	[Bom_DetId] [bigint] NULL,
	[Bom_Id] [bigint] NULL,
	[Item_Id] [bigint] NULL,
	[Qty] [bigint] NULL,
	[Uom] [nvarchar](50) NULL,
	[Color_Id] [bigint] NULL,
	[RequiredLength] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bom_Operations]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bom_Operations](
	[So_Det_Id] [bigint] NULL,
	[Operation_Id] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand_Master]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand_Master](
	[Brand_Id] [bigint] NULL,
	[Brand_Name] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category_Master]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category_Master](
	[ITEM_CATEGORY_ID] [bigint] NULL,
	[ITEM_CATEGORY_NAME] [nvarchar](50) NULL,
	[ITEM_CATEGORY_DESC] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City_Master]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City_Master](
	[CITY_ID] [bigint] NOT NULL,
	[CITY_NAME] [nvarchar](50) NULL,
	[STATE_ID] [bigint] NOT NULL,
 CONSTRAINT [PK_City_Master] PRIMARY KEY CLUSTERED 
(
	[CITY_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Code_Prefix]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Code_Prefix](
	[PF_CUSTOMERINFO] [nvarchar](50) NULL,
	[PF_SALESQUOTATION] [nvarchar](50) NULL,
	[PF_SALESORDER] [nvarchar](50) NULL,
	[PF_SALESENQUIRY] [nvarchar](50) NULL,
	[PF_DELIVERYCHALLAN] [nvarchar](50) NULL,
	[PF_SALESINVOICE] [nvarchar](50) NULL,
	[PF_PAYMENTRECEIVED] [nvarchar](50) NULL,
	[PF_INDENT] [nvarchar](50) NULL,
	[PF_PURCHASEORDER] [nvarchar](50) NULL,
	[PF_OFFERLETTER] [nvarchar](50) NULL,
	[PF_PURCHASERECEIPT] [nvarchar](50) NULL,
	[PF_BOM] [nvarchar](50) NULL,
	[PF_PRODUCTIONORDER] [nvarchar](50) NULL,
	[PF_MATERIALRECEIPIT] [nvarchar](50) NULL,
	[PF_MATERIALREQUEST] [nvarchar](50) NULL,
	[PF_LEAD] [nvarchar](50) NULL,
	[PF_SUPPLIERQUATATION] [nvarchar](50) NULL,
	[PF_EMPMAS] [nvarchar](50) NULL,
	[PF_LEAVEAPPLICATION] [nvarchar](50) NULL,
	[PF_REQQUOTATION] [nvarchar](50) NULL,
	[PF_REQGLASSQUO] [nvarchar](50) NULL,
	[PF_GQUATATIONNO] [nvarchar](50) NULL,
	[PF_GPONO] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color_Master]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color_Master](
	[Color_Id] [bigint] NOT NULL,
	[Color_Name] [nvarchar](50) NULL,
	[Color_Desc] [nvarchar](max) NULL,
 CONSTRAINT [PK_Color_Master] PRIMARY KEY CLUSTERED 
(
	[Color_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company_LogoStamps]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company_LogoStamps](
	[CL_ID] [bigint] NOT NULL,
	[CP_ID] [bigint] NULL,
	[CL_STAMP] [nvarchar](max) NULL,
	[CL_LOGOS] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company_Profile]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company_Profile](
	[CP_ID] [bigint] NOT NULL,
	[CP_FULL_NAME] [nvarchar](50) NULL,
	[CP_SHORT_NAME] [nvarchar](50) NULL,
	[CP_CEO] [nvarchar](50) NULL,
	[CP_FOUNDATIONDATE] [date] NULL,
	[CP_PHONE_OFFICE] [nvarchar](50) NULL,
	[CP_EMAIL] [nvarchar](50) NULL,
	[CP_MOBILE] [nvarchar](50) NULL,
	[CP_FAXNO] [nvarchar](50) NULL,
	[CP_ADDRESS] [nvarchar](max) NULL,
	[CP_GST] [nvarchar](50) NULL,
	[CP_CF_YEAR] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country_Master]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country_Master](
	[COUNTRY_ID] [bigint] NOT NULL,
	[COUNTRY_NAME] [nvarchar](50) NULL,
	[CURRENCY] [nvarchar](50) NULL,
 CONSTRAINT [PK_Country_Master] PRIMARY KEY CLUSTERED 
(
	[COUNTRY_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currency_Master]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency_Master](
	[CURRENCY_ID] [bigint] NOT NULL,
	[CURRENCY_NAME] [nvarchar](50) NULL,
	[CURRENCY_FULL_NAME] [nvarchar](50) NULL,
	[CURRENCY_DESC] [nvarchar](150) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer_Master]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_Master](
	[CUST_ID] [bigint] NOT NULL,
	[CUST_CODE] [nvarchar](50) NULL,
	[CUST_NAME] [nvarchar](50) NULL,
	[CUST_COMPANY_NAME] [nvarchar](max) NULL,
	[CUST_CONTACT_PERSON] [nvarchar](50) NULL,
	[CUST_PHONE] [nvarchar](50) NULL,
	[CUST_MOBILE] [nvarchar](50) NULL,
	[CUST_FAX] [nvarchar](50) NULL,
	[CUST_EMAIL] [nvarchar](50) NULL,
	[CUST_PAN] [nvarchar](50) NULL,
	[CUST_GST] [nvarchar](50) NULL,
	[REG_ID] [bigint] NULL,
	[CUST_ADDRESS] [nvarchar](max) NULL,
	[CUST_CORP_CONTACT_PERSON] [nvarchar](50) NULL,
	[CUST_CORP_PHONE] [nvarchar](50) NULL,
	[CUST_CORP_MOBILE] [nvarchar](50) NULL,
	[CUST_CORP_EMAIL] [nvarchar](50) NULL,
	[CUST_CORP_ADDRESS] [nvarchar](max) NULL,
	[CUST_CORP_DESG_ID] [bigint] NULL,
	[CUST_CORP_FAX] [nvarchar](50) NULL,
	[CUST_STATUS] [nvarchar](50) NULL,
	[CUST_DEAR] [nvarchar](50) NULL,
	[CUST_DESG_ID] [bigint] NULL,
	[CUST_REF_BY_NAME] [nvarchar](50) NULL,
	[CUST_REF_BY_CONTACT] [nvarchar](50) NULL,
	[CUST_REF_BY_ADDRESS] [nvarchar](50) NULL,
	[CUST_ARCHITECT_NAME] [nvarchar](50) NULL,
	[CUST_ARCHITECT_CONTACT] [nvarchar](50) NULL,
	[CUST_ARCHITECT_ADDRESS] [nvarchar](50) NULL,
	[CUST_SITEINCHARGE_NAME] [nvarchar](50) NULL,
	[CUST_SITEINCHARGE_CONTACT] [nvarchar](50) NULL,
	[CUST_SITEINCHARGE_ADDRESS] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer_Master] PRIMARY KEY CLUSTERED 
(
	[CUST_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer_Units]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_Units](
	[CUST_UNIT_ID] [bigint] NOT NULL,
	[CUST_ID] [bigint] NOT NULL,
	[CUST_UNIT_NAME] [nvarchar](50) NULL,
	[CUST_UNIT_ADDRESS] [nvarchar](max) NULL,
	[CUST_NO_FlOORS] [nvarchar](50) NULL,
	[CUST_WINLOAD] [nvarchar](50) NULL,
	[CUST_CONTACTPERSON] [nvarchar](50) NULL,
	[CUST_MOBILE] [nvarchar](50) NULL,
	[ARCNAME] [bigint] NULL,
	[ARCMOBILE] [nvarchar](50) NULL,
	[PRONAME] [nvarchar](50) NULL,
	[PROMOBILE] [nvarchar](50) NULL,
	[CUST_CONTACTPERSON2] [nvarchar](50) NULL,
	[CUST_MOBILE2] [nvarchar](50) NULL,
	[CUST_CONTACTPERSON3] [nvarchar](50) NULL,
	[CUST_MOBILE3] [nvarchar](50) NULL,
	[ARCADDRESS] [nvarchar](max) NULL,
	[ARCEMAIL] [nvarchar](50) NULL,
	[PROEMAIL] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer_Units] PRIMARY KEY CLUSTERED 
(
	[CUST_UNIT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery_Challan_Details]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery_Challan_Details](
	[Dc_Det_Id] [bigint] NULL,
	[Dc_Id] [bigint] NULL,
	[Mat_Id] [bigint] NULL,
	[Code] [nvarchar](50) NULL,
	[Glass] [nvarchar](50) NULL,
	[Mesh] [nvarchar](50) NULL,
	[Width] [bigint] NULL,
	[Height] [bigint] NULL,
	[Qty] [bigint] NULL,
	[Pickup_Id] [bigint] NULL,
	[Remarks] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery_Challan_Master]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery_Challan_Master](
	[Dc_Id] [bigint] NULL,
	[Dc_No] [nvarchar](50) NULL,
	[Dc_Date] [date] NULL,
	[Transport_id] [bigint] NULL,
	[Lr_No] [nvarchar](50) NULL,
	[Lr_Date] [date] NULL,
	[So_Id] [bigint] NULL,
	[Preparedby] [bigint] NULL,
	[ApprovedBy] [bigint] NULL,
	[Cust_Id] [bigint] NULL,
	[Unit_Id] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department_Master]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department_Master](
	[DEPT_ID] [bigint] NOT NULL,
	[DEPT_NAME] [nvarchar](20) NULL,
	[DEPT_DESC] [nvarchar](max) NULL,
 CONSTRAINT [PK_Department_Master] PRIMARY KEY CLUSTERED 
(
	[DEPT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designation_Master]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation_Master](
	[DESG_ID] [bigint] NOT NULL,
	[DESG_NAME] [nvarchar](20) NULL,
	[DESG_DESC] [nvarchar](max) NULL,
 CONSTRAINT [PK_Designation_Master] PRIMARY KEY CLUSTERED 
(
	[DESG_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DispatchMode_Master]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DispatchMode_Master](
	[DESPM_ID] [bigint] NOT NULL,
	[DESPM_NAME] [nvarchar](50) NULL,
	[DESPM_DESC] [nvarchar](150) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee_Attendance]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_Attendance](
	[Attendance_Id] [bigint] NULL,
	[Attendance_Date] [date] NULL,
	[Emp_Id] [bigint] NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee_Details]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_Details](
	[EMP_DET_ID] [bigint] NOT NULL,
	[EMP_ID] [bigint] NOT NULL,
	[DEPT_ID] [bigint] NOT NULL,
	[DESG_ID] [bigint] NOT NULL,
	[EMP_DET_DOJ] [datetime] NULL,
	[EMP_DET_DOT] [datetime] NULL,
	[BRAN_ID] [bigint] NOT NULL,
	[EMP_TYPE_ID] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee_Master]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_Master](
	[EMP_ID] [bigint] NOT NULL,
	[EMP_FIRST_NAME] [nvarchar](20) NULL,
	[EMP_MIDDLE_NAME] [nvarchar](20) NULL,
	[EMP_LAST_NAME] [nvarchar](20) NULL,
	[EMP_GENDER] [nvarchar](10) NULL,
	[EMP_MOBILE] [nvarchar](20) NULL,
	[EMP_PHONE] [nvarchar](20) NULL,
	[EMP_DOB] [datetime] NULL,
	[EMP_EMAIL] [nvarchar](50) NULL,
	[EMP_PHOTO] [varbinary](max) NULL,
	[EMP_ADDRESS] [nvarchar](max) NULL,
	[EMP_CITY] [nvarchar](50) NULL,
	[EMP_USERNAME] [nvarchar](50) NULL,
	[EMP_PASSWORD] [nvarchar](50) NULL,
	[EMP_CPID] [bigint] NULL,
	[EMP_LEAVEAPPROVER_ID] [bigint] NULL,
	[EMP_NO] [nvarchar](50) NULL,
	[EMP_SALARY] [decimal](18, 2) NULL,
	[EMP_TDS] [decimal](18, 2) NULL,
	[BANK_ACCOUNT] [nvarchar](50) NULL,
	[GradeId] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee_SalaryDetails]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_SalaryDetails](
	[SALARY_ID] [bigint] NOT NULL,
	[EMP_ID] [nvarchar](50) NULL,
	[ALLOWANCE_SETUP_ID] [bigint] NULL,
	[ALLOWANCE_SETUP_TYPE] [nvarchar](50) NULL,
	[AMOUNT] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee_SalaryStructure]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_SalaryStructure](
	[Emp_SalStructure_Id] [bigint] NULL,
	[Emp_Id] [bigint] NULL,
	[From_date] [date] NULL,
	[Base] [decimal](18, 2) NULL,
	[SalaryStructure_Id] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee_Type]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_Type](
	[EMP_TYPE_ID] [bigint] NOT NULL,
	[EMP_TYPE_NAME] [nvarchar](50) NULL,
	[EMP_TYPE_DESC] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enquiry_ElevationDetails]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enquiry_ElevationDetails](
	[ELEVATION_ENQID] [bigint] NULL,
	[ELEVATION_RECEIVEDDATE] [date] NULL,
	[ELEVATION_REMARKS] [nvarchar](50) NULL,
	[ELEVATION_DOCUMENTS] [nvarchar](50) NULL,
	[ENQ_ID] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enquiry_FinishDetails]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enquiry_FinishDetails](
	[FINISH_ENQID] [bigint] NULL,
	[FINISH_COLOR] [nvarchar](50) NULL,
	[FINISH_RECEIVEDDATE] [date] NULL,
	[FINISH_PROFILE] [nvarchar](50) NULL,
	[FINISH_REMARKS] [nvarchar](50) NULL,
	[ENQ_ID] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enquiry_FloorPlanDetails]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enquiry_FloorPlanDetails](
	[FLOORPLAN_ENQID] [bigint] NULL,
	[FLOORPLAN_RECEIVEDDATE] [date] NULL,
	[FLOORPLAN_REMARKS] [nvarchar](50) NULL,
	[FLOORPLAN_DOCUMENTS] [nvarchar](50) NULL,
	[ENQ_ID] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enquiry_GlassDetails]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enquiry_GlassDetails](
	[ENQ_GLASSDETAILS_ID] [bigint] NULL,
	[GLASS_SPECIFICATIONS] [nvarchar](max) NULL,
	[GLASS_RECEIVEDDATE] [date] NULL,
	[GLASS_THICK] [nvarchar](50) NULL,
	[GLASS_REMARKS] [nvarchar](max) NULL,
	[ENQ_ID] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enquiry_Mode]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enquiry_Mode](
	[ENQM_ID] [bigint] NOT NULL,
	[ENQM_NAME] [nvarchar](50) NULL,
	[ENQM_DESC] [nvarchar](150) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Glass_PO_Details]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Glass_PO_Details](
	[Sup_GPO_Det_id] [bigint] NULL,
	[Sup_GPO_Id] [bigint] NULL,
	[WindowCode] [nvarchar](50) NULL,
	[Thickness] [decimal](18, 2) NULL,
	[Description] [nvarchar](max) NULL,
	[Width] [decimal](18, 2) NULL,
	[Height] [decimal](18, 2) NULL,
	[Unit] [nvarchar](50) NULL,
	[Area] [decimal](18, 2) NULL,
	[Weight] [decimal](18, 3) NULL,
	[ReqQty] [decimal](18, 3) NULL,
	[Rate] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 3) NULL,
	[Req_Date] [date] NULL,
	[ReceivedQty] [bigint] NULL,
	[RemainingQty] [bigint] NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Glass_PO_Master]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Glass_PO_Master](
	[Sup_GPO_Id] [bigint] NULL,
	[Sup_GPO_No] [nvarchar](50) NULL,
	[Sup_GPO_Date] [date] NULL,
	[Sup_Id] [bigint] NULL,
	[GlassQua_Id] [bigint] NULL,
	[Paymentterms_Id] [nvarchar](max) NULL,
	[TermsConditions_Id] [nvarchar](max) NULL,
	[Discount] [decimal](18, 1) NULL,
	[Tax] [decimal](18, 1) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[PreparedBy] [bigint] NULL,
	[ApprovedBy] [bigint] NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Glass_Quatation_Master]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Glass_Quatation_Master](
	[Sup_GQuo_Id] [bigint] NULL,
	[Sup_GQuo_No] [nvarchar](50) NULL,
	[Sup_GQuo_Date] [date] NULL,
	[Sup_Id] [bigint] NULL,
	[Po_Id] [bigint] NULL,
	[Paymentterms_Id] [nvarchar](max) NULL,
	[TermsConditions_Id] [nvarchar](max) NULL,
	[Discount] [decimal](18, 1) NULL,
	[Tax] [decimal](18, 1) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[PreparedBy] [bigint] NULL,
	[ApprovedBy] [bigint] NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GlassQuatation_Details]    Script Date: 06-04-2019 23:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GlassQuatation_Details](
	[Sup_GQuo_Det_id] [bigint] NULL,
	[Sup_GQuo_Id] [bigint] NULL,
	[WindowCode] [nvarchar](50) NULL,
	[Thickness] [decimal](18, 2) NULL,
	[Description] [nvarchar](max) NULL,
	[Width] [decimal](18, 2) NULL,
	[Height] [decimal](18, 2) NULL,
	[Unit] [nvarchar](50) NULL,
	[Area] [decimal](18, 2) NULL,
	[Weight] [decimal](18, 3) NULL,
	[ReqQty] [decimal](18, 3) NULL,
	[Rate] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 3) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GlassRequest_Quatation_Details]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GlassRequest_Quatation_Details](
	[GlassReq_Quo_Det_Id] [bigint] NULL,
	[GlassReq_Id] [bigint] NULL,
	[WindowCode] [nvarchar](50) NULL,
	[Thickness] [decimal](18, 2) NULL,
	[Description] [nvarchar](max) NULL,
	[Width] [decimal](18, 2) NULL,
	[Height] [decimal](18, 2) NULL,
	[Quantity] [bigint] NULL,
	[Unit] [nvarchar](50) NULL,
	[Area] [decimal](18, 2) NULL,
	[Weight] [decimal](18, 3) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GlassRequest_Quatation_Master]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GlassRequest_Quatation_Master](
	[GlassReqSup_Quo_Id] [bigint] NULL,
	[GlassReqSup_Quo_No] [nvarchar](50) NULL,
	[GlassReqSup_Quo_Date] [date] NULL,
	[So_Id] [bigint] NULL,
	[Remarks] [nvarchar](max) NULL,
	[PreparedBy] [bigint] NULL,
	[ApprovedBy] [bigint] NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GlassRequest_Quatation_Supplier]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GlassRequest_Quatation_Supplier](
	[GlassReq_Sup_Id] [bigint] NULL,
	[GlassReq_Id] [bigint] NULL,
	[Sup_Id] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grade_Master]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grade_Master](
	[Grade_Id] [bigint] NULL,
	[Grade_Name] [nvarchar](50) NULL,
	[Grade_Details] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Incoterms_Master]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incoterms_Master](
	[IncoTerms_Id] [bigint] NOT NULL,
	[IncoTerms] [nvarchar](max) NULL,
	[Incoterms_Desc] [nvarchar](max) NULL,
 CONSTRAINT [PK_Incoterms_Master] PRIMARY KEY CLUSTERED 
(
	[IncoTerms_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Indent_Details]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Indent_Details](
	[Ind_det_Id] [bigint] NULL,
	[Indent_Id] [bigint] NULL,
	[Mat_Id] [bigint] NULL,
	[Length] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Color] [nvarchar](50) NULL,
	[Qty] [bigint] NULL,
	[Cust_Id] [bigint] NULL,
	[KGpermt] [bigint] NULL,
	[TotalWeight] [decimal](18, 2) NULL,
	[aluminiumcoating] [decimal](18, 2) NULL,
	[Totalamount] [decimal](18, 2) NULL,
	[Color_Id] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Indent_Master]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Indent_Master](
	[Indent_Id] [bigint] NULL,
	[Indent_No] [nvarchar](50) NULL,
	[Indent_Date] [date] NULL,
	[Dept_Id] [bigint] NULL,
	[FollowUp_Id] [bigint] NULL,
	[PreparedBy] [bigint] NULL,
	[ApprovedBy] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IndustryType_Master]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IndustryType_Master](
	[IndustryType_Id] [bigint] NULL,
	[IndustryType] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Installation_Assistance_Template]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Installation_Assistance_Template](
	[Sales_Installation_Id] [bigint] NULL,
	[Terms_Conditions_Name] [nvarchar](50) NULL,
	[Descritpion] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [CI_InstallationTempId]    Script Date: 06-04-2019 23:14:26 ******/
CREATE UNIQUE CLUSTERED INDEX [CI_InstallationTempId] ON [dbo].[Installation_Assistance_Template]
(
	[Sales_Installation_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemSeries]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemSeries](
	[Item_Series_Id] [bigint] NULL,
	[Item_Series] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobApplicant]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobApplicant](
	[JobApplicant_Id] [bigint] NULL,
	[Applicant_Name] [nvarchar](50) NULL,
	[JobOpening_Id] [bigint] NULL,
	[Applicant_Email] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[CoverLetter] [nvarchar](max) NULL,
	[Attachement] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobOpenings]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobOpenings](
	[JobOpening_id] [bigint] NULL,
	[Job_Title] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Created_On] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobTitle]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobTitle](
	[Jobtitle_Id] [bigint] NOT NULL,
	[JobTitle] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_JobTitle] PRIMARY KEY CLUSTERED 
(
	[Jobtitle_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lead]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lead](
	[Lead_Id] [bigint] NULL,
	[Lead_Status] [nvarchar](50) NULL,
	[Person_Name] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NULL,
	[Organization_Name] [nvarchar](50) NULL,
	[LeadSource_Id] [bigint] NULL,
	[Email_Address] [nvarchar](50) NULL,
	[Lead_Owner] [bigint] NULL,
	[NextContact_Date] [date] NULL,
	[NextContactBy] [bigint] NULL,
	[Phone] [nvarchar](50) NULL,
	[Salutation_Id] [bigint] NULL,
	[MobileNo] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[MarketSegment] [nvarchar](50) NULL,
	[Industry_Id] [bigint] NULL,
	[RequestType] [nvarchar](50) NULL,
	[Lead_No] [nvarchar](50) NULL,
	[Lead_Date] [date] NULL,
	[Cp_Id] [bigint] NULL,
	[StateId] [bigint] NULL,
	[CityId] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeadSource]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadSource](
	[LeadSource_id] [bigint] NULL,
	[LeadSource] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave_Application]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leave_Application](
	[Lap_id] [bigint] NOT NULL,
	[Lap_No] [nvarchar](50) NULL,
	[LeaveType_Id] [bigint] NULL,
	[Status] [nvarchar](50) NULL,
	[From_date] [date] NULL,
	[To_date] [date] NULL,
	[Reason] [nvarchar](max) NULL,
	[Halfday] [nvarchar](50) NULL,
	[Halfday_date] [date] NULL,
	[Emp_Id] [bigint] NULL,
	[Leaveapprover_id] [bigint] NULL,
	[Posting_date] [date] NULL,
 CONSTRAINT [PK_Leave_Application] PRIMARY KEY CLUSTERED 
(
	[Lap_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveType]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveType](
	[LeaveType_Id] [bigint] NULL,
	[LeaveType_name] [nvarchar](50) NULL,
	[MaxDay_Allowed] [bigint] NULL,
	[ISCarryForword] [nvarchar](50) NULL,
	[IsLeavewithoutPay] [nvarchar](50) NULL,
	[AllowNegitiveBalance] [nvarchar](50) NULL,
	[IncludeHolidayswithinLeaveasLeave] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login_Log_Details]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login_Log_Details](
	[LOGID] [bigint] NOT NULL,
	[USERNAME] [nvarchar](50) NULL,
	[DATE] [date] NULL,
	[TIME] [time](7) NULL
) ON [PRIMARY]
GO
/****** Object:  Index [CI_LoddetailsId]    Script Date: 06-04-2019 23:14:26 ******/
CREATE UNIQUE CLUSTERED INDEX [CI_LoddetailsId] ON [dbo].[Login_Log_Details]
(
	[LOGID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material_Color_Details]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material_Color_Details](
	[Material_Color_Id] [bigint] NULL,
	[Material_id] [bigint] NULL,
	[Color_Id] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material_Manufacture]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material_Manufacture](
	[Mt_Manf_Id] [bigint] NULL,
	[Mt_Man_No] [nvarchar](50) NULL,
	[Mt_Date] [date] NULL,
	[Productionorder_Id] [bigint] NULL,
	[prepared_by] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material_Manufacture_Details]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material_Manufacture_Details](
	[Mat_Man_det_Id] [bigint] NULL,
	[Mat_Man_Id] [bigint] NULL,
	[Item_Code] [bigint] NULL,
	[Color] [bigint] NULL,
	[ReqQty] [bigint] NULL,
	[BarLength] [bigint] NULL,
	[Required_Barlength] [bigint] NULL,
	[Transferqty] [bigint] NULL,
	[Uom] [nvarchar](50) NULL,
	[Sourcewarehouse_id] [bigint] NULL,
	[Targetwarehouse_Id] [bigint] NULL,
	[Scrapwarehouse_id] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material_Master]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material_Master](
	[Material_Id] [bigint] NULL,
	[Material_Code] [nvarchar](50) NULL,
	[Category_Id] [bigint] NULL,
	[Box_Size] [bigint] NULL,
	[Bar_Length] [bigint] NULL,
	[UOM_Id] [bigint] NULL,
	[Description] [nvarchar](max) NULL,
	[Weight] [bigint] NULL,
	[Plant_Id] [bigint] NULL,
	[Storage_Location_Id] [bigint] NULL,
	[Item_Group] [bigint] NULL,
	[SellingPrice] [decimal](18, 2) NULL,
	[Series] [bigint] NULL,
	[Cp_Id] [bigint] NULL,
	[BuyingPrice] [decimal](18, 2) NULL,
	[BuyingCurrency] [bigint] NULL,
	[Brand_Id] [bigint] NULL,
	[SellingCurrency] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material_Master2]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material_Master2](
	[Material_Id] [bigint] NOT NULL,
	[Material_Code] [nvarchar](50) NULL,
	[Uom_Id] [bigint] NULL,
	[MaterialGroup_Id] [bigint] NULL,
	[OldMaterial_Number] [nvarchar](50) NULL,
	[Gross_Weight] [decimal](18, 3) NULL,
	[Weight_Unit] [bigint] NULL,
	[Net_Weight] [decimal](18, 3) NULL,
	[Size_Dimensions] [nvarchar](50) NULL,
	[PackingMaterial_Id] [bigint] NULL,
	[Material_Status_Id] [bigint] NULL,
	[Material_Name] [nvarchar](50) NULL,
	[MaterialType_Id] [bigint] NULL,
	[Material_Drawings] [nvarchar](max) NULL,
	[Color_Id] [bigint] NULL,
	[MRP] [decimal](18, 2) NULL,
	[SSP] [decimal](18, 2) NULL,
	[HSN] [nvarchar](50) NULL,
	[Item_Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Material_BasicData] PRIMARY KEY CLUSTERED 
(
	[Material_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material_MRPData]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material_MRPData](
	[Material_Mrpid] [bigint] NULL,
	[CP_id] [bigint] NULL,
	[Plant_Id] [bigint] NULL,
	[Matid] [bigint] NULL,
	[MrpType_Id] [bigint] NULL,
	[ReorderPoint] [bigint] NULL,
	[LotSize] [nvarchar](50) NULL,
	[Mrp_Group_ID] [bigint] NULL,
	[Minimum_Lotsize] [nvarchar](50) NULL,
	[Procurment_Type] [nvarchar](50) NULL,
	[StoreLocation_Id] [bigint] NULL,
	[GRProcessingTime] [bigint] NULL,
	[SaftyStock] [bigint] NULL,
	[MinimumSaftyStock] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material_PurchaseData]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material_PurchaseData](
	[MaterialPurchase_Id] [bigint] NOT NULL,
	[Mat_id] [bigint] NULL,
	[Cp_Id] [bigint] NULL,
	[Plant_Id] [bigint] NULL,
	[OrderUnit] [bigint] NULL,
	[PurchaseGroup_Id] [bigint] NULL,
	[Gr_ProcessingTime] [bigint] NULL,
	[PurchaseOrder_Text] [nvarchar](max) NULL,
 CONSTRAINT [PK_Material_PurchaseData] PRIMARY KEY CLUSTERED 
(
	[MaterialPurchase_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material_Receipt]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material_Receipt](
	[Material_Receipt_Id] [bigint] NULL,
	[Material_Receipt_No] [nvarchar](50) NULL,
	[Posting_Date] [date] NULL,
	[Created_By] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material_Receipt_Details]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material_Receipt_Details](
	[Material_Receipt_Details_Id] [bigint] NULL,
	[Material_Receipt_Id] [bigint] NULL,
	[Itemcode_Id] [bigint] NULL,
	[Color_Id] [bigint] NULL,
	[Quantity] [bigint] NULL,
	[Storageloc_Id] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material_Status]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material_Status](
	[MaterialStatus_Id] [bigint] NOT NULL,
	[Material_Status] [nvarchar](50) NULL,
	[Material_Desc] [nvarchar](max) NULL,
 CONSTRAINT [PK_Material_Status] PRIMARY KEY CLUSTERED 
(
	[MaterialStatus_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material_Type]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material_Type](
	[MaterialType_Id] [bigint] NULL,
	[Material_Type] [nvarchar](50) NULL,
	[Material_Description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialGroup_Master]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialGroup_Master](
	[MaterialGroup_Id] [bigint] NOT NULL,
	[MaterialGroup] [nvarchar](50) NULL,
	[MaterialGroup_Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_MaterialGroup_Master] PRIMARY KEY CLUSTERED 
(
	[MaterialGroup_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialRequest]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialRequest](
	[MaterialRequest_Id] [bigint] NULL,
	[MaterialRequest_No] [nvarchar](50) NULL,
	[Required_Date] [date] NULL,
	[Request_Type] [nvarchar](50) NULL,
	[Requested_For] [nvarchar](max) NULL,
	[Requested_Date] [date] NULL,
	[TermsConditions_Id] [nvarchar](max) NULL,
	[Prepared_By] [bigint] NULL,
	[Status] [nvarchar](50) NULL,
	[SO_Id] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialRequest_Details]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialRequest_Details](
	[Mreq_Det_Id] [bigint] NULL,
	[Mreq_Id] [bigint] NULL,
	[Item_Code] [bigint] NULL,
	[Quantity] [bigint] NULL,
	[Req_Date] [date] NULL,
	[warehouse_Id] [bigint] NULL,
	[Color_Id] [bigint] NULL,
	[RequestedFor] [nvarchar](50) NULL,
	[SO_Id] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mode_Payment]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mode_Payment](
	[Mode_Payment_Id] [bigint] NULL,
	[Mode_Payment] [nvarchar](50) NULL,
	[Mode_Descrition] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OfferLetter]    Script Date: 06-04-2019 23:14:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfferLetter](
	[OfferLetter_Id] [bigint] NULL,
	[JobApp_Id] [bigint] NULL,
	[JobOffer_Date] [date] NULL,
	[Status] [nvarchar](50) NULL,
	[Desgination_Id] [bigint] NULL,
	[TermsandConditions] [nvarchar](max) NULL,
	[Offer_No] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OfferLetter_Details]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfferLetter_Details](
	[OfferletterDetails_Id] [bigint] NULL,
	[OfferTerm] [nvarchar](50) NULL,
	[Offerterm_Decription] [nvarchar](max) NULL,
	[OfferLetter_Id] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OfferTerms]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfferTerms](
	[Offerterm_id] [bigint] NULL,
	[Offer_term] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operation_Master]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operation_Master](
	[Operation_Id] [bigint] NULL,
	[Operation_Name] [nvarchar](50) NULL,
	[Operation_Details] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Packing_Material]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packing_Material](
	[PackingMaterial_Id] [bigint] NULL,
	[Packing_Material] [nvarchar](50) NULL,
	[Packing_Description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments_Received]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments_Received](
	[PR_Id] [bigint] NOT NULL,
	[PR_No] [nvarchar](50) NULL,
	[PR_Date] [date] NULL,
	[SI_Id] [bigint] NULL,
	[SI_Amount] [decimal](18, 2) NULL,
	[PR_Amt_Received] [decimal](18, 2) NULL,
	[PR_Paymode_Type] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Payments_Received] PRIMARY KEY CLUSTERED 
(
	[PR_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentTerms_Master]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentTerms_Master](
	[PaymentTerms_Id] [bigint] NOT NULL,
	[PaymentTerms] [nvarchar](max) NULL,
	[PaymentTerms_Desc] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plant_Master]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plant_Master](
	[Plant_Id] [bigint] NULL,
	[Company_Id] [bigint] NULL,
	[Plant_Name] [nvarchar](50) NULL,
	[Plant_Description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductionOrder]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductionOrder](
	[ProductionOrder_Id] [bigint] NULL,
	[ProductionOrder_No] [nvarchar](50) NULL,
	[Item_Id] [bigint] NULL,
	[Bom_Id] [bigint] NULL,
	[QtytoManf] [bigint] NULL,
	[SalesOrder_Id] [bigint] NULL,
	[WorkInProgress_WarehouseId] [bigint] NULL,
	[ScrapWarehouse_Id] [bigint] NULL,
	[Targetwarehouse_Id] [bigint] NULL,
	[PlannedStartDate] [datetime] NULL,
	[ExpectedDeliceryDate] [datetime] NULL,
	[PreparedBy] [bigint] NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductionOrder_Details]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductionOrder_Details](
	[ProductionOder_det_Id] [bigint] NULL,
	[Production_Id] [bigint] NULL,
	[Item_Code] [bigint] NULL,
	[Color] [bigint] NULL,
	[ReqQty] [bigint] NULL,
	[BarLength] [bigint] NULL,
	[Required_Barlength] [bigint] NULL,
	[Transferqty] [bigint] NULL,
	[Uom] [nvarchar](50) NULL,
	[Sourcewarehouse_id] [bigint] NULL,
	[Targetwarehouse_Id] [bigint] NULL,
	[Scrapwarehouse_id] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase_Receipt]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase_Receipt](
	[PR_Id] [bigint] NULL,
	[PR_No] [nvarchar](50) NULL,
	[PR_Date] [date] NULL,
	[Sup_Id] [bigint] NULL,
	[Prepared_by] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quatation_Changeables]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quatation_Changeables](
	[QC_id] [bigint] NULL,
	[Euro_Price] [decimal](18, 2) NULL,
	[Freight] [decimal](18, 2) NULL,
	[Customs] [decimal](18, 2) NULL,
	[Insurance] [decimal](18, 2) NULL,
	[Clearance] [decimal](18, 2) NULL,
	[Wastage] [decimal](18, 2) NULL,
	[WallPlugs] [decimal](18, 2) NULL,
	[Silicon] [decimal](18, 2) NULL,
	[Maskingtape] [decimal](18, 2) NULL,
	[BackorRod] [decimal](18, 2) NULL,
	[FabricationPerSft] [decimal](18, 2) NULL,
	[FabricationPerSqm] [decimal](18, 2) NULL,
	[InstallationPerSft] [decimal](18, 2) NULL,
	[InstallationPerSqm] [decimal](18, 2) NULL,
	[Margin] [decimal](18, 1) NULL,
	[Silicon_Width] [decimal](18, 2) NULL,
	[Silicon_Depth] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Index [CI_QCId]    Script Date: 06-04-2019 23:14:27 ******/
CREATE UNIQUE CLUSTERED INDEX [CI_QCId] ON [dbo].[Quatation_Changeables]
(
	[QC_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quatation_Documents]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quatation_Documents](
	[Quatation_Doc_Id] [bigint] NULL,
	[Quatation_Doc_Date] [date] NULL,
	[Quatation_Remarks] [nvarchar](max) NULL,
	[Quatation_Documents] [nvarchar](max) NULL,
	[Quatation_Id] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quotation_Master]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quotation_Master](
	[Quotation_Id] [bigint] NULL,
	[Quotation_No] [nvarchar](50) NULL,
	[Quotation_Date] [datetime] NULL,
	[Quotation_to] [nvarchar](50) NULL,
	[Valid_To] [date] NULL,
	[Enq_Id] [bigint] NULL,
	[Cust_ID] [bigint] NULL,
	[Unit_Id] [bigint] NULL,
	[SalesEmp_Id] [bigint] NULL,
	[PaymentTerms_Id] [bigint] NULL,
	[TermsCondtions_Id] [bigint] NULL,
	[Discount] [decimal](18, 1) NULL,
	[Tax] [decimal](18, 1) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[PreparedBy] [bigint] NULL,
	[ApprovedBy] [bigint] NULL,
	[RevisedKey] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[InstallationTemp_Id] [bigint] NULL,
	[DamageTemp_Id] [bigint] NULL,
	[StorageTemp_Id] [bigint] NULL,
	[Specifications] [nvarchar](max) NULL,
	[DesginerId] [bigint] NULL,
	[Revised_date] [date] NULL,
	[Aluminum_Color] [nvarchar](50) NULL,
	[Hardware_Color] [nvarchar](50) NULL,
	[Wind_Load] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [CI_QuatationId]    Script Date: 06-04-2019 23:14:27 ******/
CREATE UNIQUE CLUSTERED INDEX [CI_QuatationId] ON [dbo].[Quotation_Master]
(
	[Quotation_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuotationMaster_Details]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuotationMaster_Details](
	[QuotationDet_Id] [bigint] NULL,
	[Quotation_Id] [bigint] NULL,
	[Code] [nvarchar](50) NULL,
	[Width] [nvarchar](50) NULL,
	[Height] [nvarchar](50) NULL,
	[StillHeight] [nvarchar](50) NULL,
	[Series] [nvarchar](50) NULL,
	[Quantity] [bigint] NULL,
	[Glass] [nvarchar](50) NULL,
	[FlyScreen] [nvarchar](50) NULL,
	[Amount] [decimal](18, 2) NULL,
	[Total_Amount] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regional_Master]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regional_Master](
	[REG_ID] [bigint] NOT NULL,
	[REG_NAME] [nvarchar](50) NULL,
	[REG_DESC] [nvarchar](150) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salary_Component]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salary_Component](
	[SalaryComp_id] [bigint] NULL,
	[SalaryComp_Name] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Max_Amount] [decimal](18, 2) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salary_Structure]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salary_Structure](
	[ALLOWANCE_SETUP_ID] [bigint] NOT NULL,
	[Categoryid] [bigint] NULL,
	[ALLOWANCE_MASTER_ID] [bigint] NULL,
	[ALLOWANCE_SETUP_TYPE] [nvarchar](50) NULL,
	[ALLOWANCE_SETUP_CALCULATIONS] [nvarchar](50) NULL,
	[ALLOWANCE_SETUP_AMOUNT] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalaryStructure_Deduction]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaryStructure_Deduction](
	[SalaryStruct_Deduction_Id] [bigint] NULL,
	[Component_Id] [bigint] NULL,
	[Amout] [decimal](18, 2) NULL,
	[SalaryStructure_Id] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalaryStructure_Earning]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaryStructure_Earning](
	[SalaryStruc_Earnings_Id] [bigint] NULL,
	[Component_Id] [bigint] NULL,
	[Amount] [decimal](18, 2) NULL,
	[SalaryStructure_Id] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales_Damage_Template]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales_Damage_Template](
	[Sales_Damage_Id] [bigint] NULL,
	[Terms_Conditions_Name] [nvarchar](50) NULL,
	[Descritpion] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [CI_SalesDamageTempId]    Script Date: 06-04-2019 23:14:27 ******/
CREATE UNIQUE CLUSTERED INDEX [CI_SalesDamageTempId] ON [dbo].[Sales_Damage_Template]
(
	[Sales_Damage_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales_Invoice]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales_Invoice](
	[Invoice_Id] [bigint] NOT NULL,
	[Invoice_No] [nvarchar](50) NULL,
	[Invoice_Date] [date] NULL,
	[Invoice_DueDate] [date] NULL,
	[So_Id] [bigint] NULL,
	[PaymentTerms_Id] [bigint] NULL,
	[Remarks] [nvarchar](max) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[BalanceDue] [decimal](18, 2) NULL,
	[PreparedBy] [bigint] NULL,
	[ApprovedBy] [bigint] NULL,
	[Discount] [decimal](18, 1) NULL,
	[Tax] [decimal](18, 1) NULL,
	[CustId] [bigint] NULL,
	[UnitId] [bigint] NULL,
 CONSTRAINT [PK_Sales_Invoice] PRIMARY KEY CLUSTERED 
(
	[Invoice_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales_Invoice_Details]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales_Invoice_Details](
	[InvoiceDet_Id] [bigint] NULL,
	[Invoice_Id] [bigint] NULL,
	[Material_Id] [bigint] NULL,
	[Description] [nvarchar](max) NULL,
	[Mesh] [nvarchar](50) NULL,
	[Glass] [nvarchar](50) NULL,
	[Width] [bigint] NULL,
	[Height] [bigint] NULL,
	[Qty] [bigint] NULL,
	[AreaSqMt] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales_Order]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales_Order](
	[SalesOrder_Id] [bigint] NOT NULL,
	[SalesOrder_No] [nvarchar](50) NULL,
	[SalesOrder_Date] [date] NULL,
	[Delivery_Date] [date] NULL,
	[OrderType] [nvarchar](50) NULL,
	[CustPurchaseorder] [nvarchar](50) NULL,
	[Quatation_Id] [bigint] NULL,
	[CustId] [bigint] NULL,
	[CustSiteId] [bigint] NULL,
	[PurchaseCondtions_Id] [nvarchar](max) NULL,
	[TermsCondtions_Id] [nvarchar](max) NULL,
	[PreparedBy] [bigint] NULL,
	[ApprovedBy] [bigint] NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Sales_Order] PRIMARY KEY CLUSTERED 
(
	[SalesOrder_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales_Quatation_CalcChange]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales_Quatation_CalcChange](
	[QuatationChang_Id] [bigint] NULL,
	[Quatation_Id] [bigint] NULL,
	[Euro_Price] [decimal](18, 2) NULL,
	[Freight] [decimal](18, 2) NULL,
	[Customs] [decimal](18, 2) NULL,
	[Insurance] [decimal](18, 2) NULL,
	[Clearance] [decimal](18, 2) NULL,
	[Wastage] [decimal](18, 2) NULL,
	[WallPlugs] [decimal](18, 2) NULL,
	[Silicon] [decimal](18, 2) NULL,
	[Maskingtape] [decimal](18, 2) NULL,
	[BackorRod] [decimal](18, 2) NULL,
	[FabricationPerSft] [decimal](18, 2) NULL,
	[FabricationPerSqm] [decimal](18, 2) NULL,
	[InstallationPerSft] [decimal](18, 2) NULL,
	[InstallationPerSqm] [decimal](18, 2) NULL,
	[Margin] [decimal](18, 1) NULL,
	[Silicon_Width] [decimal](18, 2) NULL,
	[Silicon_Depth] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales_QuotationDetails]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales_QuotationDetails](
	[QuotationDet_id] [bigint] NULL,
	[Quotation_Id] [bigint] NULL,
	[WindowCode] [nvarchar](50) NULL,
	[System] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Glass] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[Mesh] [nvarchar](50) NULL,
	[ProfileColor] [nvarchar](50) NULL,
	[HardwareColor] [nvarchar](50) NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[Qty] [int] NULL,
	[TotalArea] [decimal](18, 2) NULL,
	[ProfileCostEuro] [decimal](18, 2) NULL,
	[GlassPrice] [decimal](18, 2) NULL,
	[MeshPrice] [decimal](18, 2) NULL,
	[RecractablePrice] [decimal](18, 2) NULL,
	[MSInsertPrice] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[ExtraGlassWidth] [int] NULL,
	[ExtraGlassHeight] [int] NULL,
	[ExtraGlassQty] [int] NULL,
	[ExtraGlassArea] [decimal](18, 2) NULL,
	[ExtraGlassPrice] [decimal](18, 2) NULL,
	[HardwarePrice] [decimal](18, 2) NULL,
	[Item_Image] [varbinary](max) NULL,
	[ElevationView] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [CI_QuatationDetId]    Script Date: 06-04-2019 23:14:27 ******/
CREATE UNIQUE CLUSTERED INDEX [CI_QuatationDetId] ON [dbo].[Sales_QuotationDetails]
(
	[QuotationDet_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales_Storage_Template]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales_Storage_Template](
	[Sales_Storage_Id] [bigint] NULL,
	[Terms_Conditions_Name] [nvarchar](50) NULL,
	[Descritpion] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [CI_StorageTempId]    Script Date: 06-04-2019 23:14:27 ******/
CREATE UNIQUE CLUSTERED INDEX [CI_StorageTempId] ON [dbo].[Sales_Storage_Template]
(
	[Sales_Storage_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales_TermsConditions]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales_TermsConditions](
	[Sales_TC_Id] [bigint] NULL,
	[Terms_Conditions_Name] [nvarchar](50) NULL,
	[Descritpion] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [CI_SalesTermsId]    Script Date: 06-04-2019 23:14:27 ******/
CREATE UNIQUE CLUSTERED INDEX [CI_SalesTermsId] ON [dbo].[Sales_TermsConditions]
(
	[Sales_TC_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesEnquiry_Details]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesEnquiry_Details](
	[ENQ_DET_ID] [bigint] NOT NULL,
	[ENQ_ID] [bigint] NULL,
	[CODES] [nvarchar](50) NULL,
	[WIDTH] [nvarchar](50) NULL,
	[HEIGHT] [nvarchar](50) NULL,
	[SILLHEIGHT] [nvarchar](50) NULL,
	[QTY] [nvarchar](50) NULL,
	[GLASS] [nvarchar](50) NULL,
	[FLYSCREEN] [nvarchar](50) NULL,
	[PROFILEFINISH] [nvarchar](50) NULL,
	[SERIES] [nvarchar](50) NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[LOCATION] [nvarchar](50) NULL,
	[TOTALAREA] [decimal](18, 2) NULL,
	[TOTALAMOUNT] [decimal](18, 2) NULL,
 CONSTRAINT [PK_SalesEnquiry_Details] PRIMARY KEY CLUSTERED 
(
	[ENQ_DET_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesEnquiry_Master]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesEnquiry_Master](
	[ENQ_ID] [bigint] NOT NULL,
	[ENQ_NO] [nvarchar](50) NULL,
	[ENQ_DATE] [date] NULL,
	[CUST_ID] [bigint] NULL,
	[UNIT_ID] [bigint] NULL,
	[SLAESINCHARGE_ID] [bigint] NULL,
	[DESIGNINCHARGE_ID] [bigint] NULL,
	[PREPAREDBY] [bigint] NULL,
	[APPROVEDBY] [bigint] NULL,
	[REVISEDKEY] [nvarchar](50) NULL,
	[STATUS] [nvarchar](50) NULL,
	[CONTACTBY_ID] [bigint] NULL,
	[CONTACT_DATE] [date] NULL,
	[TODISCUSS] [nvarchar](max) NULL,
	[SPECIFICATIONS] [nvarchar](max) NULL,
	[PRODUCT_REQURIED] [nvarchar](max) NULL,
	[GLASSSPECIFICATION] [nvarchar](max) NULL,
	[GLASSTHICKNESS] [nvarchar](50) NULL,
	[GLASSCOLORCODE] [nvarchar](50) NULL,
	[POWERCOATING] [nvarchar](50) NULL,
	[ANODIZING] [nvarchar](50) NULL,
	[WOODEFFECT] [nvarchar](50) NULL,
	[ARCHIDRAWINGSATTACH] [nvarchar](50) NULL,
	[SITEPHOTOSATTACH] [nvarchar](50) NULL,
 CONSTRAINT [PK_SalesEnquiry_Master] PRIMARY KEY CLUSTERED 
(
	[ENQ_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesOrder_Details]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrder_Details](
	[SalesOrderDet_Id] [bigint] NULL,
	[SalesOrder_Id] [bigint] NULL,
	[Code] [nvarchar](50) NULL,
	[Series] [nvarchar](50) NULL,
	[Width] [nvarchar](50) NULL,
	[Height] [nvarchar](50) NULL,
	[Quantity] [bigint] NULL,
	[Glass] [nvarchar](50) NULL,
	[FlyScreen] [nvarchar](50) NULL,
	[ProfileColor] [nvarchar](50) NULL,
	[HardwareColor] [nvarchar](50) NULL,
	[TotalArea] [decimal](18, 2) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[Delivery_Date] [date] NULL,
	[BOM_Status] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesOrder_GlassAnalysis]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrder_GlassAnalysis](
	[SO_GlassAna_Id] [bigint] NULL,
	[SO_Id] [bigint] NULL,
	[WindowCode] [nvarchar](50) NULL,
	[Thickness] [decimal](18, 2) NULL,
	[Description] [nvarchar](max) NULL,
	[Width] [decimal](18, 2) NULL,
	[Height] [decimal](18, 2) NULL,
	[Quantity] [bigint] NULL,
	[Unit] [nvarchar](50) NULL,
	[Area] [decimal](18, 2) NULL,
	[Weight] [decimal](18, 3) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesOrder_MaterialAnalysis]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrder_MaterialAnalysis](
	[SO_MATANA_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SO_ID] [bigint] NULL,
	[QUANTITY] [bigint] NULL,
	[PU] [bigint] NULL,
	[BARLENGTH] [nvarchar](50) NULL,
	[REQUIRED_QTY] [decimal](18, 1) NULL,
	[UNIT] [nvarchar](50) NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[COLOR] [nvarchar](50) NULL,
	[WEIGHT] [decimal](18, 3) NULL,
	[ITEMCODE] [nvarchar](50) NULL,
	[ITEMCODE_ID] [bigint] NULL,
	[COLOR_ID] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salutation_Master]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salutation_Master](
	[Salutation_id] [bigint] NULL,
	[Salutation] [nvarchar](50) NULL,
	[Sal_desc] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SoMat_FileName]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoMat_FileName](
	[FileName] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State_Master]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State_Master](
	[STATE_ID] [bigint] NOT NULL,
	[STATE_NAME] [nvarchar](50) NULL,
	[COUNTRY_ID] [bigint] NOT NULL,
 CONSTRAINT [PK_State_Master] PRIMARY KEY CLUSTERED 
(
	[STATE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[MatId] [bigint] NULL,
	[ColorId] [bigint] NULL,
	[Quantity] [bigint] NULL,
	[PlantId] [bigint] NULL,
	[StoragelocId] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock_Type]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock_Type](
	[StockType_Id] [bigint] NULL,
	[Stock_Type] [nvarchar](50) NULL,
	[Stock_Description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StorageLocation_Master]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StorageLocation_Master](
	[StorageLoacation_Id] [bigint] NOT NULL,
	[CP_Id] [bigint] NULL,
	[Plant_Id] [bigint] NULL,
	[StorageLocation_Name] [nvarchar](50) NULL,
	[StorageLoacation_Desc] [nvarchar](max) NULL,
 CONSTRAINT [PK_StorageLocation_Master] PRIMARY KEY CLUSTERED 
(
	[StorageLoacation_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategory_Master]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategory_Master](
	[SubCategory_Id] [bigint] NULL,
	[Category_Id] [bigint] NULL,
	[SubCategory_Name] [nvarchar](50) NULL,
	[SubCategory_Description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suplier_PurchaseOrder]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suplier_PurchaseOrder](
	[PO_ID] [bigint] NOT NULL,
	[PO_NO] [nvarchar](20) NULL,
	[PO_DATE] [datetime] NULL,
	[IND_ID] [bigint] NULL,
	[SUP_ID] [bigint] NULL,
	[PO_STATUS] [nvarchar](50) NULL,
	[NET_AMOUNT] [decimal](18, 2) NULL,
	[TERMS_COND] [nvarchar](max) NULL,
	[DESPM_ID] [bigint] NULL,
	[PAYMENTTERMS_ID] [nvarchar](max) NULL,
	[CURRENCY_ID] [nvarchar](50) NULL,
	[PO_DESTINATION] [nvarchar](50) NULL,
	[PO_INSURANCE] [nvarchar](50) NULL,
	[PO_FREIGHT] [nvarchar](50) NULL,
	[PO_DISCOUNT] [nvarchar](50) NULL,
	[PO_TAXGST] [decimal](18, 1) NULL,
	[PREPAREDBY] [bigint] NULL,
	[APPROVEDBY] [bigint] NULL,
	[FPO_CIF] [nvarchar](50) NULL,
	[FPO_FOB] [nvarchar](50) NULL,
	[TERMS_DELIVERY] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier_Master]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier_Master](
	[SUP_ID] [bigint] NOT NULL,
	[SUP_NAME] [nvarchar](50) NULL,
	[SUP_CONTACT_PERSON] [nvarchar](50) NULL,
	[SUP_ADDRESS] [nvarchar](max) NULL,
	[SUP_CONTACT_PER_DET] [nvarchar](max) NULL,
	[SUP_PHONE] [nvarchar](50) NULL,
	[SUP_MOBILE] [nvarchar](50) NULL,
	[SUP_EMAIL] [nvarchar](50) NULL,
	[SUP_FAXNO] [nvarchar](50) NULL,
	[SUP_PANNO] [nvarchar](50) NULL,
	[SUP_CSTNO] [nvarchar](50) NULL,
	[SUP_VATNO] [nvarchar](50) NULL,
	[SUP_GSTNO] [nvarchar](50) NULL,
	[COUNTRY_ID] [bigint] NULL,
	[CAT_ID] [bigint] NULL,
	[TITLE] [nvarchar](50) NULL,
 CONSTRAINT [PK_Supplier_Master] PRIMARY KEY CLUSTERED 
(
	[SUP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier_Po_Details]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier_Po_Details](
	[Sup_PO_Det_id] [bigint] NULL,
	[Sup_PO_Id] [bigint] NULL,
	[ItemCode] [bigint] NULL,
	[ReqQty] [bigint] NULL,
	[Uom] [nvarchar](50) NULL,
	[Color_Id] [bigint] NULL,
	[Rate] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NULL,
	[Series] [nvarchar](50) NULL,
	[Req_Date] [date] NULL,
	[ReceivedQty] [bigint] NULL,
	[RemainingQty] [bigint] NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier_Po_Master]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier_Po_Master](
	[Sup_PO_Id] [bigint] NULL,
	[Sup_PO_No] [nvarchar](50) NULL,
	[Sup_PO_Date] [date] NULL,
	[Sup_Id] [bigint] NULL,
	[Matrequest_Id] [bigint] NULL,
	[Paymentterms_Id] [nvarchar](max) NULL,
	[TermsConditions_Id] [nvarchar](max) NULL,
	[Discount] [decimal](18, 1) NULL,
	[Tax] [decimal](18, 1) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[PreparedBy] [bigint] NULL,
	[ApprovedBy] [bigint] NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier_PurchaseOrderDetails]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier_PurchaseOrderDetails](
	[PO_DET_ID] [bigint] NOT NULL,
	[PO_ID] [bigint] NULL,
	[MAT_ID] [bigint] NULL,
	[PO_DET_LENGTH] [nvarchar](max) NULL,
	[PO_DET_DESCRIPTION] [nvarchar](max) NULL,
	[PO_DET_COLOR] [nvarchar](50) NULL,
	[PO_DET_QTY] [bigint] NULL,
	[PO_DET_AMOUNT] [decimal](18, 2) NULL,
	[PO_CUSTID] [bigint] NULL,
	[PO_RECEIVED_QTY] [bigint] NULL,
	[PO_REMAINING_QTY] [bigint] NULL,
	[STATUS] [nvarchar](50) NULL,
	[KGPERMTR] [bigint] NULL,
	[TOTAL_WEIGHT] [decimal](18, 2) NULL,
	[ALUMINIUMCOATING] [decimal](18, 2) NULL,
	[PLANT_ID] [bigint] NULL,
	[STORAGELOC_ID] [bigint] NULL,
	[STOCK_TYPE] [bigint] NULL,
	[COLOR_ID] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier_PurchaseReceipt]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier_PurchaseReceipt](
	[SPR_ID] [bigint] NULL,
	[SPR_NO] [nvarchar](50) NULL,
	[SPR_DATE] [date] NULL,
	[SUP_PO_ID] [bigint] NULL,
	[PREPAREDBY] [bigint] NULL,
	[APPROVEDBY] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier_PurchaseReceipt_Details]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier_PurchaseReceipt_Details](
	[SPR_DET_ID] [bigint] NOT NULL,
	[SPR_ID] [bigint] NULL,
	[MAT_ID] [bigint] NULL,
	[PO_DET_COLOR] [nvarchar](50) NULL,
	[PO_DET_QTY] [bigint] NULL,
	[PO_RECEIVED_QTY] [bigint] NULL,
	[PLANT_ID] [bigint] NULL,
	[STORAGELOC_ID] [bigint] NULL,
	[COLOR_ID] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier_Quotation_Details]    Script Date: 06-04-2019 23:14:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier_Quotation_Details](
	[Sup_Quo_Det_id] [bigint] NULL,
	[Sup_Quo_Id] [bigint] NULL,
	[ItemCode] [bigint] NULL,
	[ReqQty] [bigint] NULL,
	[Uom] [nvarchar](50) NULL,
	[Color_Id] [bigint] NULL,
	[Rate] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NULL,
	[Series] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier_Quotation_Master]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier_Quotation_Master](
	[Sup_Quo_Id] [bigint] NULL,
	[Sup_Quo_No] [nvarchar](50) NULL,
	[Sup_Quo_Date] [date] NULL,
	[Sup_Id] [bigint] NULL,
	[Matrequest_Id] [bigint] NULL,
	[Paymentterms_Id] [nvarchar](max) NULL,
	[TermsConditions_Id] [nvarchar](max) NULL,
	[Discount] [decimal](18, 1) NULL,
	[Tax] [decimal](18, 1) NULL,
	[GrandTotal] [decimal](18, 2) NULL,
	[PreparedBy] [bigint] NULL,
	[ApprovedBy] [bigint] NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier_Type]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier_Type](
	[SupType_Id] [bigint] NULL,
	[SupType_Name] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierRequest_Quotation_Details]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierRequest_Quotation_Details](
	[SupReq_Quo_Det_id] [bigint] NULL,
	[SupReq_Quo_Id] [bigint] NULL,
	[ItemCode] [bigint] NULL,
	[ReqQty] [bigint] NULL,
	[Uom] [nvarchar](50) NULL,
	[Color_Id] [bigint] NULL,
	[Series] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierRequest_Quotation_Master]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierRequest_Quotation_Master](
	[ReqSup_Quo_Id] [bigint] NULL,
	[ReqSup_Quo_No] [nvarchar](50) NULL,
	[ReqSup_Quo_Date] [date] NULL,
	[Matrequest_Id] [bigint] NULL,
	[Remarks] [nvarchar](max) NULL,
	[PreparedBy] [bigint] NULL,
	[ApprovedBy] [bigint] NULL,
	[Status] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierRequest_Quotation_Suppliers]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierRequest_Quotation_Suppliers](
	[SupReq_Sup_Id] [bigint] NULL,
	[SupReq_Quo_Id] [bigint] NULL,
	[Sup_Id] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table1]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table1](
	[Pr_Det_Id] [bigint] NULL,
	[Pr_Id] [bigint] NULL,
	[Mat_Id] [bigint] NULL,
	[Color] [nvarchar](50) NULL,
	[QtyinEntry] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[id] [bigint] NULL,
	[Name] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uom_Master]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uom_Master](
	[UOM_ID] [bigint] NOT NULL,
	[UOM_SHORT_DESC] [nvarchar](20) NULL,
	[UOM_LONG_DESC] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Master]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Master](
	[UserId] [bigint] NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[PassWord] [nvarchar](max) NOT NULL,
	[IsDelete] [nvarchar](50) NULL,
	[IsEdit] [nvarchar](50) NULL,
	[Emp_Id] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [CI_UserId]    Script Date: 06-04-2019 23:14:28 ******/
CREATE UNIQUE CLUSTERED INDEX [CI_UserId] ON [dbo].[User_Master]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Permissions]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Permissions](
	[UserId] [bigint] NOT NULL,
	[Permissions] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users_Menu]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users_Menu](
	[slno] [bigint] NOT NULL,
	[menu] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Architect_Master] ([Architect_Id], [Architect_Name], [Architect_Mobile], [Architect_Email], [Architect_Address]) VALUES (1, N'Karunakar', N'9989666775', N'---', N'Hyderabad')
INSERT [dbo].[Architect_Master] ([Architect_Id], [Architect_Name], [Architect_Mobile], [Architect_Email], [Architect_Address]) VALUES (2, N'Raj kumar', N'9177442266', N'--', N'Manikonda,
Hyderabad.')
INSERT [dbo].[Architect_Master] ([Architect_Id], [Architect_Name], [Architect_Mobile], [Architect_Email], [Architect_Address]) VALUES (3, N'Chitra', N'9246537953', N'-', N'Hyderabad.')
INSERT [dbo].[Code_Prefix] ([PF_CUSTOMERINFO], [PF_SALESQUOTATION], [PF_SALESORDER], [PF_SALESENQUIRY], [PF_DELIVERYCHALLAN], [PF_SALESINVOICE], [PF_PAYMENTRECEIVED], [PF_INDENT], [PF_PURCHASEORDER], [PF_OFFERLETTER], [PF_PURCHASERECEIPT], [PF_BOM], [PF_PRODUCTIONORDER], [PF_MATERIALRECEIPIT], [PF_MATERIALREQUEST], [PF_LEAD], [PF_SUPPLIERQUATATION], [PF_EMPMAS], [PF_LEAVEAPPLICATION], [PF_REQQUOTATION], [PF_REQGLASSQUO], [PF_GQUATATIONNO], [PF_GPONO]) VALUES (N'CI', N'SQ', N'SO', N'ENQ', N'DC', N'SI', N'PR', N'IN', N'PO', N'OF', N'PR', N'BOM', N'PRO', N'MR', N'MREQ', N'LEAD', N'SQTN', N'EMP', N'LAPP', N'QREQ', N'GREQ', N'GQTN', N'GPO')
INSERT [dbo].[Company_Profile] ([CP_ID], [CP_FULL_NAME], [CP_SHORT_NAME], [CP_CEO], [CP_FOUNDATIONDATE], [CP_PHONE_OFFICE], [CP_EMAIL], [CP_MOBILE], [CP_FAXNO], [CP_ADDRESS], [CP_GST], [CP_CF_YEAR]) VALUES (1, N'Alumil Buidmate Pvt Ltd.', N'Alumil', N'Seema Anand', CAST(N'2017-01-01' AS Date), N'9701276699', N'info@alumil.in', N'9701276699', N'9701276699', N'Sy.No.96,Mogiligidda Village & Grampanchayath,Farooqnagar Mandal,Ranga Reddy Dist.Telangana-509410 ', N'0', N'18-19')
INSERT [dbo].[Country_Master] ([COUNTRY_ID], [COUNTRY_NAME], [CURRENCY]) VALUES (1, N'India', N'Rupees')
INSERT [dbo].[Country_Master] ([COUNTRY_ID], [COUNTRY_NAME], [CURRENCY]) VALUES (2, N'Germany', N'Euro')
INSERT [dbo].[Currency_Master] ([CURRENCY_ID], [CURRENCY_NAME], [CURRENCY_FULL_NAME], [CURRENCY_DESC]) VALUES (1, N'Rupees', N'Indian Rupees', N'--')
INSERT [dbo].[Currency_Master] ([CURRENCY_ID], [CURRENCY_NAME], [CURRENCY_FULL_NAME], [CURRENCY_DESC]) VALUES (2, N'Euro', N'Euro', N'--')
INSERT [dbo].[Customer_Master] ([CUST_ID], [CUST_CODE], [CUST_NAME], [CUST_COMPANY_NAME], [CUST_CONTACT_PERSON], [CUST_PHONE], [CUST_MOBILE], [CUST_FAX], [CUST_EMAIL], [CUST_PAN], [CUST_GST], [REG_ID], [CUST_ADDRESS], [CUST_CORP_CONTACT_PERSON], [CUST_CORP_PHONE], [CUST_CORP_MOBILE], [CUST_CORP_EMAIL], [CUST_CORP_ADDRESS], [CUST_CORP_DESG_ID], [CUST_CORP_FAX], [CUST_STATUS], [CUST_DEAR], [CUST_DESG_ID], [CUST_REF_BY_NAME], [CUST_REF_BY_CONTACT], [CUST_REF_BY_ADDRESS], [CUST_ARCHITECT_NAME], [CUST_ARCHITECT_CONTACT], [CUST_ARCHITECT_ADDRESS], [CUST_SITEINCHARGE_NAME], [CUST_SITEINCHARGE_CONTACT], [CUST_SITEINCHARGE_ADDRESS]) VALUES (1, N'CI-1/18-19', N'A.Naresh Reddy', N'A.Naresh Reddy', N'1', N'0', N'9010444449', N'0', N'0', N'1', N'1', 0, N'Green Villas,
Gandhi pet,
Hyderabad.', N'1', N'1', N'1', N'1', N'1', 1, N'1', N'1', N'1', 0, N'Chitra', N'9246537953', N'Hyderabad', N'1', N'1', N'1', N'1', N'1', N'1')
INSERT [dbo].[Customer_Master] ([CUST_ID], [CUST_CODE], [CUST_NAME], [CUST_COMPANY_NAME], [CUST_CONTACT_PERSON], [CUST_PHONE], [CUST_MOBILE], [CUST_FAX], [CUST_EMAIL], [CUST_PAN], [CUST_GST], [REG_ID], [CUST_ADDRESS], [CUST_CORP_CONTACT_PERSON], [CUST_CORP_PHONE], [CUST_CORP_MOBILE], [CUST_CORP_EMAIL], [CUST_CORP_ADDRESS], [CUST_CORP_DESG_ID], [CUST_CORP_FAX], [CUST_STATUS], [CUST_DEAR], [CUST_DESG_ID], [CUST_REF_BY_NAME], [CUST_REF_BY_CONTACT], [CUST_REF_BY_ADDRESS], [CUST_ARCHITECT_NAME], [CUST_ARCHITECT_CONTACT], [CUST_ARCHITECT_ADDRESS], [CUST_SITEINCHARGE_NAME], [CUST_SITEINCHARGE_CONTACT], [CUST_SITEINCHARGE_ADDRESS]) VALUES (2, N'CI-2/18-19', N'Raj Kumar', N'Raj Kumar', N'1', N'0', N'9177442266', N'0', N'-', N'1', N'1', 0, N'Manikonda,
Hyderabad.', N'1', N'1', N'1', N'1', N'1', 1, N'1', N'1', N'1', 0, N'Raj Kumar', N'9177442266', N'Manikonda,
Hyderabad.', N'1', N'1', N'1', N'1', N'1', N'1')
INSERT [dbo].[Customer_Master] ([CUST_ID], [CUST_CODE], [CUST_NAME], [CUST_COMPANY_NAME], [CUST_CONTACT_PERSON], [CUST_PHONE], [CUST_MOBILE], [CUST_FAX], [CUST_EMAIL], [CUST_PAN], [CUST_GST], [REG_ID], [CUST_ADDRESS], [CUST_CORP_CONTACT_PERSON], [CUST_CORP_PHONE], [CUST_CORP_MOBILE], [CUST_CORP_EMAIL], [CUST_CORP_ADDRESS], [CUST_CORP_DESG_ID], [CUST_CORP_FAX], [CUST_STATUS], [CUST_DEAR], [CUST_DESG_ID], [CUST_REF_BY_NAME], [CUST_REF_BY_CONTACT], [CUST_REF_BY_ADDRESS], [CUST_ARCHITECT_NAME], [CUST_ARCHITECT_CONTACT], [CUST_ARCHITECT_ADDRESS], [CUST_SITEINCHARGE_NAME], [CUST_SITEINCHARGE_CONTACT], [CUST_SITEINCHARGE_ADDRESS]) VALUES (3, N'CI-3/18-19', N'Sodda', N'Sodda', N'1', N'0', N'7680880090', N'0', N'cta.sodda@gmail.com', N'1', N'1', 0, N'Near NASR Public School,
Gachibowlli, 
Hyderabad.', N'1', N'1', N'1', N'1', N'1', 1, N'1', N'1', N'1', 0, N'Sodda', N'7680880090', N'Near NASR Public School,
Gachibowlli, 
Hyderabad.', N'1', N'1', N'1', N'1', N'1', N'1')
INSERT [dbo].[Customer_Units] ([CUST_UNIT_ID], [CUST_ID], [CUST_UNIT_NAME], [CUST_UNIT_ADDRESS], [CUST_NO_FlOORS], [CUST_WINLOAD], [CUST_CONTACTPERSON], [CUST_MOBILE], [ARCNAME], [ARCMOBILE], [PRONAME], [PROMOBILE], [CUST_CONTACTPERSON2], [CUST_MOBILE2], [CUST_CONTACTPERSON3], [CUST_MOBILE3], [ARCADDRESS], [ARCEMAIL], [PROEMAIL]) VALUES (1, 1, N'A.Naresh Reddy', N'Gandhipet,
Hyderabad', N'0', N'0', N'A.Naresh Reddy', N'9010444449', 3, N'9246537953', N'A.Naresh Reddy', N'9010444449', N'', N'', N'', N'', N'', N'-', N'-')
INSERT [dbo].[Customer_Units] ([CUST_UNIT_ID], [CUST_ID], [CUST_UNIT_NAME], [CUST_UNIT_ADDRESS], [CUST_NO_FlOORS], [CUST_WINLOAD], [CUST_CONTACTPERSON], [CUST_MOBILE], [ARCNAME], [ARCMOBILE], [PRONAME], [PROMOBILE], [CUST_CONTACTPERSON2], [CUST_MOBILE2], [CUST_CONTACTPERSON3], [CUST_MOBILE3], [ARCADDRESS], [ARCEMAIL], [PROEMAIL]) VALUES (2, 3, N'Sodda', N'Hyderabad', N'0', N'0', N'Sodda', N'7680880090', 1, N'9989666775', N'Sodda', N'7680880090', N'', N'', N'', N'', N'', N'---', N'cta.sodda@gmail.com')
INSERT [dbo].[Customer_Units] ([CUST_UNIT_ID], [CUST_ID], [CUST_UNIT_NAME], [CUST_UNIT_ADDRESS], [CUST_NO_FlOORS], [CUST_WINLOAD], [CUST_CONTACTPERSON], [CUST_MOBILE], [ARCNAME], [ARCMOBILE], [PRONAME], [PROMOBILE], [CUST_CONTACTPERSON2], [CUST_MOBILE2], [CUST_CONTACTPERSON3], [CUST_MOBILE3], [ARCADDRESS], [ARCEMAIL], [PROEMAIL]) VALUES (3, 2, N'Raj Kumar', N'Hyderabad', N'0', N'0', N'Raj Kumar', N'9177442266', 2, N'9177442266', N'Rajkumar', N'9177442266', N'', N'', N'', N'', N'', N'--', N'-')
INSERT [dbo].[Department_Master] ([DEPT_ID], [DEPT_NAME], [DEPT_DESC]) VALUES (1, N'Admin', N'Admin')
INSERT [dbo].[Department_Master] ([DEPT_ID], [DEPT_NAME], [DEPT_DESC]) VALUES (2, N'Sales', N'Sales')
INSERT [dbo].[Designation_Master] ([DESG_ID], [DESG_NAME], [DESG_DESC]) VALUES (1, N'Admin', N'Admin')
INSERT [dbo].[Designation_Master] ([DESG_ID], [DESG_NAME], [DESG_DESC]) VALUES (2, N'Sales Executive', N'Sales Executive')
INSERT [dbo].[Designation_Master] ([DESG_ID], [DESG_NAME], [DESG_DESC]) VALUES (3, N'Operations Head', N'Operations Head')
INSERT [dbo].[Designation_Master] ([DESG_ID], [DESG_NAME], [DESG_DESC]) VALUES (4, N'Design Executive', N'Design Executive')
INSERT [dbo].[Designation_Master] ([DESG_ID], [DESG_NAME], [DESG_DESC]) VALUES (5, N'Technical Engineer', N'Technical Engineer')
INSERT [dbo].[Designation_Master] ([DESG_ID], [DESG_NAME], [DESG_DESC]) VALUES (6, N'General Manager', N'General Manager')
INSERT [dbo].[Designation_Master] ([DESG_ID], [DESG_NAME], [DESG_DESC]) VALUES (7, N'Estimation', N'Estimation')
INSERT [dbo].[Designation_Master] ([DESG_ID], [DESG_NAME], [DESG_DESC]) VALUES (8, N'Project Co-Ordinator', N'Project Co-Ordinator')
INSERT [dbo].[Designation_Master] ([DESG_ID], [DESG_NAME], [DESG_DESC]) VALUES (9, N'Co-Ordinnator', N'Co-Ordinnator')
INSERT [dbo].[Designation_Master] ([DESG_ID], [DESG_NAME], [DESG_DESC]) VALUES (10, N'SCM', N'SCM')
INSERT [dbo].[Designation_Master] ([DESG_ID], [DESG_NAME], [DESG_DESC]) VALUES (11, N'Technician', N'Technician')
INSERT [dbo].[Employee_Details] ([EMP_DET_ID], [EMP_ID], [DEPT_ID], [DESG_ID], [EMP_DET_DOJ], [EMP_DET_DOT], [BRAN_ID], [EMP_TYPE_ID]) VALUES (1, 1, 1, 1, CAST(N'2018-04-15T00:00:00.000' AS DateTime), CAST(N'2018-04-19T00:00:00.000' AS DateTime), 0, 1)
INSERT [dbo].[Employee_Details] ([EMP_DET_ID], [EMP_ID], [DEPT_ID], [DESG_ID], [EMP_DET_DOJ], [EMP_DET_DOT], [BRAN_ID], [EMP_TYPE_ID]) VALUES (2, 2, 1, 1, CAST(N'2019-04-05T00:00:00.000' AS DateTime), CAST(N'2019-04-05T00:00:00.000' AS DateTime), 0, 1)
INSERT [dbo].[Employee_Master] ([EMP_ID], [EMP_FIRST_NAME], [EMP_MIDDLE_NAME], [EMP_LAST_NAME], [EMP_GENDER], [EMP_MOBILE], [EMP_PHONE], [EMP_DOB], [EMP_EMAIL], [EMP_PHOTO], [EMP_ADDRESS], [EMP_CITY], [EMP_USERNAME], [EMP_PASSWORD], [EMP_CPID], [EMP_LEAVEAPPROVER_ID], [EMP_NO], [EMP_SALARY], [EMP_TDS], [BANK_ACCOUNT], [GradeId]) VALUES (1, N'NagaPhani', N'-', N'B', N'Male', N'9703338826', N'9703338826', CAST(N'2018-04-15T00:00:00.000' AS DateTime), N'phani1237@gmail.com', 0x89504E470D0A1A0A0000000D49484452000001000000010008030000006BAC5854000000097048597300000B1300000B1301009A9C1800000300504C544547704C4F92FF4F92FF4F92FF4F92FF4F92FF4586FF4F92FF4A8CFF498BFF4F92FF4F92FF4F92FF4788FF4F92FF4A8CFF4F92FF4F92FF4F92FF4D8FFF4F92FF4F92FF4F92FF4F92FF4F92FF4F92FF306BFF4F92FF4F92FF4A8CFF4F92FF4F92FF4F92FF4F92FF498AFF4F92FF4F92FF306BFF4F92FF306BFF306BFF4F92FF4F92FF4F92FF4F92FF4F92FF4F92FF4F92FF4F92FF4F92FF4F92FF306BFF4F92FF4F92FF306BFF306BFF306BFF4F92FF4586FF306BFF4F92FF306BFF4F92FF306BFF306BFF306BFF306BFF4E90FB4F92FF306BFF306BFF4F92FF4F92FF306BFF306BFF306BFF306BFF306BFF4F92FF306BFF306BFF4F92FF4F92FF306BFF4F92FF306BFF3A78FF3A77FF4F92FF306BFF252546F9D2A0F6BD8EFFFFFFF3B18DF9D1A04D90FFF6BF90544B5A4B4456FFFEFEF9D09E2F2D4AF4BC8F4687FF9E8779336EFF4281FFF5BA92316CFF6398F3F7C4954B8EFFF8CB9BF4B790F6BE933471FFFADDC3E1BF96DBC7B2F5D1A23977FF2A29484485FF282F57F5F8FF26274A344D8AA5BFFFF6CF9F3A354E4A87EC26294D3E67B7F4CE9E5E525D4880E12B35615896FA272B51FAFBFFF7C599272647927D74F2CD9DF1CFA53B7AFFBFBDC14476D136529331447C2E3D6FA48D7C4E8FFBF7C094FCE8D66E9EEE3C62AEFAD6B94983E5BCAEB6F4B48F3E7DFFF8CD9CF8C999EECEA738589D3A5CA4E5B99AC9B1ADC2A5884C8AF2EDBB94B2B7C8EBC69AEFCA9C457AFFC4D5FF5293FDC7C0BDD6E1FFFEFBF78CADFF789EFFF5CB9CD8B7922C396898ADD7E9CCA9B197814273CA6098F6478AFF4579D59580765048582A315B406CBEFDECDC695C63403B51BCA186FCE4CEFEF5ED9FB0D3766768487FDF4077FF689CF2334883467BD97099FF9EA6CA84A7FFEDB68B4E8EF9819FDD96A5D0F8CBA5887570FDF0E691B1FF87A7E04C8CF4464054998477E2EAFF4278FFE7C398F1F5FF4E80FFD7E3FF76A1EA79A2E82F4075729FECCAB7B3FBDDBD9CA6CBC9AB8CBD937AF9D0AE89A1D8AB8674665A62876C68E0E9FFFAD9AEF9D5A5CFAF8E5283FFACB5CBDFAC86D5A583B9BAC4D9E4FF754BB0790000005874524E5300F48226FBD309FE0105C5E9A71761114BB58703A4F0486DD535F931651F745D422C1CBF7B77D7495F5BF9CB698C56F68FB0DE8D0DDCD6ECA9CF45FE93DD7869B93228F63ED2977EE1A0C2DEC7C64F3D51DF9DC5DD85FBFB4D05EFDD000010FC4944415478DAE49D794C54D71EC72F3030CC0C0283A06340163124200A18FDC3C4F89749FB97499BFE71E6DE015C0A149541D08A0B85B228204F1651DCE3862B2AAD76896B2BD5E7F2B4B1C6B8C4A64FFB7C49D5D8365DD2BEBC256F866160963BF7CE9DFB3D77EEE8F73FC25D7EBFCF9CE5777EE7DC731846614545C4C7A626BC5DA037BD6348CA2336E52519DE31E90BDE9E9A1A1B9F11C5BCB28A4ACE4E88D11B88880CFA9884ECE4578CC38CB9A931260D91204D564CEADC19AF84F363A6CD9E25C977170AB3664F1B13DAA53E3EDF4464CA941F1FA2F56152AE318F409467CC9D146ADE4F4CD56B09505A7DEAC4D0F13E2E17EBBD93416E5C28781F9D1E9343282927263D5AED6DFE9C9984AA66CE5173BF909CA821D4A5494C5669D98FCF240A29335E7D3541176B225AA50068892956A72EF753DE220AEBAD14F52088CE9E4982A099D92AA908E322499014394E05EE47184910658C0876D03735870455395383191E46A71848D06548095A5310914954A1CCE0D483B193F3884A9437796C10C2DE48A222454E50FAE70FD710554913AE682188984254A7290AB604696144850A8B552AC99D4854AA444512E9115944B5CA52A01A4C0B232A56D834DAAD7F8296A85ADA04AABDC10C2351BD8C141B828991240414496D0661822114FC275A03A5B0705C18091185514994A46948C8489386F77FBC968490B4E3D1FE4F2621A6C958FFC349C8291CE97F02094125BCD6BF3FB40CBC4142546F80DA7F12B282F405D9DAD005A0CD06C47F39248495334F76FC1F46425A6132C705930C24C46590B5C26E4624097945CAC80F441790574005635FB700081610C553E900B7DF5977A8776B6D3BCBB275B56D5B7BB71CBE72A989FFD2A62BF56D97009D617C80F9EF24BCF79B0F6DAD637954D7F6BCFED0BA8B77F6F46FB75DD5DFDFBAD946A9D6FE9F6F006F4D0A285B1E056F002FD6B7B392D57C1FD11006B2E01C3CFFD374A8960D4897106F4F94EE7F2CD4FD3BDF74B0016A1DC400C9F38611C808F04E2F1BB87663224289CD800E38FFBDA79E95A3C3182BA6E8821401DC3F5C27CB7F500990180D4C80A5C037B7B1327505952A97302CD2A17AC0FB5B58D9BA88FA2D4C3AC52BC0D76DF2FD67BF563E24CE00558075CD00FFEBB6C3006832FC1C03EA31313FA0F8DBB415D81DEBFD5B539A027959FF7388FF1DBB8100488A5FEB9F2149A0A6B32C467BA0E9217F5656E723DED47A19E47F471B9440BE1F3130A2056CAD65616ABF0804A0118F888D2AF31F170C0FC9283A0D80A8FF9759AC7AFF8E2320B278241A1003F6B7B1689D6DC2258985BBC23440FFBF95C5AB16170F0AAE9ED14D97FF827A9686DA2FA1004CD7D18D81D6B174D4BC59816868ACFC02D0DACCAA9DC0F4B114F380DBCFB2D4D48CAA053EF383D126D9CFDECD52543BA8253445538B019A9A6902602F837A435FB180FCCF00B7B07475F63E0440A68F0FE1E4E77FEB280360EB31452099D254503D4B5D986912DE89A231B287814D75F401344346C71ABE9D58E6C87EEC6156016152647378FA40D9BB406CAF55020066A264A6774F982EFBA11715F19F6D87F485E95E006242A109C4F504315EA950F9EB216B1502C0B60200E478A64773E5CF022AE53F64D50CC9F500207F32E49062002045C0231A9C287F41D873E5006C0100D0BA8702A9F29FD8AC1C80764492743CB806B4B20A0A1110EBDDD644CBAF01579404D08BA80393A07D803271F0C89C793FB81F002C8AAE57120064DD4C814B361CB026AE575100887E204C071C071082CF865E15585BD9861D0F4C053C0D3D1FC85E6BB8DEE8FBBF884660EA0800C4A2B0763480271CB7F22B9FFF454C12448EE48210E5091D07959EE438AEEB16D5AC8033189C867818BA00747243DAB6867FE108A21524CE2D6766AB1040E3800300F75323BD11E1EC6100B35408E002E7D4D3166AA9C159C3DFC669D407E02A37AA86477C934490E4B0E38BBAB9446D003A4A9F72AEBA50EABD620262743A6A288C2E01D739779D79EC352286189D0A4A87A20174729E1AB8EA790DC468476A344B6D007E6BF002C0150F7650009035F4799C466500160E707C3AD68807A089824C0A63012C3AC9F1CB3D30C64D136763013C91FBFBFBF29FE3D6DF820348C36D91E3348C1B94E57FCB00272097C018637502AC131805C06DEB08DCFF5B5D9CA0FE750D0B20061508BB02F06CAE240440E59C984E6201D883E12438006EE5C2C052203F71E2C202486298388207C0350CAE09A0F80F708A0320714C060D00B6E0B545A2FB8F8F715C10006430F1740070DCF54552F23F83EBB9A00088877D26EF05806BB8E02F82D24727392E380062613B257A03B005F0C77EF3A34B6CEC7CCA71C1023019930FF301C0DE210C0A17838E960B0D1C173C00F9A838C817007B7B38D8E2A34F58D3B2ED2927516000898C913A00FB70FE58E7D56BEEB5E1DAD5CE635D9C7481011819BD120086D475E6FA85279D8F1E0D3ED976FDCC0017A0C000F44CA462006C8D6231275B600091CC9B0A0240080CE04DC6F07A0330A0C64276008DBFFFFC9F7BB401DCFBEFCFBF37E2002431A8FD82D8C65FCB2C36D106607F47D9AF8D2800610CE841A4E59EC5A214008BE55E0BCA6E1480876516250158CA1EAA0BC003A7FF3E00AC2F5F585ABA709B5F43BEF5DBECD796AF170460297BA02600D6E31641002B8707048B568AFB2F72EDC88B8E5B3100208DE05E8B2080AE9101D157A2D16FD748F67F51972000CB5E4C2388E806AD65C200CA478700A2694FB16B47DF54668574838840E8478B3000971CE942310062D7BABCEA4748208408858F8A0070190DAF11032076ADCBAB8E424261C460E888FF004A250028150170043218420C87CB825305CA20C361A30200E83482100046484A4CAC0A743D16EEDAF8BBCCC75D0A548144485254AC11A41208611AC17C485AFCAE1880E2AE72A1F0962F6C2EEFE2C400DC85A4C5111323563100F8C1905D884028163335B637180020A1703C6672546C30440300663094019A1EFF457900BF400C8F432D9078A834004C422409B744E6C17125011C07A54366E1164911EB5EC50094EDB5828C8E819E2467BD7BF448196D0065478EDEB5C24C4EC06C21E82ADA00B0D6A6E196CA862600FB52D928EDEB0B6068B13493154A0056418DCD027E30E154375D0007A1C6C6003F9971EA3C55FF8BCF438D4D057E34E5540DDD1250033576AEE34425E8918AA7E902388DB435270AB581888B4E0410D74BB8E504D2563DF0EBF9119D93E04DA5C3FF4A09B79C43DAEAFC7E7E1EF2A1CF247853E2005022E19667485BE7213F9F776A83941A5D622B039552FC2FDE80B4750C72030565BA0168271009DD4223A05650B24ED06802309BA88CE83B9A00BE435A9A0EDD4667B41158457124806C025CB6D161A0A7CB9E0E9130A800BB95962275005A0372B19BA98DEAD441211F0E54EFDBE8EB7F1BF7551F101C0A9E029AE9B6991A361AFEB790134B8B8A8AAAF8FF5565FBD752C5E360063F24B6AE120150CD1BFB94548B0058751B69E578F4969A2EEA11F0A2AFC8EE26CF8703C57634BE0AC7907A90367A6CA989AD03B7858AC0F221025E65A064C8FF1D8A15804CF8B6BAAEFA9F50386F2FE945D51E3F7555B5AF9241A705F0DA56370E9A15F94228333854D78B8A96BB34F807868A858FB66158DD5F40732171F8ADB55D7553700C3854DA6DBF7765554971714955A5F36FC171E14D0AE950ECE6EA6EB180E098B07847118F76087E5255730A6A603A85EDF5FD6F079D55DE55D555C2A3805D50F378B6D7071CB0202935D6B7D4D5FDA57D2297632B00DF010B802336FC0F061C4DC1C6E5D5FB8A8AF6552FDF2896142A3E8DB58DF7880DC0212BEEC362606AA86603D6B6444AC7EC78F485B049A2F3B7C1A625D33A68C95D2F0E62FCEF7E01362C93E2719B6EFA013253DAFD03DAAE71F40E5BF324002803DDCFD056F93C6C0DB69FC8A876C96E07CEEF821B154BF3C045AFDC80CCBEA0C60A3749E8CCCD14F8DBC8861E39FEF76CC05B9442F9D055EF9830E03CF9AA7314CC113C7415BD666EB82108B01AD4ECA2614D1AF5839779C68637032804DD374FD1B045E4E0657C2C30DC164A6E097AAC742C19A7C4E1EBBCF5A0E74F2953402F2899217AF83A13A1A1F1DEF96B377DF6E90D3F11FCF9F26F9F6D5A3B9F861D9A0851004C3E05EF575798CD9F1416BEFBD73FC4DDFF63E7A785859F98CD15AB2930C817F79F893360DFF9E5269BF766F33F0A6D000A0B5FF6098EFD4BFA5E160EE923FB3D159BBEC4DA6288F30300341A9ABF6485D9A1CF1D8EBD6FB12CA8ACE29F19AAAA5C60B1BCEFB8EEF3E1DB562C411683147FFC67A2619324CBF62F363BF5E10800BB165456F6551D28B1A7418B4B4A0E54F555DA9DB76B18C08723372EDEBF0C658F3EDA2F004C06A61D5CE628FBC3FAD80D806F0D03F8D8E5D68A4D18049A0CC64F85230AFF7E57F7CDE6EFA501F8DEEDE68AFD888A90E0AFFF8CCE24BFEEBBBB6F367F200DC0071EB757C86F0B4C3ABF013013645682F756983D55280D40A1D70356BC27B3024C6024285C5EE5379B7D01B82106E086E3BABFF03C425E53102EC57F463725F037AD5DCC63FC70157877A718809D0E00FFE47BC6E225815B35452709001311E8CAB9F9ABCDBC1A6E04BF1503F02D5F2338A2D581B60461118C44FDBF9BB36949250AE3F863962662DDB28B2888144D3310B4517440C41788C85E21BA975908577021739182DC44087D00FB02052EFA040565DBBB6AD3A245B8915A5DAA759B1677736FD774CC9779393367668EFDB6471ECFFFF1793B675495F78379BEFFCE5B6D30B727AD7F2FD7DB063B82406525180364543D2FFFC989D11C84322FD20E78C9740F42DDA84A832974FD601BC116FE1F46E1CC89A212208CC278D260C4A6C2016045FD5DF96E517CD78DC35023078EA4F41F3533E0FD30244211B51B7CB5822AD6D1BE3AF68BE7A4B850D2089B4DF0FF7158021EED90685F0795204D03F982E4A6B96A2B04EAE2FAEBAD00A84ADB2AE4F59B003A1E9420DC8F1DC8E8E76ECB4D7137C762FA8F6F9A2F29DFCA182B1C20DC82B9553B00428A0BE101274BAB0F64AE45F467AF33B23D4040B1074642A001BF139B7EEEAC247820DB770410F497CE386C1E70FA41135E0B8EFC7FE7A1253073DFA7151CDD0BCB0F4AAC29AB03162F68647D18977E8E7F16245E56BAF5572E85C5675E91B982825E30BC0E9A09C836C35D65FA39EE494882B75258F99007D9CA4D7BA5F4A4D01C2F3B0FD80380018FDCFC57E49472971364E632972795FA4E36BB53AF9CB43FFDB7853BC5E68A7233A107B0B024FD2EFB9C726A19596A08E6F6A577B60498901C884E39146A3969F9B91A92B9537D06A01E24FE6A27CFA1715792D25FBA433497C77107AA25067679C41D734FCFE2FAFFFE41B5265E0887002BB3180A406BCF0FE5FEF2CB0F3CBA35B132300B98F1D8D12E402467C2C33E79503A3C5365ACEF0589DD03D8090C6B98007A4E46D58B4EF917D55B95A60A7D926038003AF0C5822301DA37245787E7AF8FE5F2E3EBF9E1D56F0D867A93C0F20574C1EBD4D80174A2BB1338BDA013FEAED371910C0714BBCEBF7ED08DD084F60AA8031D757022043AE29E6C37831F3C290EE0DB6702FBA41BF465C1425C007C0801CB02E8CEF41C6901D00E81B9693080D0146901D00A81A91018C398859C16D06E049631300CEB3C2933407B1698B782813886BE91E580EF430E3096E42249FA179360380ECA478A7C1FE5003348A5C9D09F4E81498CC623E6CB8FC447C13CC68326E7812F380EE6924A98A93F9102F3A14DEB078B3410819B8999213FC6B881141CCC8AD1F2571807908483091B293F4C98FC464FA40D2B87097A148824B96C4053F42D27815C5C94CEF53046B980706856B730F0B1A4C67ED77818DF8AE2571FDD8ABB603078FB94FCD42A561F4457293F0C1833F104A65CF025E233309084E8A0E6E9201CA44330B88C826B33B8A632127CABC14D5723A3061DDB06C586916A4234CC521B36F854D892CC36BB267B83125963B799E427D3DEE18714CD50C165361D8E45226F5111F545222BB1709A5D0E520C9D325CF93F347A9053046069F80000000049454E44AE426082, N'28/1574 RS Road,Nandyal', N'Nandyal', N'phani', N'1', 1, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Employee_Master] ([EMP_ID], [EMP_FIRST_NAME], [EMP_MIDDLE_NAME], [EMP_LAST_NAME], [EMP_GENDER], [EMP_MOBILE], [EMP_PHONE], [EMP_DOB], [EMP_EMAIL], [EMP_PHOTO], [EMP_ADDRESS], [EMP_CITY], [EMP_USERNAME], [EMP_PASSWORD], [EMP_CPID], [EMP_LEAVEAPPROVER_ID], [EMP_NO], [EMP_SALARY], [EMP_TDS], [BANK_ACCOUNT], [GradeId]) VALUES (2, N'NIDHI P S', N'-', N'ACHARI', N'Female', N'8019197087', N'8019197087', CAST(N'2019-04-05T00:00:00.000' AS DateTime), N'nidhiachari@gmail.com', 0x89504E470D0A1A0A0000000D49484452000001000000010008030000006BAC5854000000097048597300000B1300000B1301009A9C1800000300504C544547704C4F92FF4F92FF4F92FF4F92FF4F92FF4586FF4F92FF4A8CFF498BFF4F92FF4F92FF4F92FF4788FF4F92FF4A8CFF4F92FF4F92FF4F92FF4D8FFF4F92FF4F92FF4F92FF4F92FF4F92FF4F92FF306BFF4F92FF4F92FF4A8CFF4F92FF4F92FF4F92FF4F92FF498AFF4F92FF4F92FF306BFF4F92FF306BFF306BFF4F92FF4F92FF4F92FF4F92FF4F92FF4F92FF4F92FF4F92FF4F92FF4F92FF306BFF4F92FF4F92FF306BFF306BFF306BFF4F92FF4586FF306BFF4F92FF306BFF4F92FF306BFF306BFF306BFF306BFF4E90FB4F92FF306BFF306BFF4F92FF4F92FF306BFF306BFF306BFF306BFF306BFF4F92FF306BFF306BFF4F92FF4F92FF306BFF4F92FF306BFF3A78FF3A77FF4F92FF306BFF252546F9D2A0F6BD8EFFFFFFF3B18DF9D1A04D90FFF6BF90544B5A4B4456FFFEFEF9D09E2F2D4AF4BC8F4687FF9E8779336EFF4281FFF5BA92316CFF6398F3F7C4954B8EFFF8CB9BF4B790F6BE933471FFFADDC3E1BF96DBC7B2F5D1A23977FF2A29484485FF282F57F5F8FF26274A344D8AA5BFFFF6CF9F3A354E4A87EC26294D3E67B7F4CE9E5E525D4880E12B35615896FA272B51FAFBFFF7C599272647927D74F2CD9DF1CFA53B7AFFBFBDC14476D136529331447C2E3D6FA48D7C4E8FFBF7C094FCE8D66E9EEE3C62AEFAD6B94983E5BCAEB6F4B48F3E7DFFF8CD9CF8C999EECEA738589D3A5CA4E5B99AC9B1ADC2A5884C8AF2EDBB94B2B7C8EBC69AEFCA9C457AFFC4D5FF5293FDC7C0BDD6E1FFFEFBF78CADFF789EFFF5CB9CD8B7922C396898ADD7E9CCA9B197814273CA6098F6478AFF4579D59580765048582A315B406CBEFDECDC695C63403B51BCA186FCE4CEFEF5ED9FB0D3766768487FDF4077FF689CF2334883467BD97099FF9EA6CA84A7FFEDB68B4E8EF9819FDD96A5D0F8CBA5887570FDF0E691B1FF87A7E04C8CF4464054998477E2EAFF4278FFE7C398F1F5FF4E80FFD7E3FF76A1EA79A2E82F4075729FECCAB7B3FBDDBD9CA6CBC9AB8CBD937AF9D0AE89A1D8AB8674665A62876C68E0E9FFFAD9AEF9D5A5CFAF8E5283FFACB5CBDFAC86D5A583B9BAC4D9E4FF754BB0790000005874524E5300F48226FBD309FE0105C5E9A71761114BB58703A4F0486DD535F931651F745D422C1CBF7B77D7495F5BF9CB698C56F68FB0DE8D0DDCD6ECA9CF45FE93DD7869B93228F63ED2977EE1A0C2DEC7C64F3D51DF9DC5DD85FBFB4D05EFDD000010FC4944415478DAE49D794C54D71EC72F3030CC0C0283A06340163124200A18FDC3C4F89749FB97499BFE71E6DE015C0A149541D08A0B85B228204F1651DCE3862B2AAD76896B2BD5E7F2B4B1C6B8C4A64FFB7C49D5D8365DD2BEBC256F866160963BF7CE9DFB3D77EEE8F73FC25D7EBFCF9CE5777EE7DC731846614545C4C7A626BC5DA037BD6348CA2336E52519DE31E90BDE9E9A1A1B9F11C5BCB28A4ACE4E88D11B88880CFA9884ECE4578CC38CB9A931260D91204D564CEADC19AF84F363A6CD9E25C977170AB3664F1B13DAA53E3EDF4464CA941F1FA2F56152AE318F409467CC9D146ADE4F4CD56B09505A7DEAC4D0F13E2E17EBBD93416E5C28781F9D1E9343282927263D5AED6DFE9C9984AA66CE5173BF909CA821D4A5494C5669D98FCF240A29335E7D3541176B225AA50068892956A72EF753DE220AEBAD14F52088CE9E4982A099D92AA908E322499014394E05EE47184910658C0876D03735870455395383191E46A71848D06548095A5310914954A1CCE0D483B193F3884A9437796C10C2DE48A222454E50FAE70FD710554913AE682188984254A7290AB604696144850A8B552AC99D4854AA444512E9115944B5CA52A01A4C0B232A56D834DAAD7F8296A85ADA04AABDC10C2351BD8C141B828991240414496D0661822114FC275A03A5B0705C18091185514994A46948C8489386F77FBC968490B4E3D1FE4F2621A6C958FFC349C8291CE97F02094125BCD6BF3FB40CBC4142546F80DA7F12B282F405D9DAD005A0CD06C47F39248495334F76FC1F46425A6132C705930C24C46590B5C26E4624097945CAC80F441790574005635FB700081610C553E900B7DF5977A8776B6D3BCBB275B56D5B7BB71CBE72A989FFD2A62BF56D97009D617C80F9EF24BCF79B0F6DAD637954D7F6BCFED0BA8B77F6F46FB75DD5DFDFBAD946A9D6FE9F6F006F4D0A285B1E056F002FD6B7B392D57C1FD11006B2E01C3CFFD374A8960D4897106F4F94EE7F2CD4FD3BDF74B0016A1DC400C9F38611C808F04E2F1BB87663224289CD800E38FFBDA79E95A3C3182BA6E8821401DC3F5C27CB7F500990180D4C80A5C037B7B1327505952A97302CD2A17AC0FB5B58D9BA88FA2D4C3AC52BC0D76DF2FD67BF563E24CE00558075CD00FFEBB6C3006832FC1C03EA31313FA0F8DBB415D81DEBFD5B539A027959FF7388FF1DBB8100488A5FEB9F2149A0A6B32C467BA0E9217F5656E723DED47A19E47F471B9440BE1F3130A2056CAD65616ABF0804A0118F888D2AF31F170C0FC9283A0D80A8FF9759AC7AFF8E2320B278241A1003F6B7B1689D6DC2258985BBC23440FFBF95C5AB16170F0AAE9ED14D97FF827A9686DA2FA1004CD7D18D81D6B174D4BC59816868ACFC02D0DACCAA9DC0F4B114F380DBCFB2D4D48CAA053EF383D126D9CFDECD52543BA8253445538B019A9A6902602F837A435FB180FCCF00B7B07475F63E0440A68F0FE1E4E77FEB280360EB31452099D254503D4B5D986912DE89A231B287814D75F401344346C71ABE9D58E6C87EEC6156016152647378FA40D9BB406CAF55020066A264A6774F982EFBA11715F19F6D87F485E95E006242A109C4F504315EA950F9EB216B1502C0B60200E478A64773E5CF022AE53F64D50CC9F500207F32E49062002045C0231A9C287F41D873E5006C0100D0BA8702A9F29FD8AC1C80764492743CB806B4B20A0A1110EBDDD644CBAF01579404D08BA80393A07D803271F0C89C793FB81F002C8AAE57120064DD4C814B361CB026AE575100887E204C071C071082CF865E15585BD9861D0F4C053C0D3D1FC85E6BB8DEE8FBBF884660EA0800C4A2B0763480271CB7F22B9FFF454C12448EE48210E5091D07959EE438AEEB16D5AC8033189C867818BA00747243DAB6867FE108A21524CE2D6766AB1040E3800300F75323BD11E1EC6100B35408E002E7D4D3166AA9C159C3DFC669D407E02A37AA86477C934490E4B0E38BBAB9446D003A4A9F72AEBA50EABD620262743A6A288C2E01D739779D79EC352286189D0A4A87A20174729E1AB8EA790DC468476A344B6D007E6BF002C0150F7650009035F4799C466500160E707C3AD68807A089824C0A63012C3AC9F1CB3D30C64D136763013C91FBFBFBF29FE3D6DF820348C36D91E3348C1B94E57FCB00272097C018637502AC131805C06DEB08DCFF5B5D9CA0FE750D0B20061508BB02F06CAE240440E59C984E6201D883E12438006EE5C2C052203F71E2C202486298388207C0350CAE09A0F80F708A0320714C060D00B6E0B545A2FB8F8F715C10006430F1740070DCF54552F23F83EBB9A00088877D26EF05806BB8E02F82D24727392E380062613B257A03B005F0C77EF3A34B6CEC7CCA71C1023019930FF301C0DE210C0A17838E960B0D1C173C00F9A838C817007B7B38D8E2A34F58D3B2ED2927516000898C913A00FB70FE58E7D56BEEB5E1DAD5CE635D9C7481011819BD120086D475E6FA85279D8F1E0D3ED976FDCC0017A0C000F44CA462006C8D6231275B600091CC9B0A0240080CE04DC6F07A0330A0C64276008DBFFFFC9F7BB401DCFBEFCFBF37E2002431A8FD82D8C65FCB2C36D106607F47D9AF8D2800610CE841A4E59EC5A214008BE55E0BCA6E1480876516250158CA1EAA0BC003A7FF3E00AC2F5F585ABA709B5F43BEF5DBECD796AF170460297BA02600D6E31641002B8707048B568AFB2F72EDC88B8E5B3100208DE05E8B2080AE9101D157A2D16FD748F67F51972000CB5E4C2388E806AD65C200CA478700A2694FB16B47DF54668574838840E8478B3000971CE942310062D7BABCEA4748208408858F8A0070190DAF11032076ADCBAB8E424261C460E888FF004A250028150170043218420C87CB825305CA20C361A30200E83482100046484A4CAC0A743D16EEDAF8BBCCC75D0A548144485254AC11A41208611AC17C485AFCAE1880E2AE72A1F0962F6C2EEFE2C400DC85A4C5111323563100F8C1905D884028163335B637180020A1703C6672546C30440300663094019A1EFF457900BF400C8F432D9078A834004C422409B744E6C17125011C07A54366E1164911EB5EC50094EDB5828C8E819E2467BD7BF448196D0065478EDEB5C24C4EC06C21E82ADA00B0D6A6E196CA862600FB52D928EDEB0B6068B13493154A0056418DCD027E30E154375D0007A1C6C6003F9971EA3C55FF8BCF438D4D057E34E5540DDD1250033576AEE34425E8918AA7E902388DB435270AB581888B4E0410D74BB8E504D2563DF0EBF9119D93E04DA5C3FF4A09B79C43DAEAFC7E7E1EF2A1CF247853E2005022E19667485BE7213F9F776A83941A5D622B039552FC2FDE80B4750C72030565BA0168271009DD4223A05650B24ED06802309BA88CE83B9A00BE435A9A0EDD4667B41158457124806C025CB6D161A0A7CB9E0E9130A800BB95962275005A0372B19BA98DEAD441211F0E54EFDBE8EB7F1BF7551F101C0A9E029AE9B6991A361AFEB790134B8B8A8AAAF8FF5565FBD752C5E360063F24B6AE120150CD1BFB94548B0058751B69E578F4969A2EEA11F0A2AFC8EE26CF8703C57634BE0AC7907A90367A6CA989AD03B7858AC0F221025E65A064C8FF1D8A15804CF8B6BAAEFA9F50386F2FE945D51E3F7555B5AF9241A705F0DA56370E9A15F94228333854D78B8A96BB34F807868A858FB66158DD5F40732171F8ADB55D7553700C3854DA6DBF7765554971714955A5F36FC171E14D0AE950ECE6EA6EB180E098B07847118F76087E5255730A6A603A85EDF5FD6F079D55DE55D555C2A3805D50F378B6D7071CB0202935D6B7D4D5FDA57D2297632B00DF010B802336FC0F061C4DC1C6E5D5FB8A8AF6552FDF2896142A3E8DB58DF7880DC0212BEEC362606AA86603D6B6444AC7EC78F485B049A2F3B7C1A625D33A68C95D2F0E62FCEF7E01362C93E2719B6EFA013253DAFD03DAAE71F40E5BF324002803DDCFD056F93C6C0DB69FC8A876C96E07CEEF821B154BF3C045AFDC80CCBEA0C60A3749E8CCCD14F8DBC8861E39FEF76CC05B9442F9D055EF9830E03CF9AA7314CC113C7415BD666EB82108B01AD4ECA2614D1AF5839779C68637032804DD374FD1B045E4E0657C2C30DC164A6E097AAC742C19A7C4E1EBBCF5A0E74F2953402F2899217AF83A13A1A1F1DEF96B377DF6E90D3F11FCF9F26F9F6D5A3B9F861D9A0851004C3E05EF575798CD9F1416BEFBD73FC4DDFF63E7A785859F98CD15AB2930C817F79F893360DFF9E5269BF766F33F0A6D000A0B5FF6098EFD4BFA5E160EE923FB3D159BBEC4DA6288F30300341A9ABF6485D9A1CF1D8EBD6FB12CA8ACE29F19AAAA5C60B1BCEFB8EEF3E1DB562C411683147FFC67A2619324CBF62F363BF5E10800BB165456F6551D28B1A7418B4B4A0E54F555DA9DB76B18C08723372EDEBF0C658F3EDA2F004C06A61D5CE628FBC3FAD80D806F0D03F8D8E5D68A4D18049A0CC64F85230AFF7E57F7CDE6EFA501F8DEEDE68AFD888A90E0AFFF8CCE24BFEEBBBB6F367F200DC0071EB757C86F0B4C3ABF013013645682F756983D55280D40A1D70356BC27B3024C6024285C5EE5379B7D01B82106E086E3BABFF03C425E53102EC57F463725F037AD5DCC63FC70157877A718809D0E00FFE47BC6E225815B35452709001311E8CAB9F9ABCDBC1A6E04BF1503F02D5F2338A2D581B60461118C44FDBF9BB36949250AE3F863962662DDB28B2888144D3310B4517440C41788C85E21BA975908577021739182DC44087D00FB02052EFA040565DBBB6AD3A245B8915A5DAA759B1677736FD774CC9779393367668EFDB6471ECFFFF1793B675495F78379BEFFCE5B6D30B727AD7F2FD7DB063B82406525180364543D2FFFC989D11C84322FD20E78C9740F42DDA84A832974FD601BC116FE1F46E1CC89A212208CC278D260C4A6C2016045FD5DF96E517CD78DC35023078EA4F41F3533E0FD30244211B51B7CB5822AD6D1BE3AF68BE7A4B850D2089B4DF0FF7158021EED90685F0795204D03F982E4A6B96A2B04EAE2FAEBAD00A84ADB2AE4F59B003A1E9420DC8F1DC8E8E76ECB4D7137C762FA8F6F9A2F29DFCA182B1C20DC82B9553B00428A0BE101274BAB0F64AE45F467AF33B23D4040B1074642A001BF139B7EEEAC247820DB770410F497CE386C1E70FA41135E0B8EFC7FE7A1253073DFA7151CDD0BCB0F4AAC29AB03162F68647D18977E8E7F16245E56BAF5572E85C5675E91B982825E30BC0E9A09C836C35D65FA39EE494882B75258F99007D9CA4D7BA5F4A4D01C2F3B0FD80380018FDCFC57E49472971364E632972795FA4E36BB53AF9CB43FFDB7853BC5E68A7233A107B0B024FD2EFB9C726A19596A08E6F6A577B60498901C884E39146A3969F9B91A92B9537D06A01E24FE6A27CFA1715792D25FBA433497C77107AA25067679C41D734FCFE2FAFFFE41B5265E0887002BB3180A406BCF0FE5FEF2CB0F3CBA35B132300B98F1D8D12E402467C2C33E79503A3C5365ACEF0589DD03D8090C6B98007A4E46D58B4EF917D55B95A60A7D926038003AF0C5822301DA37245787E7AF8FE5F2E3EBF9E1D56F0D867A93C0F20574C1EBD4D80174A2BB1338BDA013FEAED371910C0714BBCEBF7ED08DD084F60AA8031D757022043AE29E6C37831F3C290EE0DB6702FBA41BF465C1425C007C0801CB02E8CEF41C6901D00E81B9693080D0146901D00A81A91018C398859C16D06E049631300CEB3C2933407B1698B782813886BE91E580EF430E3096E42249FA179360380ECA478A7C1FE5003348A5C9D09F4E81498CC623E6CB8FC447C13CC68326E7812F380EE6924A98A93F9102F3A14DEB078B3410819B8999213FC6B881141CCC8AD1F2571807908483091B293F4C98FC464FA40D2B87097A148824B96C4053F42D27815C5C94CEF53046B980706856B730F0B1A4C67ED77818DF8AE2571FDD8ABB603078FB94FCD42A561F4457293F0C1833F104A65CF025E233309084E8A0E6E9201CA44330B88C826B33B8A632127CABC14D5723A3061DDB06C586916A4234CC521B36F854D892CC36BB267B83125963B799E427D3DEE18714CD50C165361D8E45226F5111F545222BB1709A5D0E520C9D325CF93F347A9053046069F80000000049454E44AE426082, N'Hyderabad', N'Hyderabad', N'nidhi', N'1', 1, 1, N'EMP-1/18-19', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'0', 0)
INSERT [dbo].[Employee_Type] ([EMP_TYPE_ID], [EMP_TYPE_NAME], [EMP_TYPE_DESC]) VALUES (1, N'Admin', N'admin')
INSERT [dbo].[Grade_Master] ([Grade_Id], [Grade_Name], [Grade_Details]) VALUES (0, NULL, NULL)
INSERT [dbo].[Installation_Assistance_Template] ([Sales_Installation_Id], [Terms_Conditions_Name], [Descritpion]) VALUES (1, N'Installation and Technical assistance:', N'&lt;ol&gt;&lt;li&gt;&#160;Accommodation for installation team/tools to be provided on site by client.&lt;/li&gt;&lt;li&gt;Site measurements are to be maintained accurate to final drawings. And major variation in opening size to be rectified by client.&lt;/li&gt;&lt;/ol&gt;&lt;div&gt;For Installation related queries kindly contact: +91 8801119043&lt;/div&gt;&lt;div&gt;For Technical related queries kindly contact: +91 9849886288&lt;br&gt;&lt;/div&gt;')
INSERT [dbo].[Installation_Assistance_Template] ([Sales_Installation_Id], [Terms_Conditions_Name], [Descritpion]) VALUES (2, N'Installation and Technical assistance No.2 :', N'&lt;ol&gt;&lt;li&gt;Metal scaffolding to be arranged by client at site where required.&lt;/li&gt;&lt;li&gt;Accommodation for installation team/tools to be provided on site by the client.&lt;/li&gt;&lt;li&gt;Site measurements are to be maintained accurate to final drawings. And major variation in opening size to be rectified by client.&lt;/li&gt;&lt;li&gt;Installation charges at 80/sft.&lt;/li&gt;&lt;/ol&gt;&lt;div&gt;For Installation related queries kindly contact: +91 8008103096&lt;/div&gt;&lt;div&gt;For Technical related queries kindly contact: +91 9849886288&lt;br&gt;&lt;/div&gt;')
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (201, N'Phani', CAST(N'2018-12-26' AS Date), CAST(N'15:48:38.0130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (202, N'phani', CAST(N'2018-12-26' AS Date), CAST(N'15:52:28.6070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (203, N'Phani', CAST(N'2018-12-26' AS Date), CAST(N'16:10:08.2770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (204, N'Phani', CAST(N'2018-12-26' AS Date), CAST(N'16:17:04.2330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (205, N'Phani', CAST(N'2018-12-26' AS Date), CAST(N'16:41:16.0270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (206, N'Phani', CAST(N'2018-12-26' AS Date), CAST(N'17:28:32.6330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (207, N'Phani', CAST(N'2018-12-26' AS Date), CAST(N'17:47:58.0830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (208, N'phani', CAST(N'2018-12-26' AS Date), CAST(N'21:55:19.3500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (209, N'phani', CAST(N'2018-12-26' AS Date), CAST(N'22:04:16.5400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (210, N'phani', CAST(N'2018-12-26' AS Date), CAST(N'22:33:36.0370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (211, N'phani', CAST(N'2018-12-26' AS Date), CAST(N'22:38:16.1100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (212, N'phani', CAST(N'2018-12-26' AS Date), CAST(N'23:36:34.8930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (213, N'phani', CAST(N'2018-12-26' AS Date), CAST(N'23:38:24.5330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (214, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'01:29:22.4170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (215, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'01:43:28.7900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (216, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'02:55:58.5100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (217, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'03:56:12.8100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (218, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'04:11:46.3570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (219, N'Phani', CAST(N'2018-12-27' AS Date), CAST(N'10:11:09.4030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (220, N'Phani', CAST(N'2018-12-27' AS Date), CAST(N'10:20:45.7330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (221, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'10:44:57.0330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (222, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'13:19:15.8700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (223, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'14:14:50.2100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (224, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'14:21:05.4130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (225, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'14:31:44.5100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (226, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'14:38:26.4270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (227, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'14:42:50.1300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (228, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'14:47:43.9600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (229, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'14:54:08.6630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (230, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'15:38:08.2130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (231, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'17:24:02.2330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (232, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'18:13:00.7130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (233, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'18:20:26.3400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (234, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'18:40:15.0770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (235, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'18:49:20.7330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (236, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'18:50:40.2970000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (237, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'19:04:11.9070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (238, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'19:10:38.4070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (239, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'19:20:44.7530000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (240, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'19:32:54.1230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (241, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'20:01:13.6870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (242, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'20:06:36.9530000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (243, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'20:08:21.3430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (244, N'phani', CAST(N'2018-12-27' AS Date), CAST(N'20:12:27.3900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (245, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'10:05:41.1200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (246, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'11:21:55.3670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (247, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'11:39:28.6970000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (248, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'11:45:43.5570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (249, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'12:07:11.9670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (250, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'12:39:23.9230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (251, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'12:42:45.6600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (252, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'12:48:09.3000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (253, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'14:08:01.3100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (254, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'14:09:21.5370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (255, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'14:42:29.4300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (256, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'15:34:17.8430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (257, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'15:40:21.6570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (258, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'15:48:45.2670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (259, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'15:58:17.2700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (260, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'16:08:07.6130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (261, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'18:47:20.2000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (262, N'phani', CAST(N'2018-12-28' AS Date), CAST(N'18:59:57.2630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (263, N'PHANI', CAST(N'2018-12-29' AS Date), CAST(N'02:06:57.9800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (264, N'phani', CAST(N'2018-12-29' AS Date), CAST(N'03:43:25.8100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (265, N'PHANI', CAST(N'2018-12-29' AS Date), CAST(N'10:19:07.8800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (266, N'Phani', CAST(N'2018-12-29' AS Date), CAST(N'10:38:29.0070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (267, N'Phani', CAST(N'2018-12-29' AS Date), CAST(N'11:00:57.5130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (268, N'phani', CAST(N'2018-12-29' AS Date), CAST(N'11:07:26.9200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (269, N'Phani', CAST(N'2018-12-29' AS Date), CAST(N'11:21:16.0970000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (270, N'phani', CAST(N'2018-12-29' AS Date), CAST(N'11:25:47.6730000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (271, N'phani', CAST(N'2018-12-29' AS Date), CAST(N'14:09:52.6330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (272, N'Phani', CAST(N'2018-12-29' AS Date), CAST(N'14:50:40.2870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (273, N'Phani', CAST(N'2018-12-29' AS Date), CAST(N'15:07:02.4770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (274, N'phani', CAST(N'2018-12-29' AS Date), CAST(N'19:16:37.8570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (275, N'phani', CAST(N'2018-12-30' AS Date), CAST(N'13:01:34.6970000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (276, N'Phani', CAST(N'2018-12-31' AS Date), CAST(N'10:13:07.5770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (277, N'Phani', CAST(N'2018-12-31' AS Date), CAST(N'11:23:21.9770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (278, N'Phani', CAST(N'2018-12-31' AS Date), CAST(N'11:36:11.8070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (279, N'Phani', CAST(N'2018-12-31' AS Date), CAST(N'11:48:42.9000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (280, N'Phani', CAST(N'2018-12-31' AS Date), CAST(N'11:56:55.5430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (281, N'Phani', CAST(N'2018-12-31' AS Date), CAST(N'12:03:42.0470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (282, N'Phani', CAST(N'2018-12-31' AS Date), CAST(N'12:28:49.6700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (283, N'Phani', CAST(N'2018-12-31' AS Date), CAST(N'12:43:46.3130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (284, N'Phani', CAST(N'2018-12-31' AS Date), CAST(N'13:09:00.2630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (285, N'Phani', CAST(N'2018-12-31' AS Date), CAST(N'13:20:46.1870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (286, N'Phani', CAST(N'2018-12-31' AS Date), CAST(N'14:20:33.0870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (287, N'Phani', CAST(N'2018-12-31' AS Date), CAST(N'15:04:06.4970000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (288, N'Phani', CAST(N'2018-12-31' AS Date), CAST(N'15:55:29.3330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (289, N'Phani', CAST(N'2018-12-31' AS Date), CAST(N'18:17:23.1000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (290, N'phani', CAST(N'2019-01-01' AS Date), CAST(N'19:43:36.5230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (291, N'phani', CAST(N'2019-01-01' AS Date), CAST(N'22:20:21.3030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (292, N'Phani', CAST(N'2019-01-02' AS Date), CAST(N'10:12:53.8800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (293, N'Phani', CAST(N'2019-01-02' AS Date), CAST(N'10:34:09.1170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (294, N'Phani', CAST(N'2019-01-02' AS Date), CAST(N'10:40:17.9800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (295, N'Phani', CAST(N'2019-01-02' AS Date), CAST(N'10:53:36.6400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (296, N'Phani', CAST(N'2019-01-02' AS Date), CAST(N'11:27:12.4130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (297, N'Phani', CAST(N'2019-01-02' AS Date), CAST(N'11:34:50.8230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (298, N'Phani', CAST(N'2019-01-03' AS Date), CAST(N'10:33:18.3800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (299, N'PHANI', CAST(N'2019-01-03' AS Date), CAST(N'10:43:57.7400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (300, N'phani', CAST(N'2019-01-03' AS Date), CAST(N'11:42:26.7800000' AS Time))
GO
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (301, N'phani', CAST(N'2019-01-03' AS Date), CAST(N'11:51:21.7170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (302, N'phani', CAST(N'2019-01-03' AS Date), CAST(N'11:56:07.8130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (303, N'phani', CAST(N'2019-01-03' AS Date), CAST(N'12:08:30.1900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (304, N'Phani', CAST(N'2019-01-03' AS Date), CAST(N'15:12:45.7030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (305, N'Phani', CAST(N'2019-01-03' AS Date), CAST(N'15:19:09.8130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (306, N'Phani', CAST(N'2019-01-04' AS Date), CAST(N'11:19:55.9800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (307, N'Phani', CAST(N'2019-01-05' AS Date), CAST(N'11:20:41.3400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (308, N'Phani', CAST(N'2019-01-07' AS Date), CAST(N'10:17:53.0900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (309, N'Phani', CAST(N'2019-01-07' AS Date), CAST(N'10:34:44.8300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (310, N'Phani', CAST(N'2019-01-07' AS Date), CAST(N'12:08:55.5130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (311, N'phani', CAST(N'2019-01-07' AS Date), CAST(N'22:08:40.0400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (312, N'phani', CAST(N'2019-01-08' AS Date), CAST(N'05:35:08.2100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (313, N'phani', CAST(N'2019-01-08' AS Date), CAST(N'05:50:11.6970000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (314, N'phani', CAST(N'2019-01-08' AS Date), CAST(N'05:56:02.4630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (315, N'phani', CAST(N'2019-01-08' AS Date), CAST(N'06:01:34.8230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (316, N'PHANI', CAST(N'2019-01-08' AS Date), CAST(N'10:53:25.6900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (317, N'phani', CAST(N'2019-01-08' AS Date), CAST(N'11:37:35.7900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (318, N'phani', CAST(N'2019-01-08' AS Date), CAST(N'11:40:33.5570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (319, N'phani', CAST(N'2019-01-08' AS Date), CAST(N'19:03:01.6470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (320, N'Phani', CAST(N'2019-01-09' AS Date), CAST(N'12:15:54.9730000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (321, N'Phani', CAST(N'2019-01-09' AS Date), CAST(N'13:05:47.2500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (322, N'phani', CAST(N'2019-01-09' AS Date), CAST(N'13:37:56.7500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (323, N'phani', CAST(N'2019-01-09' AS Date), CAST(N'13:37:57.1600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (324, N'Phani', CAST(N'2019-01-09' AS Date), CAST(N'15:51:02.9230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (325, N'phani', CAST(N'2019-01-09' AS Date), CAST(N'20:15:30.0800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (326, N'phani', CAST(N'2019-01-09' AS Date), CAST(N'20:23:10.6900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (327, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'03:44:22.6570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (328, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'09:50:31.2830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (329, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'09:59:25.2870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (330, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'10:04:58.3330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (331, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'10:14:48.4730000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (332, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'10:21:44.5870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (333, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'10:36:58.3070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (334, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'10:42:09.2770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (335, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'10:50:14.9630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (336, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'10:59:41.0130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (337, N'Phani', CAST(N'2019-01-10' AS Date), CAST(N'11:11:48.7170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (338, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'11:22:28.3730000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (339, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'11:23:44.4070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (340, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'11:27:24.0630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (341, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'11:29:56.3430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (342, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'11:33:04.0330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (343, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'12:40:36.2300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (344, N'Phani', CAST(N'2019-01-10' AS Date), CAST(N'12:50:39.7600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (345, N'Phani', CAST(N'2019-01-10' AS Date), CAST(N'13:09:51.1370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (346, N'Phani', CAST(N'2019-01-10' AS Date), CAST(N'14:17:32.3930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (347, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'14:33:20.1470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (348, N'Phani', CAST(N'2019-01-10' AS Date), CAST(N'15:07:58.6830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (349, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'15:24:41.2800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (350, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'15:33:43.5130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (351, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'15:35:39.3430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (352, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'15:41:08.1400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (353, N'Phani', CAST(N'2019-01-10' AS Date), CAST(N'15:45:03.1100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (354, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'15:50:17.1430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (355, N'Phani', CAST(N'2019-01-10' AS Date), CAST(N'15:55:45.2130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (356, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'16:14:02.1070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (357, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'16:16:35.4370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (358, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'16:18:24.7800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (359, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'16:24:10.0770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (360, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'16:30:45.6900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (361, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'16:33:56.9530000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (362, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'16:36:46.4700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (363, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'16:39:40.5800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (364, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'16:41:49.4870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (365, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'16:45:12.8000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (366, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'16:48:04.7830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (367, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'16:57:06.3000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (368, N'Phani', CAST(N'2019-01-10' AS Date), CAST(N'16:58:33.2700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (369, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'17:01:02.2070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (370, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'17:08:12.8030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (371, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'17:10:58.6930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (372, N'phani', CAST(N'2019-01-10' AS Date), CAST(N'17:26:47.9930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (373, N'Phani', CAST(N'2019-01-11' AS Date), CAST(N'10:26:07.9670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (374, N'Phani', CAST(N'2019-01-11' AS Date), CAST(N'10:39:04.2030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (375, N'Phani', CAST(N'2019-01-11' AS Date), CAST(N'10:51:01.6900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (376, N'Phani', CAST(N'2019-01-11' AS Date), CAST(N'11:08:31.3000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (377, N'Phani', CAST(N'2019-01-11' AS Date), CAST(N'11:38:36.7570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (378, N'Phani', CAST(N'2019-01-11' AS Date), CAST(N'11:57:16.3700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (379, N'phani', CAST(N'2019-01-11' AS Date), CAST(N'12:02:38.2770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (380, N'Phani', CAST(N'2019-01-11' AS Date), CAST(N'12:12:17.9330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (381, N'Phani', CAST(N'2019-01-11' AS Date), CAST(N'12:28:13.1000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (382, N'Phani', CAST(N'2019-01-11' AS Date), CAST(N'12:37:13.2570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (383, N'Phani', CAST(N'2019-01-11' AS Date), CAST(N'12:46:16.8200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (384, N'Phani', CAST(N'2019-01-11' AS Date), CAST(N'13:09:20.7470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (385, N'Phani', CAST(N'2019-01-11' AS Date), CAST(N'13:18:45.1700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (386, N'phani', CAST(N'2019-01-11' AS Date), CAST(N'14:33:52.0870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (387, N'phani', CAST(N'2019-01-11' AS Date), CAST(N'14:44:53.9470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (388, N'phani', CAST(N'2019-01-11' AS Date), CAST(N'15:16:37.9200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (389, N'phani', CAST(N'2019-01-11' AS Date), CAST(N'15:20:05.7000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (390, N'Phani', CAST(N'2019-01-11' AS Date), CAST(N'15:53:56.1430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (391, N'Phani', CAST(N'2019-01-11' AS Date), CAST(N'18:27:56.3370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (392, N'Phani', CAST(N'2019-01-11' AS Date), CAST(N'18:37:23.1870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (393, N'Phani', CAST(N'2019-01-12' AS Date), CAST(N'10:22:35.1900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (394, N'Phani', CAST(N'2019-01-12' AS Date), CAST(N'10:50:34.3330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (395, N'Phani', CAST(N'2019-01-12' AS Date), CAST(N'10:53:39.5670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (396, N'Phani', CAST(N'2019-01-12' AS Date), CAST(N'11:06:36.6930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (397, N'Phani', CAST(N'2019-01-12' AS Date), CAST(N'11:22:47.6670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (398, N'phani', CAST(N'2019-01-12' AS Date), CAST(N'11:35:31.5270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (399, N'Phani', CAST(N'2019-01-12' AS Date), CAST(N'12:05:36.0170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (400, N'Phani', CAST(N'2019-01-12' AS Date), CAST(N'12:41:08.0270000' AS Time))
GO
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (401, N'phani', CAST(N'2019-01-12' AS Date), CAST(N'14:28:17.6500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (402, N'phani', CAST(N'2019-01-12' AS Date), CAST(N'15:09:03.4530000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (403, N'phani', CAST(N'2019-01-12' AS Date), CAST(N'15:38:43.3270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (404, N'phani', CAST(N'2019-01-12' AS Date), CAST(N'15:50:51.8770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (405, N'phani', CAST(N'2019-01-12' AS Date), CAST(N'15:57:50.6730000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (406, N'phani', CAST(N'2019-01-17' AS Date), CAST(N'02:10:33.9830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (407, N'phani', CAST(N'2019-01-17' AS Date), CAST(N'11:56:57.7200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (408, N'phani', CAST(N'2019-01-17' AS Date), CAST(N'15:06:16.2930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (409, N'Phani', CAST(N'2019-01-17' AS Date), CAST(N'15:09:42.6830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (410, N'phani', CAST(N'2019-01-17' AS Date), CAST(N'15:31:26.7670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (411, N'Phani', CAST(N'2019-01-17' AS Date), CAST(N'15:35:53.7670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (412, N'Phani', CAST(N'2019-01-17' AS Date), CAST(N'15:55:47.1600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (413, N'phani', CAST(N'2019-01-17' AS Date), CAST(N'16:02:43.3930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (414, N'Phani', CAST(N'2019-01-17' AS Date), CAST(N'17:08:18.3570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (415, N'phani', CAST(N'2019-01-18' AS Date), CAST(N'11:42:18.5500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (416, N'phani', CAST(N'2019-01-18' AS Date), CAST(N'12:30:32.2370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (417, N'phani', CAST(N'2019-01-18' AS Date), CAST(N'12:36:10.8930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (418, N'phani', CAST(N'2019-01-18' AS Date), CAST(N'14:05:53.7800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (419, N'phani', CAST(N'2019-01-18' AS Date), CAST(N'14:07:10.4830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (420, N'phani', CAST(N'2019-01-18' AS Date), CAST(N'14:14:43.5470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (421, N'phani', CAST(N'2019-01-18' AS Date), CAST(N'14:19:42.2930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (422, N'phani', CAST(N'2019-01-18' AS Date), CAST(N'14:39:57.4400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (423, N'phani', CAST(N'2019-01-18' AS Date), CAST(N'14:50:26.3300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (424, N'phani', CAST(N'2019-01-18' AS Date), CAST(N'15:47:13.1800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (425, N'phani', CAST(N'2019-01-19' AS Date), CAST(N'07:42:12.9300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (426, N'phani', CAST(N'2019-01-19' AS Date), CAST(N'08:04:23.4800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (427, N'phani', CAST(N'2019-01-19' AS Date), CAST(N'08:08:59.9970000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (428, N'phani', CAST(N'2019-01-19' AS Date), CAST(N'08:16:40.0900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (429, N'phani', CAST(N'2019-01-19' AS Date), CAST(N'09:41:13.7300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (430, N'phani', CAST(N'2019-01-19' AS Date), CAST(N'09:56:46.2300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (431, N'phani', CAST(N'2019-01-19' AS Date), CAST(N'09:58:12.5600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (432, N'phani', CAST(N'2019-01-19' AS Date), CAST(N'14:58:04.0700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (433, N'Phani', CAST(N'2019-01-19' AS Date), CAST(N'16:28:46.7400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (434, N'Phani', CAST(N'2019-01-19' AS Date), CAST(N'16:40:04.8030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (435, N'phani', CAST(N'2019-01-20' AS Date), CAST(N'23:42:26.3030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (436, N'phani', CAST(N'2019-01-20' AS Date), CAST(N'23:56:32.9800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (437, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'00:02:59.7770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (438, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'09:28:33.3370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (439, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'09:42:41.8530000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (440, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'10:36:04.9700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (441, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'10:37:44.8770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (442, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'10:42:51.5970000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (443, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'11:16:02.5870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (444, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'11:19:15.8070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (445, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'11:29:35.4470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (446, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'11:45:13.1200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (447, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'12:45:18.2400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (448, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'13:16:30.4000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (449, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'13:30:43.3700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (450, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'15:24:38.1030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (451, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'15:29:25.4800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (452, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'15:36:21.4500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (453, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'16:01:25.9070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (454, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'16:05:42.7030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (455, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'16:19:36.9100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (456, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'16:24:32.9870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (457, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'16:26:54.5800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (458, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'16:35:56.7400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (459, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'16:39:33.4600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (460, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'16:43:10.0370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (461, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'18:19:42.4400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (462, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'18:32:23.3500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (463, N'phani', CAST(N'2019-01-21' AS Date), CAST(N'18:40:55.5200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (464, N'Phani', CAST(N'2019-01-22' AS Date), CAST(N'10:19:01.2570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (465, N'phani', CAST(N'2019-01-22' AS Date), CAST(N'10:33:44.8400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (466, N'phani', CAST(N'2019-01-22' AS Date), CAST(N'10:58:58.0430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (467, N'phani', CAST(N'2019-01-22' AS Date), CAST(N'11:02:54.9500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (468, N'phani', CAST(N'2019-01-22' AS Date), CAST(N'11:15:33.0800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (469, N'Phani', CAST(N'2019-01-22' AS Date), CAST(N'14:40:28.2470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (470, N'Phani', CAST(N'2019-01-22' AS Date), CAST(N'15:04:57.4230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (471, N'Phani', CAST(N'2019-01-22' AS Date), CAST(N'15:04:58.9070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (472, N'Phani', CAST(N'2019-01-22' AS Date), CAST(N'15:05:15.1270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (473, N'Phani', CAST(N'2019-01-22' AS Date), CAST(N'15:15:09.7200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (474, N'Phani', CAST(N'2019-01-22' AS Date), CAST(N'15:39:07.5370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (475, N'Phani', CAST(N'2019-01-22' AS Date), CAST(N'15:54:31.5870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (476, N'phani', CAST(N'2019-01-22' AS Date), CAST(N'15:55:08.6170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (477, N'phani', CAST(N'2019-01-22' AS Date), CAST(N'16:03:05.4130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (478, N'phani', CAST(N'2019-01-22' AS Date), CAST(N'16:06:52.4470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (479, N'phani', CAST(N'2019-01-22' AS Date), CAST(N'17:12:14.9700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (480, N'phani', CAST(N'2019-01-22' AS Date), CAST(N'21:25:54.8330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (481, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'00:58:20.0670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (482, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'01:08:13.1900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (483, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'01:11:19.2070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (484, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'01:15:58.4270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (485, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'01:29:16.4770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (486, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'01:41:43.0100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (487, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'01:49:56.9470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (488, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'11:48:49.2930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (489, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'11:59:10.3100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (490, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'12:32:53.3170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (491, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'12:35:56.9270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (492, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'12:39:53.2530000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (493, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'12:43:47.4100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (494, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'12:49:11.2230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (495, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'12:51:29.6600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (496, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'14:06:48.1870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (497, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'14:12:28.8430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (498, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'14:23:11.4700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (499, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'14:24:33.8300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (500, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'14:30:10.1600000' AS Time))
GO
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (501, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'14:32:32.4730000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (502, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'14:33:44.7230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (503, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'15:37:39.8870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (504, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'15:42:12.8570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (505, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'15:47:53.4500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (506, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'15:55:08.2030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (507, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'16:04:10.7800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (508, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'16:13:46.8130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (509, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'16:20:10.0030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (510, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'16:25:12.3300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (511, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'16:26:38.3170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (512, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'16:28:32.7230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (513, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'16:32:14.3500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (514, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'16:34:42.6470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (515, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'16:51:53.6170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (516, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'17:54:57.8130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (517, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'17:59:57.5930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (518, N'phani', CAST(N'2019-01-23' AS Date), CAST(N'18:03:34.1730000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (519, N'phani', CAST(N'2019-01-24' AS Date), CAST(N'09:48:05.8200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (520, N'phani', CAST(N'2019-01-24' AS Date), CAST(N'10:09:47.4670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (521, N'phani', CAST(N'2019-01-24' AS Date), CAST(N'10:25:22.7670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (522, N'phani', CAST(N'2019-01-24' AS Date), CAST(N'10:27:09.5030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (523, N'phani', CAST(N'2019-01-24' AS Date), CAST(N'10:36:25.6300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (524, N'phani', CAST(N'2019-01-24' AS Date), CAST(N'10:38:20.0500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (525, N'phani', CAST(N'2019-01-24' AS Date), CAST(N'12:27:54.4870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (526, N'phani', CAST(N'2019-01-24' AS Date), CAST(N'12:49:13.0830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (527, N'phani', CAST(N'2019-01-24' AS Date), CAST(N'12:51:40.6470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (528, N'phani', CAST(N'2019-01-24' AS Date), CAST(N'13:07:16.0700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (529, N'phani', CAST(N'2019-01-24' AS Date), CAST(N'14:01:10.5930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (530, N'phani', CAST(N'2019-01-24' AS Date), CAST(N'14:37:49.0500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (531, N'phani', CAST(N'2019-01-24' AS Date), CAST(N'14:54:43.5530000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (532, N'phani', CAST(N'2019-01-24' AS Date), CAST(N'15:25:35.6200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (533, N'phani', CAST(N'2019-01-25' AS Date), CAST(N'09:43:06.1600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (534, N'phani', CAST(N'2019-01-25' AS Date), CAST(N'09:44:49.5370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (535, N'phani', CAST(N'2019-01-25' AS Date), CAST(N'10:42:48.6930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (536, N'phani', CAST(N'2019-01-25' AS Date), CAST(N'11:22:36.3100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (537, N'phani', CAST(N'2019-01-25' AS Date), CAST(N'11:27:43.1070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (538, N'phani', CAST(N'2019-01-25' AS Date), CAST(N'12:45:27.6330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (539, N'phani', CAST(N'2019-01-25' AS Date), CAST(N'14:08:09.0200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (540, N'phani', CAST(N'2019-01-25' AS Date), CAST(N'14:13:41.8930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (541, N'phani', CAST(N'2019-01-25' AS Date), CAST(N'14:33:40.4770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (542, N'phani', CAST(N'2019-01-25' AS Date), CAST(N'15:32:52' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (543, N'phani', CAST(N'2019-01-25' AS Date), CAST(N'15:57:22.4230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (544, N'phani', CAST(N'2019-01-25' AS Date), CAST(N'16:02:21.2370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (545, N'phani', CAST(N'2019-01-26' AS Date), CAST(N'21:41:07.2770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (546, N'phani', CAST(N'2019-01-26' AS Date), CAST(N'21:45:53.4470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (547, N'phani', CAST(N'2019-01-26' AS Date), CAST(N'23:01:52.5830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (548, N'phani', CAST(N'2019-01-27' AS Date), CAST(N'01:31:15.0730000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (549, N'phani', CAST(N'2019-01-27' AS Date), CAST(N'12:04:08.1670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (550, N'phani', CAST(N'2019-01-27' AS Date), CAST(N'13:20:30.2800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (551, N'phani', CAST(N'2019-01-27' AS Date), CAST(N'13:44:40.6530000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (552, N'phani', CAST(N'2019-01-27' AS Date), CAST(N'13:48:20.1530000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (553, N'phani', CAST(N'2019-01-27' AS Date), CAST(N'14:21:24.7200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (554, N'phani', CAST(N'2019-01-27' AS Date), CAST(N'20:08:03.9230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (555, N'phani', CAST(N'2019-01-27' AS Date), CAST(N'20:37:28.3330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (556, N'phani', CAST(N'2019-01-27' AS Date), CAST(N'20:57:24.8300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (557, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'11:12:20.7200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (558, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'11:14:53.8430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (559, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'11:19:37.3300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (560, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'11:21:42.9230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (561, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'12:11:48.6000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (562, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'13:27:21.7700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (563, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'14:43:35.1570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (564, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'14:45:26.7500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (565, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'14:55:39.0330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (566, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'14:57:26.1100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (567, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'15:10:36.1730000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (568, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'15:41:07.2630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (569, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'15:46:47.8270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (570, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'16:11:39.5500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (571, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'16:18:47.8470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (572, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'17:07:25.4470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (573, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'17:30:49.6070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (574, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'17:43:44.5000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (575, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'17:56:19.3770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (576, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'18:00:02.9530000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (577, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'18:05:39.9700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (578, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'18:31:58.6470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (579, N'phani', CAST(N'2019-01-28' AS Date), CAST(N'18:57:21.2770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (580, N'PHANI', CAST(N'2019-01-29' AS Date), CAST(N'09:46:54.8000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (581, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'10:20:46.2600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (582, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'10:34:38.5430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (583, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'10:42:07.3400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (584, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'11:04:54.9200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (585, N'PHANI', CAST(N'2019-01-29' AS Date), CAST(N'11:42:24.4430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (586, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'12:50:18.9870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (587, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'14:07:49.2230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (588, N'PHANI', CAST(N'2019-01-29' AS Date), CAST(N'14:14:13.8030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (589, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'14:39:43.8070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (590, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'15:06:52.9330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (591, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'15:26:18.6870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (592, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'15:28:49.9070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (593, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'15:35:21.6570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (594, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'15:43:33.2830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (595, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'15:49:19.7530000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (596, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'16:04:07.5670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (597, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'16:09:19.2700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (598, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'16:20:37.3370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (599, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'16:26:27.7900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (600, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'16:35:44.3070000' AS Time))
GO
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (601, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'16:54:55.8570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (602, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'17:03:05.8870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (603, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'17:06:58.2630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (604, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'17:35:54.3470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (605, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'17:43:52.1430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (606, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'17:48:02.2830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (607, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'18:01:36.9900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (608, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'18:12:17.2270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (609, N'phani', CAST(N'2019-01-29' AS Date), CAST(N'18:27:45.9000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (610, N'PHANI', CAST(N'2019-01-29' AS Date), CAST(N'23:30:26.7370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (611, N'PHANI', CAST(N'2019-01-29' AS Date), CAST(N'23:31:16.4700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (612, N'phani', CAST(N'2019-01-30' AS Date), CAST(N'00:28:19.7770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (613, N'phani', CAST(N'2019-01-30' AS Date), CAST(N'00:48:37.7330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (614, N'phani', CAST(N'2019-01-30' AS Date), CAST(N'01:13:22.7230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (615, N'phani', CAST(N'2019-01-30' AS Date), CAST(N'01:14:09.4270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (616, N'PHANI', CAST(N'2019-01-30' AS Date), CAST(N'09:40:39.6700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (617, N'phani', CAST(N'2019-01-30' AS Date), CAST(N'10:10:04.1130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (618, N'phani', CAST(N'2019-01-30' AS Date), CAST(N'11:33:53.8730000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (619, N'phani', CAST(N'2019-01-30' AS Date), CAST(N'11:53:31.5000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (620, N'phani', CAST(N'2019-01-30' AS Date), CAST(N'11:58:06.7830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (621, N'phani', CAST(N'2019-01-30' AS Date), CAST(N'12:17:00.0200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (622, N'phani', CAST(N'2019-01-30' AS Date), CAST(N'12:24:05.7400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (623, N'phani', CAST(N'2019-01-30' AS Date), CAST(N'12:55:55.5100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (624, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'09:42:29.7470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (625, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'09:54:10.3930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (626, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'09:59:45.7030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (627, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'10:12:28.6600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (628, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'11:07:10.6500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (629, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'11:16:17.3030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (630, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'11:27:53.8600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (631, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'12:04:02.7070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (632, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'12:12:24.1630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (633, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'12:13:47.0500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (634, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'12:15:02.4330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (635, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'12:16:54.2300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (636, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'12:22:29.2830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (637, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'12:35:37.4530000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (638, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'12:55:47.5070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (639, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'13:03:02.6270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (640, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'13:17:43.6630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (641, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'13:51:42.5400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (642, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'14:29:38.5100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (643, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'14:39:50.8300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (644, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'14:47:13.2100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (645, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'14:51:37.8300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (646, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'15:05:08.5330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (647, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'15:09:48.3370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (648, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'15:17:26.2500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (649, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'15:31:24.0300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (650, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'15:35:44.9800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (651, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'15:47:27.2770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (652, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'15:56:36.4000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (653, N'phani', CAST(N'2019-01-31' AS Date), CAST(N'16:22:29.9800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (654, N'phani', CAST(N'2019-02-06' AS Date), CAST(N'11:57:51.2800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (655, N'phani', CAST(N'2019-02-06' AS Date), CAST(N'12:04:26.3070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (656, N'phani', CAST(N'2019-02-06' AS Date), CAST(N'12:08:24.4000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (657, N'phani', CAST(N'2019-02-06' AS Date), CAST(N'12:12:18.9100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (658, N'phani', CAST(N'2019-02-06' AS Date), CAST(N'12:20:16.8500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (659, N'phani', CAST(N'2019-02-06' AS Date), CAST(N'12:49:54.6070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (660, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'09:38:43.4430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (661, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'10:39:59.5430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (662, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'10:59:21.6030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (663, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'11:03:55.8600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (664, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'11:50:01.5970000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (665, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'11:53:56.2170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (666, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'12:13:47.3130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (667, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'12:18:02.8970000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (668, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'12:48:50.1600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (669, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'13:13:15.4370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (670, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'14:16:54.3870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (671, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'14:21:18.0470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (672, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'14:27:49.3400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (673, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'15:05:28.0630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (674, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'15:55:04.9870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (675, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'15:57:37.1030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (676, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'17:12:28.5270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (677, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'18:24:46.3330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (678, N'phani', CAST(N'2019-02-07' AS Date), CAST(N'18:54:19.9130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (679, N'phani', CAST(N'2019-02-12' AS Date), CAST(N'11:42:14.6370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (680, N'phani', CAST(N'2019-02-12' AS Date), CAST(N'12:37:23.1600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (681, N'phani', CAST(N'2019-02-12' AS Date), CAST(N'13:38:25.3500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (682, N'phani', CAST(N'2019-02-12' AS Date), CAST(N'14:11:49.3200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (683, N'phani', CAST(N'2019-02-12' AS Date), CAST(N'15:09:42.2030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (684, N'phani', CAST(N'2019-02-12' AS Date), CAST(N'18:14:55.2470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (685, N'phani', CAST(N'2019-02-12' AS Date), CAST(N'21:07:17.7830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (686, N'phani', CAST(N'2019-02-12' AS Date), CAST(N'21:13:03.2130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (687, N'PHANI', CAST(N'2019-02-13' AS Date), CAST(N'09:28:18.5430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (688, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'10:06:28.3300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (689, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'10:28:49.1930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (690, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'10:37:23.7430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (691, N'PHANI', CAST(N'2019-02-13' AS Date), CAST(N'11:04:14.3770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (692, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'11:21:14.7630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (693, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'12:11:58.2070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (694, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'12:15:52.6700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (695, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'12:18:09.9130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (696, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'12:23:15.8800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (697, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'12:24:54.0670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (698, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'12:32:49.7900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (699, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'13:16:56.6130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (700, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'13:21:35.9830000' AS Time))
GO
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (701, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'13:32:31.9670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (702, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'13:53:00.7230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (703, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'14:38:59.1700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (704, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'14:48:18.9130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (705, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'14:50:57.0630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (706, N'phani', CAST(N'2019-02-13' AS Date), CAST(N'16:33:04.7800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (707, N'phani', CAST(N'2019-02-18' AS Date), CAST(N'09:55:26.6430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (708, N'phani', CAST(N'2019-02-20' AS Date), CAST(N'11:56:24.3470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (709, N'phani', CAST(N'2019-02-20' AS Date), CAST(N'12:40:52.7170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (710, N'phani', CAST(N'2019-02-20' AS Date), CAST(N'14:40:27.1130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (711, N'phani', CAST(N'2019-02-20' AS Date), CAST(N'15:21:01.2800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (712, N'phani', CAST(N'2019-02-20' AS Date), CAST(N'15:45:17.5270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (713, N'phani', CAST(N'2019-02-20' AS Date), CAST(N'16:32:46.3630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (714, N'phani', CAST(N'2019-02-20' AS Date), CAST(N'16:41:34.0570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (715, N'phani', CAST(N'2019-02-20' AS Date), CAST(N'17:00:10.9800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (716, N'phani', CAST(N'2019-02-20' AS Date), CAST(N'17:13:30.1070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (717, N'phani', CAST(N'2019-02-20' AS Date), CAST(N'17:19:08.9600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (718, N'Phani', CAST(N'2019-02-20' AS Date), CAST(N'22:49:07.2800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (719, N'phani', CAST(N'2019-02-20' AS Date), CAST(N'23:53:58.9170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (720, N'PHANI', CAST(N'2019-02-21' AS Date), CAST(N'10:02:28.9600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (721, N'phani', CAST(N'2019-02-21' AS Date), CAST(N'10:27:27.9100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (722, N'phani', CAST(N'2019-02-21' AS Date), CAST(N'10:36:15.8030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (723, N'phani', CAST(N'2019-02-21' AS Date), CAST(N'10:40:13.2400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (724, N'phani', CAST(N'2019-02-21' AS Date), CAST(N'11:36:46.6830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (725, N'PHANI', CAST(N'2019-02-21' AS Date), CAST(N'13:46:13.7070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (726, N'phani', CAST(N'2019-02-21' AS Date), CAST(N'14:04:40.3070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (727, N'phani', CAST(N'2019-02-21' AS Date), CAST(N'14:06:53.9400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (728, N'phani', CAST(N'2019-02-21' AS Date), CAST(N'14:31:25.4900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (729, N'phani', CAST(N'2019-02-21' AS Date), CAST(N'14:59:35.4070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (730, N'phani', CAST(N'2019-02-21' AS Date), CAST(N'15:25:59.2530000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (731, N'phani', CAST(N'2019-02-21' AS Date), CAST(N'15:39:11.2130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (732, N'phani', CAST(N'2019-02-21' AS Date), CAST(N'16:29:54.7100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (733, N'phani', CAST(N'2019-02-21' AS Date), CAST(N'17:08:57.2270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (734, N'PHANI', CAST(N'2019-02-22' AS Date), CAST(N'10:50:17.0870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (735, N'phani', CAST(N'2019-02-22' AS Date), CAST(N'11:56:45.5500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (736, N'phani', CAST(N'2019-02-22' AS Date), CAST(N'12:50:37.0770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (737, N'phani', CAST(N'2019-02-22' AS Date), CAST(N'12:53:24.3400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (738, N'phani', CAST(N'2019-02-22' AS Date), CAST(N'13:53:38.0400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (739, N'phani', CAST(N'2019-02-22' AS Date), CAST(N'15:34:51.8700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (740, N'phani', CAST(N'2019-02-22' AS Date), CAST(N'16:01:47.1970000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (741, N'phani', CAST(N'2019-02-22' AS Date), CAST(N'16:18:58.5530000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (742, N'phani', CAST(N'2019-02-22' AS Date), CAST(N'16:29:26.3370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (743, N'phani', CAST(N'2019-02-22' AS Date), CAST(N'16:33:27.6970000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (744, N'phani', CAST(N'2019-02-25' AS Date), CAST(N'10:19:03.8800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (745, N'phani', CAST(N'2019-02-25' AS Date), CAST(N'10:31:16.1330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (746, N'phani', CAST(N'2019-02-25' AS Date), CAST(N'11:11:08.1800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (747, N'phani', CAST(N'2019-02-25' AS Date), CAST(N'11:29:36.2100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (748, N'phani', CAST(N'2019-02-25' AS Date), CAST(N'16:52:47.4600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (749, N'phani', CAST(N'2019-02-25' AS Date), CAST(N'16:54:45.4700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (750, N'phani', CAST(N'2019-02-25' AS Date), CAST(N'17:30:52.5100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (751, N'phani', CAST(N'2019-02-25' AS Date), CAST(N'17:37:11.3170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (752, N'phani', CAST(N'2019-02-25' AS Date), CAST(N'17:53:06.9000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (753, N'phani', CAST(N'2019-02-25' AS Date), CAST(N'19:06:03.5400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (754, N'phani', CAST(N'2019-02-25' AS Date), CAST(N'19:35:50.0530000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (755, N'phani', CAST(N'2019-02-25' AS Date), CAST(N'19:40:06.3700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (756, N'phani', CAST(N'2019-02-25' AS Date), CAST(N'19:44:00.8300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (757, N'phani', CAST(N'2019-02-25' AS Date), CAST(N'19:46:14.1500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (758, N'phani', CAST(N'2019-02-25' AS Date), CAST(N'20:08:22.6400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (759, N'PHANI', CAST(N'2019-02-26' AS Date), CAST(N'11:44:47.1170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (760, N'phani', CAST(N'2019-02-26' AS Date), CAST(N'12:04:01.8500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (761, N'phani', CAST(N'2019-02-26' AS Date), CAST(N'12:21:46.5730000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (762, N'phani', CAST(N'2019-02-26' AS Date), CAST(N'12:30:12.4470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (763, N'phani', CAST(N'2019-02-26' AS Date), CAST(N'14:00:34.9370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (764, N'phani', CAST(N'2019-02-26' AS Date), CAST(N'15:01:22.9100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (765, N'phani', CAST(N'2019-02-26' AS Date), CAST(N'15:08:28.1300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (766, N'phani', CAST(N'2019-02-26' AS Date), CAST(N'15:21:41.9630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (767, N'phani', CAST(N'2019-02-26' AS Date), CAST(N'15:25:37.8630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (768, N'phani', CAST(N'2019-02-26' AS Date), CAST(N'15:29:13.5470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (769, N'phani', CAST(N'2019-02-26' AS Date), CAST(N'15:35:11.9370000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (770, N'phani', CAST(N'2019-02-26' AS Date), CAST(N'15:38:19.4870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (771, N'phani', CAST(N'2019-02-26' AS Date), CAST(N'15:41:22.1500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (772, N'phani', CAST(N'2019-02-26' AS Date), CAST(N'16:55:20.3230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (773, N'phani', CAST(N'2019-02-28' AS Date), CAST(N'11:52:34.1130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (774, N'phani', CAST(N'2019-02-28' AS Date), CAST(N'13:13:20.0530000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (775, N'phani', CAST(N'2019-02-28' AS Date), CAST(N'20:47:48.7700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (776, N'phani', CAST(N'2019-02-28' AS Date), CAST(N'21:29:37.1100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (777, N'phani', CAST(N'2019-03-02' AS Date), CAST(N'12:40:28.6700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (778, N'phani', CAST(N'2019-03-03' AS Date), CAST(N'10:10:23.5170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (779, N'phani', CAST(N'2019-03-03' AS Date), CAST(N'10:37:01.3170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (780, N'phani', CAST(N'2019-03-03' AS Date), CAST(N'10:55:48.6300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (781, N'phani', CAST(N'2019-03-03' AS Date), CAST(N'11:15:25.5800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (782, N'phani', CAST(N'2019-03-03' AS Date), CAST(N'11:26:34.3100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (783, N'phani', CAST(N'2019-03-04' AS Date), CAST(N'12:07:53.6700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (784, N'phani', CAST(N'2019-03-04' AS Date), CAST(N'16:15:29.5870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (785, N'phani', CAST(N'2019-03-04' AS Date), CAST(N'16:29:46.4400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (786, N'phani', CAST(N'2019-03-04' AS Date), CAST(N'16:32:11.0870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (787, N'phani', CAST(N'2019-03-04' AS Date), CAST(N'16:57:28.1200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (788, N'phani', CAST(N'2019-03-06' AS Date), CAST(N'11:07:24.2130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (789, N'phani', CAST(N'2019-03-06' AS Date), CAST(N'12:01:02.3300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (790, N'PHANI', CAST(N'2019-03-08' AS Date), CAST(N'15:15:01.3200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (791, N'PHANI', CAST(N'2019-03-08' AS Date), CAST(N'15:17:01.4100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (792, N'phani', CAST(N'2019-03-12' AS Date), CAST(N'14:05:51.3400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (793, N'phani', CAST(N'2019-03-12' AS Date), CAST(N'14:20:39.0900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (794, N'ramesh', CAST(N'2019-03-12' AS Date), CAST(N'14:38:14.3830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (795, N'phani', CAST(N'2019-03-12' AS Date), CAST(N'14:54:46.1770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (796, N'ramesh', CAST(N'2019-03-12' AS Date), CAST(N'14:57:19.2130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (797, N'phani', CAST(N'2019-03-14' AS Date), CAST(N'18:14:45.6030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (798, N'phani', CAST(N'2019-03-14' AS Date), CAST(N'18:17:00.1700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (799, N'phani', CAST(N'2019-03-14' AS Date), CAST(N'18:29:17.1300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (800, N'phani', CAST(N'2019-03-14' AS Date), CAST(N'19:23:29.3500000' AS Time))
GO
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (801, N'PHANI', CAST(N'2019-03-15' AS Date), CAST(N'11:22:00.3900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (802, N'phani', CAST(N'2019-03-15' AS Date), CAST(N'12:07:06.6100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (803, N'phani', CAST(N'2019-03-15' AS Date), CAST(N'12:16:24.7300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (804, N'phani', CAST(N'2019-03-15' AS Date), CAST(N'12:32:44.5430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (805, N'phani', CAST(N'2019-03-15' AS Date), CAST(N'12:32:54.8900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (806, N'phani', CAST(N'2019-03-15' AS Date), CAST(N'14:23:22.2130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (807, N'phani', CAST(N'2019-03-17' AS Date), CAST(N'21:44:58.3000000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (808, N'phani', CAST(N'2019-03-17' AS Date), CAST(N'22:27:31.8770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (809, N'phani', CAST(N'2019-03-17' AS Date), CAST(N'22:31:10.9100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (810, N'phani', CAST(N'2019-03-17' AS Date), CAST(N'22:45:57.1570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (811, N'phani', CAST(N'2019-03-17' AS Date), CAST(N'23:27:15.2900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (812, N'phani', CAST(N'2019-03-17' AS Date), CAST(N'23:52:56.5330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (813, N'phani', CAST(N'2019-03-18' AS Date), CAST(N'01:18:03.6570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (814, N'phani', CAST(N'2019-03-18' AS Date), CAST(N'01:44:36.0530000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (815, N'phani', CAST(N'2019-03-18' AS Date), CAST(N'01:54:30.2700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (816, N'phani', CAST(N'2019-03-18' AS Date), CAST(N'12:56:27.9700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (817, N'phani', CAST(N'2019-03-18' AS Date), CAST(N'13:24:50.1730000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (818, N'phani', CAST(N'2019-03-18' AS Date), CAST(N'13:35:32.6270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (819, N'PHANI', CAST(N'2019-03-19' AS Date), CAST(N'21:29:57.7970000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (820, N'phani', CAST(N'2019-03-20' AS Date), CAST(N'11:52:32.5030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (821, N'phani', CAST(N'2019-03-20' AS Date), CAST(N'12:42:51.6670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (822, N'phani', CAST(N'2019-03-20' AS Date), CAST(N'13:00:56.5630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (823, N'phani', CAST(N'2019-03-20' AS Date), CAST(N'13:11:12.1700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (824, N'phani', CAST(N'2019-03-20' AS Date), CAST(N'13:17:31.6500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (825, N'phani', CAST(N'2019-03-20' AS Date), CAST(N'13:31:50.8330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (826, N'phani', CAST(N'2019-03-20' AS Date), CAST(N'13:45:59.2630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (827, N'phani', CAST(N'2019-03-20' AS Date), CAST(N'14:46:57.1100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (828, N'phani', CAST(N'2019-03-20' AS Date), CAST(N'15:57:43.6270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (829, N'phani', CAST(N'2019-03-20' AS Date), CAST(N'16:39:02.2870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (830, N'phani', CAST(N'2019-03-21' AS Date), CAST(N'11:21:18.0170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (831, N'phani', CAST(N'2019-03-21' AS Date), CAST(N'13:38:54.3030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (832, N'phani', CAST(N'2019-03-22' AS Date), CAST(N'12:15:26.8100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (833, N'phani', CAST(N'2019-03-22' AS Date), CAST(N'12:23:15.3500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (834, N'phani', CAST(N'2019-03-22' AS Date), CAST(N'12:51:15.9570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (835, N'phani', CAST(N'2019-03-22' AS Date), CAST(N'13:13:14.9930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (836, N'PHANI', CAST(N'2019-03-23' AS Date), CAST(N'10:18:51.2300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (837, N'PHANI', CAST(N'2019-03-23' AS Date), CAST(N'13:08:28.7900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (838, N'PHANI', CAST(N'2019-03-23' AS Date), CAST(N'13:37:14.3570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (839, N'PHANI', CAST(N'2019-03-23' AS Date), CAST(N'13:56:38.0170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (840, N'PHANI', CAST(N'2019-03-23' AS Date), CAST(N'14:08:00.3070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (841, N'phani', CAST(N'2019-03-23' AS Date), CAST(N'14:21:55.9500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (842, N'PHANI', CAST(N'2019-03-23' AS Date), CAST(N'14:28:06.3100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (843, N'phani', CAST(N'2019-03-23' AS Date), CAST(N'14:34:05.4800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (844, N'PHANI', CAST(N'2019-03-23' AS Date), CAST(N'14:56:31.1700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (845, N'PHANI', CAST(N'2019-03-23' AS Date), CAST(N'15:20:56.3500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (846, N'phani', CAST(N'2019-03-23' AS Date), CAST(N'15:52:29.4830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (847, N'PHANI', CAST(N'2019-03-23' AS Date), CAST(N'15:54:09.5100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (848, N'PHANI', CAST(N'2019-03-23' AS Date), CAST(N'16:00:58.0170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (849, N'phani', CAST(N'2019-03-24' AS Date), CAST(N'10:44:35.9170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (850, N'phani', CAST(N'2019-03-24' AS Date), CAST(N'11:00:25.7630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (851, N'phani', CAST(N'2019-03-24' AS Date), CAST(N'12:34:19.0400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (852, N'phani', CAST(N'2019-03-24' AS Date), CAST(N'14:05:04.4100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (853, N'phani', CAST(N'2019-03-24' AS Date), CAST(N'14:18:22.9730000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (854, N'phani', CAST(N'2019-03-24' AS Date), CAST(N'14:55:15.9770000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (855, N'phani', CAST(N'2019-03-24' AS Date), CAST(N'15:15:46.0100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (856, N'phani', CAST(N'2019-03-24' AS Date), CAST(N'15:23:41.4800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (857, N'phani', CAST(N'2019-03-24' AS Date), CAST(N'15:48:48.6930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (858, N'phani', CAST(N'2019-03-25' AS Date), CAST(N'21:36:34.8870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (859, N'PHANI', CAST(N'2019-03-26' AS Date), CAST(N'12:52:26.7500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (860, N'PHANI', CAST(N'2019-03-30' AS Date), CAST(N'18:47:40.5570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (861, N'phani', CAST(N'2019-03-30' AS Date), CAST(N'19:22:43.0730000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (862, N'phani', CAST(N'2019-03-30' AS Date), CAST(N'19:34:39.2500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (863, N'phani', CAST(N'2019-03-30' AS Date), CAST(N'19:56:32.9870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (864, N'phani', CAST(N'2019-03-31' AS Date), CAST(N'09:14:29.1200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (865, N'phani', CAST(N'2019-03-31' AS Date), CAST(N'11:12:43.5730000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (866, N'phani', CAST(N'2019-03-31' AS Date), CAST(N'11:16:53.7070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (867, N'PHANI', CAST(N'2019-03-31' AS Date), CAST(N'13:09:59.8900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (868, N'PHANI', CAST(N'2019-03-31' AS Date), CAST(N'13:31:54.5700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (869, N'PHANI', CAST(N'2019-03-31' AS Date), CAST(N'13:37:28.0470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (870, N'PHANI', CAST(N'2019-03-31' AS Date), CAST(N'14:02:36.2470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (871, N'SATISH', CAST(N'2019-03-31' AS Date), CAST(N'14:06:28.6970000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (872, N'PHANI', CAST(N'2019-03-31' AS Date), CAST(N'19:12:05.3830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (873, N'phani', CAST(N'2019-03-31' AS Date), CAST(N'19:38:06.1670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (874, N'phani', CAST(N'2019-03-31' AS Date), CAST(N'19:59:48.1200000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (875, N'phani', CAST(N'2019-03-31' AS Date), CAST(N'20:02:21.3830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (876, N'phani', CAST(N'2019-03-31' AS Date), CAST(N'20:22:34.6300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (877, N'phani', CAST(N'2019-03-31' AS Date), CAST(N'21:00:56.7100000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (878, N'phani', CAST(N'2019-03-31' AS Date), CAST(N'21:36:56.2270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (879, N'phani', CAST(N'2019-03-31' AS Date), CAST(N'21:51:00.2630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (880, N'phani', CAST(N'2019-04-01' AS Date), CAST(N'12:11:42.8730000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (881, N'phani', CAST(N'2019-04-01' AS Date), CAST(N'12:52:02.4400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (882, N'PHANI', CAST(N'2019-04-01' AS Date), CAST(N'14:45:28.5170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (883, N'nidhiachari', CAST(N'2019-04-01' AS Date), CAST(N'15:19:32.3730000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (884, N'phani', CAST(N'2019-04-01' AS Date), CAST(N'15:20:32.7400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (885, N'nidhiachari', CAST(N'2019-04-01' AS Date), CAST(N'15:21:20.0330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (886, N'phani', CAST(N'2019-04-01' AS Date), CAST(N'15:22:06.3800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (887, N'nidhiachari', CAST(N'2019-04-01' AS Date), CAST(N'15:24:19.0970000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (888, N'phani', CAST(N'2019-04-01' AS Date), CAST(N'15:26:04.8930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (889, N'nidhiachari', CAST(N'2019-04-01' AS Date), CAST(N'15:29:40.7870000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (890, N'phani', CAST(N'2019-04-01' AS Date), CAST(N'15:40:01.4600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (891, N'phani', CAST(N'2019-04-01' AS Date), CAST(N'16:30:52.3700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (892, N'phani', CAST(N'2019-04-02' AS Date), CAST(N'11:41:24.1830000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (893, N'phani', CAST(N'2019-04-02' AS Date), CAST(N'12:42:37.5300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (894, N'phani', CAST(N'2019-04-02' AS Date), CAST(N'12:44:07.0670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (895, N'phani', CAST(N'2019-04-02' AS Date), CAST(N'12:45:07.4700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (896, N'phani', CAST(N'2019-04-02' AS Date), CAST(N'12:53:51.8800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (897, N'phani', CAST(N'2019-04-02' AS Date), CAST(N'12:57:59.6970000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (898, N'phani', CAST(N'2019-04-02' AS Date), CAST(N'13:03:31.0800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (899, N'nidhiachari', CAST(N'2019-04-02' AS Date), CAST(N'13:04:42.0570000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (900, N'phani', CAST(N'2019-04-02' AS Date), CAST(N'13:04:54.5200000' AS Time))
GO
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (901, N'nidhiachari', CAST(N'2019-04-02' AS Date), CAST(N'13:06:01.3130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (902, N'phani', CAST(N'2019-04-02' AS Date), CAST(N'13:11:48.3030000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (903, N'nidhiachari', CAST(N'2019-04-02' AS Date), CAST(N'13:12:06.2330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (904, N'nidhiachari', CAST(N'2019-04-02' AS Date), CAST(N'13:24:27.1900000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (905, N'phani', CAST(N'2019-04-02' AS Date), CAST(N'13:32:22.8500000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (906, N'phani', CAST(N'2019-04-05' AS Date), CAST(N'10:48:50.2470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (907, N'phani', CAST(N'2019-04-05' AS Date), CAST(N'10:50:09.9330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (908, N'phani', CAST(N'2019-04-05' AS Date), CAST(N'10:55:03.1230000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (909, N'phani', CAST(N'2019-04-05' AS Date), CAST(N'11:07:33.7700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (910, N'phani', CAST(N'2019-04-05' AS Date), CAST(N'11:26:05.9170000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (911, N'phani', CAST(N'2019-04-05' AS Date), CAST(N'11:41:12.1600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (912, N'phani', CAST(N'2019-04-05' AS Date), CAST(N'11:49:18.9700000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (913, N'nidhi', CAST(N'2019-04-05' AS Date), CAST(N'11:51:16.7470000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (914, N'nidhi', CAST(N'2019-04-05' AS Date), CAST(N'11:53:11.9430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (915, N'phani', CAST(N'2019-04-05' AS Date), CAST(N'11:58:51.9970000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (916, N'phani', CAST(N'2019-04-05' AS Date), CAST(N'12:00:23.2270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (917, N'phani', CAST(N'2019-04-05' AS Date), CAST(N'12:09:01.0400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (918, N'phani', CAST(N'2019-04-05' AS Date), CAST(N'12:10:28.4630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (919, N'phani', CAST(N'2019-04-05' AS Date), CAST(N'12:13:01.4300000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (920, N'nidhi', CAST(N'2019-04-05' AS Date), CAST(N'12:13:48.2330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (921, N'phani', CAST(N'2019-04-05' AS Date), CAST(N'13:02:08.9800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (922, N'nidhi', CAST(N'2019-04-05' AS Date), CAST(N'13:46:09.5130000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (923, N'nidhi', CAST(N'2019-04-05' AS Date), CAST(N'14:42:23.3930000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (924, N'Nidhi', CAST(N'2019-04-05' AS Date), CAST(N'14:50:47.6800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (925, N'nidhi', CAST(N'2019-04-05' AS Date), CAST(N'15:11:23.1330000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (926, N'Nidhi', CAST(N'2019-04-05' AS Date), CAST(N'15:17:42.0430000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (927, N'Phani', CAST(N'2019-04-05' AS Date), CAST(N'15:18:59.3800000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (928, N'nidhi', CAST(N'2019-04-05' AS Date), CAST(N'15:28:27.4600000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (929, N'nidhi', CAST(N'2019-04-05' AS Date), CAST(N'15:50:41.1070000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (930, N'nidhi', CAST(N'2019-04-05' AS Date), CAST(N'16:14:46.8630000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (931, N'nidhi', CAST(N'2019-04-05' AS Date), CAST(N'16:21:12.7670000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (932, N'nidhi', CAST(N'2019-04-05' AS Date), CAST(N'16:28:42.7270000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (933, N'Phani', CAST(N'2019-04-05' AS Date), CAST(N'16:40:03.3400000' AS Time))
INSERT [dbo].[Login_Log_Details] ([LOGID], [USERNAME], [DATE], [TIME]) VALUES (934, N'nidhi', CAST(N'2019-04-05' AS Date), CAST(N'17:19:10.0670000' AS Time))
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (1, N'EX-3120015001', 3, 30, 3000, 1, N'POLYAMIDE CONNECTION ROD 3m BAR', 5, 1, 1, 1, NULL, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (2, N'EX-6603602000', 2, 1, 0, 4, N'EX-6603602000', 0, 1, 1, 1, NULL, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (3, N'Windows', 1, 1, 0, 4, N'Winodws', 0, 1, 1, 1, NULL, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (4, N'M11454', 3, 1, 6000, 2, N'GLAZING BEAD', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (5, N'M15008', 3, 1, 6, 2, N'HINGED FRAME', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (6, N'M15060', 3, 1, 6, 2, N'HINGED "T" SYSTEM PROFILE', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (7, N'M15082', 3, 1, 6, 2, N'HINGED "T" SYSTEM PROFILE (Article on Request only)', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (8, N'M15157', 3, 1, 6, 2, N'HINGED ADDITIONAL PROFILE', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (9, N'EX-3805050002', 1, 2, 0, 4, N'CLOSING HANDLE FOR SMALL WINDOWS', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (10, N'EX-4000197100', 1, 20, 0, 4, N'SHIM FOR 14/18 FRAMES FOR PROJECTING-OUT WINDOW STAY ARMS', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (11, N'EX-4008349000', 1, 1, 0, 4, N'"TOP HUNG ARM 10" EUROPEAN GROOVE"', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (12, N'EX-1132341600', 2, 40, 0, 4, N'CRIMP CORNER CLEAT 23x42mm', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (14, N'EX-1252340000', 2, 40, 0, 4, N'MECHANICAL CORNER CLEAT 23x39,8mm', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (15, N'EX-1601121391', 2, 20, 0, 4, N'T-CLEAT INSIDE 13,2mm INOX SCREW', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (16, N'EX-1601123391', 2, 20, 0, 4, N'T-CLEAT INSIDE 33,2mm INOX SCREW', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (19, N'EX-1801500400', 2, 250, 0, 4, N'ALIGNMENT CORNER ?15000', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (20, N'EX-1801500700', 2, 40, 0, 4, N'ALIGNMENT CORNER LARGE ?15000', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (21, N'EX-1801900001', 2, 40, 0, 4, N'ALIGNMENT CORNER THIN', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (22, N'EX-1802501000', 2, 40, 0, 4, N'ALIGNMENT CORNER 11 25 10 11000', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (23, N'EX-2551500001', 2, 160, 0, 4, N'VULCANIZED CORNER FOR M15000 CENT GASKET EPDM', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (24, N'EX-2900000500', 2, 100, 0, 4, N'SETTING BLOCK 5mm', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (27, N'EX-4701183900', 2, 100, 0, 4, N'NAIL CORNER PIN 4,5x7,1', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (32, N'M8982934', 3, 30, 6, 4, N'ALIGNMENT CORNER LARGE ?15000', 0, 1, 1, 0, CAST(25000.00 AS Decimal(18, 2)), 1, 1, CAST(10.00 AS Decimal(18, 2)), 3, 1, 1)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (33, N'EX-274973294', 2, 40, 0, 4, N'adfadf', 0, 1, 1, 0, CAST(1000.00 AS Decimal(18, 2)), 1, 1, CAST(12.00 AS Decimal(18, 2)), 3, 1, 1)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (34, N'gu868786', 2, 100, 0, 4, N'adsfd', 0, 1, 1, 0, CAST(1000.00 AS Decimal(18, 2)), 1, 1, CAST(12.00 AS Decimal(18, 2)), 3, 1, 1)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (13, N'EX-1251346400', 2, 40, 0, 4, N'MECHANICAL CORNER CLEAT 13x46,4mm', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (17, N'EX-1601181391', 2, 20, 0, 4, N'T-CLEAT OUTSIDE 13,2mm INOX SCREW', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (18, N'EX-1601183391', 2, 20, 0, 4, N'T-CLEAT OUTSIDE 33,2mm INOX SCREW', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (28, N'EX-2000686001', 4, 200, 0, 2, N'OUTSIDE GLAZING GASKET PLUGGED 3mm EPDM', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (30, N'EX-2101500001', 4, 120, 0, 2, N'CENT GASKET M15000 EPDM', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (35, N'8055', 2, 300, 22, 1, N'-', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, 1, CAST(0.00 AS Decimal(18, 2)), 1, 1, 1)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (25, N'EX-3101150102', 2, 10, 0, 4, N'WATER EVACUATION CAP ROUND', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (26, N'EX-4701183500', 2, 100, 0, 4, N'"PIN NAIL FOR "T" PROFILES 6mm"', 0, 1, 1, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (29, N'EX-2000800601', 4, 100, 0, 2, N'GLAZING GASKET 6mm EPDM', 0, 1, 0, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (31, N'EX-2201500101', 4, 300, 0, 2, N'SEAL GASKET 5mm EPDM', 0, 1, 0, 0, CAST(0.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (36, N'234234324', 2, 1, 223, 1, N'ALIGNMENT CORNER THIN', 0, 1, 1, 3, CAST(23.00 AS Decimal(18, 2)), 1, 1, CAST(23.00 AS Decimal(18, 2)), 2, 1, 1)
INSERT [dbo].[Material_Master] ([Material_Id], [Material_Code], [Category_Id], [Box_Size], [Bar_Length], [UOM_Id], [Description], [Weight], [Plant_Id], [Storage_Location_Id], [Item_Group], [SellingPrice], [Series], [Cp_Id], [BuyingPrice], [BuyingCurrency], [Brand_Id], [SellingCurrency]) VALUES (37, N'805585', 3, 1, 25, 2, N'x', 12, 1, 1, 1, CAST(35000.00 AS Decimal(18, 2)), 1, 1, CAST(45000.00 AS Decimal(18, 2)), 1, 1, 1)
INSERT [dbo].[Material_Master2] ([Material_Id], [Material_Code], [Uom_Id], [MaterialGroup_Id], [OldMaterial_Number], [Gross_Weight], [Weight_Unit], [Net_Weight], [Size_Dimensions], [PackingMaterial_Id], [Material_Status_Id], [Material_Name], [MaterialType_Id], [Material_Drawings], [Color_Id], [MRP], [SSP], [HSN], [Item_Description]) VALUES (1, N'0001', 1, 1, N'0001', CAST(0.300 AS Decimal(18, 3)), 1, CAST(0.300 AS Decimal(18, 3)), N'12*10', 1, 1, N'Testing', 1, NULL, 1, CAST(12000.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[Material_Type] ([MaterialType_Id], [Material_Type], [Material_Description]) VALUES (1, N'RawMaterial', N'RawMaterial')
INSERT [dbo].[Material_Type] ([MaterialType_Id], [Material_Type], [Material_Description]) VALUES (2, N'Semi-Finished', N'SFG')
INSERT [dbo].[Material_Type] ([MaterialType_Id], [Material_Type], [Material_Description]) VALUES (3, N'Product', N'Product')
INSERT [dbo].[MaterialGroup_Master] ([MaterialGroup_Id], [MaterialGroup], [MaterialGroup_Description]) VALUES (1, N'Aluminium', N'Aluminium')
INSERT [dbo].[MaterialGroup_Master] ([MaterialGroup_Id], [MaterialGroup], [MaterialGroup_Description]) VALUES (2, N'Rubber', N'Rubber')
INSERT [dbo].[PaymentTerms_Master] ([PaymentTerms_Id], [PaymentTerms], [PaymentTerms_Desc]) VALUES (1, N'Payment Terms:', N'&lt;div&gt;1. 75% advance,Balance 25% before dispatch.&lt;/div&gt;&lt;div&gt;For Payments through Cheque/DD/RTGS/NEFT, to be made in favour of:&lt;/div&gt;&lt;div&gt;ALUMIL BUILDMATE PVT LTD.&lt;/div&gt;&lt;div&gt;2. UCO Bank, Banjara hills Branch,&lt;/div&gt;&lt;div&gt;A/C No : 09790210004661&lt;/div&gt;&lt;div&gt;RTGS/IFSC No : UCBA0000979&lt;/div&gt;&lt;div&gt;3. Material will be dispatched only after all dues are closed.&lt;/div&gt;&lt;div&gt;4. Any additional job/finishing/extra work apart from the agreed drawings will be considered as a new order,processed separately.&lt;br&gt;&lt;/div&gt;')
INSERT [dbo].[Quatation_Changeables] ([QC_id], [Euro_Price], [Freight], [Customs], [Insurance], [Clearance], [Wastage], [WallPlugs], [Silicon], [Maskingtape], [BackorRod], [FabricationPerSft], [FabricationPerSqm], [InstallationPerSft], [InstallationPerSqm], [Margin], [Silicon_Width], [Silicon_Depth]) VALUES (1, CAST(85.00 AS Decimal(18, 2)), CAST(5.50 AS Decimal(18, 2)), CAST(11.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), CAST(180.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(538.20 AS Decimal(18, 2)), CAST(75.00 AS Decimal(18, 2)), CAST(807.30 AS Decimal(18, 2)), CAST(59.0 AS Decimal(18, 1)), CAST(6.00 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)))
INSERT [dbo].[Quotation_Master] ([Quotation_Id], [Quotation_No], [Quotation_Date], [Quotation_to], [Valid_To], [Enq_Id], [Cust_ID], [Unit_Id], [SalesEmp_Id], [PaymentTerms_Id], [TermsCondtions_Id], [Discount], [Tax], [GrandTotal], [PreparedBy], [ApprovedBy], [RevisedKey], [Status], [InstallationTemp_Id], [DamageTemp_Id], [StorageTemp_Id], [Specifications], [DesginerId], [Revised_date], [Aluminum_Color], [Hardware_Color], [Wind_Load]) VALUES (1, N'SQ-1/18-19', CAST(N'2019-04-05T00:00:00.000' AS DateTime), N'Enquiry', CAST(N'2019-04-20' AS Date), 1, 1, 1, 1, 1, 1, CAST(0.0 AS Decimal(18, 1)), CAST(18.0 AS Decimal(18, 1)), CAST(76142.00 AS Decimal(18, 2)), 2, 0, N'R0', N'New', 1, 1, 1, N'&lt;div&gt;&lt;b&gt;Note:&lt;/b&gt;&lt;/div&gt;&lt;div&gt;1. All profiles, Hardware and Accessories are imported. So, we cannot change the color after the confirmation.&lt;/div&gt;&lt;div&gt;&lt;b&gt;Not Included in the Price:&lt;/b&gt;&lt;/div&gt;&lt;div&gt;1. price quoted are Ex-factory, Hyderabad. Transportation charges from fabrication unit to site - At actuals on To-pay basis.&lt;/div&gt;&lt;div&gt;2. Unloading to be taken care by the client.&lt;/div&gt;&lt;div&gt;3. Installation charges separate.&lt;br&gt;&lt;/div&gt;', 2, CAST(N'2019-04-05' AS Date), N'Anodizing', N'Silver', N'1.5kpa')
INSERT [dbo].[Regional_Master] ([REG_ID], [REG_NAME], [REG_DESC]) VALUES (1, N'Hyderabad', N'-')
INSERT [dbo].[Regional_Master] ([REG_ID], [REG_NAME], [REG_DESC]) VALUES (2, N'Bangalore', N'-')
INSERT [dbo].[Regional_Master] ([REG_ID], [REG_NAME], [REG_DESC]) VALUES (3, N'Vijayawada', N'-')
INSERT [dbo].[Regional_Master] ([REG_ID], [REG_NAME], [REG_DESC]) VALUES (4, N'Karnool', N'-')
INSERT [dbo].[Sales_Damage_Template] ([Sales_Damage_Id], [Terms_Conditions_Name], [Descritpion]) VALUES (1, N'Damage:', N'&lt;ol&gt;&lt;li&gt;&#160;Any breakage and damage before and during installation by Alumil team are the responsibility of Alumil.&lt;/li&gt;&lt;li&gt;In case damages are small items, replacement would be within 15 days and in case of large/special items it will be 99 days approx.&lt;br&gt;&lt;/li&gt;&lt;/ol&gt;')
INSERT [dbo].[Sales_Quatation_CalcChange] ([QuatationChang_Id], [Quatation_Id], [Euro_Price], [Freight], [Customs], [Insurance], [Clearance], [Wastage], [WallPlugs], [Silicon], [Maskingtape], [BackorRod], [FabricationPerSft], [FabricationPerSqm], [InstallationPerSft], [InstallationPerSqm], [Margin], [Silicon_Width], [Silicon_Depth]) VALUES (1, 1, CAST(85.00 AS Decimal(18, 2)), CAST(5.50 AS Decimal(18, 2)), CAST(11.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), CAST(180.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(538.20 AS Decimal(18, 2)), CAST(75.00 AS Decimal(18, 2)), CAST(807.30 AS Decimal(18, 2)), CAST(59.0 AS Decimal(18, 1)), CAST(6.00 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)))
INSERT [dbo].[Sales_QuotationDetails] ([QuotationDet_id], [Quotation_Id], [WindowCode], [System], [Description], [Glass], [Location], [Mesh], [ProfileColor], [HardwareColor], [Width], [Height], [Qty], [TotalArea], [ProfileCostEuro], [GlassPrice], [MeshPrice], [RecractablePrice], [MSInsertPrice], [TotalAmount], [ExtraGlassWidth], [ExtraGlassHeight], [ExtraGlassQty], [ExtraGlassArea], [ExtraGlassPrice], [HardwarePrice], [Item_Image], [ElevationView]) VALUES (1, 1, N'Option - 1', N'M14600', N'2  track 4 shulter sliding door', N'24mm', N'-', N'No', N'Anodizing', N'Silver', 5296, 2808, 1, CAST(14.87 AS Decimal(18, 2)), CAST(250.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(64527.53 AS Decimal(18, 2)), 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, N'')
INSERT [dbo].[Sales_Storage_Template] ([Sales_Storage_Id], [Terms_Conditions_Name], [Descritpion]) VALUES (1, N'Storage:', N'&lt;ol&gt;&lt;li&gt;&#160;In the event of site not being ready for installation, all products will be stored in our warehouse for short term.&lt;/li&gt;&lt;li&gt;Storage facility will be free of charge for first 3 weeks upon arrival of material in storage warehouse and thereon Rs.10,000/- will be charged on weekly basis post free storage period.&lt;/li&gt;&lt;/ol&gt;')
INSERT [dbo].[Sales_TermsConditions] ([Sales_TC_Id], [Terms_Conditions_Name], [Descritpion]) VALUES (1, N'Order Finalization, Validity and Delivery:', N'&lt;ol&gt;&lt;li&gt;&#160;Client to check all details provided carefully before the finalizing the design/solution.&lt;/li&gt;&lt;li&gt;&#160;Any modifications/alterations to the design will have an impact on the techno commercials.&lt;/li&gt;&lt;li&gt;Once the quote and Drawings are finalized, no changes/alterations are possible.&lt;/li&gt;&lt;li&gt;The finalized drawings and quote will be signed by the client, a copy will be provided to the customer.&lt;/li&gt;&lt;li&gt;Price validity is 15 days from the date of our proposal.&lt;/li&gt;&lt;li&gt;Delivery with in 2 to 3 weeks from the date of advance.&lt;br&gt;&lt;/li&gt;&lt;/ol&gt;')
INSERT [dbo].[SalesEnquiry_Master] ([ENQ_ID], [ENQ_NO], [ENQ_DATE], [CUST_ID], [UNIT_ID], [SLAESINCHARGE_ID], [DESIGNINCHARGE_ID], [PREPAREDBY], [APPROVEDBY], [REVISEDKEY], [STATUS], [CONTACTBY_ID], [CONTACT_DATE], [TODISCUSS], [SPECIFICATIONS], [PRODUCT_REQURIED], [GLASSSPECIFICATION], [GLASSTHICKNESS], [GLASSCOLORCODE], [POWERCOATING], [ANODIZING], [WOODEFFECT], [ARCHIDRAWINGSATTACH], [SITEPHOTOSATTACH]) VALUES (1, N'ENQ-1/18-19', CAST(N'2019-04-05' AS Date), 1, 1, 1, 2, 2, 0, N'', N'Open', 1, CAST(N'2019-04-05' AS Date), N'-', N'', N'Sliding Wondows,Doors', N'-', N'-', N'-', N'No', N'Yes', N'No', N'No', N'No')
INSERT [dbo].[SalesEnquiry_Master] ([ENQ_ID], [ENQ_NO], [ENQ_DATE], [CUST_ID], [UNIT_ID], [SLAESINCHARGE_ID], [DESIGNINCHARGE_ID], [PREPAREDBY], [APPROVEDBY], [REVISEDKEY], [STATUS], [CONTACTBY_ID], [CONTACT_DATE], [TODISCUSS], [SPECIFICATIONS], [PRODUCT_REQURIED], [GLASSSPECIFICATION], [GLASSTHICKNESS], [GLASSCOLORCODE], [POWERCOATING], [ANODIZING], [WOODEFFECT], [ARCHIDRAWINGSATTACH], [SITEPHOTOSATTACH]) VALUES (2, N'ENQ-2/18-19', CAST(N'2019-04-05' AS Date), 2, 3, 1, 1, 2, 0, N'', N'New', 0, CAST(N'2019-04-05' AS Date), N'--', N'', N'Fixed Windows
Doors', N'--', N'--', N'--', N'No', N'No', N'No', N'No', N'No')
INSERT [dbo].[SalesEnquiry_Master] ([ENQ_ID], [ENQ_NO], [ENQ_DATE], [CUST_ID], [UNIT_ID], [SLAESINCHARGE_ID], [DESIGNINCHARGE_ID], [PREPAREDBY], [APPROVEDBY], [REVISEDKEY], [STATUS], [CONTACTBY_ID], [CONTACT_DATE], [TODISCUSS], [SPECIFICATIONS], [PRODUCT_REQURIED], [GLASSSPECIFICATION], [GLASSTHICKNESS], [GLASSCOLORCODE], [POWERCOATING], [ANODIZING], [WOODEFFECT], [ARCHIDRAWINGSATTACH], [SITEPHOTOSATTACH]) VALUES (3, N'ENQ-3/18-19', CAST(N'2019-04-05' AS Date), 3, 2, 1, 1, 2, 0, N'', N'New', 0, CAST(N'2019-04-05' AS Date), N'--', N'', N'Fixed Windows, Glass Doors and Sliding Windows.', N'DGU', N'--', N'--', N'No', N'Yes', N'No', N'Yes', N'No')
INSERT [dbo].[Salutation_Master] ([Salutation_id], [Salutation], [Sal_desc]) VALUES (1, N'Mr', N'Mr')
INSERT [dbo].[Salutation_Master] ([Salutation_id], [Salutation], [Sal_desc]) VALUES (2, N'Ms', N'Ms')
INSERT [dbo].[Salutation_Master] ([Salutation_id], [Salutation], [Sal_desc]) VALUES (3, N'M/s', N'M/s')
INSERT [dbo].[Salutation_Master] ([Salutation_id], [Salutation], [Sal_desc]) VALUES (4, N'Mrs', N'Mrs')
INSERT [dbo].[SoMat_FileName] ([FileName]) VALUES (N'MaterialAnalysisforSO.xlsx')
INSERT [dbo].[SoMat_FileName] ([FileName]) VALUES (N'MaterialAnalysisforSO.xlsx')
INSERT [dbo].[SoMat_FileName] ([FileName]) VALUES (N'MaterialAnalysisforSO.xlsx')
INSERT [dbo].[SoMat_FileName] ([FileName]) VALUES (N'MaterialAnalysisforSO.xlsx')
INSERT [dbo].[SoMat_FileName] ([FileName]) VALUES (N'download.png')
INSERT [dbo].[SoMat_FileName] ([FileName]) VALUES (N'download.png')
INSERT [dbo].[SoMat_FileName] ([FileName]) VALUES (N'MaterialAnalaysisFormat.xlsx')
INSERT [dbo].[State_Master] ([STATE_ID], [STATE_NAME], [COUNTRY_ID]) VALUES (1, N'Hyderabad', 0)
INSERT [dbo].[State_Master] ([STATE_ID], [STATE_NAME], [COUNTRY_ID]) VALUES (2, N'Andhra Pradesh', 1)
INSERT [dbo].[State_Master] ([STATE_ID], [STATE_NAME], [COUNTRY_ID]) VALUES (3, N'Tamilnadu', 1)
INSERT [dbo].[State_Master] ([STATE_ID], [STATE_NAME], [COUNTRY_ID]) VALUES (4, N'karnataka', 1)
INSERT [dbo].[State_Master] ([STATE_ID], [STATE_NAME], [COUNTRY_ID]) VALUES (5, N'Maharashtra', 1)
INSERT [dbo].[State_Master] ([STATE_ID], [STATE_NAME], [COUNTRY_ID]) VALUES (6, N'Kerala', 1)
INSERT [dbo].[State_Master] ([STATE_ID], [STATE_NAME], [COUNTRY_ID]) VALUES (7, N'Telangana', 1)
INSERT [dbo].[Test] ([id], [Name], [address]) VALUES (1, N'phani', N'hello')
INSERT [dbo].[Test] ([id], [Name], [address]) VALUES (2, N'hello', N'jdasflj')
INSERT [dbo].[Test] ([id], [Name], [address]) VALUES (3, N'ldajfl', N'jlfjal')
INSERT [dbo].[Uom_Master] ([UOM_ID], [UOM_SHORT_DESC], [UOM_LONG_DESC]) VALUES (1, N'KGS', N'KGS')
INSERT [dbo].[Uom_Master] ([UOM_ID], [UOM_SHORT_DESC], [UOM_LONG_DESC]) VALUES (2, N'Meters', N'Meters')
INSERT [dbo].[Uom_Master] ([UOM_ID], [UOM_SHORT_DESC], [UOM_LONG_DESC]) VALUES (3, N'Pairs', N'Pairs')
INSERT [dbo].[Uom_Master] ([UOM_ID], [UOM_SHORT_DESC], [UOM_LONG_DESC]) VALUES (4, N'Pieces', N'pieces
')
INSERT [dbo].[Uom_Master] ([UOM_ID], [UOM_SHORT_DESC], [UOM_LONG_DESC]) VALUES (5, N'ascasc', N'ascasca')
INSERT [dbo].[User_Master] ([UserId], [UserName], [PassWord], [IsDelete], [IsEdit], [Emp_Id]) VALUES (1, N'phani', N'1', N'1', N'1', 1)
INSERT [dbo].[User_Master] ([UserId], [UserName], [PassWord], [IsDelete], [IsEdit], [Emp_Id]) VALUES (2, N'nidhi', N'1', N'1', N'1', 2)
INSERT [dbo].[User_Permissions] ([UserId], [Permissions]) VALUES (1, 1)
INSERT [dbo].[User_Permissions] ([UserId], [Permissions]) VALUES (1, 2)
INSERT [dbo].[User_Permissions] ([UserId], [Permissions]) VALUES (1, 3)
INSERT [dbo].[User_Permissions] ([UserId], [Permissions]) VALUES (1, 4)
INSERT [dbo].[User_Permissions] ([UserId], [Permissions]) VALUES (1, 5)
INSERT [dbo].[User_Permissions] ([UserId], [Permissions]) VALUES (1, 6)
INSERT [dbo].[User_Permissions] ([UserId], [Permissions]) VALUES (1, 7)
INSERT [dbo].[User_Permissions] ([UserId], [Permissions]) VALUES (1, 8)
INSERT [dbo].[User_Permissions] ([UserId], [Permissions]) VALUES (2, 2)
INSERT [dbo].[User_Permissions] ([UserId], [Permissions]) VALUES (2, 7)
INSERT [dbo].[User_Permissions] ([UserId], [Permissions]) VALUES (2, 1)
INSERT [dbo].[User_Permissions] ([UserId], [Permissions]) VALUES (2, 3)
INSERT [dbo].[Users_Menu] ([slno], [menu]) VALUES (1, N'Masters')
INSERT [dbo].[Users_Menu] ([slno], [menu]) VALUES (2, N'Sales')
INSERT [dbo].[Users_Menu] ([slno], [menu]) VALUES (3, N'Purchases')
INSERT [dbo].[Users_Menu] ([slno], [menu]) VALUES (4, N'Manufacture')
INSERT [dbo].[Users_Menu] ([slno], [menu]) VALUES (5, N'Stock')
INSERT [dbo].[Users_Menu] ([slno], [menu]) VALUES (6, N'Finance')
INSERT [dbo].[Users_Menu] ([slno], [menu]) VALUES (7, N'HR')
INSERT [dbo].[Users_Menu] ([slno], [menu]) VALUES (8, N'Help')
/****** Object:  Index [CI_PaymentTermsId]    Script Date: 06-04-2019 23:14:28 ******/
CREATE UNIQUE NONCLUSTERED INDEX [CI_PaymentTermsId] ON [dbo].[PaymentTerms_Master]
(
	[PaymentTerms_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[State_Master]  WITH CHECK ADD  CONSTRAINT [FK_State_Master_State_Master] FOREIGN KEY([STATE_ID])
REFERENCES [dbo].[State_Master] ([STATE_ID])
GO
ALTER TABLE [dbo].[State_Master] CHECK CONSTRAINT [FK_State_Master_State_Master]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomers]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCustomers]
       @SearchTerm VARCHAR(100) = ''
      ,@RecordCount INT OUTPUT
AS
BEGIN
      SET NOCOUNT ON;
      SELECT ROW_NUMBER() OVER
      (
            ORDER BY CUST_ID ASC
      )AS RowNumber
      ,CUST_NAME
      ,CUST_COMPANY_NAME
      ,CUST_MOBILE
      ,CUST_EMAIL
      INTO #Results
      FROM Customer_Master
      WHERE CUST_NAME LIKE @SearchTerm + '%' OR @SearchTerm = ''
      SELECT @RecordCount = COUNT(*)
      FROM #Results
          
    
      DROP TABLE #Results
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_CATEGORY_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MASTER_CATEGORY_SEARCH_SELECT]
@SearchItemName nvarchar(50),
@SearchValue nvarchar(50)
as

if (@SearchValue<>'0')
begin
	if (@SearchItemName<>'0')
	begin
		if (@SearchItemName='ITEM_CATEGORY_ID')
			begin
			if (PATINDEX('%[^0-9^]%', @SearchValue)=0)
				begin
					select * from Category_Master where ITEM_CATEGORY_ID = @SearchValue ORDER BY ITEM_CATEGORY_ID
				end
			end
		else if (@SearchItemName='ITEM_CATEGORY_NAME')
			begin
				select * from Category_Master where ITEM_CATEGORY_NAME like '%'+@SearchValue+'%' ORDER BY ITEM_CATEGORY_ID
			end
		
	end
end
else
begin
	select * from Category_Master ORDER BY ITEM_CATEGORY_ID DESC
end






GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_COUNTRY_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MASTER_COUNTRY_SEARCH_SELECT]
@SearchItemName nvarchar(50),
@SearchValue nvarchar(50)
as

if (@SearchValue<>'0')
begin
	if (@SearchItemName<>'0')
	begin
		if (@SearchItemName='COUNTRY_ID')
			begin
			if (PATINDEX('%[^0-9^]%', @SearchValue)=0)
				begin
					select * from Country_Master where COUNTRY_ID = @SearchValue ORDER BY COUNTRY_NAME
				end
			end
		else if (@SearchItemName='COUNTRY_NAME')
			begin
				select * from Country_Master where COUNTRY_NAME like '%'+@SearchValue+'%' ORDER BY COUNTRY_NAME
			end
	end
end
else
begin
	select * from Country_Master ORDER BY COUNTRY_NAME DESC
end
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_CURRENCYTYPE_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

cREATE PROCEDURE [dbo].[SP_MASTER_CURRENCYTYPE_SEARCH_SELECT]
@SearchItemName nvarchar(50),
@SearchValue nvarchar(50)
as

if (@SearchValue<>'0')
begin
	if (@SearchItemName<>'0')
	begin
		if (@SearchItemName='CURRENCY_ID')
			begin
			if (PATINDEX('%[^0-9^]%', @SearchValue)=0)
				begin
					select * from Currency_Master where CURRENCY_ID = @SearchValue ORDER BY CURRENCY_ID
				end
			end
		else if (@SearchItemName='CURRENCY_NAME')
			begin
				select * from Currency_Master where CURRENCY_NAME like '%'+@SearchValue+'%' ORDER BY CURRENCY_ID
			end
		else if (@SearchItemName='CURRENCY_FULL_NAME')
			begin
				select * from Currency_Master where CURRENCY_FULL_NAME like '%'+@SearchValue+'%' ORDER BY CURRENCY_ID
		
       	end	
       else if (@SearchItemName='CURRENCY_DESC')
			begin
				select * from Currency_Master where CURRENCY_DESC like '%'+@SearchValue+'%' ORDER BY CURRENCY_ID
			end	
end
end
else
begin
	select * from Currency_Master ORDER BY CURRENCY_ID DESC
end






GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_DEPT_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MASTER_DEPT_SEARCH_SELECT]
@SearchItemName nvarchar(50),
@SearchValue nvarchar(50)
as

if (@SearchValue<>'0')
begin
	if (@SearchItemName<>'0')
	begin
		if (@SearchItemName='DEPT_ID')
			begin
			if (PATINDEX('%[^0-9^]%', @SearchValue)=0)
				begin
					select * from Department_Master where DEPT_ID = @SearchValue ORDER BY DEPT_ID
				end
			end
		else if (@SearchItemName='DEPT_NAME')
			begin
				select * from Department_Master where DEPT_NAME like '%'+@SearchValue+'%' ORDER BY DEPT_ID
			end
		else if (@SearchItemName='DEPT_DESC')
			begin
				select * from Department_Master where DEPT_DESC like '%'+@SearchValue+'%' ORDER BY DEPT_ID
			end	
	end
end
else
begin
	select * from Department_Master ORDER BY DEPT_ID DESC
end
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_DESG_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MASTER_DESG_SEARCH_SELECT]
@SearchItemName nvarchar(50),
@SearchValue nvarchar(50)
as

if (@SearchValue<>'0')
begin
	if (@SearchItemName<>'0')
	begin
		if (@SearchItemName='DESG_ID')
			begin
				if (PATINDEX('%[^0-9^]%', @SearchValue)=0)
					begin
						select * from Designation_Master where DESG_ID = @SearchValue ORDER BY DESG_ID
					end
			end
		else if (@SearchItemName='DESG_NAME')
			begin
				select * from Designation_Master where DESG_NAME like '%'+@SearchValue+'%' ORDER BY DESG_ID
			end
		else if (@SearchItemName='DESG_DESC')
			begin
				select * from Designation_Master where DESG_DESC like '%'+@SearchValue+'%' ORDER BY DESG_ID
			end	
	end
end
else
begin
	select * from Designation_Master ORDER BY DESG_ID DESC
end




GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_DESPMODE_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MASTER_DESPMODE_SEARCH_SELECT]
@SearchItemName nvarchar(50),
@SearchValue nvarchar(50)
as

if (@SearchValue<>'0')
begin
	if (@SearchItemName<>'0')
	begin
		if (@SearchItemName='DESPM_ID')
			begin
			if (PATINDEX('%[^0-9^]%', @SearchValue)=0)
				begin
					select * from DispatchMode_Master where DESPM_ID = @SearchValue ORDER BY DESPM_ID
				end
			end
		else if (@SearchItemName='DESPM_NAME')
			begin
				select * from DispatchMode_Master where DESPM_NAME like '%'+@SearchValue+'%' ORDER BY DESPM_ID
			end
		else if (@SearchItemName='DESPM_DESC')
			begin
				select * from DispatchMode_Master where DESPM_DESC like '%'+@SearchValue+'%' ORDER BY DESPM_ID
			end	
	end
end
else
begin
	select * from DispatchMode_Master ORDER BY DESPM_ID
end





GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_ENQUIRYMODE_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MASTER_ENQUIRYMODE_SEARCH_SELECT]
@SearchItemName nvarchar(50),
@SearchValue nvarchar(50)
as

if (@SearchValue<>'0')
begin
	if (@SearchItemName<>'0')
	begin
		if (@SearchItemName='ENQM_ID')
			begin
				if (PATINDEX('%[^0-9^]%', @SearchValue)=0)
				begin
					select * from Enquiry_Mode where ENQM_ID = @SearchValue ORDER BY ENQM_ID
				end
			end
		else if (@SearchItemName='ENQM_NAME')
			begin
				select * from Enquiry_Mode where ENQM_NAME like '%'+@SearchValue+'%' ORDER BY ENQM_ID
			end
		else if (@SearchItemName='ENQM_DESC')
			begin
				select * from Enquiry_Mode where ENQM_DESC like '%'+@SearchValue+'%' ORDER BY ENQM_ID
			end	
	end
end
else
begin
	select * from Enquiry_Mode ORDER BY ENQM_ID DESC
end







GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_PLANT_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MASTER_PLANT_SEARCH_SELECT]
@SearchItemName nvarchar(50),
@SearchValue nvarchar(50)
as

if (@SearchValue<>'0')
begin
	if (@SearchItemName<>'0')
	begin
		if (@SearchItemName='Plant_Id')
			begin
				if (PATINDEX('%[^0-9^]%', @SearchValue)=0)
				begin
					select * from Plant_Master,Company_Profile WHERE Plant_Master.Company_Id = Company_Profile.CP_ID AND Plant_Id = @SearchValue ORDER BY Plant_Id
				end
			end	
		else if (@SearchItemName='Plant_Name')
			begin
				select * from Plant_Master,Company_Profile WHERE Plant_Master.Company_Id = Company_Profile.CP_ID AND Plant_Name like '%'+@SearchValue+'%' ORDER BY Plant_Id
			end
		else if (@SearchItemName='CP_FULL_NAME')
			begin
					select * from Plant_Master,Company_Profile WHERE Plant_Master.Company_Id = Company_Profile.CP_ID AND CP_FULL_NAME like '%'+@SearchValue+'%' ORDER BY Plant_Id
			end	
	end
end
else
begin
	select * from Plant_Master,Company_Profile WHERE Plant_Master.Company_Id = Company_Profile.CP_ID ORDER BY Plant_Id DESC
end



GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_REGION_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MASTER_REGION_SEARCH_SELECT]
@SearchItemName nvarchar(50),
@SearchValue nvarchar(50)
as

if (@SearchValue<>'0')
begin
	if (@SearchItemName<>'0')
	begin
		if (@SearchItemName='REG_ID')
			begin
				if (PATINDEX('%[^0-9^]%', @SearchValue)=0)
				begin
					select * from Regional_Master where REG_ID = @SearchValue ORDER BY REG_ID
				end
			end	
		else if (@SearchItemName='REG_NAME')
			begin
				select * from Regional_Master where REG_NAME like '%'+@SearchValue+'%' ORDER BY REG_ID
			end
		else if (@SearchItemName='REG_DESC')
			begin
				select * from Regional_Master where REG_DESC like '%'+@SearchValue+'%' ORDER BY REG_ID
			end	
	end
end
else
begin
	select * from Regional_Master ORDER BY REG_ID DESC
end



GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_SUBCATEGORY_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_MASTER_SUBCATEGORY_SEARCH_SELECT]
@SearchItemName nvarchar(50),
@SearchValue nvarchar(50)
as

if (@SearchValue<>'0')
begin
	if (@SearchItemName<>'0')
	begin
		if (@SearchItemName='SubCategory_Id')
			begin
			if (PATINDEX('%[^0-9^]%', @SearchValue)=0)
				begin
					select * from SubCategory_Master,Category_Master where SubCategory_Master.Category_Id = Category_Master.ITEM_CATEGORY_ID and SubCategory_Id = @SearchValue ORDER BY SubCategory_Name
				end
			end
		else if (@SearchItemName='SubCategory_Name')
			begin
				select * from SubCategory_Master,Category_Master where SubCategory_Master.Category_Id = Category_Master.ITEM_CATEGORY_ID and SubCategory_Name like '%'+@SearchValue+'%' ORDER BY SubCategory_Name
			end
	end
end
else
begin
	select * from SubCategory_Master,Category_Master where SubCategory_Master.Category_Id = Category_Master.ITEM_CATEGORY_ID ORDER BY SubCategory_Name DESC
end
GO
/****** Object:  StoredProcedure [dbo].[SP_MASTER_UOM_SEARCH_SELECT]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

cREATE PROCEDURE [dbo].[SP_MASTER_UOM_SEARCH_SELECT]
@SearchItemName nvarchar(50),
@SearchValue nvarchar(50)
as

if (@SearchValue<>'0')
begin
	if (@SearchItemName<>'0')
	begin
		if (@SearchItemName='UOM_ID')
			begin
			if (PATINDEX('%[^0-9^]%', @SearchValue)=0)
				begin
					select * from Uom_Master where UOM_ID = @SearchValue ORDER BY UOM_ID
				end
			end
		else if (@SearchItemName='UOM_SHORT_DESC')
			begin
				select * from Uom_Master where UOM_SHORT_DESC like '%'+@SearchValue+'%' ORDER BY UOM_ID
			end
		else if (@SearchItemName='UOM_LONG_DESC')
			begin
				select * from Uom_Master where UOM_LONG_DESC like '%'+@SearchValue+'%' ORDER BY UOM_ID
			end	
	end
end
else
begin
	select * from Uom_Master ORDER BY UOM_ID DESC
end
GO
/****** Object:  StoredProcedure [dbo].[SP_PERMISSIONS]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SP_PERMISSIONS]
@SearchValue nvarchar(50)
as

Select * from User_Permissions, Users_Menu 
WHERE 
User_Permissions.Permissions = Users_Menu.SLNO and 
User_Permissions.UserId = @SearchValue ORDER BY Users_Menu.SLNO








GO
/****** Object:  StoredProcedure [dbo].[SP_UTY_USER_MASTER]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[SP_UTY_USER_MASTER]
@SearchItem varchar(100),
@SearchValue varchar(100)
as

if (@SearchValue<>'0')
BEGIN
	if (@SearchItem<>'0')
	BEGIN
		 if(@SearchItem='UserName')
           BEGIN
              SELECT * FROM User_Master where User_Master.UserName like '%' + @SearchValue + '%' ORDER BY User_Master.UserId
            END
         
         
      END
END
ELSE
BEGIN 
   SELECT * FROM User_Master order by User_Master.UserId
END






GO
/****** Object:  StoredProcedure [dbo].[spEmpUserNameExists]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spEmpUserNameExists] 
@UserName nvarchar(100) 
as Begin 
Declare @Count int 
Select @Count = Count(UserId) 
from User_Master 
where UserName = @UserName
If (@Count > 0) 
Select 1 as UserNameExists
 Else 
Select 0 as UserNameExists End
GO
/****** Object:  StoredProcedure [dbo].[spUserNameExists]    Script Date: 06-04-2019 23:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spUserNameExists] 
@UserName nvarchar(100) 
as Begin 
Declare @Count int 
Select @Count = Count(CUST_ID) 
from Customer_Master 
where CUST_NAME = @UserName
If (@Count > 0) 
Select 1 as UserNameExists
 Else 
Select 0 as UserNameExists End
GO
USE [master]
GO
ALTER DATABASE [Alumil] SET  READ_WRITE 
GO
