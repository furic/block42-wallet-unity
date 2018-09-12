![Block42](http://assets.block42.world/images/icons/block42_logo_200.png)

# Block42 Unity Wallet Plugin

## About
A Ethereum wallet and transaction system in Unity. This plug-in is inspired by Alto's [unit3d-blockchain-wallet](https://github.com/alto-io/unity3d-blockchain-wallet) and aims to be scalable and easy-to-use for all other projects with minimal coding. Changes includes separating UI logic from manager logic, optimize the code to follow Unity standard, as well as adding a number of demos for learning purposes. Few advanced usages are also added such as using geth and mining inside Unity.

Please note that this is still in prototype and under heavy development. The final product may be subject to a number of quality assurance tests to verify conformance with specifications.

## Requirements
- Unity 2017+
- Set Scripting Runtime Version to .NET 4.x Equivalent in PlayerSettings
![PlayerSettings](Documents/Intro/00_playersettings.png)

## Settings
ScriptableObject is used globally for wallet setting, access the settings in menu through Block42 > Wallet > Settings
![Menu Wallet Settings](Documents/Intro/01_menu_wallet_settings.png)

Inspector will show:
![Wallet Settings Inspector](Documents/Intro/02_wallet_settings_inspector.png)

- Network: 
Ropsten is set as default and used throughout all demos, you can use another testnet, or custom network by providing the URL in settings. Note that the smart contracts used in demos were deployed in Ropsten. For trying the demos in other networks or using your own smart contracts, deploy the contracts accordingly and set the ABI and the address in [ContractController](Assets/Block42/Wallet/Scripts/Contracts/ContractController.cs). See Demo [02-MyWalletBalance](Assets/Block42/Wallet/Demos/02-MyWalletBalance) on how to change them.
- Infura Api Key:
Infura API are used to comuunicate with the blockchains. You can use my API key for development, but make sure you register your own one for [free](https://infura.io/) here and put your own key in.
- Custom Network URL:
A mannual URL used for custom network only, it can be your localhost with your desired port, or a AWS server where you run your private chain node.
- Gas Price:
The default gas price on your chain, it is used when sending ETH or token.
- Off Chain Mode:
A testing mode that can work offline and simulate all the chain function (excluding smart contract of course).
- Debug Log:
A rich log mode for debugging purpose.

## Core Scripts
- [`WalletManager`](Assets/Block42/Wallet/Scripts/WalletManager.cs): A master manager on managing wallets, such as create, save and load. This is a static class so all variables and methods can be easily access everywhere. Transactions are asynchronous and `Couroutine` is required to process transaction. For easier access, a [`CouroutineManager`](Assets/Block42/Common/Utils/CoroutineManager.cs) is automatically created for handling all coroutines of static classes.
- [`ContractController`](Assets/Block42/Wallet/Scripts/Contracts/ContractController.cs): A base class that holds the ABI and address of the smart contract, all other contract should be inherent from this and attach to anywhere of the scene.
- [`ERC20ContractController`](Assets/Block42/Wallet/Scripts/Contracts/ContractController.cs): A child class inherited from ContractController that implements all the method of a ERC20 standard token contract. 
- ERC721ContractController: (TODO) Same as `ERC20ContractController` but implements a ERC721 standard token contract.

## Demos
This projects contains a number of demos from basic to intermediate, go to each demo in [Demos](Assets/Block42/Wallet/Demos) folder for more details. It's recommended to spend 10 minutes to go through all demos before any integration. 


## Notes
- [Nethereum](https://github.com/Nethereum/Nethereum) is used as the .NET integration library for Ethereum here. If you already have that in your project, you can safely delete [Plugins](Assets/Block42/Plugins) folder. 
- [Nethereum.Web3](Assets/Block42/Plugins/Nethereum/Nethereum.Web3.dll) is used to demonstrate the difference of using Web3 and UnityRPCRequests in Demo [01-StaticWalletBalance](Assets/Block42/Wallet/Demos/01-StaticWalletBalance). If you are not using any Web3 library in your project, you can delete the library to save building space.
- [Nethereum.Geth](Assets/Block42/Plugins/Nethereum/Nethereum.Geth) is used to demonstrate how to mine ethereum of using Geth in Demo [04-Mining](Assets/Block42/Wallet/Demos/04-Mining). If you are not using any Geth library in your project or not mining in Unity, you can delete library to save building space.

## TODO
- Add ERC721 token contract controller
- Add Travis CI for build test