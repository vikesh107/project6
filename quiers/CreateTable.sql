use project6;

CREATE TABLE Users(
 UserID int PRIMARY KEY,
 Username VARCHAR(255),
 Password VARCHAR(255),
 Role ENUM('Retailer','Customer','Admin'),
 IsActive bool
);

CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(255)
);

CREATE TABLE Vendors (
    VendorID INT PRIMARY KEY,
    VendorName VARCHAR(255),
    ContactDetails VARCHAR(255),
    IsActive BOOLEAN
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(255),
    CategoryID INT,
    VendorID INT,
    Price DECIMAL(10, 2),
    ImageURL VARCHAR(255),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    FOREIGN KEY (VendorID) REFERENCES Vendors(VendorID)
);

CREATE TABLE ProductRatings (
    RatingID INT PRIMARY KEY,
    ProductID INT,
    CustomerID INT,
    Rating INT,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (CustomerID) REFERENCES Users(UserID)
);

CREATE TABLE CustomerInterests (
    InterestID INT PRIMARY KEY,
    ProductID INT,
    CustomerID INT,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (CustomerID) REFERENCES Users(UserID)
);
