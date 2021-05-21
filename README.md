# WebApplication1
I use postman for the tests, type JSON.


- Create a wallet:
	post to:
	https://localhost:44335/api/wallets
	{
    "balance": 0,
    "avg": 0
	}
- Make a credit operation to a wallet:
	post to:
	https://localhost:44335/api/walletsmovements
	{
    "walletid": 1,
    "debit": 0,
    "credit": 1000
	}

- Make a debit operation to a wallet
	post to
	https://localhost:44335/api/walletsmovements
	{
    "walletid": 1,
    "debit": 200,
    "credit": 0
	}

- See all the movements of a wallet
	get to
	https://localhost:44335/api/walletsmovements/1
	The parameter is the number of the wallet.
	
- See the balance and the average of a wallet
	get to
	https://localhost:44335/api/wallets/1
	The parameter is the number of the wallet.
	
- Make a transfer from a wallet to another wallet
	post to
	https://localhost:44335/api/walletsmovements/Transfer
	{
    "fromWallet" : 1,
    "toWallet" : 2,
    "amount" : 7000
	}
