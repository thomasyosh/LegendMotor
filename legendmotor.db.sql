BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
	"MigrationId"	TEXT NOT NULL,
	"ProductVersion"	TEXT NOT NULL,
	CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY("MigrationId")
);
CREATE TABLE IF NOT EXISTS "Staff" (
	"StaffId"	TEXT NOT NULL,
	"Address"	TEXT NOT NULL,
	"AreaCode"	TEXT NOT NULL,
	"Email"	TEXT NOT NULL,
	"Gemder"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	"Password"	TEXT NOT NULL,
	"Phone"	TEXT NOT NULL,
	"PositionCode"	TEXT NOT NULL,
	CONSTRAINT "PK_Staff" PRIMARY KEY("StaffId")
);
CREATE TABLE IF NOT EXISTS "Position" (
	"PositionCode"	TEXT NOT NULL,
	"Description"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	CONSTRAINT "PK_Position" PRIMARY KEY("PositionCode")
);
CREATE TABLE IF NOT EXISTS "BinLocationStaff" (
	"BinLocationCode"	TEXT NOT NULL,
	"StaffId"	TEXT NOT NULL,
	CONSTRAINT "PK_BinLocationStaff" PRIMARY KEY("BinLocationCode","StaffId")
);
CREATE TABLE IF NOT EXISTS "BinLocationSpare" (
	"Id"	TEXT NOT NULL,
	"BinLocationCode"	TEXT NOT NULL,
	"DL"	INTEGER NOT NULL,
	"ROL"	INTEGER NOT NULL,
	"Reserved"	INTEGER NOT NULL,
	"SpareId"	TEXT NOT NULL,
	"Stock"	INTEGER NOT NULL,
	CONSTRAINT "PK_BinLocationSpare" PRIMARY KEY("Id")
);
CREATE TABLE IF NOT EXISTS "BinLocation" (
	"BinLocationCode"	TEXT NOT NULL,
	"Address"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	"isActive"	INTEGER NOT NULL,
	CONSTRAINT "PK_BinLocation" PRIMARY KEY("BinLocationCode")
);
CREATE TABLE IF NOT EXISTS "Area" (
	"AreaCode"	TEXT NOT NULL,
	"Description"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	CONSTRAINT "PK_Area" PRIMARY KEY("AreaCode")
);
CREATE TABLE IF NOT EXISTS "Dealer" (
	"DealerCode"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	"Email"	TEXT NOT NULL,
	"Phone"	TEXT NOT NULL,
	"Telex"	TEXT NOT NULL,
	"Fax"	TEXT NOT NULL,
	"Address"	TEXT NOT NULL,
	CONSTRAINT "PK_Dealer" PRIMARY KEY("DealerCode")
);
CREATE TABLE IF NOT EXISTS "IncomingOrder" (
	"OrderId"	TEXT NOT NULL,
	"InvoiceName"	TEXT NOT NULL,
	"InvoiceAddress"	TEXT NOT NULL,
	"DeliveryAddress"	TEXT NOT NULL,
	"DealerCode"	TEXT NOT NULL,
	"Type"	TEXT NOT NULL,
	"Remark"	TEXT NOT NULL,
	"Status"	TEXT NOT NULL,
	"staffId"	TEXT NOT NULL,
	"OrderHeaderId"	TEXT NOT NULL,
	"InvoiceId"	TEXT NOT NULL,
	CONSTRAINT "PK_IncomingOrder" PRIMARY KEY("OrderId")
);
CREATE TABLE IF NOT EXISTS "OrderHeader" (
	"OrderHeaderId"	TEXT NOT NULL,
	"CreatedAt"	TEXT NOT NULL,
	"UpdatedAt"	TEXT NOT NULL,
	CONSTRAINT "PK_OrderHeader" PRIMARY KEY("OrderHeaderId")
);
CREATE TABLE IF NOT EXISTS "SparePrice" (
	"SpareID"	TEXT NOT NULL,
	"SupplierCode"	TEXT NOT NULL,
	"PurchasingPrice"	REAL NOT NULL,
	CONSTRAINT "PK_SparePrice" PRIMARY KEY("SpareID","SupplierCode")
);
CREATE TABLE IF NOT EXISTS "Supplier" (
	"SupplierCode"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	"Address"	TEXT NOT NULL,
	"Phone"	TEXT NOT NULL,
	"Email"	TEXT NOT NULL,
	CONSTRAINT "PK_Supplier" PRIMARY KEY("SupplierCode")
);
CREATE TABLE IF NOT EXISTS "Spare" (
	"SpareId"	TEXT NOT NULL,
	"Category"	TEXT NOT NULL,
	"Count"	INTEGER NOT NULL,
	"Description"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	"Price"	INTEGER NOT NULL,
	"Url"	BLOB NOT NULL,
	"Weight"	INTEGER NOT NULL,
	CONSTRAINT "PK_Spare" PRIMARY KEY("SpareId")
);
INSERT INTO "__EFMigrationsHistory" ("MigrationId","ProductVersion") VALUES ('20240604052721_Initial','8.0.6');
INSERT INTO "__EFMigrationsHistory" ("MigrationId","ProductVersion") VALUES ('20240605074630_second','8.0.6');
INSERT INTO "__EFMigrationsHistory" ("MigrationId","ProductVersion") VALUES ('20240605081757_third','8.0.6');
INSERT INTO "__EFMigrationsHistory" ("MigrationId","ProductVersion") VALUES ('20240607024118_fourth','8.0.6');
INSERT INTO "__EFMigrationsHistory" ("MigrationId","ProductVersion") VALUES ('20240607083225_fifth','8.0.6');
INSERT INTO "__EFMigrationsHistory" ("MigrationId","ProductVersion") VALUES ('20240607202702_sixth','8.0.6');
INSERT INTO "Staff" ("StaffId","Address","AreaCode","Email","Gemder","Name","Password","Phone","PositionCode") VALUES ('3AEFAE23-F316-4079-AD54-222AA599AF80','testing','A000000001','string','string','admin','abcd1234','testing','admin');
INSERT INTO "Staff" ("StaffId","Address","AreaCode","Email","Gemder","Name","Password","Phone","PositionCode") VALUES ('c90bb60c-40e0-45e8-9681-62f7c834dba1','abcd','A000000001','string','string','storemen','abcd1234','abcd','storemen');
INSERT INTO "Staff" ("StaffId","Address","AreaCode","Email","Gemder","Name","Password","Phone","PositionCode") VALUES ('c0f76f94-768e-46f5-ac89-260b91d698f1','addr','A000000001','test@mail.com','M','sales','abcd1234','1234','sales');
INSERT INTO "Staff" ("StaffId","Address","AreaCode","Email","Gemder","Name","Password","Phone","PositionCode") VALUES ('ef75b277-79a9-4f88-a383-7394c31a5140','addr','A000000001','testing@mail.com','M','salemanager','abcd1234','12314','smanager');
INSERT INTO "Staff" ("StaffId","Address","AreaCode","Email","Gemder","Name","Password","Phone","PositionCode") VALUES ('ea55c101-d928-4475-b164-182135a0491d','addr','A000000001','areamgr@mail.com','M','areamanager','abcd1234','12342','amanager');
INSERT INTO "Staff" ("StaffId","Address","AreaCode","Email","Gemder","Name","Password","Phone","PositionCode") VALUES ('f2a13268-4b3b-478c-adb1-169fc368624c','addr','A000000001','purchase','M','purchase','abcd1234','123344','pd');
INSERT INTO "Position" ("PositionCode","Description","Name") VALUES ('admin','System admin','System Admin');
INSERT INTO "Position" ("PositionCode","Description","Name") VALUES ('amanager','Area manager','Area Manager');
INSERT INTO "Position" ("PositionCode","Description","Name") VALUES ('dm','Delivery men','Delivery men');
INSERT INTO "Position" ("PositionCode","Description","Name") VALUES ('pd','Purchasing department','Purchasing Department');
INSERT INTO "Position" ("PositionCode","Description","Name") VALUES ('sales','Sales officer','Sales Officer');
INSERT INTO "Position" ("PositionCode","Description","Name") VALUES ('smanager','Sales manager','Sales Manager');
INSERT INTO "Position" ("PositionCode","Description","Name") VALUES ('src','Stock Record Clerk','Stock Record Clerk');
INSERT INTO "Position" ("PositionCode","Description","Name") VALUES ('storemen','Storemen','Storemen');
INSERT INTO "BinLocationStaff" ("BinLocationCode","StaffId") VALUES ('B000000001','e56c1b60-c894-4c38-acf5-d5bbbba455d0');
INSERT INTO "BinLocationStaff" ("BinLocationCode","StaffId") VALUES ('string','string');
INSERT INTO "BinLocationStaff" ("BinLocationCode","StaffId") VALUES ('B000000001','c90bb60c-40e0-45e8-9681-62f7c834dba1');
INSERT INTO "BinLocationSpare" ("Id","BinLocationCode","DL","ROL","Reserved","SpareId","Stock") VALUES ('3FA85F64-5717-4562-B3FC-2C963F66AFA6','B000000001',500,3000,0,'string',2000);
INSERT INTO "BinLocationSpare" ("Id","BinLocationCode","DL","ROL","Reserved","SpareId","Stock") VALUES ('9B1E2B9E-7527-406C-9EEA-39AFFE465E54','B000000001',220,500,20,'spare001',5000);
INSERT INTO "BinLocation" ("BinLocationCode","Address","Name","isActive") VALUES ('B000000001','Address 1','Bin Location 1',1);
INSERT INTO "BinLocation" ("BinLocationCode","Address","Name","isActive") VALUES ('B000000002','Address 2','Bin Location 2',1);
INSERT INTO "Area" ("AreaCode","Description","Name") VALUES ('A000000001','Area 1','Area 1');
INSERT INTO "Area" ("AreaCode","Description","Name") VALUES ('A000000002','Area 2','Area 2');
INSERT INTO "Dealer" ("DealerCode","Name","Email","Phone","Telex","Fax","Address") VALUES ('5ea904f8-0c67-483e-82d3-7f6baeba9b63','test01','mail@123.com','stri12312ng','3333','stri2131ng','string');
INSERT INTO "Dealer" ("DealerCode","Name","Email","Phone","Telex","Fax","Address") VALUES ('DE00000002','testdealer','1213','3124','132413','341234','124');
INSERT INTO "IncomingOrder" ("OrderId","InvoiceName","InvoiceAddress","DeliveryAddress","DealerCode","Type","Remark","Status","staffId","OrderHeaderId","InvoiceId") VALUES ('358C73FE-ECF5-4925-A88F-0D7CF6770991','d1','address','address','5ea904f8-0c67-483e-82d3-7f6baeba9b63','Email     ','test','Completed','3AEFAE23-F316-4079-AD54-222AA599AF80','20E68946-4821-4ACA-A2D2-06F995E036E1','0040952F-84BE-4883-92FA-589A117F7F4B');
INSERT INTO "OrderHeader" ("OrderHeaderId","CreatedAt","UpdatedAt") VALUES ('20E68946-4821-4ACA-A2D2-06F995E036E1','2024-05-21 21:03:56.703','2024-05-21 21:03:56.703');
INSERT INTO "Supplier" ("SupplierCode","Name","Address","Phone","Email") VALUES ('S000000001','iveSupplier','King Leng Road','12345678','testmail@mail.com');
INSERT INTO "Spare" ("SpareId","Category","Count","Description","Name","Price","Url","Weight") VALUES ('string','A',0,'string','string',0,'string',0);
INSERT INTO "Spare" ("SpareId","Category","Count","Description","Name","Price","Url","Weight") VALUES ('spare001','A',20,'string','Iron',30,'string',500);
CREATE UNIQUE INDEX IF NOT EXISTS "IX_Staff_Email_Name" ON "Staff" (
	"Email",
	"Name"
);
COMMIT;
