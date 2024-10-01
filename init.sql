
CREATE TABLE "Activities" (
    "Id" SERIAL PRIMARY KEY,
    "Type" INT NOT NULL,  -- 1: leer archivo
    "FileName" VARCHAR(255) NOT NULL,
    "FileNumber" INT NOT NULL,
    "Data" TEXT,
    "Log" TEXT,
    "Status" INT NOT NULL, 
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT NOW(),
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT NOW()
);

CREATE TABLE "FileInformations" (
    "Id" SERIAL PRIMARY KEY,
    "Random" VARCHAR(255),
    "RandomFloat" DECIMAL,
    "Bool" BOOLEAN NOT NULL,
    "Date" VARCHAR(50),  
    "RegEx" VARCHAR(255),
    "FileName" VARCHAR(255),
    "FileNumber" INTEGER,
    "Enum" VARCHAR(255),
    "Elt" JSONB,
    "Person" JSONB,
    "LastUpdated" VARCHAR(255),
    "LastModified" VARCHAR(255),
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT NOW(),
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT NOW()
);
