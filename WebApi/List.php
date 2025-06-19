<?php
require_once('db.php');
header('Content-Type: application/json');
$requete = $PDO->prepare('SELECT * FROM soins');
    $requete->execute(); 
    $response = $requete->fetchAll(PDO::FETCH_ASSOC);
    echo json_encode($response);