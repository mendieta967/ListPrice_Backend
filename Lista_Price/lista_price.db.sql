BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Products" (
	"Id"	int NOT NULL,
	"Name"	longtext NOT NULL,
	"Description"	longtext NOT NULL,
	"Price"	decimal(65, 30) NOT NULL,
	"IsActive"	tinyint(1) NOT NULL,
	"CreatedAt"	datetime(6) NOT NULL,
	"UpdatedAt"	datetime(6) NOT NULL,
	CONSTRAINT "PK_Products" PRIMARY KEY("Id")
);
CREATE TABLE IF NOT EXISTS "Users" (
	"Id"	int NOT NULL,
	"UserName"	longtext NOT NULL,
	"Email"	longtext NOT NULL,
	"Password"	longtext NOT NULL,
	CONSTRAINT "PK_Users" PRIMARY KEY("Id")
);
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
	"MigrationId"	TEXT NOT NULL,
	"ProductVersion"	TEXT NOT NULL,
	CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY("MigrationId")
);
INSERT INTO "Users" VALUES (1,'Rodolfo','rodo.granollers@gmail.com','123456');
INSERT INTO "__EFMigrationsHistory" VALUES ('20250814163712_PrimeraMigracion','8.0.13');
INSERT INTO "__EFMigrationsHistory" VALUES ('20250815020723_agregandoUsers','8.0.13');
INSERT INTO "__EFMigrationsHistory" VALUES ('20250815034225_CambioEntidad','8.0.13');
COMMIT;
