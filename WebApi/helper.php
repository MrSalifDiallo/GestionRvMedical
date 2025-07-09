<?php
require_once('db.php');

function getAll($table) {
    global $PDO;
    $stmt = $PDO->prepare("SELECT * FROM $table");
    $stmt->execute();
    return $stmt->fetchAll(PDO::FETCH_ASSOC);
}

function deleteById($table, $primaryKey, $id) {
    global $PDO;
    $stmt = $PDO->prepare("DELETE FROM $table WHERE $primaryKey = ?");
    return $stmt->execute([$id]);
}

function updateById($table, $primaryKey, $id, $data) {
    global $PDO;
    if (empty($data)) return false;

    $fields = [];
    $values = [];
    foreach ($data as $key => $value) {
        $fields[] = "$key = ?";
        $values[] = $value;
    }
    $values[] = $id;

    $sql = "UPDATE $table SET " . implode(", ", $fields) . " WHERE $primaryKey = ?";
    $stmt = $PDO->prepare($sql);
    return $stmt->execute($values) ? $stmt->rowCount() : false;
}
function insert($table, $data) {
    global $PDO;
    if (empty($data)) return false;

    $columns = implode("`, `", array_keys($data));
    $placeholders = ":" . implode(", :", array_keys($data));

    $sql = "INSERT INTO `$table` (`$columns`) VALUES ($placeholders)";
    $stmt = $PDO->prepare($sql);

    return $stmt->execute($data) ? $PDO->lastInsertId() : false;
}