<?php
include_once 'db.php';

// Réception des informations de login
$username_p = mysqli_real_escape_string($conn, $_POST["Username"]);
$password_p = mysqli_real_escape_string($conn, $_POST["Password"]);

// Vérification des informations de login
$sql = "SELECT ID FROM Login WHERE Username='$username_p' AND Password=MD5('$password_p')";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // Récupération de l'ID correspondant
    $row = $result->fetch_assoc();
    $id = $row["ID"];

    echo $id;
    echo ",";

    // Récupération du rôle correspondant à l'ID dans la table "Role"
    $sql_role = "SELECT Role FROM Role WHERE ID='$id'";
    $result_role = $conn->query($sql_role);

    if ($result_role->num_rows > 0) {
        // Récupération du nom du rôle correspondant
        $row_role = $result_role->fetch_assoc();
        $role_name = $row_role["Role"];

        // Affichage du nom du rôle en echo
        echo $role_name;
    } else {
        // Le rôle correspondant à l'ID n'existe pas
        echo "Rôle introuvable pour cet utilisateur";
    }
} else {
    // Informations de login incorrectes
    echo "Informations de login incorrectes";
}

$conn->close();
?>
