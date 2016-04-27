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
        public int CallValue;
        public int AiVariable = 75; // arvot joiden väliltä Random lasketaan
        public int AiVariable2 = 25;  //  Käden laskettu arvo muuttaa tätä väliä
        public int HandValue = 0;
        public int winner = 0; // 0 = loser, 1 = winner, 2 = draw
        public bool Fold = false; // has player folded?
        public bool Lost = false; // has player lost all his money?
        int rand;


        public int AiTurn(Hand hand)
        {
            if(HandValue >= 2) // jos AI näkee ainakin parin
            {
                AiVariable = 75;
                AiVariable2 = 25;
                int ai = 5 * HandValue;

                AiVariable += ai;
                AiVariable2 += ai;

                if (AiVariable > 100) AiVariable = 100;
                if (AiVariable2 > 90) AiVariable2 = 90;
            }
            if(HandValue == 1) // jos kädessä ei ole mitään
            {
                AiVariable -= 5;
                AiVariable2 -= 5;

                if (AiVariable < 10) AiVariable = 10;
                if (AiVariable2 < 0) AiVariable2 = 0;

            }

            Random random = new Random();
            rand = random.Next(AiVariable2, AiVariable);

            int ReturnValue = 0; // paljonko rahaa AI palauttaa pöytään

            if (rand >= 0 && rand <= 5) // AI luovuttaa
            {
                Action = 3;
                ReturnValue = 0;
                return ReturnValue;
            }

            if (rand <= 66 && rand >= 6)
            {
                // AI Calls
                Money -= CallValue;
                ReturnValue += CallValue;
                Action = 0;                
                return ReturnValue;
            }
            if (rand >= 67 && rand <= 100)
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
        public void GetCallValue(int callvalue) // pelaaja hakee nykyisen CallValuen pelistä
        {            
            CallValue = callvalue;
        }
        public int ReturnNewCallValue() // pelaaja palauttaa uuden CallValuen
        {
            return CallValue;
        }

        public bool GoForAllIn() // aikooko AI mennä ALLIN?!?!?
        {
            Random random = new Random();
            rand = random.Next(AiVariable2, AiVariable);

            if (rand >= 50) return true;
            else return false;
        }
    }
}
