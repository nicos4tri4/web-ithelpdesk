CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;
CREATE TABLE "TeamMembers" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_TeamMembers" PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "Role" TEXT NOT NULL,
    "Status" TEXT NOT NULL
);

CREATE TABLE "TicketRequests" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_TicketRequests" PRIMARY KEY,
    "RequesterName" TEXT NOT NULL,
    "Description" TEXT NOT NULL,
    "TargetDelivery" TEXT NOT NULL,
    "AttachmentName" TEXT NULL,
    "AttachmentUrl" TEXT NULL,
    "Status" TEXT NOT NULL,
    "AssignedResource" TEXT NULL,
    "CreatedAt" TEXT NOT NULL
);

CREATE TABLE "FollowUpNotes" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_FollowUpNotes" PRIMARY KEY AUTOINCREMENT,
    "TicketRequestId" TEXT NOT NULL,
    "Date" TEXT NOT NULL,
    "Note" TEXT NOT NULL,
    CONSTRAINT "FK_FollowUpNotes_TicketRequests_TicketRequestId" FOREIGN KEY ("TicketRequestId") REFERENCES "TicketRequests" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_FollowUpNotes_TicketRequestId" ON "FollowUpNotes" ("TicketRequestId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20260609023024_InitialCreate', '9.0.0');

COMMIT;

