using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokeri
{
    class Player
    {
        public string Name;
        public int Money;
        public int Action = 5; // shows what action AI takes to player 0 = call etc. 5 = Waiting...
        public int playerAction; // What player had done 0 = Call, 1 = Raise, 2 = ALLIN! 3 = Fold, folding works same as player had called
        public int CallValue;
        public int AiVariable = 101; // 0 - 66 values = Ai will call
        public int AiVariable2 = 0;  // 0 -5 fold, 6 - 66 call, 67 - 94 Raise, 95 - 100 All In 
        public int HandValue = 0;
        public int winner = 0; // 0 = loser, 1 = winner, 2 = draw
        public bool Fold = false; // has player folded?

        Random random = new Random();

        public int AiTurn(Hand hand)
        {
            int ReturnValue = 0; // what amount of goods transfers to the table
            int rand = random.Next(0, AiVariable);

            if (rand <= 66 && rand >= 0)
            {
                // AI Calls
                Money -= CallValue;
                ReturnValue += CallValue;
                Action = 0;                
                return ReturnValue;
            }
            if (rand > 66 && rand <= 100)
            {
                // AI Raises
                CallValue += 5;
                Money -= CallValue;
                ReturnValue += CallValue;
                Action = 1;
                return ReturnValue;
            }
            return 0;


        }
        public void GetCallValue(int callvalue)
        {            
            CallValue = callvalue;
        }
        public int ReturnNewCallValue()
        {
            return CallValue;
        }

        public bool GoForAllIn()
        {
            return true;
        }
    }
}
