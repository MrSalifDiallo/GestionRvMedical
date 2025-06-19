<?php

$BD_DSN = "mysql:host=localhost;dbname=apibdrvmedical";
$BD_user = "root";
$BD_usercode = "passer";
$option =
        [
            PDO::MYSQL_ATTR_INIT_COMMAND => 'SET NAMES utf8', 
            /*
            Pour être sur de travailler avec une bonne 
            encodage dans mysql
            */
            PDO::ATTR_ERRMODE => PDO::ERRMODE_SILENT, 
            /*
            Mode par défaut pour la gestion des erreurs donc aucun n'affichage a faire
            Le mieux est de travailler avec des avertissements donc changeons
            ERRMODE_SILENT en ERRMODE_EXCEPTION car nous sommes en développement
            */
            PDO::ATTR_EMULATE_PREPARES=>false
            /*
            Permet d'utiliser des vraies requêtes préparées car 
            car par défaut l'interface PDO simule des requêtes préparées
            */
        ];
$PDO = new PDO ($BD_DSN,$BD_user,$BD_usercode,$option);
