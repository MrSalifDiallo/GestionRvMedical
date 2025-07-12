<?php
require_once('helper.php');
header('Content-Type: application/json');

$action = $_GET['action'] ?? null;
$table = $_GET['table'] ?? null;

if (!$action || !$table) {
    echo json_encode(['error' => 'Action ou table manquante']);
    exit;
}

switch ($action) {
    case 'getAll':
        echo json_encode(getAll($table));
        break;

    case 'delete':
        $id = $_POST['id'] ?? null;
        if ($id && deleteById($table, "Id" . ucfirst(rtrim($table, "s")), $id)) {
            echo json_encode(['success' => true]);
        } else {
            echo json_encode(['error' => 'Échec suppression']);
        }
        break;

    case 'update':
        $id = $_POST['id'] ?? null;
        $data = $_POST;
        unset($data['id']);
        $result = updateById($table, "Id" . ucfirst(rtrim($table, "s")), $id, $data);
        echo json_encode([
            'success' => $result !== false,
            'rows_updated' => $result
        ]);

        
    case 'insert':
        $data = $_POST;
        $insertId = insert($table, $data);
        if ($insertId !== false) {
            echo json_encode([
                'success' => true,
                'insert_id' => $insertId
            ]);
        } else {
            echo json_encode(['error' => 'Échec insertion']);
        }
        break;
    default:
        echo json_encode(['error' => 'Action non reconnue']);
}
if (isset($_GET['debug']) && $_GET['debug'] == 'true') {
    error_reporting(E_ALL);
    ini_set('display_errors', 1);
} else {
    error_reporting(0);
}