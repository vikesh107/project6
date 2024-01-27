INSERT INTO Users (UserID, Username, Password, Role, IsActive) VALUES
(1, 'vikesh_gupta', 'password123', 'Admin', 1),
(2, 'gangadhar', '12345678', 'Customer', 1),
(3, 'sakshi_singh', 'shop123', 'Retailer', 1),
(4, 'naman_jain', 'buyerpass', 'Customer', 1),
(5, 'rinkesh_gupta', 'password107', 'Retailer', 1);

INSERT INTO Categories (CategoryID, CategoryName) VALUES
(1, 'Clothing'),
(2, 'Electronics'),
(3, 'Home Appliances');

INSERT INTO Vendors (VendorID, VendorName, ContactDetails, IsActive) VALUES
(1, 'FashionHub', 'contact@fashionhub.com', 1),
(2, 'TechWorld', 'contact@techworld.com', 1),
(3, 'HomeEssentials', 'contact@homeessentials.com', 1);

-- Inserting Dummy Data into Products Table
INSERT INTO Products (ProductID, ProductName, CategoryID, VendorID, Price, ImageURL) VALUES
(1, 'T-Shirt', 1, 1, 19.99, 'tshirt.jpg'),
(2, 'Laptop', 2, 2, 799.99, 'laptop.jpg'),
(3, 'Smartphone', 2, 1, 399.99, 'phone.jpg'),
(4, 'Microwave Oven', 3, 3, 129.99, 'microwave.jpg'),
(5, 'Jeans', 1, 1, 29.99, 'jeans.jpg');

-- Inserting Dummy Data into ProductRatings Table
INSERT INTO ProductRatings (RatingID, ProductID, CustomerID, Rating) VALUES
(1, 1, 2, 4),
(2, 2, 2, 5),
(3, 3, 2, 4),
(4, 4, 4, 4),
(5, 5, 5, 3);

-- Inserting Dummy Data into CustomerInterests Table
INSERT INTO CustomerInterests (InterestID, ProductID, CustomerID) VALUES
(1, 1, 2),
(2, 3, 2),
(3, 2, 1),
(4, 4, 4),
(5, 5, 5);