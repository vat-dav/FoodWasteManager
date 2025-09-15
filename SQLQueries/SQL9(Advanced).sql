SELECT ApplicationId, EarliestPickup FROM FoodWasteManager.dbo.Applications WHERE AStatus = 1
ORDER BY EarliestPickup ASC;
