Drop Table [project].[Rent];
Drop Table [project].[Vehicle];
Drop Table [project].[User];
Drop Table [project].[UserStatus];
Drop Table [project].[Client];
Drop Table [project].[FeulType]
Drop Table [project].[Type];



CREATE TABLE [project].[Client] (
    Cid int   NOT NULL IDENTITY,
    FirstName varchar(20)  NOT NULL,
    LastName varchar(20)  NOT NULL,
    PESEL int  NOT NULL,
    PhoneNumber int  NOT NULL,
    Address varchar(20)  NOT NULL,
    CONSTRAINT Client_pk PRIMARY KEY  (Cid)
);

-- Table: FeulType
CREATE TABLE [project].[FeulType] (
    Fid int  NOT NULL IDENTITY,
    Feul varchar(20)  NOT NULL,
    CONSTRAINT FeulType_pk PRIMARY KEY  (Fid)
);

-- Table: Rent
CREATE TABLE [project].[Rent] (
    Rid int  NOT NULL IDENTITY,
    DateOfRental date  NOT NULL,
    DateOfReturn date  NULL,
    Client_Id int  NOT NULL,
    User_Id int  NOT NULL,
    Vehicle_Id int  NOT NULL,
    CONSTRAINT Rent_pk PRIMARY KEY  (Rid)
);

-- Table: Type
CREATE TABLE [project].[Type] (
    Tid int  NOT NULL IDENTITY,
    Name varchar(20)  NOT NULL,
    CONSTRAINT Type_pk PRIMARY KEY  (Tid)
);

-- Table: User
CREATE TABLE [project].[User] (
    Uid int  NOT NULL IDENTITY,
    Login varchar(20)  NOT NULL,
    Pass varchar(20)  NOT NULL,
    UserStatus_Id int  NOT NULL,
    CONSTRAINT User_pk PRIMARY KEY  (Uid)
);

-- Table: UserStatus
CREATE TABLE [project].[UserStatus] (
    USid int  NOT NULL IDENTITY,
    Status varchar(50)  NOT NULL,
    CONSTRAINT UserStatus_pk PRIMARY KEY  (USid)
);

-- Table: Vehicle
CREATE TABLE [project].[Vehicle] (
    Vid int  NOT NULL IDENTITY,
    VIN varchar(17)  NOT NULL UNIQUE,
    Type_Id int  NOT NULL,
    Brand varchar(20)  NOT NULL,
    Model varchar(20)  NOT NULL,
    Color varchar(20)  NOT NULL,
    MakeYear int  NOT NULL,
    FeulType_Id int  NOT NULL,
    PriceByDay int  NOT NULL,
    Mileage int  NOT NULL,
    IfRent int  NOT NULL,
    CONSTRAINT Vehicle_pk PRIMARY KEY  (Vid)
);

-- foreign keys
-- Reference: Rent_Client (table: Rent)
-- ALTER TABLE project.Rent ADD CONSTRAINT Rent_Client
    -- FOREIGN KEY (Client_Id)
    -- REFERENCES project.Client (Cid);

-- -- Reference: Rent_User (table: Rent)
-- ALTER TABLE project.Rent ADD CONSTRAINT Rent_User
    -- FOREIGN KEY (User_Id)
    -- REFERENCES project."User" (Uid);

-- -- Reference: Rent_Vehicle (table: Rent)
-- ALTER TABLE project.Rent ADD CONSTRAINT Rent_Vehicle
    -- FOREIGN KEY (Vehicle_Id)
    -- REFERENCES project.Vehicle (Vid);

-- -- Reference: User_UserStatus (table: User)
-- ALTER TABLE project."User" ADD CONSTRAINT User_UserStatus
    -- FOREIGN KEY (UserStatus_Id)
    -- REFERENCES project.UserStatus (USid);

-- -- Reference: Vehicle_FeulType (table: Vehicle)
-- ALTER TABLE project.Vehicle ADD CONSTRAINT Vehicle_FeulType
    -- FOREIGN KEY (FeulType_Id)
    -- REFERENCES project.FeulType (Fid);

-- -- Reference: Vehicle_Type (table: Vehicle)
-- ALTER TABLE project.Vehicle ADD CONSTRAINT Vehicle_Type
    -- FOREIGN KEY (Type_Id)
    -- REFERENCES project.Type (Tid);


INSERT INTO [project].[UserStatus] values ('Admin');
INSERT INTO [project].[UserStatus] values ('Boss');
INSERT INTO [project].[UserStatus] values ('Employee');

INSERT INTO [project].[User] values ('admin','admin',1);
INSERT INTO [project].[User] values ('Jan','jan1',2);
INSERT INTO [project].[User] values ('adam123','haslo',3);
INSERT INTO [project].[User] values ('nightwing10036','batman',3);

INSERT INTO [project].[FeulType] values ('Benzyna');
INSERT INTO [project].[FeulType] values ('Diesel');
INSERT INTO [project].[FeulType] values ('LPG');
INSERT INTO [project].[FeulType] values ('Elektryczny');

INSERT INTO [project].[Type] values ('Samochod osobowy');
INSERT INTO [project].[Type] values ('Motocykl/Skuter');
INSERT INTO [project].[Type] values ('Dostawczy/Ciężarowy');
INSERT INTO [project].[Type] values ('Kamper');
INSERT INTO [project].[Type] values ('Autobus');


select * from [project].[UserStatus];
select * from [project].[User] where Pass like 'admin'



-- End of file.

