<?php
include_once 'db.php';

// Réception des informations de login
$username_p = mysqli_real_escape_string($conn, $_POST["Username"]);
$password_p = mysqli_real_escape_string($conn, $_POST["Password"]);

// Vérification des informations de login
$sql = "SELECT ID FROM Login WHERE Username='$username_p' AND Password='$password_p'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // Récupération de l'ID correspondant
    $row = $result->fetch_assoc();
    $id = $row["ID"];
    echo $id;
} else {
    // Informations de login incorrectes
    echo "0";
}

$conn->close();

?>
