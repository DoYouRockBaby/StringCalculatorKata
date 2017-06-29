Evaluation finale du cours .NET à l'IUT Lyon 1
==============================================

Critères d'évaluation
---------------------

* Solution apportée aux problèmes posés dans le fichier Readme.md + réponses aux questions (à mettre dans le fichier ci-dessous)
* La qualité des commits : granularité fine et commentaires explicites du pourquoi (et non du quoi, i.e ne pas dire quels fichiers ont été modifiés, c'est inutile, Git le dit déjà)
* La qualité du code : utiliser un nommage correct + R# donne des règles à respecter, il suffit de les corriger
* Les tests unitaires : expressivité (le nommage tout particulièrement), granularité (i.e on teste une chose à la fois), rapidité (i.e instantané), couverture de code et indépendance (un test ne dépend pas des autres)
* Le design du code : utiliser les pratiques vues en cours pour éviter de faire du code difficilement maintenable et évolutif (SOLID...)

ATTENTION: ne pas changer le nommage des projets, des classes et méthodes donnés (sauf sur les tests si vous voulez).

A LA FIN DU TP: pensez à pousser vos commits sur votre compte GitHub et envoyer votre dépôt à mon adresse mail.

Réponses aux questions posées
-----------------------------
J'ai crée une structure basé sur l'abstraction des opérations via une interface : Operator/IOperator qui est implementé par des classes représentants les différentes opérations possibles
Q1) Pour éviter les if/switch en masse, il faut privilégier la factorisation du code

Q2) J'abstrait la liste des opérations

Q3) Je rends ma classe modulaire

Q4) Cette classe n'est pas assez modulaire, elle implemente elle même le Calculator et les calculs a réaliser

Q5) Je factorise ma classe

Q6) Je factorise ma classe
 