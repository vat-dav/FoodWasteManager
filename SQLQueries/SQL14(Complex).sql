SELECT DISTINCT u.Id, u.UserFirstName, u.UserLastName FROM FoodWasteManager.dbo.AspNetUsers u
WHERE u.Id IN (SELECT Id FROM FoodWasteManager.dbo.Applications)
AND u.Id NOT IN (SELECT Id FROM FoodWasteManager.dbo.FoodPosts);
