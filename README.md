# ChestSystem
Chest system like clash royale

Every number here should be flexible to change by the designers and should not be hard coded!

Common chest(15 mins)- 
    Coins : 100-200
		Gems : 10-20
Rare chest(30 mins) - 
    Coins : 300-500
		Gems : 20-40
Epic chest(1 Hr) - 
    Coins : 600-800
		Gems : 45-60
Legendary chest(3 Hr) - 
    Coins : 1000-1200
    Gems : 80-100
			
There will be a scrollable dynamic list of slots for chests with a minimum of 4 slots where we can place chests.
Create a Button, which will generate random chests in the empty slot after click. (there will be different types of chests, read further to get a better idea)
When the chest is getting added, the timer of the chest will not start. So you need to click on the chest then one pop-up will come, and on that pop up there will be two buttons on the pop-up.

Start Timer button → Which will start the respective time for the chest depending upon the time. For starting the timer to unlock there won't be any cost.
Unlock with Gems button → Which will directly unlock the chest without the timer spending particular gems cost, for understanding more about cost read further.

If slots are full → Pop up saying slots are full will appear.!
	
Chests can be

- Locked (Timer Haven't started)
- Unlocking (Timer is running on the Chest)
- Unlocked but not collected (Timer is finished → Tap to collect reward state)
- Collected (rewards have been collected and the chest leaves the slot that it was occupying)

Rewards will be received depending upon the type of the chest
    We can start unlocking only one chest at max, which means if the timer is on for any of the chests, we can't start unlocking other chests
    Just like the below image, we can open any unlocking chest by spending gems. The cost for that will be → 1 Gem for every 10 mins, which means suppose on the chest we have 30 mins left then cost should be 3 Gems, if 1 Hour is remaining then cost should be 6 gems, likewise. This cost of gems should also reduce as time is reduced.
    Always take a ceil while calculating the cost , e.g. minutes are 11 ⇒ 1.1 Gem then consider the cost as 2 Gem. if minutes are 29 , then gems will be 2.9 , take cost as 3 Gems , always take a ceil.
    If gems are not enough to skip the timer then there should be one pop up saying that.
    Implement an undo option if you want to revert your decision of spending gems for unlocking a chest through gems.
    
![chestsys1](https://github.com/sbtrwt/ChestSystem/assets/5724149/6bd1111b-7f0e-49d3-8e66-d43082ce310f)


![chestSystem Layout](https://github.com/sbtrwt/ChestSystem/assets/5724149/d2c190d9-f2aa-46a7-abd3-58cd9a18f8b4)
![chestsys3](https://github.com/sbtrwt/ChestSystem/assets/5724149/2f4ea5a5-0176-4b58-9062-ff51635150f7)

![chestsys2](https://github.com/sbtrwt/ChestSystem/assets/5724149/aa752b9f-2003-4c18-8f62-e487b2e83a03)


