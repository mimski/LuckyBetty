# LuckyBetty
Lucky Betty is a console app built using .NET 8. It simulates a player wallet for a slot game.

## Tech Stack

- .NET 8 Console App
- Dependency Injection IoC Container: Microsoft.Extension.DependencyInjection

## Requirements

Build a console application in .NET Core which mimics the operations of the player wallet that powers our gaming experience.

The wallet is the heart of the gaming experience and as such, it needs to provide the following features:

- In the beginning, the player starts with a balance of $0 and after every operation, their new balance is displayed.
- Money deposit - the player must be able to deposit funds
- Money withdrawal - the player must be able to withdraw funds
- Placing bets & accepting wins - the player must be able to play a simple game that simulates a real slot game (see game rules below)

## Game Rules

Our game of chance provides a simple betting experience with the following rules:

- The game accepts bets between $1 and $10
- The game plays out as follows:
    - 50% of the bets lose
    - 40% of the bets win up to x2 the bet amount 
    - 10% of the bets win between x2 and x10 the bet amount
- After every round the player balance is calculated as follows:
    - {new balance} = {old balance} - {bet amount} + {win amount}

The game ends when the player decides to leave.

All operations that require an amount must include the amount as a positive number, regardless of the direction of the balance.

## Presentation

When the app is started:

![image](https://github.com/mimski/Csharp/assets/44443424/df0c20fa-990a-4234-89eb-942aa3dac732)

deposit, bet, and withdraw operations:

![image](https://github.com/mimski/Csharp/assets/44443424/e5b48014-cb67-4495-af4b-c17a051ae279)

deposit command:

![image](https://github.com/mimski/Csharp/assets/44443424/63f51011-165c-4114-a4c9-de3b22e1b3b9)

bet command: 

![image](https://github.com/mimski/Csharp/assets/44443424/c427f761-f56b-4f55-9748-8d852bce8f48)

withdraw command:

![image](https://github.com/mimski/Csharp/assets/44443424/5aa82600-18b6-42f2-958d-a9dc5452a749)

help command:

![image](https://github.com/mimski/Csharp/assets/44443424/7f1f07d8-1ddb-47fb-9d3e-65e3c5ee6e3a)

rules command:

![image](https://github.com/mimski/Csharp/assets/44443424/a5f21bde-9e5b-428f-ac29-0bf4332ee216)

exit command:

![image](https://github.com/mimski/LuckyBetty/assets/44443424/d754216b-a841-4d37-a6d6-f1c3da5be045)

clear command:

![image](https://github.com/mimski/LuckyBetty/assets/44443424/db3478d6-1c20-4594-8d6a-2b02f02cfa64)


Thank you for checking out LuckyBetty. Enjoy the game!
