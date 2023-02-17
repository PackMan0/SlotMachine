Simplified Slot Machine

***The rules**:*

- At the start of the game the player should enter the deposit amount (e.g. the initial money balance).
- After that, for each spin, the player is asked how much money he wants to stake.
- A table with the results of each spin is displayed to the player.
- The win amount should be displayed together with the total balance at the current stage. After the first spin the total balance will be equal to:

*({deposit amount} - {stake amount}) + {win amount}.*

- Game ends when the player balance hits 0.

***The game:***

- A slot game with dimensions 4 rows of 3 symbols each.
- Supports following symbols:



|Symbol|Coefficient|Probability to appear on a cell|
| - | - | - |
|Apple (**A**)|0.4|45%|
|Banana (**B**)|0.6|35%|
|Pineapple (**P**)|0.8|15%|
|Wildcard (**\***)|0|5%|
- The symbols are placed randomly respecting the probability of each item. For example: there is 5% chance that a Wildcard will be placed in a cell and there is 45% chance for an Apple.
- The player will win only if one or more horizontal lines contain 3 matching symbols. *Wildcard (\*) is a symbol that matches any other symbol (**A**, **B** or **P**).*
- The won amount should be the sum of the coefficients of the symbols on the winning line(s), multiplied by the stake amount.

***Example:***

BAA  // 0

AAA  // 0.4 + 0.4 + 0.4 = 1.2 coefficient A\*B   // 0

\*AA   // 0 + 0.4 + 0.4 = 0.8 coefficient

Player has staked 10 and winning coefficient is 1.2 + 0.8 = 2 so win is: 10 \* 2 = 20.

The won amount is then added to the current balance of the player 200 - 10 + 20 = 210.

***Win calculation examples:***



|Win combinations| - | - |Calculation of win|
| - | - | - | - |
|\*|P|\*|(0 + 0.8 + 0)\*10 = 8|
|A|A|A|(0.4 + 0.4 + 0.4)\*10 = 12|
|B|B|B|(0.6 + 0.6 + 0.6)\*10 = 18|
|P|P|P|(0.8 + 0.8 + 0.8)\*10 = 24|
|A|B|P|No matching symbols|
|\*|A|B|No matching symbols|
