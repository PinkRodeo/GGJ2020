// Conversation line with AI_Fridge where the fridge inventory was unlocked
public class Fridge_B_1_Access_Menu : Event
{
    public override void PlayEvent()
    {
        Text = @"Welcome to your Fridger 2.0. Today is:
02-AUG-2065
--------------------------------------
CONTENTS:
Milk: 2 liters                 Expiry date: 07-JUL-2065
Take-away pizza: one crust     Expiry date: 14-JUL-2065
Take-away pizza: two slices    Expiry date: 19-JUL-2065
Take-away pizza: three slices  Expiry date: 22-JUL-2065
Take-away pizza: five slices   Expiry date: 27-JUL-2065
Take-away pizza: six slices    Expiry date: 27-JUL-2065
Home-cooked Thai grill.        Expiry date: 03-AUG-2065
Soylent Green Soy Sauce        Expiry date: 26-FEB-2122";
        EventActor = Actors.AI_Fridge();

        {
            var choice = NewChoice("[disgusted] CLOSE");
        }
    }
}
