SELECT u.UserFirstName, u.UserLastName, f.FoodName, f.FoodQuantity, f.FoodPrice 
FROM FoodWasteManager.dbo.FoodPosts f JOIN FoodWasteManager.dbo.AspNetUsers u ON f.UserId = u.Id;