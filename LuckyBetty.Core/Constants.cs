namespace LuckyBetty.Core;

internal struct Constants
{
    internal const string LOGO = @"
     _   _   _   _   _     _   _   _   _   _  
    / \ / \ / \ / \ / \   / \ / \ / \ / \ / \ 
   ( L | U | C | K | Y ) ( B | E | T | T | Y )
    \_/ \_/ \_/ \_/ \_/   \_/ \_/ \_/ \_/ \_/ 

    Lucky Betty * Where Luck Shines Brightest

";
    internal const string WELCOME = @"Welcome to Lucky Betty!

You are starting with a balance of $0 in your wallet.

To begin playing the game, you'll need to deposit funds into your wallet. 
You can deposit money using the ""deposit"" command followed by the amount you wish to add.

Example:
deposit 50

Once you have funds in your wallet, you can start placing bets and experiencing the thrill of our gaming experience!
Please note that the bet amount must be between $1 and $10.

Let's get started!";

    internal const string DELIMITER = "---------------------------------------------------------------------";
    internal const string ORNAMENT = " >> ";
    internal const string PROMPT = " Please, submit action:";
    internal const string HELP_SUGGESTION = $"Write help to see a list of all available commands.";
    internal const string GOODBYE = "Thank you for playing! Hope to see you soon.";
    internal const string NO_SUCH_COMMAND = "There is no such command";
    internal const string NO_ENOUGH_MONEY = "Insufficient funds.";
    internal const string CURRENT_BALANCE = "Your current balance is:";
    internal const string AMOUNT_GREATER_THAN = $"amount must be greater than";
    internal const string NO_WIN = "No luck this time!";
    internal const string WIN = "Congrats - you won";
    internal const string GAME_RULES = "Game rules:\nYou can place bets between $1 and $10.\nYou can win between 2 and 10 times your bet amount!";

    public struct Command
    {
        internal const string EXIT = "exit";
        internal const string INVALID_ARGUMENTS = "Invalid command arguments.";

        public struct Category
        {
            internal const string OTHER = "Other";
            internal const string WALLET = "Wallet";
            internal const string GAME = "Game";
        }

        public struct Description
        {
            internal const string BET = "Places a bet in the game.";
            internal const string CLEAR = "Clears the console.";
            internal const string DEPOSIT = "Deposits money.";
            internal const string HELP = "Displays help information about available commands.";
            internal const string RULES = "Displays the game rules.";
            internal const string WITHDRAW = "Withdraws money.";
            internal const string EXIT = "Exits the application.";
        }

        public struct Usage
        {
            internal const string BET = "bet <amount>";
            internal const string CLEAR = "clear";
            internal const string DEPOSIT = "deposit <amount>";
            internal const string HELP = "help";
            internal const string RULES = "rules";
            internal const string WITHDRAW = "withdraw <amount>";
        }
    }
}
