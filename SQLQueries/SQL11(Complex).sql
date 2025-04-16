SELECT u.UserFirstName, u.UserLastName, f.FoodName, f.FoodBestBefore FROM dbo.FoodPosts f
JOIN AspNetUsers u ON f.Id = u.Id
WHERE f.FoodBestBefore <= DATEADD(day, 2, GETDATE());