# Algorithme de Luhm

L'algorithme procède en trois étapes.

L'algorithme multiplie par deux un chiffre sur deux, en commençant par l'avant dernier et en se déplaçant de droite à gauche. Si le double d'un chiffre est plus grand que neuf (par exemple 2 × 8 = 16), alors il faut le ramener à un chiffre entre 1 et 9 en prenant son reste dans la division euclidienne par 9. Pour cela, il y a 2 manières de faire (pour un résultat identique) :

* Soit on additionne les chiffres composant le double. Dans l'exemple du chiffre 8, 2 × 8 = 16, puis on additionne les chiffres 1 + 6 = 7.
* Soit on soustrait 9 au double. Avec le même exemple, 16 − 9 = 7.

La somme de tous les chiffres obtenus est effectuée.
Le résultat est divisé par 10. Si le reste de la division est égal à zéro, alors le nombre original est valide.

Il faut d'avoir développer le test unitaire permettant de vérifier le descriptif ci-dessus, puis de l'implémenter.