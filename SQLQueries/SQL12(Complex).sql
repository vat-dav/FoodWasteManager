SELECT u.UserFirstName, u.UserLastName, COUNT(f.FoodPostId) AS FoodPostCount FROM FoodWasteManager.dbo.AspNetUsers u
JOIN FoodWasteManager.dbo.FoodPosts f ON u.Id = f.UserId
GROUP BY u.UserFirstName, u.UserLastName HAVING COUNT(f.FoodPostId) > 3;
