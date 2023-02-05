<?php
include_once 'db.php';

$username_p = mysqli_real_escape_string($conn, $_POST["Username"]);
$password_p = mysqli_real_escape_string($conn, $_POST["Password"]);

$sql = "SELECT * FROM Login WHERE `Username` = '$username_p'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    echo "Ce nom d'utilisateur existe déjà.";
} else {
    $sql = "INSERT INTO Login (`Username`, `Password`)
    VALUES ('$username_p' , '$password_p')";
    
    if ($conn->query($sql) === TRUE) {
        echo "Enregistrement effectué avec succès.";
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }
}

$conn->close();
?>
