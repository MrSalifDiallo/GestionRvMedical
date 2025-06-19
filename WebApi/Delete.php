<?php
require_once('db.php');
$soinId = (int) $_POST['id'];
    $requete = $PDO->prepare("DELETE FROM soins WHERE IdSoin = ?");
    $requete->bindParam(1, $soinId);
    $requete->execute(); 
    $response = $requete->fetchAll(PDO::FETCH_ASSOC);
echo json_encode ( [
'id' => $id,
'success' => $response
]);
?>