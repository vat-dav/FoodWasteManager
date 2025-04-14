SELECT u.UserFirstName, u.UserLastName, f.FoodName, f.FoodQuantity, f.FoodPrice 
FROM FoodPosts f JOIN AspNetUsers u ON f.Id = u.Id;