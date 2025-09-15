SELECT u.UserFirstName, u.UserLastName, f.FoodName, f.FoodBestBefore FROM FoodWasteManager.dbo.FoodPosts f
JOIN FoodWasteManager.dbo.AspNetUsers u ON f.UserId = u.Id
WHERE f.FoodBestBefore <= DATEADD(day, 2, GETDATE());