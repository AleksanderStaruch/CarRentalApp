CREATE SCHEMA project;

GO

CREATE TABLE [project].[Client] (
    Cid int  NOT NULL,
    FirstName varchar(20)  NOT NULL,
    LastName varchar(20)  NOT NULL,
    PESEL int  NOT NULL,
    PhoneNumber int  NOT NULL,
    Address varchar(20)  NOT NULL,
    CONSTRAINT Client_pk PRIMARY KEY  (Cid)
);

-- Table: FeulType
CREATE TABLE [project].[FeulType] (
    Fid int  NOT NULL,
    Feul varchar(20)  NOT NULL,
    CONSTRAINT FeulType_pk PRIMARY KEY  (Fid)
);

-- Table: Rent
CREATE TABLE [project].[Rent] (
    Rid int  NOT NULL,
    DateOfRental date  NOT NULL,
    DateOfReturn date  NULL,
    Client_Id int  NOT NULL,
    User_Id int  NOT NULL,
    Vehicle_Id int  NOT NULL,
    CONSTRAINT Rent_pk PRIMARY KEY  (Rid)
);

-- Table: Type
CREATE TABLE [project].[Type] (
    Tid int  NOT NULL,
    Type varchar(20)  NOT NULL,
    CONSTRAINT Type_pk PRIMARY KEY  (Tid)
);

-- Table: User
CREATE TABLE [project].["User"] (
    Uid int  NOT NULL,
    Login varchar(20)  NOT NULL,
    Pass varchar(20)  NOT NULL,
    UserStatus_Id int  NOT NULL,
    CONSTRAINT User_pk PRIMARY KEY  (Uid)
);

-- Table: UserStatus
CREATE TABLE [project].[UserStatus] (
    USid int  NOT NULL,
    Status varchar(50)  NOT NULL,
    CONSTRAINT UserStatus_pk PRIMARY KEY  (USid)
);

-- Table: Vehicle
CREATE TABLE [project].[Vehicle] (
    Vid int  NOT NULL,
    VIN int  NOT NULL,
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
ALTER TABLE Rent ADD CONSTRAINT Rent_Client
    FOREIGN KEY (Client_Id)
    REFERENCES Client (Cid);

-- Reference: Rent_User (table: Rent)
ALTER TABLE Rent ADD CONSTRAINT Rent_User
    FOREIGN KEY (User_Id)
    REFERENCES "User" (Uid);

-- Reference: Rent_Vehicle (table: Rent)
ALTER TABLE Rent ADD CONSTRAINT Rent_Vehicle
    FOREIGN KEY (Vehicle_Id)
    REFERENCES Vehicle (Vid);

-- Reference: User_UserStatus (table: User)
ALTER TABLE "User" ADD CONSTRAINT User_UserStatus
    FOREIGN KEY (UserStatus_Id)
    REFERENCES UserStatus (USid);

-- Reference: Vehicle_FeulType (table: Vehicle)
ALTER TABLE Vehicle ADD CONSTRAINT Vehicle_FeulType
    FOREIGN KEY (FeulType_Id)
    REFERENCES FeulType (Fid);

-- Reference: Vehicle_Type (table: Vehicle)
ALTER TABLE Vehicle ADD CONSTRAINT Vehicle_Type
    FOREIGN KEY (Type_Id)
    REFERENCES Type (Tid);

-- End of file.

