﻿// Conversation line with AI_Trashcan where the trashcan inventory was unlocked
using UnityEngine;

public class Trashcan_B_1_Inventory : Event
{
	public override void PlayEvent()
	{
		Text = @"OMGGGGGGGG:
--------------------------------------
LAST ORDER PLACED: 01-07-2065 | 09:13
--------------------------------------
CURRENT CONTENTS:
Milk: 2 Liters. Expiry date: 03-07-2065
Home-cooked Thai Grill. Expiry date: 04-07-2065
Soy sauce. Expiry date: 31-02-2064
Soy sauce. Expiry date: 25-06-2065
Soy sauce. Expiry date: 01-12-2065
FLYING DOUGH: DOUBLE PEPPERONI SPECIAL: two slices, 6 crusts.  Expiry date: 02-07-2065
FLYING DOUGH: PEPPERONI PIZZA: three slices, 5 crusts.  Expiry date: 12-07-2065
FLYING DOUGH: CHICKEN BBQ: seven slices, 1 crust.  Expiry date: 13-07-2065";
		EventActor = Actors.AI_Trashcan();

		{
			var choice = NewChoice("CLOSE");
		}
	}
}
