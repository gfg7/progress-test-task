CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230509230014_initial') THEN
    CREATE TABLE "Diagnoses" (
        "Id" character varying(36) NOT NULL,
        "Name" text NOT NULL,
        "ParentId" text NOT NULL,
        CONSTRAINT "PK_Diagnoses" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230509230014_initial') THEN
    CREATE TABLE "Patients" (
        "Id" character varying(36) NOT NULL,
        "Surname" character varying(50) NOT NULL,
        "Name" character varying(50) NOT NULL,
        "Patronymic" character varying(50) NULL,
        "DateOfBirth" timestamp with time zone NOT NULL,
        "PhoneNumber" character varying(15) NULL,
        CONSTRAINT "PK_Patients" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230509230014_initial') THEN
    CREATE TABLE "Visits" (
        "Id" character varying(36) NOT NULL,
        "Time" timestamp with time zone NOT NULL,
        "Diagnosis" character varying(36) NOT NULL,
        "PatientId" character varying(36) NOT NULL,
        CONSTRAINT "PK_Visits" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Visits_Diagnoses_Diagnosis" FOREIGN KEY ("Diagnosis") REFERENCES "Diagnoses" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_Visits_Patients_PatientId" FOREIGN KEY ("PatientId") REFERENCES "Patients" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230509230014_initial') THEN
    CREATE INDEX "IX_Visits_Diagnosis" ON "Visits" ("Diagnosis");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230509230014_initial') THEN
    CREATE INDEX "IX_Visits_PatientId" ON "Visits" ("PatientId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20230509230014_initial') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20230509230014_initial', '7.0.5');
    END IF;
END $EF$;
COMMIT;

