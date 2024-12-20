CREATE DATABASE TransportationsDB;
GO

USE TransportationsDB;
GO

CREATE TABLE Transportation (
    PickupDateTime DATETIME NOT NULL,
    DropoffDateTime DATETIME NOT NULL,
    PassengerCount INT NOT NULL,
    TripDistance FLOAT NOT NULL,
    StoreAndFwdFlag NVARCHAR(3) NOT NULL,
    PULocationID INT NOT NULL,
    DOLocationID INT NOT NULL,
    FareAmount DECIMAL(10, 2) NOT NULL,
    TipAmount DECIMAL(10, 2) NOT NULL
);
GO

CREATE INDEX IX_Transportation_PULocationID 
ON Transportation (PULocationID) INCLUDE (TipAmount);
GO

CREATE INDEX IX_Transportation_TripDistance
ON Transportation (TripDistance);
GO

CREATE INDEX IX_Transportation_PickupDropoffDatetime
ON Transportation (PickupDatetime, DropoffDatetime);
GO
