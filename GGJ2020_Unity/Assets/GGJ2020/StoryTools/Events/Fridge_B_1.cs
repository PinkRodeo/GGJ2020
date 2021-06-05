// Conversation line with AI_Fridge where the fridge inventory was unlocked
public class Fridge_B_1_Access_Menu : Event
{
    public override void PlayEvent()
    {
        Text = @"Welcome to your Fridger 2.0. Today is:
14-AUG-2065
--------------------------------------
CONTENTS:
Milk: 2 liters.                Expiry date: 03-JUL-2065
Home-cooked Thai grill.        Expiry date: 04-JUL-2065
Take-away pizza: two slices    Expiry date: 02-JUL-2065
Take-away pizza: three slices  Expiry date: 12-JUL-2065
Take-away pizza: seven slices  Expiry date: 13-JUL-2065";
        EventActor = Actors.AI_Fridge();

        {
            var choice = NewChoice("[disgusted] CLOSE");
        }
    }
}
