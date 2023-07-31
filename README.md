# AtikYonetimi - First MVC Project

I've just created this project to see how mvc works. This is so simple project with crud and list operations.

<h2>Database</h2>
I created four tables for this project.

<h4>1 - Main Table : tbl_WasteOperation</h4>

	[ID] [INT] IDENTITY(1,1) NOT NULL,
	[MonthId] [INT] NOT NULL,
	[StoreId] [INT] NOT NULL,
	[WasteTypeId] [INT] NOT NULL,
	[WasteSortId] [INT] NOT NULL,
	[Quantity] [INT] NOT NULL,
	[UnitId] [INT] NOT NULL,
	[ReceivingCompanyId] [INT] NOT NULL,
	[WasteDate] [DATETIME] NOT NULL,
	[Content] [NVARCHAR](MAX) NULL

 <h4>2 - Supplementary Table : tbl_Stores</h4>

 	[ID] [INT] IDENTITY(1,1) NOT NULL,
	[StoreName] [NVARCHAR](200) NOT NULL,
	[OpeningDate] [DATETIME] NOT NULL

  <h4>3 - Supplementary Table : tbl_Companies</h4>

	[ID] [INT] IDENTITY(1,1) NOT NULL,
	[CompanyName] [NVARCHAR](200) NOT NULL

   <h4>4 - Parameter/Definition Table : tbl_Definiton</h4> 
   
   This table is used to fill the dropdowns by type parameter.
   
	[ID] [INT] IDENTITY(1,1) NOT NULL,
	[Type] [INT] NOT NULL,
	[Description] [NVARCHAR](200) NOT NULL 
 
![image](https://github.com/GizemErgin/AtikYonetimi/assets/77542796/cbb7e0e7-980f-4216-8a88-9067acd9d56b)

I created two store procedurs.

<h4>1 - sp_WasteOperation</h4> 

This sp lists the all records in main table, using the join of the main table and additional tables.

<h4>2 - sp_WasteOperationDetail</h4> 

This sp lists the details of a single record with the id parameter, using the join of the main table and additional tables.

*********************************************************************************************************************************************************************
<h2>Look</h2>

<h4>Simple List Look;</h4>

![image](https://github.com/GizemErgin/AtikYonetimi/assets/77542796/1b4c340f-4e3a-41dc-a5c4-bfcae674442b)

<h4>Simple Update Modal;</h4>

![image](https://github.com/GizemErgin/AtikYonetimi/assets/77542796/b144758d-4b98-4d95-aed2-1fb74862846e)

<h4>Simple Add Modal;</h4>

![image](https://github.com/GizemErgin/AtikYonetimi/assets/77542796/c5a05bad-30ea-44bc-a02b-7d0a3c15942e)

