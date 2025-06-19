<?php
require_once('db.php');
header('Content-Type: application/json');
$soinId = htmlspecialchars($_GET['id']);
$requete = $PDO->prepare('SELECT * FROM soins WHERE IdSoin=?');
    $requete->bindParam(1, $soinId);
    $requete->execute(); 
    $response = $requete->fetchAll(PDO::FETCH_ASSOC);
    echo json_encode($response);