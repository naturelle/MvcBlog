Create Trigger AddScoreinComment
On Comments		
After Insert
As
Declare @ID int
Declare @Score int
Declare @RatingCount int
Select @ID=BlogID, @Score=BlogScore from inserted
Update BlogRatings Set BlogTotalScore=BlogTotalScore+@Score, BlogRatingCount+=1
Where BlogID=@ID
