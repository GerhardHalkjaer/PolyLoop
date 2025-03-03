
USE master
GO

ALTER DATABASE PolyLoop
SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

DROP DATABASE PolyLoop;
GO
CREATE DATABASE PolyLoop;
GO

ALTER DATABASE PolyLoop
SET MULTI_USER

USE PolyLoop
GO

CREATE TABLE MaterialTypes(
Id int IDENTITY(1,1) NOT NULL,
"Name" nvarchar(50) NOT NULL,
IconPath nvarchar(500) NOT NULL
CONSTRAINT PK_MaterialType_Id PRIMARY KEY(Id))

CREATE TABLE SpecificTypes(
Id int IDENTITY(1,1) NOT NULL,
MaterialTypeId int NOT NULL,
"Name" nvarchar(50) NOT NULL,
IconPath nvarchar(500) NOT NULL
CONSTRAINT PK_SpecificType_Id PRIMARY KEY(Id))

CREATE TABLE Packagings(
Id int IDENTITY(1,1) NOT NULL,
"Name" nvarchar(50) NOT NULL,
IconPath nvarchar(500) NOT NULL,
PackagingWeight int NOT NULL
CONSTRAINT PK_Packagings_Id PRIMARY KEY(Id))

CREATE TABLE PackagedUnits(
Id int IDENTITY(5000,1) NOT NULL,
SpecificTypeId int NOT NULL,
PackagingId int NOT NULL,
"Weight" int NOT NULL,
ImagePath nvarchar(500),
ProcessedDate date
CONSTRAINT PK_PackagedUnits_Id PRIMARY KEY(Id))
GO

ALTER TABLE SpecificTypes
	ADD CONSTRAINT FK_MaterialTypesId FOREIGN KEY (MaterialTypeId)
	REFERENCES MaterialTypes(Id)

ALTER TABLE PackagedUnits
	ADD CONSTRAINT FK_SpecificTypesId FOREIGN KEY (SpecificTypeId)
	REFERENCES SpecificTypes(Id)

ALTER TABLE PackagedUnits
	ADD CONSTRAINT FK_PackagingId FOREIGN KEY (PackagingId)
	REFERENCES Packagings(Id)
GO

INSERT INTO Packagings ("Name",IconPath,PackagingWeight)
VALUES ('Papkasse','Emballage/PapkasseIcon.jpg',35)

INSERT INTO Packagings ("Name",IconPath,PackagingWeight)
VALUES ('BigBag','Emballage/BigBagIcon.jpg',130)

INSERT INTO Packagings ("Name",IconPath,PackagingWeight)
VALUES ('Lille Palle','Emballage/LillePalleIcon.jpg',25)

INSERT INTO Packagings ("Name",IconPath,PackagingWeight)
VALUES ('Stor Palle','Emballage/StorePalleIcon.jpg',50)

INSERT INTO Packagings ("Name",IconPath,PackagingWeight)
VALUES ('Lang Trækasse','Emballage/LangTraekasseIcon.jpg',35)


INSERT INTO MaterialTypes ("Name",IconPath)
VALUES ('ABS','Materialetype/Abs.jpg')

INSERT INTO MaterialTypes ("Name",IconPath)
VALUES ('ALU','Materialetype/Alu-Dibond.jpg')

INSERT INTO MaterialTypes ("Name",IconPath)
VALUES ('PA','Materialetype/Pa.jpg')

INSERT INTO MaterialTypes ("Name",IconPath)
VALUES ('PC','Materialetype/Pc.jpg')

INSERT INTO MaterialTypes ("Name",IconPath)
VALUES ('PE','Materialetype/Pe.jpg')

INSERT INTO MaterialTypes ("Name",IconPath)
VALUES ('PET','Materialetype/Pet.jpg')

INSERT INTO MaterialTypes ("Name",IconPath)
VALUES ('PMMA','Materialetype/Pmma.jpg')

INSERT INTO MaterialTypes ("Name",IconPath)
VALUES ('POM','Materialetype/Pom.jpg')

INSERT INTO MaterialTypes ("Name",IconPath)
VALUES ('PP','Materialetype/Pp.jpg')

INSERT INTO MaterialTypes ("Name",IconPath)
VALUES ('PS','Materialetype/Ps.jpg')

INSERT INTO MaterialTypes ("Name",IconPath)
VALUES ('PVC','Materialetype/Pvc.jpg')

INSERT INTO MaterialTypes ("Name",IconPath)
VALUES ('ANDRE','Materialetype/Andre.jpg')
GO

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'ABS'),'ABS OC Farvet','Materialetype/Specific/ABSOCFarvet.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'ABS'),'ABS OC Hvid','Materialetype/Specific/ABSOCHvid.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'ABS'),'ABS Regrind','Materialetype/Specific/ABSRegrind.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'ALU'),'ALU Composite OC','Materialetype/Specific/ALUCompositeOC.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'ALU'),'ALU Ren','Materialetype/Specific/ALURen.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PET'),'PETG OC','Materialetype/Specific/PETGOC.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PET'),'PETP OC','Materialetype/Specific/PETPOC.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PET'),'A-Pet','Materialetype/Specific/A-Pet.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PS'),'PS Hvid','Materialetype/Specific/PSHvid.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PS'),'PS Farvet','Materialetype/Specific/PSFarvet.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PS'),'PS Natur (GPPS)','Materialetype/Specific/PSNatur.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PS'),'EPS','Materialetype/Specific/PSEPS.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PS'),'XPS Blue','Materialetype/Specific/PSXPSBlue.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PA'),'PA OC Mix','Materialetype/Specific/PAOCMix.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PA'),'PA6 Injection regrind','Materialetype/Specific/PA6InjectionRegrind.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PA'),'PA 6 REGRIND GF','Materialetype/Specific/PA6RegrindGF.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PA'),'PA66 Injection Regrind','Materialetype/Specific/PA66InjectionRegrind.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PC'),'PC OC','Materialetype/Specific/PCOC.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PC'),'PC OC Twinwall','Materialetype/Specific/PCOCTwinwall.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PC'),'PC Kværnet Materiale','Materialetype/Specific/PCKvaernet.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PE'),'PE 100','Materialetype/Specific/PE100.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PE'),'PE 300','Materialetype/Specific/PE300.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PE'),'PE 500-1000 Natural','Materialetype/Specific/PE500-1000Natural.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PE'),'PE 500-1000 Sort','Materialetype/Specific/PE500-1000Sort.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PE'),'PE 500-1000 Farvet','Materialetype/Specific/PE500-1000Farvet.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PE'),'PE Film 60/40','Materialetype/Specific/PEFilm6040.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PE'),'PE Film Natural','Materialetype/Specific/PEFilmNatural.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PE'),'PE Regrind','Materialetype/Specific/PERegrind.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PMMA'),'PMMA XT Natural','Materialetype/Specific/PMMAXTNatural.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PMMA'),'PMMA XT Opal','Materialetype/Specific/PMMAXTOpal.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PMMA'),'PMMA XT ALU','Materialetype/Specific/PMMAXTAlu.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PMMA'),'PMMA CAST Natural','Materialetype/Specific/PMMACastNatural.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PMMA'),'PMMA Dark Colour Shredded','Materialetype/Specific/PMMADarkColourShredded.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PMMA'),'PMMA Mix OC','Materialetype/Specific/PMMAMixOc.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'POM'),'POM OC','Materialetype/Specific/POMOC.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'POM'),'POM Regrind','Materialetype/Specific/POMRegrind.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PP'),'PP Mix OC','Materialetype/Specific/PPMixOc.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PP'),'PP OC Natural','Materialetype/Specific/PPOcNatural.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PP'),'PP Blå Baller','Materialetype/Specific/PPBlaaBaller.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PP'),'PP Regrind Mix Colour','Materialetype/Specific/PPRegrindMixColour.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PVC'),'PVC OC Foam','Materialetype/Specific/PVCOcFoam.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'PVC'),'PVC OC Solid','Materialetype/Specific/PVCOcSolid.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'ANDRE'),'PTFE OC','Materialetype/Specific/AndrePTFEOC.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'ANDRE'),'SAN OC','Materialetype/Specific/AndreSANOC.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'ANDRE'),'Silicone Natural','Materialetype/Specific/AndreSiliconeNatural.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'ANDRE'),'PBT Regrind','Materialetype/Specific/AndrePBTRegrind.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'ANDRE'),'ECTFE Regrind Natural','Materialetype/Specific/AndreECTFERegrindNatural.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'ANDRE'),'PVDF','Materialetype/Specific/AndrePVDF.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'ANDRE'),'PPS Injection','Materialetype/Specific/AndrePPSInjection.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'ANDRE'),'PEEK OC and Lumps','Materialetype/Specific/AndrePEEKOCAndLumps.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'ANDRE'),'Elastomer Regrind','Materialetype/Specific/AndreElastomerRegrind.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'ANDRE'),'PC/ABS Regrind','Materialetype/Specific/AndrePCABSRegrind.jpg')

INSERT INTO SpecificTypes (MaterialTypeId,"Name",IconPath)
VALUES ((SELECT Id FROM MaterialTypes WHERE "Name" = 'ANDRE'),'PSU OC','Materialetype/Specific/AndrePSUOC.jpg')

GO
