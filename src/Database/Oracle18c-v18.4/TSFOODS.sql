 CREATE TABLE "TSFOODS"."CLIENTS" 
   (	"ID" NUMBER GENERATED ALWAYS AS IDENTITY MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE  NOKEEP  NOSCALE  NOT NULL ENABLE, 
	"NAMES" VARCHAR2(60 BYTE), 
	"SURNAMES" VARCHAR2(60 BYTE), 
	"ADDRESS" VARCHAR2(100 BYTE), 
	"PHONE" VARCHAR2(20 BYTE), 
	 CONSTRAINT "CLIENTS_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS"  ENABLE
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
  
  CREATE TABLE "TSFOODS"."WAITERS" 
   (	"ID" NUMBER GENERATED ALWAYS AS IDENTITY MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE  NOKEEP  NOSCALE  NOT NULL ENABLE, 
	"NAMES" VARCHAR2(60 BYTE), 
	"SURNAMES" VARCHAR2(60 BYTE), 
	"AGE" NUMBER(*,0), 
	"SENIORITY" NUMBER(*,0), 
	 CONSTRAINT "WAITERS_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS"  ENABLE
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;


  CREATE TABLE "TSFOODS"."TABLES" 
   (	"ID" NUMBER GENERATED ALWAYS AS IDENTITY MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE  NOKEEP  NOSCALE  NOT NULL ENABLE, 
	"NAME" VARCHAR2(60 BYTE), 
	"RESERVED" CHAR(1 BYTE), 
	"CHAIRS" NUMBER(*,0), 
	 CONSTRAINT "TABLES_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS"  ENABLE
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
  
  
  CREATE TABLE "TSFOODS"."INVOICES" 
   (	"ID" NUMBER GENERATED ALWAYS AS IDENTITY MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE  NOKEEP  NOSCALE  NOT NULL ENABLE, 
	"ID_CLIENT" NUMBER, 
	"ID_TABLE" NUMBER, 
	"ID_WAITER" NUMBER, 
	"INVOICE_DATE" DATE, 
	 CONSTRAINT "INVOICES_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS"  ENABLE, 
	 CONSTRAINT "FK_INVOICES_CLIENTS" FOREIGN KEY ("ID_CLIENT")
	  REFERENCES "TSFOODS"."CLIENTS" ("ID") ENABLE, 
	 CONSTRAINT "FK_INVOICES_TABLES" FOREIGN KEY ("ID_TABLE")
	  REFERENCES "TSFOODS"."TABLES" ("ID") ENABLE, 
	 CONSTRAINT "FK_INVOICES_WAITERS" FOREIGN KEY ("ID_WAITER")
	  REFERENCES "TSFOODS"."WAITERS" ("ID") ENABLE
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;


  CREATE TABLE "TSFOODS"."INVOICES_DET" 
   (	"ID" NUMBER GENERATED ALWAYS AS IDENTITY MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE  NOKEEP  NOSCALE  NOT NULL ENABLE, 
	"ID_INVOICE" NUMBER, 
	"RECIPE_NAME" VARCHAR2(60 BYTE), 
	"PRICE" NUMBER, 
	 CONSTRAINT "INVOICES_DET_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS"  ENABLE, 
	 CONSTRAINT "INVOICES_DET_INVOICES" FOREIGN KEY ("ID_INVOICE")
	  REFERENCES "TSFOODS"."INVOICES" ("ID") ENABLE
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;

  CREATE OR REPLACE FORCE NONEDITIONABLE VIEW "TSFOODS"."VIEW_INVOICES" ("ID", "INVOICE_DATE", "ID_CLIENT", "CLIENTNAME", "ID_TABLE", "TABLENAME", "ID_WAITER", "WAITER") AS 
  SELECT
 INVOICES.ID
,INVOICES.INVOICE_DATE 
,INVOICES.ID_CLIENT
,CLIENTS.NAMES AS CLIENTNAME
,INVOICES.ID_TABLE
,TABLES.NAME AS TABLENAME
,INVOICES.ID_WAITER
,WAITERS.NAMES AS WAITER
FROM INVOICES
LEFT JOIN CLIENTS  ON INVOICES.ID_CLIENT = CLIENTS.ID
LEFT JOIN TABLES  ON INVOICES.ID_TABLE = TABLES.ID
LEFT JOIN WAITERS  ON INVOICES.ID_WAITER = WAITERS.ID;




  
  
  