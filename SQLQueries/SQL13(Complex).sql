SELECT a.ApplicationId, a.EarliestPickup, u.UserFirstName, u.UserLastName FROM FoodWasteManager.dbo.Applications a
JOIN FoodWasteManager.dbo.AspNetUsers u ON a.UserId = u.Id
WHERE a.FoodPostId = 10;
