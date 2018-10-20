# REVERB

EN: 
This is a project realized during the fifth year of Applied Mathematics and Computer Science at the graduate school of engineering Polytech Sorbonne. The aim of the project is to modelize self-sufficient houses powered solely by solar energy and to use the Blockchain concept to represent the transactions of energy. 
Different steps are required: the creation of the Smart Grid and the Blockchain in C#. Their connection and also the use of Unity3D and of the virtual reality headset Oculus Rift for the 3D representation.

/!\ You need to install dotnet core project build and run before starting. The command line is: dotnet build dotnet run.

Files:

- blocks.cs: containt the different elements of a block such as the hash key. 
- IBlocks.cs: interface. 
- blockchain.cs: create a set of blocks et update the informations (previous hash...).
- transactions.cs: modelize transferts between different users. 
- generation_pubkey.sh: to create the public and private keys.
- keys.cs: to save public keys in a dictionnary. 
- REVERB.csproj, bin folder and obj folder: to use dotnet. 

Remark : 
To add a new library, please use dotnet. 
Example : 
dotnet add package NBitcoin
dotnet restore

FR : 
Il s'agit d'un projet réalisé de la cadre de la 5 ème de Mathématiques Appliquées et Informatique à Polytech Sorbonne. 
Le but de ce projet est de modéliser un complexe de logements autosuffisants en énergie et d'utiliser le concept de blockchain pour assurer les transactions énergétiques au sein du système. 
Le projet a également un objectif pédagogique : expliquer le concept de la blockchain au travers d'une interface de réalité virtuelle attractive. 
Plusieurs étapes sont donc nécessaires : la création d'une Smart Grid et d'une Blockchain en C# et leur connexion ainsi que l'utilisation de Unity3D et du casque à réalité virtuelle Oculus Rift pour la représentation en 3 dimensions.

/!\ Vous avez besoin d'installer  dotnet build and run avant de commander. La ligne de commande à taper est : dotnet build dotnet run.

Fichiers : 

- blocks.cs: contient les différents éléments d'un block tels que le Nonce, les transactions et les clés de hachage 
- IBlocks.cs : correspond à l'interface de la classe Block. 
- blockchain.cs : crée un ensemble de blocks et met à jour les informations (précédents Hash,transactions...)
- transactions.cs : modélise les transferts entre plusieurs personnes. 
- generation_pubkey.sh : pour créer les clés publiques et privés.
- keys.cs : pour stocker les clés publiques dans un dictionnaire. 
- REVERB.csproj, bin folder and obj folder : pour utiliser dotnet.  

Remarque : 
Pour utiliser une nouvelle bibliothèque, utilisez dotnet.
Par exemple : 
dotnet add package NBitcoin
dotnet restore 
