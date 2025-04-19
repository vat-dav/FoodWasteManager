INSERT INTO FoodWasteManager.dbo.FoodTypes (FoodTypeName) VALUES
('Fresh Produce'),
('Bakery & Grains'),
('Dairy & Eggs'),
('Meat & Seafood'),
('Pantry Staples'),
('Frozen & Prepared'),
('Snacks & Sweets'),
('Beverages');


INSERT INTO FoodWasteManager.dbo.AspNetUsers (Id, UserFirstName, UserLastName, UserPhone, UserLandline, UserAddress,
    UserName, NormalizedUserName, Email, NormalizedEmail,
    EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp,
    PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount)
VALUES
('user1', 'Alice', 'Johnson', '0221234567', '09-813-3900', '123 Apple Street', 'alicej', 'ALICEJ', 'alice@example.com', 'ALICE@EXAMPLE.COM', 1, '', '', '', 0, 0, 0, 0),
('user2', 'Bob', 'Smith', '0229876543', NULL, '456 Orange Ave', 'bobsmith', 'BOBSMITH', 'bob@example.com', 'BOB@EXAMPLE.COM', 1, '', '', '', 0, 0, 0, 0),
('user3', 'Charlie', 'Lee', '0221111111', NULL, '789 Banana Blvd', 'charlie', 'CHARLIE', 'charlie@example.com', 'CHARLIE@EXAMPLE.COM', 1, '', '', '', 0, 0, 0, 0),
('user4', 'Dana', 'Williams', '0222222222', '09-812-3900', '101 Cherry Lane', 'dana', 'DANA', 'dana@example.com', 'DANA@EXAMPLE.COM', 1, '', '', '', 0, 0, 0, 0),
('user5', 'Eli', 'Taylor', '0223333333', NULL, '202 Pear Street', 'eli', 'ELI', 'eli@example.com', 'ELI@EXAMPLE.COM', 1, '', '', '', 0, 0, 0, 0),
('user6', 'Fay', 'Brown', '0224444444', NULL, '303 Peach Road', 'fay', 'FAY', 'fay@example.com', 'FAY@EXAMPLE.COM', 1, '', '', '', 0, 0, 0, 0),
('user7', 'George', 'Harris', '0225555555', NULL, '404 Lemon Ave', 'george', 'GEORGE', 'george@example.com', 'GEORGE@EXAMPLE.COM', 1, '', '', '', 0, 0, 0, 0),
('user8', 'Hana', 'Clark', '0226666666', NULL, '505 Kiwi Drive', 'hana', 'HANA', 'hana@example.com', 'HANA@EXAMPLE.COM', 1, '', '', '', 0, 0, 0, 0),
('user9', 'Ivan', 'Young', '0227777777', NULL, '606 Fig Blvd', 'ivan', 'IVAN', 'ivan@example.com', 'IVAN@EXAMPLE.COM', 1, '', '', '', 0, 0, 0, 0),
('user10', 'Jane', 'Lopez', '0228888888', NULL, '707 Melon Path', 'jane', 'JANE', 'jane@example.com', 'JANE@EXAMPLE.COM', 1, '', '', '', 0, 0, 0, 0),
('user11', 'Ken', 'Moore', '0229999999', NULL, '808 Mango Way', 'ken', 'KEN', 'ken@example.com', 'KEN@EXAMPLE.COM', 1, '', '', '', 0, 0, 0, 0),
('user12', 'Lia', 'Scott', '0230000000', NULL, '909 Berry Blvd', 'lia', 'LIA', 'lia@example.com', 'LIA@EXAMPLE.COM', 1, '', '', '', 0, 0, 0, 0),
('user13', 'Max', 'Hill', '0231111111', NULL, '101 Kiwi Ct', 'max', 'MAX', 'max@example.com', 'MAX@EXAMPLE.COM', 1, '', '', '', 0, 0, 0, 0),
('user14', 'Nina', 'Green', '0232222222', NULL, '202 Date Lane', 'nina', 'NINA', 'nina@example.com', 'NINA@EXAMPLE.COM', 1, '', '', '', 0, 0, 0, 0),
('user15', 'Omar', 'Baker', '0233333333', NULL, '303 Plum St', 'omar', 'OMAR', 'omar@example.com', 'OMAR@EXAMPLE.COM', 1, '', '', '', 0, 0, 0, 0);

INSERT INTO FoodWasteManager.dbo.FoodPosts (FoodImage, FoodName, FoodQuantity, FoodPrice, FoodBestBefore, DatePosted, UserId, FoodTypeId) VALUES
('/images/InitialSetupImages/image1.jpg', 'Lettuce', 10, 0, '2025-05-01', GETDATE(), 'user1', 1),        -- Fresh Produce
('/images/InitialSetupImages/image2.jpg', 'Bananas', 8, 0, '2025-04-28', GETDATE(), 'user2', 1),         -- Fresh Produce
('/images/InitialSetupImages/image3.jpg', 'Bread Loaf', 5, 1, '2025-04-20', GETDATE(), 'user3', 2),      -- Bakery & Grains
('/images/InitialSetupImages/image4.jpg', 'Milk Carton', 3, 2, '2025-04-22', GETDATE(), 'user4', 3),     -- Dairy & Eggs
('/images/InitialSetupImages/AdobeStock_83103702_530x@2x.webp', 'Chicken Breast', 6, 4, '2025-04-25', GETDATE(), 'user5', 4),  -- Meat & Seafood
('/images/InitialSetupImages/cooked-peeled-shrimp.jpg', 'Shrimp Pack', 2, 5, '2025-04-26', GETDATE(), 'user6', 4),     -- Meat & Seafood
('/images/InitialSetupImages/9-Packet-Lay-s-Classic-Potato-Chips-Crispy-Gluten-free-and-Easy-to-carry-Potato-snacks_3f555135-d2c8-4d69-b6c1-4a3271d152a4.f558fb7aed5b0f4c4248a4a2834907b2.webp', 'Chips', 9, 2, '2025-05-02', GETDATE(), 'user7', 7),           -- Snacks & Sweets
('/images/InitialSetupImages/images (1).jpg', 'Juice Box', 12, 1, '2025-04-27', GETDATE(), 'user8', 8),      -- Beverages
('/images/InitialSetupImages/1686004821631.webp', 'Rice Bag', 4, 3, '2025-05-05', GETDATE(), 'user9', 2),        -- Bakery & Grains
('/images/InitialSetupImages/10813-best-chocolate-chip-cooookei.jpg', 'Cookies', 7, 2, '2025-04-30', GETDATE(), 'user10', 7),       -- Snacks & Sweets
('/images/InitialSetupImages/Frozen-Peas.webp', 'Frozen Peas', 5, 1, '2025-05-07', GETDATE(), 'user11', 6),   -- Frozen & Prepared
('/images/InitialSetupImages/__opt__aboutcom__coeus__resources__content_migration__serious_eats__seriouseats.com__recipes__images__2014__07__lasanga.jpg', 'Lasagna Tray', 3, 6, '2025-04-23', GETDATE(), 'user12', 6),  -- Frozen & Prepared
('/images/InitialSetupImages/istockphoto-459026777-612x612.jpg', 'Canned Beans', 11, 0, '2025-04-29', GETDATE(), 'user13', 5), -- Pantry Staples
('/images/InitialSetupImages/heinzketchuo.webp', 'Ketchup Bottle', 4, 2, '2025-05-03', GETDATE(), 'user14', 5),-- Pantry Staples
('/images/InitialSetupImages/should-you-refrigerate-basil-.jpg', 'Fresh Basil', 2, 1, '2025-05-06', GETDATE(), 'user15', 1);   -- Fresh Produce



INSERT INTO FoodWasteManager.dbo.Applications (FoodPostId, UserId, QuantityRequired, EarliestPickup, LatestPickup, AStatus)
VALUES
(2, 'user1', 2, '2025-04-18 10:00', '2025-04-18 14:00', 2),
(2, 'user2', 3, '2025-04-19 09:00', '2025-04-19 13:00', 2),
(3, 'user3', 1, '2025-04-20 11:00', '2025-04-20 15:00', 2),
(4, 'user4', 2, '2025-04-21 08:00', '2025-04-21 12:00', 2),
(5, 'user5', 4, '2025-04-22 10:00', '2025-04-22 14:00', 2),
(6, 'user6', 1, '2025-04-23 09:00', '2025-04-23 11:00', 2),
(7, 'user7', 2, '2025-04-24 12:00', '2025-04-24 16:00', 2),
(8, 'user8', 3, '2025-04-25 13:00', '2025-04-25 17:00', 2),
(9, 'user9', 2, '2025-04-26 14:00', '2025-04-26 18:00', 2),
(10, 'user10', 1, '2025-04-27 15:00', '2025-04-27 19:00', 2),
(11, 'user11', 2, '2025-04-28 10:00', '2025-04-28 12:00', 2),
(12, 'user12', 3, '2025-04-29 11:00', '2025-04-29 13:00', 2),
(13, 'user13', 2, '2025-04-30 09:00', '2025-04-30 11:00', 2),
(14, 'user14', 1, '2025-05-01 08:00', '2025-05-01 10:00', 2),
(15, 'user15', 2, '2025-05-02 10:00', '2025-05-02 12:00', 2);
